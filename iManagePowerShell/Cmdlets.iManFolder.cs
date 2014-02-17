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
    public class New_iManFolder : PSCmdlet
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
        public iManFolder[] Folder { get; set; }

        [Parameter(Position = 0)]
        public string DestinationPath { get; set; }

        protected override void ProcessRecord()
        {
            //if (ProfiledFolder != null) Folder = ProfiledFolder.Select(w => (iManFolder)w).ToArray();
            //if (Workspace != null) Folder = Workspace.Select(w => (iManFolder)w).ToArray();
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
                    DoExport(folder.SubFolders, basepath);
            }
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

    [Cmdlet(VerbsData.Import, "iManFolder")]
    public class Import_iManFolder : PSCmdlet
    {
        [Parameter(ParameterSetName = "iManFolder", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public iManFolder[] Folders { get; set; }

        [Parameter(Position = 0)]
        public string SourcePath { get; set; }

        [Parameter] public SwitchParameter FromCurrentDirectory;

        // [Parameter] public SwitchParameter MakeMultipleCopies;

        protected override void ProcessRecord()
        {
            // parameter validation
            if (SourcePath == null && !FromCurrentDirectory)
                throw new PSArgumentException("Specify SourcePath or use -FromCurrentDirectory", SourcePath);

            if (SourcePath != null && FromCurrentDirectory)
                throw new PSArgumentException("Specify SourcePath or -FromCurrentDirectory, but not both.", SourcePath);

            string basepath = FromCurrentDirectory ? SessionState.Path.CurrentFileSystemLocation.Path : Path.GetFullPath(SourcePath);
            if (!Directory.Exists(basepath))
                throw new PSArgumentException("SourcePath does not exist.", SourcePath);

            foreach (var folder in Folders)
            {
                DoImport(basepath, folder, WriteWarning);
            }

        }

        private static void DoImport(string source, iManFolder folder, Action<string> WriteWarning)
        {
            var files = System.IO.Directory.GetFiles(source);
            if (files.Any() && folder.ObjectType == imObjectType.imTypeWorkspace)
            {
                WriteWarning(String.Format("Folder {0} is a workspace and can not contain files. Files in the directory \"{1}\" will not be imported.", folder.Name, source));
            }
            else
            {
                foreach (string filename in files)
                {
                    var fi = new System.IO.FileInfo(filename);
                    if (fi.Length <= 0) continue; // dont import zero length files

                    iManDocument newD = folder.Database.CreateDocument();
                    iManProfile newP = newD.Profile;
                    //newP.SetAttributeByID(imProfileAttributeID.imProfileAuthor, folder.Database.Session.UserID);
                    newD.Type = folder.Database.GetDocumentTypeFromPath(filename);
                    newD.Description = filename;
                    //newD.Author = folder.Database.CurrentUser;

                    newD.CheckIn(filename);
                }

                foreach (var directory in System.IO.Directory.GetDirectories(source))
                {
                    if (!folder.SubFolders.Any(f => f.Name == directory))
                    {
                        var newFolder = folder.AddNewDocumentFolderInheriting(directory, "");
                        var basepath = Path.Combine(source, directory);
                        DoImport(basepath, newFolder, WriteWarning);
                    }
                }
            }
        }

    }

}