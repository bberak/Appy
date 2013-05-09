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
        {
            Content = ToJson(model);
            ContentType = "application/json";
        }

        protected virtual string ToJson(object model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
