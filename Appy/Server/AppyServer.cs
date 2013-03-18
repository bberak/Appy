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
            return assembly.FindMethodsDecoratedWithAttribute(typeof(UrlAttribute));
        }

        object[] GetUrlAttributesFromMethod(MethodInfo method)
        {
            return method.GetCustomAttributes(typeof(UrlAttribute), true);
        }

        protected override void OnPathNotFound(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            if (!Router.Execute(rawRequest, rawResponse))
                base.OnPathNotFound(rawRequest, rawResponse);
            else
                Console.WriteLine(string.Format("Client requested path ({0})... Handler found", rawRequest.RawUrl));
        }
    }
}
