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


    public class iManFolder : iManObjectDatabase
    {
        internal new iml.IManFolder Me { get { return (iml.IManFolder)base.Me; } }

        public iManFolder(iml.IManFolder folder, iManDatabase database) : base(folder,database)
        {
        }

        public new string Name { get { return Me.Name; } set { Me.Name = value; } }

        public string Description { get { return Me.Description;  } set { Me.Description = value; }}

        public IEnumerable<iManContent> Contents
        {
            get
            {
                foreach (iml.IManContent c in Me.Contents)
                {
                    yield return new iManContent(c, Database);
                }
            }
        }

        public IEnumerable<iManDocument> Documents
        {
            get
            {
                foreach (iml.IManContent c in Me.Contents)
                {
                    if (c is iml.IManDocument)
                        yield return new iManDocument(c as iml.IManDocument, Database);
                }
            }
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
            
        }

        public void RefileSecurity()
        {
            foreach (iml.IManContent c in Me.Contents)
            {
                var d = c as iml.IManDocument;
                if (d == null) continue;
                d.Refile(d.Profile, Me.Security);
            }
        }

        public iManFolder AddNewDocumentFolderInheriting(string name, string description)
        {
            return new iManFolder(((iml.IManDocumentFolders)Me.SubFolders).AddNewDocumentFolderInheriting(name, description), Database);
        }

        public void AddDocumentReference(iManDocument document)
        {
            var df = (iml.IManDocuments)Me.Contents;
            df.AddDocumentReference(document.Me);
        }

        public void Update() { Me.Update(); }

        public IEnumerable<iml.IManAdditionalProperty> AdditionalProperties
        {
            get
            {
                foreach (iml.IManAdditionalProperty ap in Me.AdditionalProperties)
                    yield return ap;
            }
        }

        public string FullPath
        {
            get
            {
                var result = new StringBuilder();
                var parent = Me.Parent;
                while (parent != null)
                {
                    result.Insert(0, @"\");
                    result.Insert(0, parent.Name);
                    parent = parent.Parent;
                }
                return result.Append(Name).ToString();
            }
        }

        public override string ToString()
        {
            return FullPath;
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

        public iManSecurity Security
        {get {return new iManSecurity(Me.Security, this);}}

        public bool IsRoot { get { return Me.IsRoot; } }
        public bool IsRootLevelFolder { get { return Me.IsRootLevelFolder; } }


        public string EmailPrefix
        {
            get { return Me.EmailPrefix; }
            set { Me.EmailPrefix = value; }
        }

        public string FullEmail { get { return Me.FullEmail; } }

        public bool Hidden
        {
            get { return Me.Hidden; }
            set { Me.Hidden = value; }
        }

        public iManUser Owner
        {
            get { return new iManUser(Me.Owner, Database);}
            set { Me.Owner = value.Me; }
        }

        public iManFolder Parent
        {
            get { return new iManFolder(Me.Parent, Database);}
        }

        public IEnumerable<iManFolder> Path
        {
            get
            {
                foreach (iml.IManFolder folder in Me.Path)
                {
                    yield return new iManFolder(folder, Database);
                }
            }
        }

        public void Refresh() { Me.Refresh();}

        public IEnumerable<iml.IManRules> Rules { get { throw new NotImplementedException();}}

        public string View
        {
            get { return Me.View; }
            set { Me.View = value; }
        }

        public iManWorkspace Workspace { get { return new iManWorkspace(Me.Workspace, Database);}}

        public imAccessRight EffectiveAccess { get { return (imAccessRight) Me.EffectiveAccess; }}

        public int FolderID { get { return Me.FolderID; }}

        public bool IsOperationAllowed(imFolderOp operation)
        {
            return Me.IsOperationAllowed((iml.imFolderOp) operation);
        }

        public iManLocation Location { get { return new iManLocation(Me.Location, Database);}}

    }

}