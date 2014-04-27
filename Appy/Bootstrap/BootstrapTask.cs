using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Appy.Core;
using Appy.Common;
using Appy.Core.Framework;

namespace Appy.Bootstrap
{
    public class BootstrapTask : CompositeTask
    {
        public AppSettings Settings { get; protected set; }

        public BootstrapTask(IUserInterface ui)
        {
            string appName = ui.Ask("What is the name of your new app?");

            string partialAppPath = ui.Ask("Where should " + appName + " be stored?");

            string fullAppPath = Dirs.CleanAndCombine(partialAppPath, appName);

            Settings = new AppSettings(fullAppPath);
        }

        protected override void BeforeRun()
        {
            Add(new CreateFolderTask(Settings.AppFolder));

            Add(new CreateFolderTask(Settings.BuildFolder));

            Add(new UnzipTask(FindFile("Resources/Libs.zip"), Settings.AppFolder));

            Add(new UnzipTask(FindFile("Resources/Site.zip"), Settings.AppFolder));

            Add(new UnzipTask(FindFile("Resources/Other.zip"), Settings.AppFolder));

            Add(new UnzipTask(FindFile("Resources/Config.zip"), Settings.AppFolder));

            Add(new CreateFolderTask(Settings.CodeFolder));

            Add(new GenerateCodeTask(Settings.AppName, Settings.AppNamespace, Settings.CodeFolder)); 
        }

        string FindFile(string criteria)
        {
            return Files.FindFirst(criteria);
        }
    }
}
