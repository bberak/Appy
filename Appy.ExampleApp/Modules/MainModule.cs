using Appy.Core;
using Appy.Core.Nancy;
using Appy.ExampleApp.Services;
using BB.Common.WinForms;
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

            Post["/launcher/run"] = parameters =>
            {
                var selectValue = this.Request.Form["exe-select"];
                var inputValue = this.Request.Form["exe-input"];

                Process.Start(String.IsNullOrEmpty(inputValue) ? selectValue : inputValue);

                return Response.AsRedirect("/launcher");
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

            Get["/testing"] = parameters =>
            {
                var count = Variables.Current.GetOrAdd("count", 0) as int?;

                Variables.Current["count"] = ++count;

                return View["testing", count];
            };

            Get["/theme/change/{newTheme}"] = parameters =>
            {
                if (parameters.newTheme == "JaffasTheme")
                    ThemeManager.ApplyTheme(new JaffasTheme());
                else
                    ThemeManager.ApplyTheme(new AppyTheme());

                return Response.AsRedirect("/testing");
            };
        }
    }
}
