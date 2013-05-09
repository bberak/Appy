using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using SelfServe;

namespace Appy.Core
{
    public class ResponseAdapter
    {
        Response Source;

        public ResponseAdapter(Response source)
        {
            Source = source;
        }

        public static void Write(Response source, HttpListenerResponse destination)
        {
            new ResponseAdapter(source).WriteTo(destination);
        }

        public void WriteTo(HttpListenerResponse destination)
        {
            destination.Cookies = Source.Cookies;
            destination.Headers = Source.Headers;
            destination.ContentType = Source.ContentType;
            destination.StatusCode = Source.StatusCode;
            destination.WriteBytes(Source.ToBytes());
        }
    }
}
