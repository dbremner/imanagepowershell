using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManProfiledFolder : iManFolder
    {
        internal new iml.IManProfiledFolder Me { get { return (iml.IManProfiledFolder)base.Me; } }

        public iManProfiledFolder(iml.IManProfiledFolder folder, iManDatabase database)
                    : base(folder, database)
        {
        }

        public iManProfile Profile { get { return new iManProfile(Me.Profile, Database); }}

    }
}
