using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Appy.Core;

namespace Appy
{
    public class BootstrapTask : BaseTask
    {
        Args Args;

        public BootstrapTask(Args args)
        {
            Args = args;
        }

        public BootstrapTask(IUserInterface ui)
        {
            Args = new Args();

            string projectName = ui.Ask("What is the name of your new project? ");

            string partialProjectPath = ui.Ask("Where should your new app be stored (full path)? ");

            string projectPath = Dirs.CleanAndCombine(partialProjectPath, projectName);

            Args.Add("ProjectName", projectName)
                .Add("ProjectPath", projectPath);
        }

        protected override void LoadTasks()
        {
            string projectPath = Args["ProjectPath"];

            Tasks.Add(new CreatePathTask(projectPath));

            Tasks.Add(new UnzipTask(Files.FindFirst("Resources/Libs.zip"), projectPath));

            Tasks.Add(new UnzipTask(Files.FindFirst("Resources/Site.zip"), projectPath));

            Tasks.Add(new CreatePathTask(Dirs.Combine(projectPath, "Code")));

            Tasks.Add(new CreatePathTask(Dirs.Combine(projectPath, "Builds")));
        }
    }
}
