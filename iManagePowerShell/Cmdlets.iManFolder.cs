using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iml = IManage;

namespace iManagePowerShell
{

    [Cmdlet(VerbsCommon.New, "iManFolder")]
    public class New_iManDocument : PSCmdlet
    {
        [Parameter(ParameterSetName = "iManFolder", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManFolder[] ParentFolder { get; set; }

        [Parameter(ParameterSetName = "iManWorkspace", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManWorkspace[] ParentWorkspace { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        public string Description { get; set; }

        protected override void ProcessRecord()
        {
            if (ParentFolder != null) foreach (var f in ParentFolder) { ((iml.IManDocumentFolders)f.me.SubFolders).AddNewDocumentFolderInheriting(Name, Description); }
            if (ParentWorkspace != null) foreach (var f in ParentWorkspace) { ((iml.IManDocumentFolders)f.me.SubFolders).AddNewDocumentFolderInheriting(Name, Description); }
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
                if (Client != null) { psp.Add(d.ClientCustomField, Client); }
                if (Matter != null) { psp.Add(d.MatterCustomField, Matter); }

                WriteObject(d.SearchWorkspaces(wssp, psp), true);
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

    [Cmdlet(VerbsCommon.Add, "ToiManFolder")]
    public class Add_ToiManFolder : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManDocument[] Document { get; set; }

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public iManFolder Folder { get; set; }

        [Parameter]
        public bool InheritSecurity = true;

        protected override void ProcessRecord()
        {
            iml.IManDocuments df = (iml.IManDocuments)Folder.me.Contents;
            foreach (var d in Document)
            {
                df.AddDocumentReference(d.me);
                if (InheritSecurity) { d.me.Refile(d.me.Profile, Folder.me.Security); }
            }
        }

    }



}