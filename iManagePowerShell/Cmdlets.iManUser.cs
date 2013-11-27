using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iml = IManage;

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
                        try
                        {
                            WriteObject(d.me.SearchUsers(u, iml.imSearchAttributeType.imSearchExactMatch, true).ToList(d), true);
                        }
                        catch (System.Runtime.InteropServices.COMException e)
                        {
                            if (e.ErrorCode != -2147211972)
                                throw e;
                        }
                    }
                }

                if (Fullname != null)
                {
                    foreach (var f in Fullname)
                    {
                        WriteObject(d.me.SearchUsers(f, iml.imSearchAttributeType.imSearchFullName, true).ToList(d), true);
                    }
                }
            }
        }

    }
}