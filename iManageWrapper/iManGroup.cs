using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManGroup : iManObjectDatabase
    {
        internal new iml.IManGroup Me { get { return (iml.IManGroup)base.Me; } }

        public iManGroup(iml.IManGroup group, iManDatabase database) : base(group,database)
        {
        }

        public string DomainName { get { return Me.DomainName; }}

        public bool Enabled { get { return Me.Enabled; }}

        public string FullName { get { return Me.FullName; }}

        public int GroupNumber { get { return Me.GroupNumber; }}

        public bool IsExternal { get { return Me.IsExternal; }}

        public new string Name { get { return Me.Name; }}

        public iml.imNOS NOS { get { return Me.NOS; }}

        public IEnumerable<iManUser> Users
        {
            get
            {
                foreach (iml.IManUser user in Me.Users)
                    yield return new iManUser(user, Database);
            }
        }
    }
}
