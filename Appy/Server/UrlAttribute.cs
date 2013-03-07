using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class UrlAttribute : Attribute
    {
        public readonly string Url;

        public readonly string Methods;

        public UrlAttribute(string url, string methods = "GET, POST, PUT, UPDATE, DELETE")
        {
            Url = url;

            Methods = methods;
        }
    }
}
