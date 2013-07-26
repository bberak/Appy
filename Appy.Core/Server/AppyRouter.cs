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
        private AppyRouter(params Assembly[] assembliesWithRoutes)
            : base(assembliesWithRoutes)
        {
        }

        public static AppyRouter LoadFromAssemblies(params Assembly[] assembliesWithRoutes)
        {
            return new AppyRouter(assembliesWithRoutes);
        }

        public override void TryHandleRequest(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            UrlRoute route = FindUrlRouteFor(rawRequest);

            Request appyRequest = RequestAdapter.GetRequest(rawRequest);
            Response appyResponse = InvokeMethod(route.Method, appyRequest) as Response;

            ResponseAdapter.Write(appyResponse, rawResponse);
        }

        protected override UrlRoute FindUrlRouteFor(HttpListenerRequest rawRequest)
        {
            UrlRoute route = UrlRoutes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);

            if (route == null)
                throw new RouteNotFoundException(rawRequest.RawUrl);

            return route;
        }

        public override void TryHandleException(Exception ex)
        {
            TryHandleException(null, ex);
        }

        public override void TryHandleException(HttpListenerResponse rawResponse, Exception ex)
        {
            ExceptionRoute route = FindExceptionRouteFor(ex);

            Response appyResponse = InvokeMethod(route.Method, ex) as Response;

            if ((rawResponse != null).And(appyResponse != null))
                ResponseAdapter.Write(appyResponse, rawResponse);
        }

        protected override ExceptionRoute FindExceptionRouteFor(Exception ex)
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
