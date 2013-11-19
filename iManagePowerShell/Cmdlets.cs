using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iml = IManage;

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

    [Cmdlet(VerbsCommon.Get, "iManWorkspace")]
    public class Get_iManWorkspace : PSCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManDatabase[] Database { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Owner { get; set; }

        [Parameter]
        public string Client { get; set; }

        [Parameter]
        public string Matter { get; set; }

        protected override void ProcessRecord()
        {
            foreach (var d in Database)
            {
                iml.IManWorkspaceSearchParameters wssp = d.me.Session.DMS.CreateWorkspaceSearchParameters();
                if (Description != null) { wssp.Add(iml.imFolderAttributeID.imFolderDescription, Description); }
                if (Name != null) { wssp.Add(iml.imFolderAttributeID.imFolderName, Name); }
                if (Owner != null) { wssp.Add(iml.imFolderAttributeID.imFolderOwner, Owner); }

                iml.IManProfileSearchParameters psp = d.me.Session.DMS.CreateProfileSearchParameters();
                if (Client != null) { psp.Add(d._ClientCustomField, Client); }
                if (Matter != null) { psp.Add(d._MatterCustomField, Matter); }

                WriteObject(d.SearchWorkspaces(wssp, psp));
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "iManDocument")]
    public class Get_iManDocument : PSCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FromDatabase")]
        [ValidateNotNullOrEmpty]
        public iManDatabase[] Database { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FromWorkspace")]
        [ValidateNotNullOrEmpty]
        public iManWorkspace[] Workspace { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Number { get; set; }

        [Parameter]
        public string Version { get; set; }

        [Parameter]
        public string Author { get; set; }

        [Parameter]
        public string CreatedBy { get; set; }

        [Parameter]
        public string Client { get; set; }

        [Parameter]
        public string Matter { get; set; }

        [Parameter]
        public string Fulltext { get; set; }

        protected override void ProcessRecord()
        {

            if (Workspace != null)
            {
                foreach (var w in Workspace)
                {
                    iml.IManProfileSearchParameters psp = w.Database.me.Session.DMS.CreateProfileSearchParameters();
                    // still have to figure out how to limit to a workspace
                    if (Name != null) { psp.Add(iml.imProfileAttributeID.imProfileName, Name); }
                    if (Number != null) { psp.Add(iml.imProfileAttributeID.imProfileDocNum, Number); }
                    if (Version != null) { psp.Add(iml.imProfileAttributeID.imProfileVersion, Version); }
                    if (Author != null) { psp.Add(iml.imProfileAttributeID.imProfileAuthor, Author); }
                    if (CreatedBy != null) { psp.Add(iml.imProfileAttributeID.imProfileOperator, CreatedBy); }
                    if (Client != null) { psp.Add(w.Database._ClientCustomField, Client); }
                    if (Matter != null) { psp.Add(w.Database._MatterCustomField, Matter); }
                    if (Fulltext != null) { psp.AddFullTextSearch(Fulltext, iml.imFullTextSearchLocation.imFullTextAnywhere); }

                    WriteObject(w.me.Database.SearchDocuments(psp, true).ToDocumentList(w.Database), true);
                }
            }

            if (Database != null)
            {
                foreach (var d in Database)
                {
                    iml.IManProfileSearchParameters psp = d.me.Session.DMS.CreateProfileSearchParameters();
                    if (Name != null) { psp.Add(iml.imProfileAttributeID.imProfileName, Name); }
                    if (Number != null) { psp.Add(iml.imProfileAttributeID.imProfileDocNum, Number); }
                    if (Version != null) { psp.Add(iml.imProfileAttributeID.imProfileVersion, Version); }
                    if (Author != null) { psp.Add(iml.imProfileAttributeID.imProfileAuthor, Author); }
                    if (CreatedBy != null) { psp.Add(iml.imProfileAttributeID.imProfileOperator, CreatedBy); }
                    if (Client != null) { psp.Add(d._ClientCustomField, Client); }
                    if (Matter != null) { psp.Add(d._MatterCustomField, Matter); }
                    if (Fulltext != null) { psp.AddFullTextSearch(Fulltext, iml.imFullTextSearchLocation.imFullTextAnywhere); }

                    WriteObject(d.me.SearchDocuments(psp, true).ToDocumentList(d), true);
                }
            }
            
        }
    }

    [Cmdlet(VerbsData.Export, "iManDocument")]
    public class Export_iManDocument : PSCmdlet
    {

        [Parameter]
        public string DestinationPath { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
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

    [Cmdlet(VerbsData.Export, "iManFolder")]
    public class Export_iManFolder : PSCmdlet
    {
        [Parameter(ParameterSetName = "iManFolder", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManFolder[] Folder { get; set; }

        [Parameter(ParameterSetName = "iManWorkspace", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManWorkspace[] Workspace { get; set; }

        [Parameter]
        public string DestinationPath { get; set; }

        protected override void ProcessRecord()
        {
            if (Folder == null) Folder = Workspace.Select(s => new iManFolder(s.me, s.Database)).ToArray();
            string basepath = (DestinationPath == null) ? this.SessionState.Path.CurrentFileSystemLocation.Path : System.IO.Path.GetFullPath(DestinationPath);
            foreach (iManFolder f in Folder)
                DoExport(f, basepath);
        }

        private void DoExport(iManFolder Folder, string Destination)
        {
            string basepath = System.IO.Path.Combine(Destination, Folder.Name.Replace(System.IO.Path.GetInvalidFileNameChars(), "_"));
            System.IO.Directory.CreateDirectory(basepath);
            foreach (iManDocument d in Folder.Documents)
                d.GetCopy(System.IO.Path.Combine(basepath, String.Format("{0}_{1}.{2}", d.Number, d.Version, d.Extension)));
            foreach (iManFolder f in Folder.Folders)
                DoExport(f, basepath);
        }

    }


}
