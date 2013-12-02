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

    public class iManDocumentHistory
    {
        internal iml.IManDocumentHistory me;
        public iManDatabase Database;

        public iManDocumentHistory(iml.IManDocumentHistory DocumentHistory, iManDatabase Database)
        {
            this.me = DocumentHistory;
            this.Database = Database;
        }

        public string Application { get { return me.Application; } }
        public string Comment { get { return me.Comment; } }
        public DateTime Date { get { return me.Date; } }
        public int Duration { get { return me.Duration; } }
        public string Location { get { return me.Location; } }
        public string Number { get { return me.Number; } }
        public string Operation { get { return me.Operation; } }
        public int PagesPrinted { get { return me.PagesPrinted; } }
        public string User { get { return me.User; } }
        public string Version { get { return me.Version; } }

    }

}