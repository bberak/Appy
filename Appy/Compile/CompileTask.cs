using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public class CompileTask : InteractiveTask
    {
        public CompileTask(Settings settings)
            :base(settings)
        {
        }

        public CompileTask(IUserInterface ui)
            : base(ui)
        {
        }

        protected override void BeginInteraction(IUserInterface ui)
        {
            base.BeginInteraction(ui);

            string projectRootPath = ui.Ask("What is the root path of your project?");

            Settings.Add("ProjectRootPath", projectRootPath);
        }

        public override void Run()
        {
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

            string projectRootPath = Settings["ProjectRootPath"];

            string[] assemblies = Directory.GetFiles(Path.Combine(projectRootPath, "Libs"));

            //assemblies = new string[]{ "System.Linq.dll" };



            CompilerParameters parameters = new CompilerParameters(assemblies, "Out.exe");
            parameters.GenerateExecutable = true;
            parameters.ReferencedAssemblies.Add("System.Linq.dll");
            parameters.ReferencedAssemblies.Add("System.Collections.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Net.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            
        


            string[] files = Directory.GetFiles(Path.Combine(projectRootPath, "Code"));

            CompilerResults results = codeProvider.CompileAssemblyFromFile(parameters, files);

            if (results.Errors.Count > 0)
                throw new Exception(results.Errors[0].ErrorText);
           
        }
    }
}
