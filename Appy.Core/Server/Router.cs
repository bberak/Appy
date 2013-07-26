using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Appy.Core
{
    public abstract class Router : IDisposable
    {
        protected List<UrlRoute> UrlRoutes;
        protected List<ExceptionRoute> ExceptionRoutes;
        protected Dictionary<Type, object> Controllers;

        public int UrlRouteCount { get { return UrlRoutes.Count; } }
        public int ExceptionRouteCoumt { get { return ExceptionRoutes.Count; } }
        
        public Router(params Assembly[] assembliesWithRoutes)
        {
            UrlRoutes = new List<UrlRoute>();
            ExceptionRoutes = new List<ExceptionRoute>();
            Controllers = new Dictionary<Type, object>();

            foreach (var assembly in assembliesWithRoutes)
                LoadRoutesFrom(assembly);
        }

        protected virtual void LoadRoutesFrom(Assembly assembly)
        {
            LoadUrlRoutes(assembly);
            LoadExceptionRoutes(assembly);
        }

        protected virtual void LoadUrlRoutes(Assembly assembly)
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

        protected virtual void LoadExceptionRoutes(Assembly assembly)
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

        public abstract void TryHandleRequest(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse);

        protected abstract UrlRoute FindUrlRouteFor(HttpListenerRequest rawRequest);

        public abstract void TryHandleException(Exception ex);

        public abstract void TryHandleException(HttpListenerResponse rawResponse, Exception ex);

        protected abstract ExceptionRoute FindExceptionRouteFor(Exception ex);
    }
}
