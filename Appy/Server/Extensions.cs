using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Appy
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
    }
}
