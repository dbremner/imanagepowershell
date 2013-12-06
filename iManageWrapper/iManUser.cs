using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Data.SqlClient;
using iml = IManage;

namespace iManageWrapper
{

    // ReSharper disable once InconsistentNaming
    public class iManUser : iManObjectDatabase
    {
        internal new iml.IManUser Me { get { return (iml.IManUser)base.Me; } }

        public iManUser(iml.IManUser user, iManDatabase database) : base(user,database)
        {
        }

        public string Custom1 { get { return Me.Custom1; } }
        public string Custom2 { get { return Me.Custom2; } }
        public string Custom3 { get { return Me.Custom3; } }
        public string DomainName { get { return Me.DomainName; } }
        public string Email { get { return Me.Email; } }
        public string Email2 { get { return Me.Email2; } }
        public string Email3 { get { return Me.Email3; } }
        public string Email4 { get { return Me.Email4; } }
        public string Email5 { get { return Me.Email5; } }
        public string Extension { get { return Me.Extension; } }
        public string Fax { get { return Me.Fax; } }
        public string FullName { get { return Me.FullName; } }
        public bool HasPreferredDatabase { get { return Me.HasPreferredDatabase; } }
        public bool HasPreferredFileServer { get { return Me.HasPreferredFileServer; } }
        public bool IsExternal { get { return Me.IsExternal; } }
        public string Location { get { return Me.Location; } }
        public bool LoginEnabled { get { return Me.LoginEnabled; } }
        public string Mobile { get { return Me.Mobile; } }
        public string Name { get { return Me.Name; } }
        public string Other { get { return Me.Other; } }
        public string Pager { get { return Me.Pager; } }
        public bool PasswordExpires { get { return Me.PasswordExpires; } }
        public string Phone { get { return Me.Phone; } }
        public iManDatabase PreferredDatabase { get { return new iManDatabase(Me.PreferredDatabase); } }
        public string PreferredFileServer { get { return Me.PreferredFileServer; } }

        public bool? Supervisor
        {
            get
            {
                try { return Me.Supervisor; }
                catch (COMException e)
                {
                    if (e.ErrorCode == -2147212778) return null;
                    throw;
                }
            }
        }

    }

}
