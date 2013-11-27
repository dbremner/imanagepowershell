using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using iml = IManage;

namespace iManagePowerShell
{

    public class iManServer : IDisposable
    {
        public iml.IManDMS me;

        private static Dictionary<string, iml.IManDMS> ServerSingletons = new Dictionary<string, iml.IManDMS>();

        public iManServer(string Server, string Username = null, string Password = null)
        {
            iml.IManDMS SingletonServer;
            ServerSingletons.TryGetValue(Server, out SingletonServer);
            if (SingletonServer == null)
            {
                me = new iml.ManDMS();
                ServerSingletons.Add(Server, me);
                iml.IManSession s = me.Sessions.Add(Server);
                if (Username == null)
                {
                    s.TrustedLogin();
                }
                else
                {
                    s.Login(Username, Password);
                }
            }
            else
            {
                me = SingletonServer;
            }
        }

        public void Dispose()
        {
            foreach (iml.IManSession s in me.Sessions)
            {
                if (s.Connected)
                {
                    ServerSingletons.Remove(s.ServerName);
                    s.Logout();
                }
            }
            me.Close();
        }

        public static List<iManServer> AutoConnect()
        {
            List<iManServer> result = new List<iManServer>();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Interwoven\WorkSite\8.0\Common\Login\RegisteredServers");
            foreach (var s in rk.GetSubKeyNames().Select(s => rk.OpenSubKey(s)))
            {
                string ServerName = s.GetValue("ServerName").ToString();
                if (s.GetValue("TrustedLogin").ToString() == "Y")
                {
                    result.Add(new iManServer(ServerName));
                }
                else
                {
                    string username = s.GetValue("UserId").ToString();
                    string password = s.GetValue("Password").ToString();
                    result.Add(new iManServer(ServerName, username, password));
                }
            }
            return result;
        }

        public List<iManSession> Sessions
        {
            get { return me.Sessions.ToList(); }
        }

    }

    public class iManSession : IDisposable
    {
        public iml.IManSession me;

        public iManSession(iml.IManSession Session)
        {
            me = Session;
        }

        public void Dispose()
        {
            if (me.Connected) me.Logout();
        }

        public List<iManDatabase> Databases
        {
            get
            {
                return me.Databases.ToList();
            }
        }

        public string ServerName
        {
            get
            {
                return me.ServerName;
            }
        }
    }

    public class iManDatabase
    {
        public iml.IManDatabase me;

        private SqlConnection SqlServer;
        public bool SqlEnabled { get { return (SqlServer != null); } }

        public void ConnectToSql(string ConnectionString)
        {
            try
            {
                SqlServer = new SqlConnection(ConnectionString);
                SqlServer.Open();
            }
            catch
            {
                SqlServer = null;
            }
        }

        public void ConnectToSql(string Server, string Database, string Username = null, string Password = null)
        {
            try
            {
                SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
                con.DataSource = Server;
                con.InitialCatalog = Database;
                if (Username == null)
                {
                    con.IntegratedSecurity = true;
                }
                else
                {
                    con.IntegratedSecurity = false;
                    con.UserID = Username;
                    if (Password != null) { con.Password = Password; }
                }

                SqlServer = new SqlConnection(con.ToString());
                SqlServer.Open();
            }
            catch
            {
                SqlServer = null;
            }

        }

        public SqlDataReader ExecuteSql(string Query)
        {
            if (!SqlEnabled) throw new Exception("SQL Server not configured. Call ConnectToSql() on the iManDatabase object to configure a connection.");
            SqlCommand QueryCommand = new SqlCommand(Query, SqlServer);
            return QueryCommand.ExecuteReader();
        }

        public iml.imProfileAttributeID ClientCustomField
        {
            get;
            set;
        }
        public void SetClientCustomField(int ClientCustomFieldPosition)
        {
            this.ClientCustomField = (iml.imProfileAttributeID)Enum.Parse(typeof(iml.imProfileAttributeID), "imProfileCustom" + ClientCustomFieldPosition);
        }

        public iml.imProfileAttributeID MatterCustomField
        {
            get;
            set;
        }
        public void SetMatterCustomField(int MatterCustomFieldPosition)
        {
            this.MatterCustomField = (iml.imProfileAttributeID)Enum.Parse(typeof(iml.imProfileAttributeID), "imProfileCustom" + MatterCustomFieldPosition);
        }

        public iManDatabase(iml.IManDatabase database, int ClientCustomFieldPosition = 1, int MatterCustomFieldPosition = 2)
        {
            me = database;
            SetClientCustomField(ClientCustomFieldPosition);
            SetMatterCustomField(MatterCustomFieldPosition);
        }

        public string Name
        {
            get
            {
                return me.Name;
            }
        }

        public List<iManWorkspace> SearchWorkspaces(iml.IManWorkspaceSearchParameters wssp, iml.IManProfileSearchParameters psp)
        {
            return ((iml.IManFolders)me.SearchWorkspaces(psp, wssp)).ToWorkspaceList(this);
        }

        public List<iManDocument> SearchDocuments()
        {
            return ((iml.IManDocuments)me.SearchDocuments(me.Session.DMS.CreateProfileSearchParameters(), false)).ToList(this);
        }

        public iManDocument GetDocument(int DocumentNumber, int DocumentVersion)
        {
            return new iManDocument(me.GetDocument(DocumentNumber, DocumentVersion), this);
        }

        public List<iManDocument> CheckedOutDocuments { get { return me.CheckedOutList.ToDocumentList(this); } }

    }

    public class iManWorkspace
    {
        public iml.IManWorkspace me;
        public iManDatabase Database { get; private set; }

        public iManWorkspace(iml.IManWorkspace workspace, iManDatabase Database)
        {
            me = workspace;
            this.Database = Database;
        }

        public List<iManFolder> SubFolders
        {
            get
            {
                return me.SubFolders.ToList(Database);
            }
        }

        public void Refile()
        {
            SubFolders.ForEach(f => f.Refile());
        }

        public string Name { get { return me.Name; } set { me.Name = value; } }

        public string Description { get { return me.Description; } set { me.Description = value; } }

        public void Update() { me.Update(); }

    }

    public class iManFolder
    {
        public iml.IManFolder me;
        public iManDatabase Database { get; private set; }

        public iManFolder(iml.IManFolder folder, iManDatabase Database)
        {
            me = folder;
            this.Database = Database;
        }

        public string Name { get { return me.Name; } set { me.Name = value; } }

        public List<iManDocument> Documents
        {
            get
            {
                List<iManDocument> results = new List<iManDocument>();
                foreach (iml.IManContent c in me.Contents)
                    if (c is iml.IManDocument)
                        results.Add(new iManDocument((iml.IManDocument)c, Database));
                return results;
            }
        }

        public List<iManFolder> Folders { get { return me.SubFolders.ToList(Database); } }

        public void Refile()
        {
        }

        public void Update() { me.Update(); }
    }

    public class iManDocument
    {
        public iml.IManDocument me;
        public iManDatabase Database { get; private set; }

        public iManDocument(iml.IManDocument Document, iManDatabase Database)
        {
            me = Document;
            this.Database = Database;
        }

        public int Number { get { return me.Number; } }

        public int Version { get { return me.Version; } }

        public bool CheckedOut { get { return me.CheckedOut; } }

        public string Comment { get { return me.Comment; } set { me.Comment = value; } }

        public string Description { get { return me.Description; } set { me.Description = value; } }

        public string ClientCode { get { return me.CustomAttributes.ToList().Where(a => a.Type == Database.ClientCustomField).Single().Name; } }

        public string MatterCode { get { return me.CustomAttributes.ToList().Where(a => a.Type == Database.MatterCustomField).Single().Name; } }

        public string Extension { get { return me.Extension; } }

        public void CheckOut(string Filename)
        {
            if (me.CheckedOut)
                throw new ApplicationException(String.Format("Document {0}.{1} already checked out by {2} to {3}", me.Number, me.Version, me.InUseBy, me.CheckoutLocation));
            me.CheckOut(Filename, iml.imCheckOutOptions.imDontReplaceExistingFile, DateTime.Now.AddDays(1), "");
        }

        /// <summary>
        /// If run from the same machine as CheckOut(), uploads the checked out local copy of the document and removes the checked out status.
        /// </summary>
        public void CheckIn(string Filename = null)
        {
            object errorObject = new object();
            if (me.CheckedOut)
                me.CheckIn((Filename == null) ? me.CheckoutLocation : Filename, iml.imCheckinDisposition.imCheckinReplaceOriginal, iml.imCheckinOptions.imDontKeepCheckedOut, ref errorObject);
        }

        /// <summary>
        /// Removes the checked out status of a checked out document.
        /// </summary>
        public void Unlock()
        {
            if (me.CheckedOut)
                ((iml.IManDocument)me).UnlockContent();
            else
                throw new ApplicationException(String.Format("Document {0}.{1} not checked out", me.Number, me.Version));

        }

        /// <summary>
        /// Saves a copy of the document to the specified file without checking it out.
        /// </summary>
        /// <param name="filename">The path to the file to save to.</param>
        /// <param name="ConvertToHTML">If true, converts the document to HTML during the copy.</param>
        public void GetCopy(string filename, bool ConvertToHTML = false)
        {
            me.GetCopy(filename, ConvertToHTML ? iml.imGetCopyOptions.imHTMLFormat : iml.imGetCopyOptions.imNativeFormat);
        }

        public void Update() { me.Update(); }

        /// <summary>
        /// The folders that contain this document, a.k.a. "Where Used".
        /// </summary>
        public List<iManFolder> Folders { get { return me.Folders.ToList(Database); } }

        public List<iManDocumentHistory> History { get { return me.HistoryList.ToList(Database); } }

    }

    public class iManDocumentHistory
    {
        public iml.IManDocumentHistory me;
        public iManDatabase Database;

        public iManDocumentHistory(iml.IManDocumentHistory DocumentHistory, iManDatabase Database)
        {
            this.me = DocumentHistory;
            this.Database = Database;
        }

        public string Application { get { return me.Application; } }
        public string Comment { get { return me.Comment; } }
        public DateTime Date { get { return me.Date; } }
        public int Duration { get { return me.Duration; } }
        public string Location { get { return me.Location; } }
        public string Number { get { return me.Number; } }
        public string Operation { get { return me.Operation; } }
        public int PagesPrinted { get { return me.PagesPrinted; } }
        public string User { get { return me.User; } }
        public string Version { get { return me.Version; } }

    }

    public class iManUser
    {
        public iml.IManUser me;
        public iManDatabase Database;

        public iManUser(iml.IManUser User, iManDatabase Database)
        {
            this.me = User;
            this.Database = Database;
        }

        public string Custom1 { get { return me.Custom1; } }
        public string Custom2 { get { return me.Custom2; } }
        public string Custom3 { get { return me.Custom3; } }
        public string DomainName { get { return me.DomainName; } }
        public string Email { get { return me.Email; } }
        public string Email2 { get { return me.Email2; } }
        public string Email3 { get { return me.Email3; } }
        public string Email4 { get { return me.Email4; } }
        public string Email5 { get { return me.Email5; } }
        public string Extension { get { return me.Extension; } }
        public string Fax { get { return me.Fax; } }
        public string FullName { get { return me.FullName; } }
        public bool HasPreferredDatabase { get { return me.HasPreferredDatabase; } }
        public bool HasPreferredFileServer { get { return me.HasPreferredFileServer; } }
        public bool IsExternal { get { return me.IsExternal; } }
        public string Location { get { return me.Location; } }
        public bool LoginEnabled { get { return me.LoginEnabled; } }
        public string Mobile { get { return me.Mobile; } }
        public string Name { get { return me.Name; } }
        public string Other { get { return me.Other; } }
        public string Pager { get { return me.Pager; } }
        public bool PasswordExpires { get { return me.PasswordExpires; } }
        public string Phone { get { return me.Phone; } }
        public iManDatabase PreferredDatabase { get { return new iManDatabase(me.PreferredDatabase); } }
        public string PreferredFileServer { get { return me.PreferredFileServer; } }
        public bool Supervisor { get { return me.Supervisor; } }

    }
}
