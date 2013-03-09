using SelfServe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Appy
{
    public static partial class Extensions
    {
        public static Cookie ExpiresIn(this Cookie cookie, int minutes = 0, int hours = 0, int days = 0)
        {
            cookie.Expires = DateTime.Now.AddMinutes(minutes).AddHours(hours).AddDays(days);

            return cookie;
        }
        
        public static string Get(this Dictionary<string, string> dic, string key, string defaultValue = "")
        {
            string result = null;

            return dic.TryGetValue(key, out result) ? result : defaultValue;
        }
    }
}
