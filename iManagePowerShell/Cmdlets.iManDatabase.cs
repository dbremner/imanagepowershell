using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iml = IManage;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Get, "iManDatabase")]
    public class Get_iManDatabase : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = false)]
        public string Database { get; set; }

        [Parameter(Position = 1, Mandatory = false)]
        public string Server { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public string Username { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public string Password { get; set; }

        protected override void BeginProcessing()
        {
            List<iManServer> servers;
            if (Server == null)
            {
                servers = iManServer.AutoConnect();
            }
            else
            {
                servers = new List<iManServer>{new iManServer(Server, Username, Password)};
            }


            if (Database == null)
            {
                servers.ForEach(server => server.Sessions.ForEach(session => WriteObject(session.Databases, true)));
            }
            else
            {
                servers.ForEach(server => server.Sessions.ForEach(session => WriteObject(session.Databases.Where(d => string.Equals(d.Name, Database, StringComparison.OrdinalIgnoreCase)), true)));
            }
            
        }
    }

}