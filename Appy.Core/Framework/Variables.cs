using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Core.Framework
{
    public sealed class Variables : ConcurrentDictionary<string, object>
    {
        private static readonly Lazy<Variables> lazy = new Lazy<Variables>(() => new Variables());

        public static Variables Current { get { return lazy.Value; } }

        private Variables()
        {
        }
    }
}
