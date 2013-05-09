using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy.Core
{
    public class Request
    {
        public string[] AcceptTypes { get; set; }

        public Encoding ContentEncoding { get; set; }

        public long ContentLength { get; set; }

        public string ContentType { get; set; }

        public CookieCollection Cookies { get; set; }

        public NameValueCollection Headers { get; set; }

        public string HttpMethod { get; set; }

        public string RawUrl { get; set; }

        public string UserAgent { get; set; }

        public NameValueCollection QueryString { get; set; }

        public HttpListenerRequest LowLevelRequest { get; set; }

        public Dictionary<string, string> Form { get; set; }

        public List<HttpFile> Files { get; set; }
    }
}
