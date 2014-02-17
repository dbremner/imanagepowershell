using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using iml = IManage;

namespace iManageWrapper
{


    public class iManDocumentHistory : iManObjectDatabase
    {
        internal new iml.IManDocumentHistory Me { get { return (iml.IManDocumentHistory)base.Me; } }

        public iManDocumentHistory(iml.IManDocumentHistory documentHistory, iManDatabase database) : base(documentHistory,database)
        {
        }

        public string Application { get { return Me.Application; } }
        public string Comment { get { return Me.Comment; } }
        public DateTime Date { get { return Me.Date; } }
        public int Duration { get { return Me.Duration; } }
        public string Location { get { return Me.Location; } }
        public string Number { get { return Me.Number; } }
        public string Operation { get { return Me.Operation; } }
        public int PagesPrinted { get { return Me.PagesPrinted; } }
        public string User { get { return Me.User; } }
        public string Version { get { return Me.Version; } }

        public override string ToString()
        {
            return string.Format("{0} by {1} @ {2} using {3} on {4}", Operation, User, Date, Application, Location);
        }

    }

}