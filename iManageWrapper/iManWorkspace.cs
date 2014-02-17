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

    public class iManWorkspace : iManProfiledFolder
    {
        internal new iml.IManWorkspace Me { get { return (iml.IManWorkspace)base.Me; } }

        public iManWorkspace(iml.IManWorkspace workspace, iManDatabase database) : base(workspace, database)
        {
        }

        public iManDocumentClass Class { get { return new iManDocumentClass(Me.Class, Database);}}
        public IEnumerable<iManObject> ConnectorFolders { get { throw new NotImplementedException(); } }
        public DateTime CreationDate { get { return Me.CreationDate; } }
        public IEnumerable<iManObject> CustomProperties { get { throw new NotImplementedException(); } }
        public DateTime DateModified { get { return Me.DateModified; } }
        public IEnumerable<iManDocumentFolder> DocumentFolders { get { foreach (iml.IManDocumentFolder f in Me.DocumentFolders) yield return new iManDocumentFolder(f, Database); } }
        public IEnumerable<iManObject> EventFoldesr { get { throw new NotImplementedException(); } }
        public IEnumerable<iManDocumentHistory> HistoryList { get { foreach (iml.IManDocumentHistory h in Me.HistoryList) yield return  new iManDocumentHistory(h, Database); } }
        public iManUser InUseBy { get { return new iManUser(Me.InUseBy, Database); } }
        public iManUser LastUser { get { return new iManUser(Me.LastUser, Database); } }
        public IEnumerable<iManObject> LinkListFolders { get { throw new NotImplementedException(); } }
        public IEnumerable<iManObject> MessageFolders { get { throw new NotImplementedException(); } }
        public IEnumerable<iManObject> NoteFolders { get { throw new NotImplementedException(); } }
        public int Size { get { return Me.Size; } }
        public iManDocumentClass SubClass { get { return new iManDocumentClass(Me.SubClass, Database); } }
        public string SubType { get { return Me.SubType; } }
        public IEnumerable<iManObject> Tabs { get { throw new NotImplementedException(); ; } }
        public IEnumerable<iManObject> TaskFolders { get { throw new NotImplementedException(); ; } }
        public iManDocumentType Type { get { return new iManDocumentType(Me.Type, Database); } }
        public int WorkspaceID { get { return Me.WorkspaceID; } }

        public void AddToRecentWorkspaces()
        {
            Me.AddToRecentWorkspaces();
        }

        public imProfileAttributeID GetAttributeByID(imProfileAttributeID attribute)
        {
            return (imProfileAttributeID)Me.GetAttributeByID((iml.imProfileAttributeID)attribute);
        }

        public object GetAttributeValueByID(imProfileAttributeID attribute)
        {
            object result = Me.GetAttributeValueByID((iml.imProfileAttributeID) attribute);
            return result;
        }

        public void GetCopy(string path) { Me.GetCopy(path); }

        public bool IsWorkspaceOperationAllowed(imWorkspaceOperation operation)
        {
            return Me.IsWorkspaceOperationAllowed((iml.imWorkspaceOperation) operation);
        }

        public void UpdateAll(string file, ref object errors)
        {
            Me.UpdateAll(file, ref errors);
        }
    }

}