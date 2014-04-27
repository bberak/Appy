using Appy.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Bootstrap
{
    public class UnzipTask : ITask
    {
        string Source;

        string Destination;

        public UnzipTask(string source, string desination)
        {
            Source = source;

            Destination = desination;
        }

        public void Run()
        {
            ZipFile.ExtractToDirectory(Source, Destination);
        }
    }
}
