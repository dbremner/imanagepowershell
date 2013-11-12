using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iml = IManage;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Get,"iManServer")]
    public class Get_iManServer: PSCmdlet
    {

        [Parameter(Position = 0, Mandatory = false)]
        public string iManServerName { get; set; }

        protected override void BeginProcessing()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Interwoven\WorkSite\8.0\Common\Login\RegisteredServers");
            foreach (var s in rk.GetSubKeyNames().Select(s => rk.OpenSubKey(s)))
            {
                string ServerName = s.GetValue("ServerName").ToString();
                if (s.GetValue("TrustedLogin").ToString() == "Y")
                {
                    WriteObject(new iManServer(ServerName));
                }
                else
                {
                    string username = s.GetValue("UserId").ToString();
                    string password = s.GetValue("Password").ToString();
                    WriteObject(new iManServer(ServerName, username, password));
                }
            }
        }
    }


    [Cmdlet(VerbsCommon.Get,"iManDocument")]
    public class Get_iManDocument: PSCmdlet
    {

        [Parameter(Mandatory = true, ParameterSetName = "DatabaseByPipeline", ValueFromPipeline = true)]
        public string iManServer { get; set; }

        [Parameter(Position = 0, Mandatory = false, HelpMessage = "A document number in the format of xxx for all versions or xxx.v for a specific version.")]
        public string DocumentNumber { get; set; }

        protected override void BeginProcessing()
        {
 	        base.BeginProcessing();
        }
    }

}
