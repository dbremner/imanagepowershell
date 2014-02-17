using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iManageWrapper;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Set, "iManSecurity")]
    public class Set_iManSecurity : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public iManDocument[] Documents { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public iManFolder[] Folders { get; set; }

        [Parameter]
        public imSecurityType? DefaultVisibility { get; set; }

        [Parameter]
        public bool? IncludeExternalUsersInDefaultSecurity { get; set; }

        [Parameter]
        public bool? Inherited { get; set; }

        protected override void ProcessRecord()
        {
            if (Folders != null)
                foreach (var item in Folders)
                {
                    bool updated = false;
                    var s = item.Security;
                    if (DefaultVisibility != null && DefaultVisibility.Value != s.DefaultVisibility)
                    {
                        s.DefaultVisibility = DefaultVisibility.Value;
                        updated = true;
                    }
                    if (IncludeExternalUsersInDefaultSecurity != null
                        && IncludeExternalUsersInDefaultSecurity.Value != s.IncludeExternalUsersInDefaultSecurity)
                    {
                        s.IncludeExternalUsersInDefaultSecurity = IncludeExternalUsersInDefaultSecurity.Value;
                        updated = true;
                    }
                    if (Inherited != null && Inherited.Value != s.Inherited)
                    {
                        s.Inherited = Inherited.Value;
                        updated = true;
                    }
                    if (updated) item.Update();
                }

            if (Documents != null)
                foreach (var item in Documents)
                {
                    bool updated = false;
                    var s = item.Security;
                    if (DefaultVisibility != null && DefaultVisibility.Value != s.DefaultVisibility)
                    {
                        s.DefaultVisibility = DefaultVisibility.Value;
                        updated = true;
                    }
                    if (IncludeExternalUsersInDefaultSecurity != null
                        && IncludeExternalUsersInDefaultSecurity.Value != s.IncludeExternalUsersInDefaultSecurity)
                    {
                        s.IncludeExternalUsersInDefaultSecurity = IncludeExternalUsersInDefaultSecurity.Value;
                        updated = true;
                    }
                    if (Inherited != null && Inherited.Value != s.Inherited)
                    {
                        s.Inherited = Inherited.Value;
                        updated = true;
                    }
                    if (updated) item.Update();
                }
        }
    }

    [Cmdlet(VerbsCommon.Add, "iManACL")]
    public class Add_iManACL : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public iManDocument[] Documents { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public iManFolder[] Folders { get; set; }

        [Parameter(ParameterSetName = "Groups", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public iManGroup[] Groups { get; set; }

        [Parameter(ParameterSetName = "Users", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public iManUser[] Users { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public imAccessRight Right { get; set; }

        protected override void ProcessRecord()
        {
            if (Folders != null)
                foreach (var item in Folders)
                {
                    if (Users != null)
                        foreach (var user in Users)
                            item.Security.AddUserACL(user, Right);
                    if (Groups != null)
                        foreach (var group in Groups)
                            item.Security.AddGroupACL(group, Right);
                    item.Update();
                }

            if (Documents != null)
                foreach (var item in Documents)
                {
                    if (Users != null)
                        foreach (var user in Users)
                            item.Security.AddUserACL(user, Right);
                    if (Groups != null)
                        foreach (var group in Groups)
                            item.Security.AddGroupACL(group, Right);
                    item.Update();
                }
        }
    }

    [Cmdlet(VerbsCommon.Set, "iManACL")]
    public class Set_iManACL : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public iManUserACL[] UserACLs { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public iManGroupACL[] GroupACLs { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public imAccessRight Right { get; set; }

        protected override void ProcessRecord()
        {
            if (UserACLs != null)
                foreach (var item in UserACLs)
                    if (item.Right != Right)
                    {
                        item.Right = Right;
                        item.Update();
                    }

            if (GroupACLs != null)
                foreach (var item in GroupACLs)
                    if (item.Right != Right)
                    {
                        item.Right = Right;
                        item.Update();
                    }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "iManACL")]
    public class Remove_iManACL : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public iManUserACL[] UserACLs { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public iManGroupACL[] GroupACLs { get; set; }

        protected override void ProcessRecord()
        {
            if (UserACLs != null)
                foreach (var item in UserACLs)
                {
                    item.Remove();
                    item.Update();
                }

            if (GroupACLs != null)
                foreach (var item in GroupACLs)
                {
                    item.Remove();
                    item.Update();
                }
        }
    }
}
