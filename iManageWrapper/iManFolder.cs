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

    public class iManFolder
    {
        internal iml.IManFolder me;
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

        public iManFolder AddNewDocumentFolderInheriting(string Name, string Description)
        {
            return new iManFolder(((iml.IManDocumentFolders)me.SubFolders).AddNewDocumentFolderInheriting(Name, Description), Database);
        }

        public void AddDocumentReference(iManDocument Document)
        {
            iml.IManDocuments df = (iml.IManDocuments)me.Contents;
            df.AddDocumentReference(Document.me);
        }

        public void Update() { me.Update(); }

        public string FullPath
        {
            get
            {
                StringBuilder result = new StringBuilder();
                var Parent = me.Parent;
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