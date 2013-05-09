using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Appy.Core
{
    public class JsonResponse : BasicResponse
    {
        public JsonResponse(object model)
            : base(contentType: "application/json")
        {
            Content = ToJson(model);
        }

        public virtual string ToJson(object model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
