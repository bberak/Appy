using Appy.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Bootstrap
{
    public class CopyFileTask : ITask
    {
        string Source;

        string Destination;

        public CopyFileTask(string source, string destination)
        {
            Source = source;

            Destination = destination;
        }

        public void Run()
        {
            File.Copy(Source, Destination, true);
        }
    }
}
