using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appy.Core;

namespace Appy
{
    public class AppSettings
    {
        public string AppFolder { get; private set; }

        public AppSettings(string appPath)
        {
            AppFolder = appPath;
        }

        public string AppName 
        { 
            get 
            { 
                return Path.GetFileName(AppFolder); 
            } 
        }

        public string AppNamespace
        {
            get
            {
                var appNamespace = Dirs.GetCleanPath(AppName, "_")
                    .Replace(" ", "_");

                return appNamespace;
            }
        }

        public string CodeFolder
        {
            get
            {
                return GetAppFolder("Code");
            }
        }

        public string BuildFolder
        {
            get
            {
                return GetAppFolder("Build");
            }
        }

        public string LibsFolder
        {
            get
            {
                return GetAppFolder("Libs");
            }
        }

        public string OtherFolder
        {
            get
            {
                return GetAppFolder("Other");
            }
        }

        public string SiteFolder
        {
            get
            {
                return GetAppFolder("Site");
            }
        }

        public string ConfigFolder
        {
            get
            {
                return GetAppFolder("Config");
            }
        }

        public string AppConfigFile
        {
            get
            {
                return Path.Combine(ConfigFolder, "App.config");
            }
        }

        public string ExeOutputFile
        {
            get
            {
                return Path.Combine(BuildFolder, Path.GetFileName(AppFolder) + ".exe");
            }
        }

        public string AppIconFile
        {
            get
            {
                return Path.Combine(ConfigFolder, "App.ico");
            }
        }

        public string ExeIconFile
        {
            get
            {
                return Path.Combine(ConfigFolder, "Exe.ico");
            }
        }

        public string ManifestFile
        {
            get
            {
                return Path.Combine(ConfigFolder, "App.manifest");
            }
        }

        public string[] GetAssemblyFiles()
        {
            List<string> assemblies = new List<string>();

            assemblies.AddRange(Directory.GetFiles(LibsFolder, "*.dll", SearchOption.AllDirectories).ToList());
            assemblies.AddRange(Directory.GetFiles(LibsFolder, "*.exe", SearchOption.AllDirectories).ToList());

            assemblies.Add("System.Linq.dll");
            assemblies.Add("System.Collections.dll");
            assemblies.Add("System.Core.dll");
            assemblies.Add("System.Net.dll");
            assemblies.Add("System.Windows.Forms.dll");
            assemblies.Add("System.dll");

            return assemblies.ToArray();
        }

        public string[] GetSourceCodeFiles()
        {
            return Directory.GetFiles(CodeFolder, "*.cs", SearchOption.AllDirectories);
        }

        private string GetAppFolder(string subfolder)
        {
            return Path.Combine(AppFolder, subfolder);
        }
    }
}
