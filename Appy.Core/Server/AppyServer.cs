using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Appy.Core
{
    public class AppyServer : HttpFileServer
    {
        UrlRouter UrlRouter;
        ExceptionRouter ExceptionRouter;

        public AppyServer(string prefix)
            :base(new string[] { prefix })
        {
            UrlRouter = new UrlRouter();
            UrlRouter.LoadRoutesFrom(Assembly.GetEntryAssembly());

            ExceptionRouter = new ExceptionRouter();
            ExceptionRouter.LoadRoutesFrom(Assembly.GetEntryAssembly());
        }

        public static AppyServer FromUrl(string url)
        {
            Regex prefixRegex = new Regex("(http://.+/).+");

            var match = prefixRegex.Match(url);

            if (match.Success)
            {
                var group = match.Groups[1];
                string prefix = group.Value;
                return new AppyServer(prefix);
            }
            else
                throw new Exception("Url must be in the format: http://localhost:{PORT}/{PAGE} eg http://localhost:80/index");
        }

        protected override void OnPathNotFound(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            try
            {
                UrlRouter.TryHandleRequest(rawRequest, rawResponse);

                Log("Client requested path ({0})... Handler found", rawRequest.RawUrl);
            }
            catch (RouteNotFoundException)
            {
                base.OnPathNotFound(rawRequest, rawResponse);
            }
        }

        protected override void OnException(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse, Exception ex)
        {
            ExceptionRouter.TryHandleException(rawResponse, ex);
        }
    }
}
