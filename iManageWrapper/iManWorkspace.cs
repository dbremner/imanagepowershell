using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using iml = IManage;

namespace iManageWrapper
{

// ReSharper disable once InconsistentNaming
    public class iManWorkspace : iManObjectDatabase
    {
        internal new iml.IManWorkspace Me { get { return (iml.IManWorkspace)base.Me; } }

        public iManWorkspace(iml.IManWorkspace workspace, iManDatabase database) : base(workspace, database)
        {
        }

        static public implicit operator iManFolder(iManWorkspace w)
        {
            return new iManFolder(w.Me, w.Database);
        }

        public IEnumerable<iManFolder> SubFolders
        {
            get
            {
                foreach (iml.IManFolder f in Me.SubFolders)
                    yield return new iManFolder(f, Database);
            }
        }

        public void Refile()
        {
            foreach (var f in SubFolders)
                f.Refile();
        }

        public string Name { get { return Me.Name; } set { Me.Name = value; } }

        public string Description { get { return Me.Description; } set { Me.Description = value; } }

        public void Update() { Me.Update(); }

        public iManFolder AddNewDocumentFolderInheriting(string name, string description)
        {
            return new iManFolder(((iml.IManDocumentFolders)Me.SubFolders).AddNewDocumentFolderInheriting(name, description), Database);
        }

        public IEnumerable<iManDocument> SearchDocuments(string name, string number, string version, string author, string createdBy, string client, string matter, string fulltext)
        {
            var psp = Database.Me.Session.DMS.CreateProfileSearchParameters();
            if (name != null) { psp.Add(iml.imProfileAttributeID.imProfileName, name); }
            if (number != null) { psp.Add(iml.imProfileAttributeID.imProfileDocNum, number); }
            if (version != null) { psp.Add(iml.imProfileAttributeID.imProfileVersion, version); }
            if (author != null) { psp.Add(iml.imProfileAttributeID.imProfileAuthor, author); }
            if (createdBy != null) { psp.Add(iml.imProfileAttributeID.imProfileOperator, createdBy); }
            if (client != null) { psp.Add(Database.ClientCustomField, client); }
            if (matter != null) { psp.Add(Database.MatterCustomField, matter); }
            if (fulltext != null) { psp.AddFullTextSearch(fulltext, iml.imFullTextSearchLocation.imFullTextAnywhere); }

            // this line is the only difference between FromWorkspace and FromDatabase
            psp.Add(iml.imProfileAttributeID.imProfileContainerID, Me.FolderID.ToString(CultureInfo.InvariantCulture));

            foreach (iml.IManDocument d in Me.Database.SearchDocuments(psp, true))
                yield return new iManDocument(d, Database);
        }

    }

}