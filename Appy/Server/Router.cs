using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Appy
{
    public abstract class Router<T>
    {
        protected List<T> Routes;
        protected Dictionary<Type, object> Controllers;

        public Router()
        {
            Routes = new List<T>();
            Controllers = new Dictionary<Type, object>();
        }

        public int RouteCount { get { return Routes.Count; } }

        public abstract void LoadRoutesFrom(Assembly assembly);

        protected object GetControllerOfType(Type controllerType)
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

        protected object CreateControllerFromType(Type controllerType)
        {
            object controller = Activator.CreateInstance(controllerType);
            Controllers[controllerType] = controller;

            return controller;
        }

        protected object InvokeMethod(MethodInfo method, object arg)
        {
            object controller = GetControllerOfType(method.DeclaringType);

            try
            {
                return method.Invoke(controller, new object[] { arg });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }  
    }
}
