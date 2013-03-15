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

        void LoadRoutes()
        {
            Router = new RouteTable();

            foreach (var method in FindMethodsDecoratedWithUrlAttributes())
            {
                Route route = new Route { Method = method };

                foreach (var urlObj in GetUrlAttributesFromMethod(method))
                {
                    UrlAttribute attr = urlObj as UrlAttribute;

                    route.Attributes.Add(attr);
                }

                Router.Add(route);
            }
        }

        MethodInfo[] FindMethodsDecoratedWithUrlAttributes()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var methods = assembly.GetTypes()
                  .SelectMany(t => t.GetMethods())
                  .Where(m => m.GetCustomAttributes(typeof(UrlAttribute), false).Length > 0)
                  .ToArray();

            return methods;
        }

        object[] GetUrlAttributesFromMethod(MethodInfo method)
        {
            return method.GetCustomAttributes(typeof(UrlAttribute), true);
        }

        protected override void OnPathNotFound(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            if (!Router.Execute(rawRequest, rawResponse))
                base.OnPathNotFound(rawRequest, rawResponse);
        }
    }
}
