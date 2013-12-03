using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using iml = IManage;

namespace iManageWrapper
{
// ReSharper disable once InconsistentNaming
    public class iManDatabase
    {
        private SqlConnection _sqlServer;
        internal iml.IManDatabase Me;

        public iManDatabase(iml.IManDatabase database, int clientCustomFieldPosition = 1,
            int matterCustomFieldPosition = 2)
        {
            Me = database;
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
                    (iml.imProfileAttributeID) Enum.Parse(typeof (iml.imProfileAttributeID), "imProfileCustom" + value);
            }
        }

        internal iml.imProfileAttributeID MatterCustomField { get; set; }

        public int MatterCustomFieldPosition
        {
            get { return Convert.ToInt32(MatterCustomField.ToString().Replace("imProfileCustom", "")); }
            set
            {
                MatterCustomField =
                    (iml.imProfileAttributeID) Enum.Parse(typeof (iml.imProfileAttributeID), "imProfileCustom" + value);
            }
        }

        public string Name
        {
            get { return Me.Name; }
        }

        public string ServerName
        {
            get { return Me.Session.ServerName; }
        }

        public List<iManDocument> CheckedOutDocuments
        {
            get { return Me.CheckedOutList.ToDocumentList(this); }
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
                var con = new SqlConnectionStringBuilder {DataSource = server, InitialCatalog = database};

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

        public List<iManDocument> SearchDocuments(string name, string number, string version, string author,
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

            if (psp.Count > 0)
                return Me.SearchDocuments(psp, true).ToDocumentList(this);
            throw new ApplicationException("No search criteria specified.");
        }

        public iManDocument GetDocument(int documentNumber, int documentVersion)
        {
            return new iManDocument(Me.GetDocument(documentNumber, documentVersion), this);
        }

        public List<iManUser> SearchUsersByUsername(string username)
        {
            var result = new List<iManUser>();
            try
            {
                result = Me.SearchUsers(username, iml.imSearchAttributeType.imSearchExactMatch, true).ToList(this);
            }
            catch (COMException e)
            {
                if (e.ErrorCode != -2147211972)
                    throw;
            }
            return result;
        }

        public List<iManUser> SearchUsersByFullname(string fullname)
        {
            return Me.SearchUsers(fullname, iml.imSearchAttributeType.imSearchFullName, true).ToList(this);
        }

        public List<iManWorkspace> SearchWorkspaces(string description, string name, string owner, string client,
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

            return Me.SearchWorkspaces(psp, wssp).ToWorkspaceList(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}