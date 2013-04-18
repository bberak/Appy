using System;
using System.Collections.Generic;
using System.Linq;
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
            ExceptionRoute route = FindExceptionRouteFor(ex);

            InvokeMethod(route.Method, ex);
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
