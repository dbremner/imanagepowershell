using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using iml = IManage;

namespace iManageWrapper
{

    public class iManDatabase
    {
        internal iml.IManDatabase me;

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

        public string Name { get { return me.Name; } }

        public string ServerName { get { return me.Session.ServerName; } }

        public List<iManDocument> SearchDocuments(string Name, string Number, string Version, string Author, string CreatedBy, string Client, string Matter, string Fulltext)
        {
            var psp = me.Session.DMS.CreateProfileSearchParameters();
            if (Name != null) { psp.Add(iml.imProfileAttributeID.imProfileName, Name); }
            if (Number != null) { psp.Add(iml.imProfileAttributeID.imProfileDocNum, Number); }
            if (Version != null) { psp.Add(iml.imProfileAttributeID.imProfileVersion, Version); }
            if (Author != null) { psp.Add(iml.imProfileAttributeID.imProfileAuthor, Author); }
            if (CreatedBy != null) { psp.Add(iml.imProfileAttributeID.imProfileOperator, CreatedBy); }
            if (Client != null) { psp.Add(ClientCustomField, Client); }
            if (Matter != null) { psp.Add(MatterCustomField, Matter); }
            if (Fulltext != null) { psp.AddFullTextSearch(Fulltext, iml.imFullTextSearchLocation.imFullTextAnywhere); }

            if (psp.Count > 0)
                return me.SearchDocuments(psp, true).ToDocumentList(this);
            else
                throw new ApplicationException("No search criteria specified.");
        }

        public iManDocument GetDocument(int DocumentNumber, int DocumentVersion)
        {
            return new iManDocument(me.GetDocument(DocumentNumber, DocumentVersion), this);
        }

        public List<iManDocument> CheckedOutDocuments { get { return me.CheckedOutList.ToDocumentList(this); } }

        public List<iManUser> SearchUsersByUsername(string Username)
        {
            List<iManUser> result = new List<iManUser>();
            try
            {
                result = me.SearchUsers(Username, iml.imSearchAttributeType.imSearchExactMatch, true).ToList(this);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                if (e.ErrorCode != -2147211972)
                    throw e;
            }
            return result;
        }

        public List<iManUser> SearchUsersByFullname(string Fullname)
        {
            return me.SearchUsers(Fullname, iml.imSearchAttributeType.imSearchFullName, true).ToList(this);
        }

        public List<iManWorkspace> SearchWorkspaces(string Description, string Name, string Owner, string Client, string Matter)
        {
            var wssp = me.Session.DMS.CreateWorkspaceSearchParameters();
            if (Description != null) { wssp.Add(iml.imFolderAttributeID.imFolderDescription, Description); }
            if (Name != null) { wssp.Add(iml.imFolderAttributeID.imFolderName, Name); }
            if (Owner != null) { wssp.Add(iml.imFolderAttributeID.imFolderOwner, Owner); }

            var psp = me.Session.DMS.CreateProfileSearchParameters();
            if (Client != null) { psp.Add(ClientCustomField, Client); }
            if (Matter != null) { psp.Add(MatterCustomField, Matter); }

            return me.SearchWorkspaces(psp, wssp).ToWorkspaceList(this);
        }

        public override string ToString()
        {
            return Name;
        }

    }

}