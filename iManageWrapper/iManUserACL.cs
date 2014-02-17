using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    // ReSharper disable once InconsistentNaming
    public class iManUserACL : iManObjectDatabase
    {
        internal new iml.IManUserACL Me { get { return (iml.IManUserACL)base.Me; } }

        private readonly iManProfiledContent _parentContent;
        private readonly iManFolder _parentFolder;

        public iManUserACL(iml.IManUserACL userAcl, iManProfiledContent parent)
            : base(userAcl, parent.Database)
        {
            _parentContent = parent;
        }

        public iManUserACL(iml.IManUserACL userAcl, iManFolder parent)
            : base(userAcl, parent.Database)
        {
            _parentFolder = parent;
        }

        public imAccessRight Right
        {
            get { return (imAccessRight)Me.Right; }
            set { Me.Right = (iml.imAccessRight) value;  }
        }

        public iManUser User
        {
            get { return new iManUser(Me.User, Database);}
            set { Me.let_User(value.Me);}
        }

        public new string Name { get { return string.Format("{0} for user {1}", Right, User.Name); }}

        public void Update()
        {
            if (_parentContent != null) { _parentContent.Update(); }
            if (_parentFolder != null) { _parentFolder.Update(); }
        }

        public void Remove()
        {
            if (_parentContent != null)
            {
                _parentContent.Security.Me.UserACLs.RemoveByObject(Me);
            }
            if (_parentFolder != null)
            {
                _parentFolder.Security.Me.UserACLs.RemoveByObject(Me);
            }
        }

    }
}
