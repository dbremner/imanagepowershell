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

// ReSharper disable once InconsistentNaming
    public class iManSession : IDisposable
    {
        internal readonly iml.IManSession Me;

        public iManSession(iml.IManSession session)
        {
            Me = session;
        }

        public void Dispose()
        {
            if (Me.Connected) Me.Logout();
        }

        public List<iManDatabase> Databases
        {
            get
            {
                return Me.Databases.ToList();
            }
        }

        public string ServerName
        {
            get
            {
                return Me.ServerName;
            }
        }
    }

}