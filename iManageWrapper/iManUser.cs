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

    public class iManUser
    {
        internal iml.IManUser me;
        public iManDatabase Database;

        public iManUser(iml.IManUser User, iManDatabase Database)
        {
            this.me = User;
            this.Database = Database;
        }

        public string Custom1 { get { return me.Custom1; } }
        public string Custom2 { get { return me.Custom2; } }
        public string Custom3 { get { return me.Custom3; } }
        public string DomainName { get { return me.DomainName; } }
        public string Email { get { return me.Email; } }
        public string Email2 { get { return me.Email2; } }
        public string Email3 { get { return me.Email3; } }
        public string Email4 { get { return me.Email4; } }
        public string Email5 { get { return me.Email5; } }
        public string Extension { get { return me.Extension; } }
        public string Fax { get { return me.Fax; } }
        public string FullName { get { return me.FullName; } }
        public bool HasPreferredDatabase { get { return me.HasPreferredDatabase; } }
        public bool HasPreferredFileServer { get { return me.HasPreferredFileServer; } }
        public bool IsExternal { get { return me.IsExternal; } }
        public string Location { get { return me.Location; } }
        public bool LoginEnabled { get { return me.LoginEnabled; } }
        public string Mobile { get { return me.Mobile; } }
        public string Name { get { return me.Name; } }
        public string Other { get { return me.Other; } }
        public string Pager { get { return me.Pager; } }
        public bool PasswordExpires { get { return me.PasswordExpires; } }
        public string Phone { get { return me.Phone; } }
        public iManDatabase PreferredDatabase { get { return new iManDatabase(me.PreferredDatabase); } }
        public string PreferredFileServer { get { return me.PreferredFileServer; } }
        public bool Supervisor { get { return me.Supervisor; } }

    }

}
