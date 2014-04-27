using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Core.Framework
{
    public static class Json
    {
        public static string ToString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static object ToObject(string jsonString)
        {
            return JsonConvert.DeserializeObject(jsonString);
        }

        public static T ToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
