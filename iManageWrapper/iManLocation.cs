using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iml = IManage;

namespace iManageWrapper
{
    public class iManLocation : iManObjectDatabase
    {
        internal new iml.IManLocation Me { get { return (iml.IManLocation)base.Me; } }

        public iManLocation(iml.IManLocation location, iManDatabase database)
            : base(location, database)
        {
        }

        public string Cell {
            get { return Me.Cell; }
            set { Me.Cell = value; }
        }

        public int Order
        {
            get { return Me.Order; }
            set { Me.Order = value; }
        }
    }
}
