using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using iml = IManage;

namespace iManageWrapper
{
    
    public class iManDatabase : iManObject
    {
        private SqlConnection _sqlServer;

        internal new iml.IManDatabase Me
        {
            get { return (iml.IManDatabase) base.Me; }
        }

        public iManDatabase(iml.IManDatabase database, int clientCustomFieldPosition = 1,
            int matterCustomFieldPosition = 2) : base(database)
        {
            ClientCustomFieldPosition = clientCustomFieldPosition;
            MatterCustomFieldPosition = matterCustomFieldPosition;
        }

        public bool SqlEnabled
        {
            get { return (_sqlServer != null); }
        }

        internal iml.imProfileAttributeID ClientCustomField { get; set; }

        public int ClientCustomFieldPosition
        {
            get { return Convert.ToInt32(ClientCustomField.ToString().Replace("imProfileCustom", "")); }
            set
            {
                ClientCustomField =
                    (iml.imProfileAttributeID)Enum.Parse(typeof(iml.imProfileAttributeID), "imProfileCustom" + value);
            }
        }

        internal iml.imProfileAttributeID MatterCustomField { get; set; }

        public int MatterCustomFieldPosition
        {
            get { return Convert.ToInt32(MatterCustomField.ToString().Replace("imProfileCustom", "")); }
            set
            {
                MatterCustomField =
                    (iml.imProfileAttributeID)Enum.Parse(typeof(iml.imProfileAttributeID), "imProfileCustom" + value);
            }
        }

        public new string Name
        {
            get { return Me.Name; }
        }

        public string ServerName
        {
            get { return Me.Session.ServerName; }
        }

        public IEnumerable<iManDocument> CheckedOutDocuments
        {
            get
            {
                foreach (iml.IManDocument d in Me.CheckedOutList)
                    yield return new iManDocument(d, this);
            }
        }

        public void ConnectToSql(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");
            try
            {
                _sqlServer = new SqlConnection(connectionString);
                _sqlServer.Open();
            }
            catch
            {
                _sqlServer = null;
            }
        }

        public void ConnectToSql(string server, string database, string username = null, string password = null)
        {
            try
            {
                var con = new SqlConnectionStringBuilder { DataSource = server, InitialCatalog = database };

                if (username == null)
                {
                    con.IntegratedSecurity = true;
                }
                else
                {
                    con.IntegratedSecurity = false;
                    con.UserID = username;
                    if (password != null)
                    {
                        con.Password = password;
                    }
                }

                _sqlServer = new SqlConnection(con.ToString());
                _sqlServer.Open();
            }
            catch
            {
                _sqlServer = null;
                throw;
            }
        }

        public SqlDataReader ExecuteSql(string query)
        {
            if (!SqlEnabled)
                throw new ApplicationException(
                    "SQL Server not configured. Call ConnectToSql() on the iManDatabase object to configure a connection.");
            var queryCommand = new SqlCommand(query, _sqlServer);
            return queryCommand.ExecuteReader();
        }

        public IEnumerable<iManDocument> SearchDocuments(string name, string number, string version, string author,
            string createdBy, string client, string matter, string fulltext)
        {
            var psp = Me.Session.DMS.CreateProfileSearchParameters();
            if (name != null)
            {
                psp.Add(iml.imProfileAttributeID.imProfileName, name);
            }
            if (number != null)
            {
                psp.Add(iml.imProfileAttributeID.imProfileDocNum, number);
            }
            if (version != null)
            {
                psp.Add(iml.imProfileAttributeID.imProfileVersion, version);
            }
            if (author != null)
            {
                psp.Add(iml.imProfileAttributeID.imProfileAuthor, author);
            }
            if (createdBy != null)
            {
                psp.Add(iml.imProfileAttributeID.imProfileOperator, createdBy);
            }
            if (client != null)
            {
                psp.Add(ClientCustomField, client);
            }
            if (matter != null)
            {
                psp.Add(MatterCustomField, matter);
            }
            if (fulltext != null)
            {
                psp.AddFullTextSearch(fulltext, iml.imFullTextSearchLocation.imFullTextAnywhere);
            }

            if (psp.Count == 0)throw new ApplicationException("No search criteria specified.");

            foreach (iml.IManDocument d in Me.SearchDocuments(psp, true))
                yield return new iManDocument(d, this);
            
        }

        public iManUser CurrentUser
        {get{ return new iManUser(Me.GetUser(Me.Session.UserID), this);}}

        public iManDocument GetDocument(int documentNumber, int documentVersion)
        {
            return new iManDocument(Me.GetDocument(documentNumber, documentVersion), this);
        }

        public iManDocument CreateDocument()
        {
            return new iManDocument(Me.CreateDocument(), this);
        }

        public iManDocumentType GetDocumentTypeFromPath(string documentPath)
        {
            return new iManDocumentType(Me.GetDocumentTypeFromPath(documentPath), this);
        }

        public iManFolder GetFolder(int folderID)
        {
            return new iManFolder(Me.GetFolder(folderID), this);
        }

        public iManUser GetUser(string userName)
        {
            return new iManUser(Me.GetUser(userName), this);
        }

        public IEnumerable<iManUser> SearchUsersByUsername(string username)
        {
            iml.IManUsers result = null;
            try
            {
                result = Me.SearchUsers(username, iml.imSearchAttributeType.imSearchExactMatch, true);
            }
            catch (COMException e)
            {
                if (e.ErrorCode != -2147211972)
                    throw;
            }
            if (result == null) yield break;
            foreach (iml.IManUser u in result)
                yield return new iManUser(u, this);
        }

        public IEnumerable<iManUser> SearchUsersByFullname(string fullname)
        {
            foreach (iml.IManUser u in Me.SearchUsers(fullname, iml.imSearchAttributeType.imSearchFullName, true))
                yield return new iManUser(u, this);
        }

        public IEnumerable<iManWorkspace> SearchWorkspaces(string description, string name, string owner, string client,
            string matter)
        {
            var wssp = Me.Session.DMS.CreateWorkspaceSearchParameters();
            if (description != null)
            {
                wssp.Add(iml.imFolderAttributeID.imFolderDescription, description);
            }
            if (name != null)
            {
                wssp.Add(iml.imFolderAttributeID.imFolderName, name);
            }
            if (owner != null)
            {
                wssp.Add(iml.imFolderAttributeID.imFolderOwner, owner);
            }

            var psp = Me.Session.DMS.CreateProfileSearchParameters();
            if (client != null)
            {
                psp.Add(ClientCustomField, client);
            }
            if (matter != null)
            {
                psp.Add(MatterCustomField, matter);
            }

            foreach (iml.IManWorkspace w in Me.SearchWorkspaces(psp, wssp))
                yield return new iManWorkspace(w, this);
        }

        public override string ToString()
        {
            return Me.HasObjectID ? Me.ObjectID : Name;
        }

        public IEnumerable<iManContent> Worklist()
        {
            foreach (iManContent content in Me.Worklist)
                yield return content;
        }

        public IEnumerable<iManWorkspace> Workspaces()
        {
            foreach (iManWorkspace workspace in Me.Workspaces)
                yield return workspace;
        }

        public IEnumerable<iManContent> CheckedOutList()
        {
            foreach (iManContent content in Me.CheckedOutList)
            {
                yield return content;
            }
        }

        public void DeleteDocument(int number, int version)
        {
            Me.DeleteDocument(number, version);
        }

        public void DeleteDocument(iManDocument d)
        {
            DeleteDocument(d.Number, d.Version);
        }

        public string Description { get { return Me.Description; } }

        public iManSession Session { get { return new iManSession(Me.Session); }}

        public IEnumerable<iManFolder> SubscriptionFolders()
        {
            foreach (iml.IManFolder subscriptionFolder in Me.SubscriptionFolders)
            {
                yield return new iManFolder(subscriptionFolder, this);
            }
        }

        public IEnumerable<iManFolder> FavoritesFolders()
        {
            foreach (iml.IManFolder favoriteFolder in Me.FavoritesFolders)
            {
                yield return new iManFolder(favoriteFolder, this);
            }
        }

        public iManFolder Root()
        {
            return new iManFolder(Me.Root, this);
        }
    }
}