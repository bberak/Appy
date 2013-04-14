using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CatchesAttribute : Attribute
    {
        public Type[] Exceptions { get; protected set; }

        public CatchesAttribute(params Type[] exceptions)
        {
            Exceptions = exceptions;
        }

        public bool IsDefault 
        { 
            get 
            { 
                return Exceptions.Length == 0 || (Exceptions.Length == 1 && Exceptions[0].Equals(typeof(Exception))); 
            } 
        }

        public bool Matches(Exception ex)
        {
            return Exceptions.Contains(ex.GetType());
        }
    }
}
