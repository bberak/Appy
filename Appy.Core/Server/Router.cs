using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Appy.Core
{
    public abstract class Router : IDisposable
    {
        protected List<UrlRoute> UrlRoutes;
        protected List<ExceptionRoute> ExceptionRoutes;
        protected Dictionary<Type, object> Controllers;
        
        public Router()
        {
            UrlRoutes = new List<UrlRoute>();
            ExceptionRoutes = new List<ExceptionRoute>();
            Controllers = new Dictionary<Type, object>();
        }

        public int UrlRouteCount { get { return UrlRoutes.Count; } }

        public int ExceptionRouteCoumt { get { return ExceptionRoutes.Count; } }

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

        protected object InvokeMethod(MethodInfo method, params object[] args)
        {
            object controller = GetControllerOfType(method.DeclaringType);

            try
            {
                return method.Invoke(controller, args);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        public virtual void Dispose()
        {
            foreach (object controller in Controllers.Values)
            {
                IDisposable disposable = controller as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }
        }
    }
}
