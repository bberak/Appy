using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy.Core
{    
    public abstract class Response
    {
        public int StatusCode { get; set; }

        public string ContentType { get; set; }

        public CookieCollection Cookies { get; set; }

        public WebHeaderCollection Headers { get; set; }

        public abstract byte[] ToBytes();

        public Response(int statusCode = 200, string contentType = "")
        {
            StatusCode = statusCode;

            ContentType = contentType;

            Cookies = new CookieCollection();

            Headers = new WebHeaderCollection();
        }

        public Response And(Action<Response> action) 
        {
            action(this);

            return this;
        }

        public Response With(Action<Response> action)
        {
            return And(action);
        }

        public static Response operator +(Response response, Cookie cookie)
        {
            response.Cookies.Add(cookie);

            return response;
        }

        public static Response operator +(Response response, Header header)
        {
            response.Headers.Add(header.Name, header.Value);

            return response;
        }
    }
}
