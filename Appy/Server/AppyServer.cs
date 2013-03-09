using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Appy
{
    public class AppyServer : HttpFileServer
    {
        RouteTable Router;

        public AppyServer()
        {
            LoadRoutes();
        }

        protected void LoadRoutes()
        {
            Router = new RouteTable();

            Assembly assembly = Assembly.GetExecutingAssembly();
            var methods = assembly.GetTypes()
                  .SelectMany(t => t.GetMethods())
                  .Where(m => m.GetCustomAttributes(typeof(UrlAttribute), false).Length > 0)
                  .ToArray();

            foreach (var method in methods)
            {
                Route route = new Route { Method = method };

                object[] urlAttributes = method.GetCustomAttributes(typeof(UrlAttribute), true);

                foreach (var obj in urlAttributes)
                {
                    UrlAttribute attr = obj as UrlAttribute;

                    route.Attributes.Add(attr);
                }

                Router.Add(route);
            }
        }

        protected override void OnPathNotFound(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            if (!Router.Execute(rawRequest, rawResponse))
                base.OnPathNotFound(rawRequest, rawResponse);
        }
    }
}
