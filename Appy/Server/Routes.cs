using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Appy
{
    public abstract class Route<T> where T : Attribute
    {
        public List<T> Attributes { get; set; }

        public MethodInfo Method { get; set; }

        public Route()
        {
            Attributes = new List<T>();
        }
    }

    public class UrlRoute : Route<UrlAttribute> { }

    public class ExceptionRoute : Route<CatchesAttribute> { }
}
