using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Appy.Core;

namespace Appy
{
    public class BootstrapTask : CompositeTask
    {
        public string ProjectName { get; protected set; }

        public string ProjectPath { get; protected set; }

        public BootstrapTask(IUserInterface ui)
        {
            ProjectName = ui.Ask("What is the name of your new project?");

            string partialProjectPath = ui.Ask("Where should your new app be stored?");

            ProjectPath = Dirs.CleanAndCombine(partialProjectPath, ProjectName);
        }

        protected override void BeforeRun()
        {
            Add(new CreateFolderTask(ProjectPath));

            Add(new CreateFolderTask(GetBuildPath()));

            Add(new UnzipTask(FindFile("Resources/Libs.zip"), ProjectPath));

            Add(new UnzipTask(FindFile("Resources/Site.zip"), ProjectPath));

            Add(new UnzipTask(FindFile("Resources/Other.zip"), ProjectPath));

            Add(new UnzipTask(FindFile("Resources/Config.zip"), ProjectPath));

            Add(new CreateFolderTask(GetCodePath()));

            Add(new GenerateCodeTask(GetAppNamespace(), GetCodePath())); 
        }

        string GetBuildPath()
        {
            return Dirs.Combine(ProjectPath, "Build");
        }

        string FindFile(string criteria)
        {
            return Files.FindFirst(criteria);
        }

        string GetCodePath()
        {
            return Dirs.Combine(ProjectPath, "Code"); ;
        }

        string GetAppNamespace()
        {
            return Dirs.GetCleanPath(ProjectName);
        }
    }
}
