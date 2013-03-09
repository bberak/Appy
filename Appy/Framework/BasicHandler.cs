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

        [Url("/index")]
        [Url("/default")]
        public Response Index(Request incoming)
        {
            Count++;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<!DOCTYPE HTML>");
            sb.AppendFormat("<html>");
                sb.AppendFormat("<head></head>");
                sb.AppendFormat("<body>");
                    sb.AppendFormat("<h1>This action has been reached {0} times!</h1>", Count);
                    sb.AppendFormat("<a href=\"{0}\">Refresh</a>", "/index");
                sb.AppendFormat("</body>");
            sb.AppendFormat("</html>");

            var Name = incoming.Form.Get("Name");
            var Email = incoming.Form.Get("Email");

            var cookie = new Cookie("name", "value").ExpiresIn(30);

            return new BasicResponse(sb);
        }
    }
}
