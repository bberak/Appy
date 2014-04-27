using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Core.Framework
{
    public class DisposableObject : IDisposable
    {
        public void Dispose()
        {
            CleanUpManagedResources();
            CleanUpNativeResources();
            GC.SuppressFinalize(this);
        }

        protected virtual void CleanUpManagedResources()
        {
        }

        protected virtual void CleanUpNativeResources()
        {
        }

        ~DisposableObject()
        {
            CleanUpNativeResources();
        }
    }
}
