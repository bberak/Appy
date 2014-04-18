using Nancy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.ExampleApp.Modules
{
    public class MainModule : NancyModule
    {
        ISystemMonitor SystemMonitor;

        public MainModule(ISystemMonitor systemMonitor)
        {
            SystemMonitor = systemMonitor;

            Get["/"] = parameters =>
            {
                return View["flat-ui"];
            };

            Get["/launcher"] = parameters =>
            {
                return View["launcher"];
            };

            Get["/sysmon"] = parameters =>
            {
                return View["system_monitor"];
            };

            Get["/sysmon/check"] = parameters =>
            {
                var model = new
                {
                    cpuLoad = (int)SystemMonitor.GetCpuLoad(),
                    memoryLoad = (int)SystemMonitor.GetMemoryLoad()
                };

                return model;
            };
        }
    }
}
