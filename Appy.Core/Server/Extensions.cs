using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using SelfServe;

namespace Appy.Core
{
    public static partial class Extensions
    {
        public static MethodInfo[] FindMethodsWithAttribute<T>(this Assembly assembly)
        {
            var methods = assembly.GetTypes()
                  .SelectMany(t => t.GetMethods())
                  .Where(m => m.GetCustomAttributes(typeof(T), false).Length > 0)
                  .ToArray();

            return methods;
        }

        public static T[] GetAttributes<T>(this MethodInfo method)
        {
            object[] urlObjects = method.GetCustomAttributes(typeof(T), true);

            return Array.ConvertAll(urlObjects, item => (T)item);
        }

        public static T As<T>(this object obj)
        {
            if (typeof(T).IsAssignableFrom(obj.GetType()))
                return (T)obj;

            return default(T);
        }

        public static bool Is<T>(this object obj)
        {
            return obj is T;
        }

        public static bool And(this bool lhs, bool rhs)
        {
            return lhs && rhs;
        }

        public static bool Or(this bool lhs, bool rhs)
        {
            return lhs || rhs;
        }

        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static bool NotNull(this object source)
        {
            return !IsNull(source);
        }
    }
}
