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

    public class iManSession : IDisposable
    {
        internal iml.IManSession me;

        public iManSession(iml.IManSession Session)
        {
            me = Session;
        }

        public void Dispose()
        {
            if (me.Connected) me.Logout();
        }

        public List<iManDatabase> Databases
        {
            get
            {
                return me.Databases.ToList();
            }
        }

        public string ServerName
        {
            get
            {
                return me.ServerName;
            }
        }
    }

}