﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iManageWrapper;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Get, "iManDatabase")]
    public class Get_iManDatabase : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Server")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "ServerAndDatabase")]
        public string Database { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "ServerAndDatabase")]
        [Parameter(ParameterSetName = "Database")]
        public string Server { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Server")]
        [Parameter(Mandatory = false, ParameterSetName = "ServerAndDatabase")]
        public string Username { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Server")]
        [Parameter(Mandatory = false, ParameterSetName = "ServerAndDatabase")]
        public string Password { get; set; }

        protected override void BeginProcessing()
        {
            IEnumerable<iManServer> servers;
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (Server == null)
            {
                servers = iManServer.AutoConnect();
            }
            else
            {
                servers = new List<iManServer> { new iManServer(Server, Username, Password) };
            }


            if (Database == null)
            {
                foreach (var session in servers.SelectMany(server => server.Sessions))
                    WriteObject(session.Databases, true);
            }
            else
            {
                foreach (var database in servers.SelectMany(server => server.Sessions)
                    .SelectMany(session => session.Databases)
                    .Where(d => string.Equals(d.Name, Database, StringComparison.OrdinalIgnoreCase)))
                {
                    WriteObject(database);
                }
            }

        }
    }

}