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
        List<Route> Routes;

        Dictionary<Type, object> Handlers;

        public RouteTable()
        {
            Routes = new List<Route>();

            Handlers = new Dictionary<Type, object>();
        }

        public void Add(Route newRoute)
        {
            Routes.Add(newRoute);
        }

        public bool Execute(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            Route route = Routes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);

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

                Request appyRequest = new Request(rawRequest);
                Response appyResponse = route.Method.Invoke(handler, new object[] { appyRequest }) as Response;

                rawResponse.Cookies = appyResponse.Cookies;
                rawResponse.Headers = appyResponse.Headers;
                rawResponse.ContentType = appyResponse.ContentType;
                rawResponse.StatusCode = appyResponse.Status;
                rawResponse.WriteBytes(appyResponse.ToBytes());

                return true;
            }
            else
            {
                return false;
            }
        }     
    }
}
