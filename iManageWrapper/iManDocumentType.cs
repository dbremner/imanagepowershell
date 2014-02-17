using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManDocumentType : iManObjectDatabase
    {
        internal new iml.IManDocumentType Me { get { return (iml.IManDocumentType)base.Me; } }
        public iManDocumentType(iml.IManDocumentType documentType, iManDatabase database) : base(documentType, database) { }

        public string ApplicationExtension { get { return Me.ApplicationExtension; } }
        public bool AutoDetect { get { return Me.AutoDetect; } }
        public string Description { get { return Me.Description; } }
        public string DMSExtension { get { return Me.DMSExtension; } }
        public bool Indexable { get { return Me.Indexable; } }
        public new string Name { get { return Me.Name; } }
        public iml.IManLaunchMethod Openmethod { get { return Me.Openmethod; } }
        public IEnumerable<iml.IManLaunchMethod> OtherApplications { get { foreach (iml.IManLaunchMethod m in Me.OtherApplications) yield return m; } }
        public iml.IManLaunchMethod Viewmethod { get { return Me.Viewmethod; } }

    }
}
