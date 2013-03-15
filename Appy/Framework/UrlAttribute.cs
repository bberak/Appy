using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

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

        public bool Matches(HttpListenerRequest request)
        {
            //-- Case insensitive match
            Regex expression = new Regex("(?i)" + Url + "(?-i)");

            if (expression.IsMatch(request.RawUrl)
                && Methods.Contains(request.HttpMethod))
                return true;

            return false;
        }
    }
}
