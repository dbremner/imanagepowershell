using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManAdditionalProperty : iManObjectDatabase
    {
        internal new iml.IManAdditionalProperty Me { get { return (iml.IManAdditionalProperty)base.Me; } }
        public iManAdditionalProperty(iml.IManAdditionalProperty property, iManDatabase database) : base(property, database) { }

        public string ID { get { return Me.ID; }}
        public new string Name { get { return Me.Name; } set { Me.Name = value; }}
        public int Number { get { return Me.Number; }}
        public string Value { get { return Me.Value; } set { Me.Value = value; }}
    }
}
