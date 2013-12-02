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

    public class iManServer : IDisposable
    {
        internal iml.IManDMS me;

        private static Dictionary<string, iml.IManDMS> ServerSingletons = new Dictionary<string, iml.IManDMS>();

        public iManServer(string Server, string Username = null, string Password = null)
        {
            iml.IManDMS SingletonServer;
            ServerSingletons.TryGetValue(Server, out SingletonServer);
            if (SingletonServer == null)
            {
                me = new iml.ManDMS();
                ServerSingletons.Add(Server, me);
                iml.IManSession s = me.Sessions.Add(Server);
                if (Username == null)
                {
                    s.TrustedLogin();
                }
                else
                {
                    s.Login(Username, Password);
                }
            }
            else
            {
                me = SingletonServer;
            }
        }

        public void Dispose()
        {
            foreach (iml.IManSession s in me.Sessions)
            {
                if (s.Connected)
                {
                    ServerSingletons.Remove(s.ServerName);
                    s.Logout();
                }
            }
            me.Close();
        }

        public static List<iManServer> AutoConnect()
        {
            List<iManServer> result = new List<iManServer>();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Interwoven\WorkSite\8.0\Common\Login\RegisteredServers");
            foreach (var s in rk.GetSubKeyNames().Select(s => rk.OpenSubKey(s)))
            {
                string ServerName = s.GetValue("ServerName").ToString();
                if (s.GetValue("TrustedLogin").ToString() == "Y")
                {
                    result.Add(new iManServer(ServerName));
                }
                else
                {
                    string username = s.GetValue("UserId").ToString();
                    string password = s.GetValue("Password").ToString();
                    result.Add(new iManServer(ServerName, username, password));
                }
            }
            return result;
        }

        public List<iManSession> Sessions
        {
            get { return me.Sessions.ToList(); }
        }

    }

}