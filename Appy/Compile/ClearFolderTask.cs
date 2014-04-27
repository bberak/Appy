using Appy.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Compile
{
    public class ClearFolderTask : ITask
    {
        string FolderPath;

        public ClearFolderTask(string folderPath)
        {
            FolderPath = folderPath;
        }

        public void Run()
        {
            foreach (string subfolder in Directory.GetDirectories(FolderPath))
            {
                Directory.Delete(subfolder, true);
            }

            foreach (string file in Directory.GetFiles(FolderPath))
            {
                File.Delete(file);
            }
        }
    }
}
