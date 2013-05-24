using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public class CompileTask : ComponentTask
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
        }

        public override void Run()
        {
            base.Run();

            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

            CompilerParameters parameters = new CompilerParameters(GetAssemblyFiles(), GetExeOutputPath());
            parameters.IncludeDebugInformation = false;
            parameters.GenerateExecutable = true;

            CompilerResults results = codeProvider.CompileAssemblyFromFile(parameters, GetSourceFiles());

            if (results.Errors.Count > 0)
                throw new Exception(results.Errors[0].ErrorText);  
        }

        string GetBuildFolder()
        {
            string buildFolder = Path.Combine(ProjectPath, "Build");

            return buildFolder;
        }

        string GetExeOutputPath()
        {
            string fullOutputPath = Path.Combine(GetBuildFolder(), Path.GetFileName(ProjectPath) + ".exe");

            return fullOutputPath;
        }

        string[] GetAssemblyFiles()
        {
            List<string> assemblies = Directory.GetFiles(Path.Combine(ProjectPath, "Libs")).ToList();
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
            return Directory.GetFiles(Path.Combine(ProjectPath, "Code"));
        }
    }
}
