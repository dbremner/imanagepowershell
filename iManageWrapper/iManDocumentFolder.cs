using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManDocumentFolder : iManFolder
    {
        internal new iml.IManDocumentFolder Me { get { return (iml.IManDocumentFolder)base.Me; } }

        public iManDocumentFolder(iml.IManDocumentFolder folder, iManDatabase database)
            : base(folder, database)
        {
        }
    }
}
