using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class BasicResponse : Response
    {
        public string Content { get; set; }

        public BasicResponse(string content = "", int status = 200)
            : base(status, "text/html; charset=UTF-8")
        {
            Content = content;
        }

        public BasicResponse(StringBuilder sb, int status = 200)
            : this(sb.ToString(), status)
        {
        }

        public override byte[] ToBytes()
        {
            return Content.ToBytes();
        }
    }
}
