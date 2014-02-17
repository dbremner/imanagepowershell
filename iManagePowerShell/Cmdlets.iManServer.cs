using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iManageWrapper;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Get, "iManServer")]

    public class Get_iManServer : PSCmdlet
    {

        [Parameter(Position = 0, Mandatory = false)]
        public string Server { get; set; }

        [Parameter(Position = 1, Mandatory = false)]
        public string Username { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public string Password { get; set; }

        protected override void BeginProcessing()
        {
            if (Server == null)
            {
                WriteObject(iManServer.AutoConnect(), true);
            }
            else
            {
                WriteObject(new iManServer(Server, Username, Password));
            }
        }
    }


}
