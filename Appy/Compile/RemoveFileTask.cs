using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public class RemoveFileTask : ITask
    {
        string Path;

        public RemoveFileTask(string fileToDelete)
        {
            Path = fileToDelete;
        }

        public void Run()
        {
            File.Delete(Path);
        }
    }
}
