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
    public class iManFolder : iManObjectDatabase
    {
        internal new iml.IManFolder Me { get { return (iml.IManFolder)base.Me; } }

        public iManFolder(iml.IManFolder folder, iManDatabase database) : base(folder,database)
        {
        }

        public string Name { get { return Me.Name; } set { Me.Name = value; } }

        public IEnumerable<iManDocument> Documents
        {
            get
            {
                foreach (iml.IManContent c in Me.Contents)
                {
                    var document = c as iml.IManDocument;
                    if (document != null)
                        yield return new iManDocument(document, Database);
                }
            }
        }

        public IEnumerable<iManFolder> Folders
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
    }

}