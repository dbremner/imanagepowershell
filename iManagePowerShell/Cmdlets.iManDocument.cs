using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Data.SqlClient;
using iManageWrapper;

namespace iManagePowerShell
{
    [Cmdlet(VerbsCommon.Get, "iManDocument")]
    public class Get_iManDocument : PSCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FromDatabase")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FromDatabaseSQL")]
        [ValidateNotNullOrEmpty]
        public iManDatabase[] Database { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FromWorkspace")]
        [ValidateNotNullOrEmpty]
        public iManWorkspace[] Workspace { get; set; }

        [Parameter(ParameterSetName = "FromDatabaseSQL")]
        [ValidateNotNullOrEmpty]
        public string[] SqlQuery { get; set; }

        [Parameter(ParameterSetName = "FromDatabaseSQL")]
        public string DocNumColumnName { get; set; }

        [Parameter(ParameterSetName = "FromDatabaseSQL")]
        public int? DocNumColumnNumber { get; set; }

        [Parameter(ParameterSetName = "FromDatabaseSQL")]
        public string VersionColumnName { get; set; }

        [Parameter(ParameterSetName = "FromDatabaseSQL")]
        public int? VersionColumnNumber { get; set; }

        [Parameter(ParameterSetName = "FromDatabase")]
        [Parameter(ParameterSetName = "FromWorkspace")]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = "FromDatabase")]
        [Parameter(Position = 0, ParameterSetName = "FromWorkspace")]
        public string Number { get; set; }

        [Parameter(Position = 1, ParameterSetName = "FromDatabase")]
        [Parameter(Position = 1, ParameterSetName = "FromWorkspace")]
        public string Version { get; set; }

        [Parameter(ParameterSetName = "FromDatabase")]
        [Parameter(ParameterSetName = "FromWorkspace")]
        public string Author { get; set; }

        [Parameter(ParameterSetName = "FromDatabase")]
        [Parameter(ParameterSetName = "FromWorkspace")]
        public string CreatedBy { get; set; }

        [Parameter(ParameterSetName = "FromDatabase")]
        [Parameter(ParameterSetName = "FromWorkspace")]
        public string Client { get; set; }

        [Parameter(ParameterSetName = "FromDatabase")]
        [Parameter(ParameterSetName = "FromWorkspace")]
        public string Matter { get; set; }

        [Parameter(ParameterSetName = "FromDatabase")]
        [Parameter(ParameterSetName = "FromWorkspace")]
        public string Fulltext { get; set; }

        protected override void ProcessRecord()
        {

            switch (this.ParameterSetName)
            {
                case "FromWorkspace":
                    foreach (var w in Workspace)
                    {
                        WriteObject(w.SearchDocuments(Name, Number, Version, Author, CreatedBy, Client, Matter, Fulltext), true);
                    }
                    break;

                case "FromDatabase":
                    foreach (var d in Database)
                    {
                        WriteObject(d.SearchDocuments( Name,  Number,  Version,  Author,  CreatedBy,  Client,  Matter,  Fulltext), true);
                    }
                    break;

                case "FromDatabaseSQL":

                    if (DocNumColumnName != null && DocNumColumnNumber != null)
                        throw new ApplicationException("DocNumColumnName and DocNumColumnNumber can not both be specified at the same time.");

                    if (VersionColumnName != null && VersionColumnNumber != null)
                        throw new ApplicationException("VersionColumnName and VersionColumnNumber can not both be specified at the same time.");

                    foreach (var d in Database)
                    {
                        if (d.SqlEnabled)
                        {
                            foreach (var s in SqlQuery)
                            {
                                SqlDataReader r = d.ExecuteSql(s);
                                try
                                {
                                    DocNumColumnName = DocNumColumnName ?? "docnum";
                                    int DocNumColumnOrdinal = DocNumColumnNumber ?? r.GetOrdinal(DocNumColumnName);

                                    VersionColumnName = VersionColumnName ?? "Version";
                                    int VersionColumnOrdinal = VersionColumnNumber ?? r.GetOrdinal(VersionColumnName);

                                    // one row must be read to be able to know the data types of the columns
                                    if (r.Read())
                                    {
                                        // performance optimization for when docnum and version are of the type native to the iManage database
                                        if (r[DocNumColumnOrdinal].GetType() == typeof(System.Double) && r[VersionColumnOrdinal].GetType() == typeof(System.Int32))
                                            do
                                            {
                                                WriteObject(d.GetDocument(Convert.ToInt32((double)r[DocNumColumnOrdinal]), (int)r[VersionColumnOrdinal]));
                                            }
                                            while (r.Read());
                                        else
                                            do
                                            {
                                                try
                                                {
                                                    WriteObject(d.GetDocument(Int32.Parse(r[DocNumColumnOrdinal].ToString()), Int32.Parse(r[VersionColumnOrdinal].ToString())));
                                                }
                                                catch (FormatException e)
                                                {
                                                    WriteWarning(string.Format("Could not parse document number {0} or version number {1}. Error was \"{2}\".", r[DocNumColumnOrdinal].ToString(), r[VersionColumnOrdinal].ToString(), e.Message));
                                                }
                                            }
                                            while (r.Read());
                                    }
                                    r.Close();
                                }
                                finally
                                {
                                    if (!r.IsClosed) r.Close();
                                }
                            }
                        }
                        else
                        {
                            WriteWarning(String.Format("Database {0} on server {1} does not have a SQL Configuration.", d.Name, d.ServerName));
                        }
                    }
                    break;
            }

        }
    }

    [Cmdlet(VerbsData.Export, "iManDocument")]
    public class Export_iManDocument : PSCmdlet
    {

        [Parameter(Position = 0)]
        public string DestinationPath { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManDocument[] Document { get; set; }

        protected override void ProcessRecord()
        {
            foreach (var d in Document)
            {
                string filename = string.Format("{0}_{1}.{2}", d.Number, d.Version, d.Extension);
                if (DestinationPath == null)
                    d.GetCopy(System.IO.Path.Combine(this.SessionState.Path.CurrentFileSystemLocation.Path, filename));
                else
                    d.GetCopy(System.IO.Path.Combine(System.IO.Path.GetFullPath(DestinationPath), filename));
            }
        }

    }

}