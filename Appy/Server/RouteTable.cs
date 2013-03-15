using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
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
            Route route = FindRoute(rawRequest);

            if (route != null)
            {
                Request appyRequest = new Request(rawRequest);
                Response appyResponse = InvokeMethod(route.Method, appyRequest);

                rawResponse.WriteResponse(appyResponse);

                return true;
            }
            else
            {
                return false;
            }
        }

        Route FindRoute(HttpListenerRequest rawRequest)
        {
            return Routes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);
        }

        Response InvokeMethod(MethodInfo method, Request arg)
        {
            object routeHandler = GetHandlerOfType(method.DeclaringType);

            return method.Invoke(routeHandler, new object[] { arg }) as Response;
        }

        object GetHandlerOfType(Type handlerType)
        {
            object handler = null;

            if (Handlers.ContainsKey(handlerType))
            {
                handler = Handlers[handlerType];
            }
            else
            {
                handler = CreateHandlerFromType(handlerType);
            }

            return handler;
        }

        object CreateHandlerFromType(Type handlerType)
        {
            object handler = Activator.CreateInstance(handlerType);
            Handlers[handlerType] = handler;

            return handler;
        }
    }
}
