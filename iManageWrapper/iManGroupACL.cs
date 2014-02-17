using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    // ReSharper disable once InconsistentNaming
    public class iManGroupACL : iManObjectDatabase
    {
        internal new iml.IManGroupACL Me { get { return (iml.IManGroupACL)base.Me; } }

        private readonly iManProfiledContent _parentContent;
        private readonly iManFolder _parentFolder;

        public iManGroupACL(iml.IManGroupACL groupAcl, iManProfiledContent parent)
            : base(groupAcl, parent.Database)
        {
            _parentContent = parent;
        }

        public iManGroupACL(iml.IManGroupACL groupAcl, iManFolder parent)
            : base(groupAcl, parent.Database)
        {
            _parentFolder = parent;
        }

        public imAccessRight Right
        {
            get { return (imAccessRight)Me.Right; }
            set { Me.Right = (iml.imAccessRight)value; }
        }

        public iManGroup Group
        {
            get { return new iManGroup(Me.Group, Database); }
            set { Me.let_Group(value.Me); }
        }

        public new string Name { get { return string.Format("{0} for group {1}", Right, Group.Name); } }

        public void Update()
        {
            if (_parentContent != null) { _parentContent.Update(); }
            if (_parentFolder != null) { _parentFolder.Update(); }
        }

        public void Remove()
        {
            if (_parentContent != null)
            {
                _parentContent.Security.Me.GroupACLs.RemoveByObject(Me);
            }
            if (_parentFolder != null)
            {
                _parentFolder.Security.Me.GroupACLs.RemoveByObject(Me);
            }
        }

    }
}
