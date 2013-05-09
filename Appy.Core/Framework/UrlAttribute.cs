using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Appy.Core
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class UrlAttribute : Attribute
    {
        public string Url { get; protected set; }

        public string Methods { get; protected set; }

        public UrlAttribute(string url, string methods = "GET, POST, PUT, UPDATE, DELETE")
        {
            Url = url;

            Methods = methods;
        }

        public bool Matches(HttpListenerRequest request)
        {
            //-- Strip everything after "?"
            string rawUrl = request.RawUrl.Contains("?") ? request.RawUrl.Substring(0, request.RawUrl.IndexOf("?")) : request.RawUrl;

            //-- Case insensitive match
            Regex expression = new Regex("(?i)" + rawUrl + "(?-i)");

            if (expression.IsMatch(Url)
                && Methods.Contains(request.HttpMethod))
                return true;

            return false;
        }
    }
}
