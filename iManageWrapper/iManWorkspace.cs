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

    public class iManWorkspace
    {
        internal iml.IManWorkspace me;
        public iManDatabase Database { get; private set; }

        public iManWorkspace(iml.IManWorkspace workspace, iManDatabase Database)
        {
            me = workspace;
            this.Database = Database;
        }

        static public implicit operator iManFolder(iManWorkspace w)
        {
            return new iManFolder((iml.IManFolder)w.me, w.Database);
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

        public iManFolder AddNewDocumentFolderInheriting(string Name, string Description)
        {
            return new iManFolder(((iml.IManDocumentFolders)me.SubFolders).AddNewDocumentFolderInheriting(Name, Description), Database);
        }

        public List<iManDocument> SearchDocuments(string Name, string Number, string Version, string Author, string CreatedBy, string Client, string Matter, string Fulltext)
        {
            var psp = Database.me.Session.DMS.CreateProfileSearchParameters();
            if (Name != null) { psp.Add(iml.imProfileAttributeID.imProfileName, Name); }
            if (Number != null) { psp.Add(iml.imProfileAttributeID.imProfileDocNum, Number); }
            if (Version != null) { psp.Add(iml.imProfileAttributeID.imProfileVersion, Version); }
            if (Author != null) { psp.Add(iml.imProfileAttributeID.imProfileAuthor, Author); }
            if (CreatedBy != null) { psp.Add(iml.imProfileAttributeID.imProfileOperator, CreatedBy); }
            if (Client != null) { psp.Add(Database.ClientCustomField, Client); }
            if (Matter != null) { psp.Add(Database.MatterCustomField, Matter); }
            if (Fulltext != null) { psp.AddFullTextSearch(Fulltext, iml.imFullTextSearchLocation.imFullTextAnywhere); }

            // this line is the only difference between FromWorkspace and FromDatabase
            psp.Add(iml.imProfileAttributeID.imProfileContainerID, me.FolderID.ToString());

            return me.Database.SearchDocuments(psp, true).ToDocumentList(Database);
        }

    }

}