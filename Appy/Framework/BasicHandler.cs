using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public class BasicHandler
    {
        int Count;

        [Url("/index")]
        [Url("/default")]
        public Response Index(Request incoming)
        {
            Count++;

            var name = incoming.Form.Get("Name");
            var email = incoming.Form.Get("Email");

            var cookie = new Cookie("Name", "Value").ExpiresIn(30);

            return new ViewResponse("index.html", Count);
        }

        [Url("/test")]
        public Response Test(Request incoming)
        {
            return new ViewResponse("test.html") + new Cookie("abc", "xyz") + new Header("header1", "value1");
        }

        [Url("/redirect")]
        public Response Redirect(Request incoming)
        {
            return new RedirectResponse("/test");
        }
    }
}
