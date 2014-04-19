using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.ExampleApp.Services
{
    public interface ISystemMonitor
    {
        float GetCpuLoad();

        float GetMemoryLoad();
    }
}
