using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iManageWrapper;

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
            if (ParentFolder != null) foreach (var f in ParentFolder) { WriteObject(f.AddNewDocumentFolderInheriting(Name, Description)); }
            if (ParentWorkspace != null) foreach (var f in ParentWorkspace) { WriteObject(f.AddNewDocumentFolderInheriting(Name, Description)); }
        }

    }

    [Cmdlet(VerbsCommon.Get, "iManWorkspace")]
    public class Get_iManWorkspace : PSCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GetAll")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "Search")]
        [ValidateNotNullOrEmpty]
        public iManDatabase[] Database { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "GetAll")]
        public SwitchParameter GetAll;

        [Parameter(ParameterSetName = "Search")]
        public string Description { get; set; }

        [Parameter(ParameterSetName = "Search")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = "Search")]
        public string Owner { get; set; }

        [Parameter(ParameterSetName = "Search")]
        public string Client { get; set; }

        [Parameter(ParameterSetName = "Search")]
        public string Matter { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "Search" && null == (Description ?? Name ?? Owner ?? Client ?? Matter))
                throw new ApplicationException(@"At least one search parameter must be specified. If you want all Workspaces then use the -GetAll switch.");
            foreach (var d in Database)
            {
                WriteObject(d.SearchWorkspaces(Description, Name, Owner, Client, Matter), true);
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

        [Parameter(Position = 0)]
        public string DestinationPath { get; set; }

        protected override void ProcessRecord()
        {
            if (Folder == null) Folder = Workspace.Select(w => (iManFolder)w).ToArray();
            string basepath = (DestinationPath != null) ? System.IO.Path.GetFullPath(DestinationPath) : this.SessionState.Path.CurrentFileSystemLocation.Path;

            var FolderCount = Folder.Count();
            for (int i = 0; i < FolderCount; i++ )
            {
                DoExport(Folder[i], basepath);
            }
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

        protected override void ProcessRecord()
        {
            foreach (var d in Document)
            {
                Folder.AddDocumentReference(d);
            }
        }

    }



}