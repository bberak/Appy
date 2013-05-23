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
        Settings Settings;

        public BootstrapTask(Settings settings)
        {
            Settings = settings;
        }

        public BootstrapTask(IUserInterface ui)
        {
            Settings = new Settings();

            string projectName = ui.Ask("What is the name of your new project? ");

            string partialProjectPath = ui.Ask("Where should your new app be stored (full path)? ");

            string projectPath = Dirs.CleanAndCombine(partialProjectPath, projectName);

            Settings.Add("ProjectName", projectName)
                .Add("ProjectPath", projectPath);
        }

        protected override void BeforeRun()
        {
            string projectPath = Settings["ProjectPath"];

            Add(new CreatePathTask(projectPath));

            Add(new UnzipTask(Files.FindFirst("Resources/Libs.zip"), projectPath));

            Add(new UnzipTask(Files.FindFirst("Resources/Site.zip"), projectPath));

            Add(new UnzipTask(Files.FindFirst("Resources/Other.zip"), projectPath));

            string codeFolderPath = Dirs.Combine(projectPath, "Code");

            Add(new CreatePathTask(codeFolderPath));

            string appNamespace = Dirs.GetCleanPath(Settings["ProjectName"]);

            Add(new GenerateCodeTask(appNamespace, codeFolderPath));

            Add(new CreatePathTask(Dirs.Combine(projectPath, "Builds")));
        }
    }
}
