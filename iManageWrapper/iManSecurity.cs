using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManSecurity : iManObjectDatabase
    {
        internal new iml.IManSecurity Me { get { return (iml.IManSecurity)base.Me; } }

        public iManSecurity(iml.IManSecurity workspace, iManDatabase database) : base(workspace,database)
        {
        }
   }
}
