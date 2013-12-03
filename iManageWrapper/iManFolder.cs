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

// ReSharper disable once InconsistentNaming
    public class iManFolder
    {
        internal readonly iml.IManFolder Me;
        public iManDatabase Database { get; private set; }

        public iManFolder(iml.IManFolder folder, iManDatabase database)
        {
            Me = folder;
            this.Database = database;
        }

        public string Name { get { return Me.Name; } set { Me.Name = value; } }

        public List<iManDocument> Documents
        {
            get
            {
                var results = new List<iManDocument>();
                foreach (iml.IManContent c in Me.Contents)
                {
                    var document = c as iml.IManDocument;
                    if (document != null)
                        results.Add(new iManDocument(document, Database));
                }
                return results;
            }
        }

        public List<iManFolder> Folders { get { return Me.SubFolders.ToList(Database); } }

        public void Refile()
        {
        }

        public iManFolder AddNewDocumentFolderInheriting(string name, string description)
        {
            return new iManFolder(((iml.IManDocumentFolders)Me.SubFolders).AddNewDocumentFolderInheriting(name, description), Database);
        }

        public void AddDocumentReference(iManDocument document)
        {
            var df = (iml.IManDocuments)Me.Contents;
            df.AddDocumentReference(document.me);
        }

        public void Update() { Me.Update(); }

        public string FullPath
        {
            get
            {
                var result = new StringBuilder();
                var Parent = Me.Parent;
                while (Parent != null)
                {
                    result.Insert(0, @"\");
                    result.Insert(0, Parent.Name);
                    Parent = Parent.Parent;
                }
                return result.Append(Name).ToString();
            }
        }

        public override string ToString()
        {
            return FullPath;
        }
    }

}