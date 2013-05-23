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
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

            string[] assemblies = Directory.GetFiles(Path.Combine(ProjectPath, "Libs"));

            CompilerParameters parameters = new CompilerParameters(assemblies, "Out.exe");
            parameters.GenerateExecutable = true;
            parameters.ReferencedAssemblies.Add("System.Linq.dll");
            parameters.ReferencedAssemblies.Add("System.Collections.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Net.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.dll");

            string[] files = Directory.GetFiles(Path.Combine(ProjectPath, "Code"));

            CompilerResults results = codeProvider.CompileAssemblyFromFile(parameters, files);

            if (results.Errors.Count > 0)
                throw new Exception(results.Errors[0].ErrorText);  
        }
    }
}
