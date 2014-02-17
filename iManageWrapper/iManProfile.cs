using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{

    public class iManProfile : iManObjectDatabase
    {
        internal new iml.IManProfile Me { get { return (iml.IManProfile)base.Me; } }

        public iManProfile(iml.IManProfile profile, iManDatabase database) : base(profile,database)
        {
        }

        public T GetAttributeByID<T>(iml.imProfileAttributeID attribute)
        {
            return (T) Me.GetAttributeByID(attribute);
        }

        public T GetAttributeValueByID<T>(iml.imProfileAttributeID attribute)
        {
            return (T) Me.GetAttributeValueByID(attribute);
        }

        public void SetAttributeByID(iml.imProfileAttributeID attribute, object value)
        {
            Me.SetAttributeByID(attribute, value);
        }
    }
}
