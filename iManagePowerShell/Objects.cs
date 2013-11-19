using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
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
                if (s.Connected) s.Logout();
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

        public iml.imProfileAttributeID _ClientCustomField;
        public string ClientCustomField
        {
            get { return _ClientCustomField.ToString(); }
            set { _ClientCustomField = (iml.imProfileAttributeID)Enum.Parse(typeof(iml.imProfileAttributeID), "imProfileCustom" + value); }
        }

        public iml.imProfileAttributeID _MatterCustomField;
        public string MatterCustomField
        {
            get { return _MatterCustomField.ToString(); }
            set { _MatterCustomField = (iml.imProfileAttributeID)Enum.Parse(typeof(iml.imProfileAttributeID), "imProfileCustom" + value); }
        }

        public iManDatabase(iml.IManDatabase database, int ClientCustomFieldPosition = 1, int MatterCustomFieldPosition = 2)
        {
            me = database;
            ClientCustomField = ClientCustomFieldPosition.ToString();
            MatterCustomField = MatterCustomFieldPosition.ToString();
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

        public string ClientCode { get { return me.CustomAttributes.ToList().Where(a => a.Type == Database._ClientCustomField).Single().Name; } }

        public string MatterCode { get { return me.CustomAttributes.ToList().Where(a => a.Type == Database._MatterCustomField).Single().Name; } }

        public string Extension { get { return me.Extension; } }

        public void CheckOut(string Filename)
        {
            if (me.CheckedOut)
                throw new ApplicationException(String.Format("Document {0}.{1} already checked out by {3} to {4}", me.Number, me.Version, me.InUseBy, me.CheckoutLocation));
            me.CheckOut(Filename, iml.imCheckOutOptions.imDontReplaceExistingFile, DateTime.Now.AddDays(1), "");
        }

        /// <summary>
        /// If run from the same machine as CheckOut(), uploads the checked out local copy of the document and removes the checked out status.
        /// </summary>
        public void CheckIn()
        {
            object errorObject = new object();
            if (me.CheckedOut)
                me.CheckIn(me.CheckoutLocation, iml.imCheckinDisposition.imCheckinReplaceOriginal, iml.imCheckinOptions.imDontKeepCheckedOut, ref errorObject);
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



    }


}
