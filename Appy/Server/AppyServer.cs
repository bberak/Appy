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
        private RouteTable RouteTable;

        public AppyServer()
        {
            LoadRoutes();
        }

        protected void LoadRoutes()
        {
            RouteTable = new RouteTable();

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

                RouteTable.Add(route);
            }
        }

        protected override void OnPathNotFound(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (!RouteTable.Execute(request, response))
                base.OnPathNotFound(request, response);
        }
    }
}
