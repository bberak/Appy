using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public class VerifyFolderTask : ITask
    {
        string SourcePath;

        public VerifyFolderTask(string srcPath)
        {
            SourcePath = srcPath;
        }

        public void Run()
        {
            if (!Directory.Exists(SourcePath))
                Directory.CreateDirectory(SourcePath);
        }
    }
}
