using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Appy
{
    public static partial class Extensions
    {
        public static MethodInfo[] FindMethodsDecoratedWithAttribute(this Assembly assembly, Type attributeType)
        {
            var methods = assembly.GetTypes()
                  .SelectMany(t => t.GetMethods())
                  .Where(m => m.GetCustomAttributes(attributeType, false).Length > 0)
                  .ToArray();

            return methods;
        }
    }
}
