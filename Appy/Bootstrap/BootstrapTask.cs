using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Appy.Core;

namespace Appy
{
    public class BootstrapTask : ComponentTask
    {
        public string ProjectName { get; protected set; }

        public string ProjectPath { get; protected set; }

        public BootstrapTask(IUserInterface ui)
        {
            ProjectName = ui.Ask("What is the name of your new project? ");

            string partialProjectPath = ui.Ask("Where should your new app be stored (full path)? ");

            ProjectPath = Dirs.CleanAndCombine(partialProjectPath, ProjectName);
        }

        protected override void BeforeRun()
        {
            Add(new CreatePathTask(ProjectPath));

            Add(new UnzipTask(Files.FindFirst("Resources/Libs.zip"), ProjectPath));

            Add(new UnzipTask(Files.FindFirst("Resources/Site.zip"), ProjectPath));

            Add(new UnzipTask(Files.FindFirst("Resources/Other.zip"), ProjectPath));

            string codeFolderPath = Dirs.Combine(ProjectPath, "Code");

            Add(new CreatePathTask(codeFolderPath));

            string appNamespace = Dirs.GetCleanPath(ProjectName);

            Add(new GenerateCodeTask(appNamespace, codeFolderPath));

            Add(new CreatePathTask(Dirs.Combine(ProjectPath, "Builds")));
        }
    }
}
