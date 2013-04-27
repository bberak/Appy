using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Appy
{
    public class ExceptionRouter : Router<ExceptionRoute>
    {
        public override void LoadRoutesFrom(Assembly assembly)
        {
            foreach (var method in assembly.FindMethodsWithAttribute<CatchesAttribute>())
            {
                ExceptionRoute route = new ExceptionRoute { Method = method };

                foreach (var attr in method.GetAttributes<CatchesAttribute>())
                {
                    route.Attributes.Add(attr);
                }

                Routes.Add(route);
            }
        }

        public void TryHandleException(Exception ex)
        {
            TryHandleException(null, ex);
        }

        public void TryHandleException(HttpListenerResponse rawResponse, Exception ex)
        {
            ExceptionRoute route = FindExceptionRouteFor(ex);

            Response appyResponse = InvokeMethod(route.Method, ex) as Response;

            if (rawResponse != null && appyResponse != null)
                rawResponse.WriteResponse(appyResponse);
        }

        ExceptionRoute FindExceptionRouteFor(Exception ex)
        {
            ExceptionRoute route = Routes.Find(x => x.Attributes.Count(y => y.Matches(ex)) > 0);

            if (route == null)
                route = Routes.Find(x => x.Attributes.Count(y => y.IsDefault) > 0);

            if (route == null)
                throw ex;

            return route;
        }
    }
}
