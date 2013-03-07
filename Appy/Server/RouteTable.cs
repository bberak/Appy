using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public class RouteTable
    {
        private List<Route> Routes;

        private Dictionary<Type, object> Handlers;

        public RouteTable()
        {
            Routes = new List<Route>();

            Handlers = new Dictionary<Type, object>();
        }

        public void Add(Route newRoute)
        {
            Routes.Add(newRoute);
        }

        public bool Execute(HttpListenerRequest request, HttpListenerResponse response)
        {
            Route route = Routes.Find(x => x.Attributes.Count(y => Matches(y, request)) > 0);

            if (route != null)
            {
                Type handlerType = route.Method.DeclaringType;
                object handler = null;

                if (Handlers.ContainsKey(handlerType))
                {
                    handler = Handlers[handlerType];
                }
                else
                {
                    handler = Activator.CreateInstance(handlerType);
                    Handlers[handlerType] = handler;
                }

                var result = route.Method.Invoke(handler, null) as string;

                response.WriteHtml(result);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Matches(UrlAttribute attr, HttpListenerRequest request)
        {
            if (attr.Url.Equals(request.RawUrl, StringComparison.InvariantCultureIgnoreCase)
                && attr.Methods.Contains(request.HttpMethod))
                return true;

            return false;
        }
    }
}
