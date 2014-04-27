using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appy.Core;
using Appy.Common;
using Appy.Core.Framework;

namespace Appy.Compile
{
    public class CopyFolderTask : ITask
    {
        string Source;

        string Destination;

        public CopyFolderTask(string sourceFolder, string destinationFolder)
        {
            Source = sourceFolder;

            Destination = destinationFolder;
        }

        public void Run()
        {
            Dirs.Copy(Source, Destination);
        }
    }
}
