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
        public string ProjectPath { get; protected set; }

        public CompileTask(IUserInterface ui)
        {
            ProjectPath = ui.Ask("What is the root path of your project?");
        }

        public CompileTask(string projectPath)
        {
            ProjectPath = projectPath;
        }

        protected override void BeforeRun()
        {
            Add(new ClearFolderTask(GetBuildFolder()));

            Add(new CopyFolderTask(GetLibsFolder(), GetBuildFolder()));

            Add(new CopyFolderTask(GetOtherFolder(), GetBuildFolder()));

            Add(new CopyFolderTask(GetSiteFolder(), Combine(GetBuildFolder(), "Site")));

            Add(new CopyFileTask(GetConfigFile(), GetExeOutputPath() + ".config"));
        }

        string GetBuildFolder()
        {
            return GetProjectFolder("Build");
        }

        string GetLibsFolder()
        {
            return GetProjectFolder("Libs");
        }

        string GetOtherFolder()
        {
            return GetProjectFolder("Other");
        }

        string GetSiteFolder()
        {
            return GetProjectFolder("Site");
        }

        string GetProjectFolder(string subfolderName)
        {
            return Path.Combine(ProjectPath, subfolderName);
        }

        string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        string GetConfigFile()
        {
            return Path.Combine(GetProjectFolder("Config"), "App.config");
        }

        string GetExeOutputPath()
        {
            return Path.Combine(GetBuildFolder(), Path.GetFileName(ProjectPath) + ".exe");
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

            CompilerParameters parameters = new CompilerParameters(GetAssemblyFiles(), GetExeOutputPath());
            parameters.IncludeDebugInformation = false;
            parameters.GenerateExecutable = true;
            parameters.CompilerOptions = "/platform:x86 /target:winexe /win32manifest:" + GetManifestFile();

            return codeProvider.CompileAssemblyFromFile(parameters, GetSourceFiles());
        }

        string GetManifestFile()
        {
            return Path.Combine(GetProjectFolder("Config"), "App.manifest");
        }

        string[] GetAssemblyFiles()
        {
            List<string> assemblies = Directory.GetFiles(GetLibsFolder()).ToList();
            assemblies.Add("System.Linq.dll");
            assemblies.Add("System.Collections.dll");
            assemblies.Add("System.Core.dll");
            assemblies.Add("System.Net.dll");
            assemblies.Add("System.Windows.Forms.dll");
            assemblies.Add("System.dll");

            return assemblies.ToArray();
        }

        string[] GetSourceFiles()
        {
            return Directory.GetFiles(GetProjectFolder("Code"), "*.cs", SearchOption.AllDirectories);
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
