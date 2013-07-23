using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public class CompileTask : CompositeTask
    {
        public AppSettings Settings { get; protected set; }
        public bool DebugMode { get; protected set; }

        public CompileTask(IUserInterface ui)
            : this(ui, ui.Ask("What is the root path of your app?"))
        {     
        }

        public CompileTask(IUserInterface ui, string rootAppPath)
            : this(rootAppPath, ui.Ask("Turn on (d)ebug mode?", "d,y"))
        {
        }

        public CompileTask(string rootAppPath, bool enableDebugMode)
        {
            Settings = new AppSettings(rootAppPath);
            DebugMode = enableDebugMode;
        }

        protected override void BeforeRun()
        {
            Add(new VerifyFolderTask(Settings.BuildFolder));
            Add(new ClearFolderTask(Settings.BuildFolder));
            Add(new CopyFolderTask(Settings.LibsFolder, Settings.BuildFolder));
            Add(new RemoveFileTask(Path.Combine(Settings.BuildFolder, "GAC.txt")));
            Add(new CopyFolderTask(Settings.OtherFolder, Settings.BuildFolder));
            Add(new CopyFolderTask(Settings.SiteFolder, Path.Combine(Settings.BuildFolder, "Site")));
            Add(new CopyFileTask(Settings.AppConfigFile, Settings.ExeOutputFile + ".config"));
            Add(new CopyFileTask(Settings.AppIconFile, Path.Combine(Settings.BuildFolder, "App.ico")));
        }

        public override void Run()
        {
            base.Run();

            CompilerResults compilerResults = CompileProject();

            VerifyCompilation(compilerResults);
        }

        CompilerResults CompileProject()
        {
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

            CompilerParameters parameters = new CompilerParameters(Settings.GetAssemblyFiles(), Settings.ExeOutputFile);
            parameters.IncludeDebugInformation = DebugMode;
            parameters.GenerateExecutable = true;
            parameters.CompilerOptions = string.Format("/platform:x86 /target:{0}exe /win32manifest:\"{1}\" /win32icon:\"{2}\"", 
                DebugMode ? "" : "win",
                Settings.ManifestFile, 
                Settings.ExeIconFile);

            return codeProvider.CompileAssemblyFromFile(parameters, Settings.GetSourceCodeFiles());
        }

        void VerifyCompilation(CompilerResults compilerResults)
        {
            if (compilerResults.Errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in compilerResults.Errors)
                {
                    sb.AppendLine(string.Format("{0}---{1}---{2}", error.ErrorText, Path.GetFileName(error.FileName), error.Line));
                }

                throw new Exception(sb.ToString());
            }
        }   
    }
}
