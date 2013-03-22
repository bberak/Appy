
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{    
    public abstract class Response
    {
        public int Status { get; protected set; }

        public string ContentType { get; protected set; }

        public CookieCollection Cookies { get; protected set; }

        public WebHeaderCollection Headers { get; protected set; }

        public abstract byte[] ToBytes();

        public Response(int status = 200, string contentType = "")
        {
            Status = status;

            ContentType = contentType;

            Cookies = new CookieCollection();

            Headers = new WebHeaderCollection();
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
