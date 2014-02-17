using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using iml = IManage;

namespace iManageWrapper
{
    public class iManSecurity : iManObjectDatabase
    {
        internal new iml.IManSecurity Me { get { return (iml.IManSecurity)base.Me; } }

        private readonly iManProfiledContent _parentContent;
        private readonly iManFolder _parentFolder;

        public iManSecurity(iml.IManSecurity security, iManProfiledContent parent)
            : base(security, parent.Database)
        {
            _parentContent = parent;
        }

        public iManSecurity(iml.IManSecurity security, iManFolder parent)
            : base(security, parent.Database)
        {
            _parentFolder = parent;
        }

        public imSecurityType DefaultVisibility
        {
            get { return (imSecurityType)Me.DefaultVisibility; }
            set { Me.DefaultVisibility = (iml.imSecurityType)value; }
        }

        public bool ExternallyVisible
        {
            get { return Me.ExternallyVisible; }
        }

        public IEnumerable<iManGroupACL> GroupACLs
        {
            get
            {
                foreach (iml.IManGroupACL groupAcl in Me.GroupACLs)
                    if (_parentContent != null)
                        yield return new iManGroupACL(groupAcl, _parentContent);
                    else
                        yield return new iManGroupACL(groupAcl, _parentFolder);
            }
        }

        public bool IncludeExternalUsersInDefaultSecurity
        {
            get { return Me.IncludeExternalUsersInDefaultSecurity; }
            set { Me.IncludeExternalUsersInDefaultSecurity = value; }
        }

        public bool Inherited
        {
            get { return Me.Inherited; }
            set { Me.Inherited = value; }
        }

        public IEnumerable<iManUserACL> UserACLs
        {
            get
            {
                foreach (iml.IManUserACL userAcL in Me.UserACLs)
                    if (_parentContent != null)
                        yield return new iManUserACL(userAcL, _parentContent);
                    else
                        yield return new iManUserACL(userAcL, _parentFolder);
            }
        }

        public override string Name
        {
            get { return string.Format("visibility: {0}, users: {1}, groups: {2}", Me.DefaultVisibility.ToString(), UserACLs.Count(), GroupACLs.Count()); }
        }

        public void AddUserACL(iManUser user, imAccessRight right)
        {
            Me.UserACLs.Add(user.Name, (iml.imAccessRight)right);
        }

        public void AddGroupACL(iManGroup group, imAccessRight right)
        {
            Me.GroupACLs.Add(group.Name, (iml.imAccessRight)right);
        }

        public void Update()
        {
            if (_parentContent != null ) { _parentContent.Update(); }
            if (_parentFolder != null) { _parentFolder.Update(); }
        }

    }
}
