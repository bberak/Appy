using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class HttpFile
    {
        public string Name { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public string ContentDisposition { get; set; }

        public Stream Data { get; set; }
    }
}
