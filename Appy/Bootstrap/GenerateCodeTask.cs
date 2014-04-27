using Appy.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Bootstrap
{
    public class GenerateCodeTask : CompositeTask
    {
        string AppName;
        string AppNamespace;
        string CodeFolderPath;

        public GenerateCodeTask(string appName, string appNamespace, string codeFolderPath)
        {
            AppName = appName;
            AppNamespace = appNamespace;
            CodeFolderPath = codeFolderPath;
        }

        public override void Run()
        {
            base.Run();

            ExtractStartTemplate();

            ExtractModuleTemplates();

            ExtractServiceTemplates();
        }

        void ExtractStartTemplate()
        {
            StartTemplate template = new StartTemplate();
            template.AppName = AppName;
            template.AppNamespace = AppNamespace;

            var output = template.TransformText();

            File.WriteAllText(Path.Combine(CodeFolderPath, "Start.cs"), output);
        }

        void ExtractModuleTemplates()
        {
            var template = new ExampleModuleTemplate();
            template.AppNamespace = AppNamespace;

            var output = template.TransformText();

            File.WriteAllText(Path.Combine(CodeFolderPath, "Modules", "ExampleModule.cs"), output);
        }

        void ExtractServiceTemplates()
        {
            var interfaceTemplate = new ISystemMonitorTemplate();
            var concreteTemplate = new WindowsSystemMonitorTemplate();

            interfaceTemplate.AppNamespace = AppNamespace;
            concreteTemplate.AppNamespace = AppNamespace;

            var output = interfaceTemplate.TransformText();
            var output2 = concreteTemplate.TransformText();

            File.WriteAllText(Path.Combine(CodeFolderPath, "Services", "ISystemMonitor.cs"), output);
            File.WriteAllText(Path.Combine(CodeFolderPath, "Services", "WindowsSystemMonitor.cs"), output2);
        }

        protected override void BeforeRun()
        {
            Add(new CreateFolderTask(Path.Combine(CodeFolderPath, "Modules")));
            Add(new CreateFolderTask(Path.Combine(CodeFolderPath, "Services")));
        }
    }
}
