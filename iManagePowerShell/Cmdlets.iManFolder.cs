using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Management.Automation;
using iManageWrapper;

namespace iManagePowerShell
{

    [Cmdlet(VerbsCommon.New, "iManFolder")]
// ReSharper disable once InconsistentNaming
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
// ReSharper disable once InconsistentNaming
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
// ReSharper disable once InconsistentNaming
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
            var basepath = (DestinationPath != null) ? Path.GetFullPath(DestinationPath) : SessionState.Path.CurrentFileSystemLocation.Path;

            DoExport(Folder, basepath);
        }

        private static void DoExport(IEnumerable<iManFolder> folders, string destination)
        {
            foreach (var folder in folders)
            {
                var basepath = Path.Combine(destination, folder.Name.Replace(Path.GetInvalidFileNameChars(), "_"));
                Directory.CreateDirectory(basepath);
                foreach (var d in folder.Documents)
                    d.GetCopy(Path.Combine(basepath, String.Format("{0}_{1}.{2}", d.Number, d.Version, d.Extension)));
                    DoExport(folder.Folders, basepath);
            }
        }

    }

    [Cmdlet(VerbsCommon.Add, "ToiManFolder")]
// ReSharper disable once InconsistentNaming
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