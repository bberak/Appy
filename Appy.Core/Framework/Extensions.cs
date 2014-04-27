using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Appy.Core.Framework
{
    public static partial class Extensions
    {
        public static Cookie ExpiresIn(this Cookie cookie, int minutes = 0, int hours = 0, int days = 0)
        {
            cookie.Expires = DateTime.Now.AddMinutes(minutes).AddHours(hours).AddDays(days);

            return cookie;
        }
        
        public static string Find(this Dictionary<string, string> dic, string key, string defaultValue = "")
        {
            string result = null;

            return dic.TryGetValue(key, out result) ? result : defaultValue;
        }

        public static string Find(this NameValueCollection collection, string key, string defaultValue = "")
        {
            if (collection.AllKeys.Contains(key))
                return collection[key];

            return defaultValue;
        }

        public static bool Matches<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            return source.SequenceEqual(target);
        }

        public static string F(this string source, params object[] args)
        {
            return string.Format(source, args);
        }
    }
}
