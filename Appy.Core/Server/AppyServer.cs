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
        Router Router;

        public AppyServer(string binding)
            : base(new string[] { binding })
        {
            Router = AppyRouter.LoadFromAssemblies(Assembly.GetEntryAssembly());
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
                Log("Client requested path ({0})... Searching for handler", rawRequest.RawUrl);

                Router.TryHandleRequest(rawRequest, rawResponse);
            }
            catch (RouteNotFoundException)
            {
                base.OnPathNotFound(rawRequest, rawResponse);
            }
        }

        protected override void OnException(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse, Exception ex)
        {
            Router.TryHandleException(rawResponse, ex);
        }

        public override void Dispose()
        {
            base.Dispose();

            Router.Dispose();
        }
    }
}
