using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iManageWrapper;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Get, "iManUser")]

    public class Get_iManUser : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManDatabase[] Database { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "byUsername")]
        public string[] Username { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "byFullname")]
        public string[] Fullname { get; set; }

        protected override void ProcessRecord()
        {
            foreach (var d in Database)
            {
                if (Username != null)
                {
                    foreach (var u in Username)
                    {
                        WriteObject(d.SearchUsersByUsername(u), true);
                    }
                }

                if (Fullname != null)
                {
                    foreach (var f in Fullname)
                    {
                        WriteObject(d.SearchUsersByFullname(f), true);
                    }
                }
            }
        }

    }
}