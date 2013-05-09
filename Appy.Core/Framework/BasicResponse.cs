using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class BasicResponse : Response
    {
        public string Content { get; set; }

        public BasicResponse(string content = "", int statusCode = 200, string contentType = "text/html; charset=UTF-8")
            : base(statusCode, contentType)
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
