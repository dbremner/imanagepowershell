using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using Microsoft.Win32;
using iml = IManage;

namespace iManageWrapper
{

// ReSharper disable once InconsistentNaming
    public class iManServer : IDisposable
    {
        internal readonly iml.IManDMS Me;

        private static readonly Dictionary<string, iml.IManDMS> ServerSingletons = new Dictionary<string, iml.IManDMS>();

        public iManServer(string server, string username = null, string password = null)
        {
            iml.IManDMS singletonServer;
            ServerSingletons.TryGetValue(server, out singletonServer);
            if (singletonServer == null)
            {
                Me = new iml.ManDMS();
                ServerSingletons.Add(server, Me);
                var s = Me.Sessions.Add(server);
                if (username == null)
                {
                    s.TrustedLogin();
                }
                else
                {
                    s.Login(username, password);
                }
            }
            else
            {
                Me = singletonServer;
            }
        }

        public void Dispose()
        {
            foreach (iml.IManSession s in Me.Sessions)
            {
                if (s.Connected)
                {
                    ServerSingletons.Remove(s.ServerName);
                    s.Logout();
                }
            }
            Me.Close();
        }

        public static List<iManServer> AutoConnect()
        {
            var result = new List<iManServer>();
            var rk = Registry.CurrentUser.OpenSubKey(@"Software\Interwoven\WorkSite\8.0\Common\Login\RegisteredServers");

            if (rk == null) throw new ApplicationException("No iManage Configuration found in registry.");

            foreach (var s in rk.GetSubKeyNames().Select(rk.OpenSubKey))
            {
                var serverName = s.GetValue("ServerName").ToString();
                if (s.GetValue("TrustedLogin").ToString() == "Y")
                {
                    result.Add(new iManServer(serverName));
                }
                else
                {
                    var username = s.GetValue("UserId").ToString();
                    var password = s.GetValue("Password").ToString();
                    result.Add(new iManServer(serverName, username, password));
                }
            }
            return result;
        }

        public List<iManSession> Sessions
        {
            get { return Me.Sessions.ToList(); }
        }

    }

}