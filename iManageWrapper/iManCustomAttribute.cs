using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{

    public class iManCustomAttribute : iManObjectDatabase
    {
        internal new iml.IManCustomAttribute Me
        {
            get { return (iml.IManCustomAttribute) base.Me; }
        }

        public iManCustomAttribute(iml.IManCustomAttribute attribute, iManDatabase database) : base(attribute, database)
        {
        }

        public string Description { get { return Me.Description; } }
        public bool Enabled { get { return Me.Enabled; } }
        public string ID { get { return Me.ID; } }
        public new string Name { get { return Me.Name; } }
        public iManCustomAttribute Parent { get { return new iManCustomAttribute(Me.Parent, Database); } }
        public iml.imProfileAttributeID Type { get { return Me.Type; } }

    }
}
