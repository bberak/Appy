using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public class GenerateCodeTask : ITask
    {
        string AppNamespace;
        string CodeFolderPath;

        public GenerateCodeTask(string appNamespace, string codeFolderPath)
        {
            AppNamespace = appNamespace;
            CodeFolderPath = codeFolderPath;
        }

        public void Run()
        {
            ExampleControllerTemplate template = new ExampleControllerTemplate();
            template.AppNamespace = AppNamespace;

            string output = template.TransformText();

            File.WriteAllText(Path.Combine(CodeFolderPath, "ExampleController.cs"), output);

            StartTemplate startTemplate = new StartTemplate();
            startTemplate.AppNamespace = AppNamespace;

            string output2 = startTemplate.TransformText();

            File.WriteAllText(Path.Combine(CodeFolderPath, "Start.cs"), output2);


        }
    }
}
