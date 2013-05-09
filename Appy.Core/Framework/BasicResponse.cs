using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SelfServe;

namespace Appy.Core
{
    public class BasicResponse : Response
    {
        public string Content { get; set; }

        public BasicResponse(object  obj)
            : this(obj.ToString())
        {
        }

        public BasicResponse(string content = "")
            : base(contentType: "text/html; charset=UTF-8")
        {
            Content = content;
        }

        public override byte[] ToBytes()
        {
            return Content.ToBytes();
        }
    }
}
