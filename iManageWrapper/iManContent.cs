using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManContent : iManObjectDatabase
    {
        internal new iml.IManContent Me { get { return (iml.IManContent)base.Me; } }

        public iManContent(iml.IManContent content, iManDatabase database) : base(content, database)
        {
        }

        public void Update()
        {
            Me.Update();
        }
    }
}
