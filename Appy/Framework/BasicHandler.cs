using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public class BasicHandler
    {
        int Count;

        [Url("/Index")]
        [Url("/Default")]
        public Response Index(Request incoming)
        {
            Count++;

            var name = incoming.Form.Get("Name");
            var email = incoming.Form.Get("Email");

            var cookie = new Cookie("Name", "Value").ExpiresIn(30);

            return new ViewResponse("Index.html", Count);
        }
    }
}
