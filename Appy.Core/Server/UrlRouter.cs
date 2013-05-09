using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Appy.Core
{
    public class UrlRouter : Router<UrlRoute>
    {
        public override void LoadRoutesFrom(Assembly assembly)
        {
            foreach (var method in assembly.FindMethodsWithAttribute<UrlAttribute>())
            {
                UrlRoute route = new UrlRoute { Method = method };

                foreach (var attr in method.GetAttributes<UrlAttribute>())
                {
                    route.Attributes.Add(attr);
                }

                Routes.Add(route);
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
            UrlRoute route = Routes.Find(x => x.Attributes.Count(y => y.Matches(rawRequest)) > 0);

            if (route == null)
                throw new RouteNotFoundException(rawRequest.RawUrl);

            return route;
        }
    }
}
