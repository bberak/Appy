using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using BB.Common.WinForms;
using Appy.Core;

namespace Appy.ExampleApp
{
    public class ExampleController : Controller
    {
        int Count;
        Lazy<PerformanceCounter> CpuCounter;
        Lazy<PerformanceCounter> MemoryCounter;

        public ExampleController()
        {
            CpuCounter = new Lazy<PerformanceCounter>(() =>
            {
                return new PerformanceCounter("Processor", "% Processor Time", "_Total");
            });

            MemoryCounter = new Lazy<PerformanceCounter>(() =>
            {
                return new PerformanceCounter("Memory", "% Committed Bytes in Use");
            });
        }

        [Url("/index")]
        [Url("/flat-ui")]
        public Response FlatUI(Request incoming)
        {
            var name = incoming.Form.Find("Name");
            var email = incoming.Form.Find("Email");

            var cookie = new Cookie("Name", "Value").ExpiresIn(30);

            return new ViewResponse("flat-ui.html", Count);
        }
        
        [Url("/launcher")]
        public Response Launcher(Request incoming)
        {
            return View("launcher.html") + Cookie("testCookie", "abc") + Header("testHeader", "123");
        }

        [Url("/launcher/run")]
        public Response Run(Request incoming)
        {
            var exe = string.IsNullOrEmpty(incoming.Form.Find("exe-input"))
                ? incoming.Form.Find("exe-select")
                : incoming.Form.Find("exe-input");

            Process.Start(exe);

            return new RedirectResponse("/launcher");
        }

        [Url("/testing")]
        public Response Testing(Request incoming)
        {
            Count++;

            return new ViewResponse("testing.html", Count);
        }

        [Url("/change-theme")]
        public Response ChangeTheme(Request incoming)
        {
            string themeName = incoming.QueryString.Find("theme");

            if (themeName.Equals("JaffasTheme"))
                ThemeManager.ApplyTheme(new JaffasTheme());
            else
                ThemeManager.ApplyTheme(new AppyTheme());
 
            return Redirect("/testing");
        }

        [Url("/sysmon")]
        public Response SystemMonitor(Request incoming)
        {
            return View("system_monitor.html");
        }

        [Url("/sysmon/check")]
        public Response SystemMonitorCheck(Request incoming)
        {
            var model = new
            {
                cpuLoad = (int)CpuCounter.Value.NextValue(),
                memoryLoad = (int)MemoryCounter.Value.NextValue()
            };

            Debugging.WriteLine("Getting cpu and memory values: {0}, {1}", model.cpuLoad, model.memoryLoad);

            return Json(model);
        }

        protected override void CleanUpManagedResources()
        {
            //-- The "cleanup" methods are only available if your class inherits from Controller 
            //-- or DisposableObject.

            base.CleanUpManagedResources();

            if (CpuCounter.IsValueCreated)
                CpuCounter.Value.Dispose();

            if (MemoryCounter.IsValueCreated)
                MemoryCounter.Value.Dispose();
        }

        protected override void CleanUpNativeResources()
        {
            //-- The "cleanup" methods are only available if your class inherits from Controller 
            //-- or DisposableObject.

            base.CleanUpNativeResources();

            //-- Clean up any native resources here (pointers or handles etc).
        }
    }
}