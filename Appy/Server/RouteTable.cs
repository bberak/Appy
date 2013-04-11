﻿using SelfServe;
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

        Dictionary<Type, object> Controllers;

        public RouteTable()
        {
            Routes = new List<Route>();
            Controllers = new Dictionary<Type, object>();
        }

        public void Add(Route newRoute)
        {
            Routes.Add(newRoute);
        }

        public void TryExecuteRequest(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            Route route = FindRoute(rawRequest);

            Request appyRequest = new Request(rawRequest);
            Response appyResponse = InvokeMethod(route.Method, appyRequest);

            rawResponse.WriteResponse(appyResponse);
        }

        Route FindRoute(HttpListenerRequest rawRequest)
        {
            Route route = Routes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);

            if (route == null)
                throw new RouteNotFoundException(rawRequest.RawUrl);

            return route;
        }

        Response InvokeMethod(MethodInfo method, Request arg)
        {
            object routeController = GetControllerOfType(method.DeclaringType);

            return method.Invoke(routeController, new object[] { arg }) as Response;
        }

        object GetControllerOfType(Type controllerType)
        {
            object controller = null;

            if (Controllers.ContainsKey(controllerType))
            {
                controller = Controllers[controllerType];
            }
            else
            {
                controller = CreateControllerFromType(controllerType);
            }

            return controller;
        }

        object CreateControllerFromType(Type controllerType)
        {
            object controller = Activator.CreateInstance(controllerType);
            Controllers[controllerType] = controller;

            return controller;
        }
    }
}
