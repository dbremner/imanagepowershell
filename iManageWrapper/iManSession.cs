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
    public class iManSession : iManObject, IDisposable
    {
        internal new iml.IManSession Me { get { return (iml.IManSession)base.Me; } }

        public iManSession(iml.IManSession session) : base(session)
        {
        }

        public void Dispose()
        {
            if (Me.Connected) Me.Logout();
        }

        public IEnumerable<iManDatabase> Databases
        {
            get
            {
                foreach (iml.IManDatabase d in Me.Databases)
                    yield return new iManDatabase(d);
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