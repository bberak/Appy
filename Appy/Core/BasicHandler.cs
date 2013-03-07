using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class BasicHandler
    {
        private int Count;

        [Url("/index")]
        [Url("/default")]
        public string Index()
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

            return sb.ToString();
        }
    }
}
