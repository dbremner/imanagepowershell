using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{

    public class iManDocumentClass : iManObjectDatabase
    {
        internal new iml.IManDocumentClass Me { get { return (iml.IManDocumentClass)base.Me; } }

        public iManDocumentClass(iml.IManDocumentClass documentClass, iManDatabase database) : base(documentClass,database)
        {
        }

        public iml.imSecurityType DefaultSecurity { get { return Me.DefaultSecurity; } }
        public string Description { get { return Me.Description; } }
        public bool Echo { get { return Me.Echo; } }
        public bool Indexable { get { return Me.Indexable; } }
        public bool IsSubClass { get { return Me.IsSubclass; } }
        public new string Name { get { return Me.Name; } }
        public iManDocumentClass Parent { get { return new iManDocumentClass(Me.Parent, Database); } }
        //public iml.IManAttributeSelections RequiredFields { get { return Me.RequiredFields; } }
        public long RetentionDays { get { return Me.RetentionDays; } }
        public bool SubClassRequired { get { return Me.SubClassRequired; } }

    }
}
