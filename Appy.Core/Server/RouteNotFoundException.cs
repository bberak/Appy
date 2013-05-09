using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class RouteNotFoundException : Exception
    {
        public string Url { get; protected set; }

        public RouteNotFoundException(string url)
        {
            Url = url;
        }
    }
}
