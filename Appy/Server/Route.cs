using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Appy
{
    public class Route
    {
        public List<UrlAttribute> Attributes { get; set; }

        public MethodInfo Method { get; set; }

        public Route()
        {
            Attributes = new List<UrlAttribute>();
        }
    }
}
