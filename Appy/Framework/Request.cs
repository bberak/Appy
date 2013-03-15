using HttpMultipartParser;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public class Request
    {
        public string[] AcceptTypes { get; protected set; }

        public Encoding ContentEncoding { get; protected set; }

        public long ContentLength { get; protected set; }

        public string ContentType { get; protected set; }

        public CookieCollection Cookies { get; protected set; }

        public NameValueCollection Headers { get; protected set; }

        public string HttpMethod { get; protected set; }

        public string RawUrl { get; protected set; }

        public string UserAgent { get; set; }

        public NameValueCollection QueryString { get; protected set; }

        public HttpListenerRequest LowLevelRequest { get; protected set; }

        public Dictionary<string, string> Form { get; protected set; }

        public List<FilePart> Files { get; protected set; }

        public Request(HttpListenerRequest raw)
        {
            AcceptTypes = raw.AcceptTypes;
            ContentEncoding = raw.ContentEncoding;
            ContentLength = raw.ContentLength64;
            ContentType = raw.ContentType;
            Cookies = raw.Cookies;
            Headers = raw.Headers;
            RawUrl = raw.RawUrl;
            UserAgent = raw.UserAgent;
            QueryString = raw.QueryString;
            LowLevelRequest = raw;

            ParsePostData(raw);
        }

        void ParsePostData(HttpListenerRequest incoming)
        {
            Form = new Dictionary<string,string>();

            Files = new List<FilePart>();

            if (incoming.ContentLength64 < 1)
                return;

            Stream inputStream = incoming.InputStream;

            MultipartFormDataParser parser = new MultipartFormDataParser(inputStream);

            foreach (var parameterName in parser.Parameters.Keys)
            {
                Form.Add(parameterName, parser.Parameters[parameterName].Data);
            }

            Files = parser.Files;
        }
    }
}
