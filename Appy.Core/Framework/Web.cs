using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Core
{
    public static class Web
    {
        public static string Get(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        public static string TryGet(string url, string defaultResult = "")
        {
            try
            {
                return Get(url);
            }
            catch
            {
                return defaultResult;
            }
        }

        public static byte[] GetBytes(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }
    }
}
