using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Appy.Core
{
    public class AppyRouter : Router
    {
        public override void LoadRoutesFrom(Assembly assembly)
        {
            LoadUrlRoutes(assembly);
            LoadExceptionRoutes(assembly);
        }

        void LoadUrlRoutes(Assembly assembly)
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

        void LoadExceptionRoutes(Assembly assembly)
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

        public void TryHandleRequest(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            UrlRoute route = FindUrlRouteFor(rawRequest);

            Request appyRequest = RequestAdapter.GetRequest(rawRequest);
            Response appyResponse = InvokeMethod(route.Method, appyRequest) as Response;

            ResponseAdapter.Write(appyResponse, rawResponse);
        }

        UrlRoute FindUrlRouteFor(HttpListenerRequest rawRequest)
        {
            UrlRoute route = UrlRoutes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);

            if (route == null)
                throw new RouteNotFoundException(rawRequest.RawUrl);

            return route;
        }

        public void TryHandleException(Exception ex)
        {
            TryHandleException(null, ex);
        }

        public void TryHandleException(HttpListenerResponse rawResponse, Exception ex)
        {
            ExceptionRoute route = FindExceptionRouteFor(ex);

            Response appyResponse = InvokeMethod(route.Method, ex) as Response;

            if ((rawResponse != null).And(appyResponse != null))
                ResponseAdapter.Write(appyResponse, rawResponse);
        }

        ExceptionRoute FindExceptionRouteFor(Exception ex)
        {
            ExceptionRoute route = ExceptionRoutes.Find(x => x.Attributes.Count(y => y.Matches(ex)) > 0);

            if (route == null)
                route = ExceptionRoutes.Find(x => x.Attributes.Count(y => y.IsDefault) > 0);

            if (route == null)
                throw ex;

            return route;
        }
    }
}
