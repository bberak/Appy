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
        List<UrlRoute> UrlRoutes;
        List<ExceptionRoute> ExceptionRoutes;
        Dictionary<Type, object> Controllers;

        public RouteTable()
        {
            UrlRoutes = new List<UrlRoute>();
            ExceptionRoutes = new List<ExceptionRoute>();
            Controllers = new Dictionary<Type, object>();
        }

        public void LoadRoutesFrom(Assembly assembly)
        {
            LoadUrlRoutesFrom(assembly);
            LoadExceptionRoutesFrom(assembly);
        }

        void LoadUrlRoutesFrom(Assembly assembly)
        {
            foreach (var method in assembly.FindMethodsWithAttribute<UrlAttribute>())
            {
                UrlRoute route = new UrlRoute { Method = method };

                foreach (var attr in method.GetAttributes<UrlAttribute>())
                {
                    route.Attributes.Add(attr);
                }

                UrlRoutes.Add(route);
            }
        }

        void LoadExceptionRoutesFrom(Assembly assembly)
        {
            foreach (var method in assembly.FindMethodsWithAttribute<CatchesAttribute>())
            {
                ExceptionRoute route = new ExceptionRoute { Method = method };

                foreach (var attr in method.GetAttributes<CatchesAttribute>())
                {
                    route.Attributes.Add(attr);
                }

                ExceptionRoutes.Add(route);
            }
        }

        public void TryExecuteRequest(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            UrlRoute route = FindUrlRouteFor(rawRequest);

            Request appyRequest = new Request(rawRequest);
            Response appyResponse = InvokeMethod(route.Method, appyRequest);

            rawResponse.WriteResponse(appyResponse);
        }

        public void TryHandleException(Exception ex)
        {
            if (ex is TargetInvocationException)
                ex = ex.InnerException ?? ex;

            ExceptionRoute route = FindExceptionRouteFor(ex);

            InvokeMethod(route.Method, ex);
        }

        UrlRoute FindUrlRouteFor(HttpListenerRequest rawRequest)
        {
            UrlRoute route = UrlRoutes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);

            if (route == null)
                throw new RouteNotFoundException(rawRequest.RawUrl);

            return route;
        }

        ExceptionRoute FindExceptionRouteFor(Exception ex)
        {
            ExceptionRoute route = ExceptionRoutes.Find(x => x.Attributes.Count(y => y.Matches(ex)) > 0);

            if (route == null )
                route = ExceptionRoutes.Find(x => x.Attributes.Count(y => y.IsDefault) > 0);

            if (route == null)
                throw ex;

            return route;
        }

        Response InvokeMethod(MethodInfo method, Request arg)
        {
            object controller = GetControllerOfType(method.DeclaringType);

            return method.Invoke(controller, new object[] { arg }) as Response;
        }

        void InvokeMethod(MethodInfo method, Exception arg)
        {
            object controller = GetControllerOfType(method.DeclaringType);

            method.Invoke(controller, new object[] { arg });
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
