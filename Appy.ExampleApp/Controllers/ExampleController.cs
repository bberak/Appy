using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Appy.Core;
using BB.Common.WinForms;

namespace Appy.ExampleApp
{
    public class ExampleController : Controller
    {
        int Count;

        Lazy<PerformanceCounter> CpuCounter = new Lazy<PerformanceCounter>(() =>
        {
            return new PerformanceCounter("Processor", "% Processor Time", "_Total");
        });

        Lazy<PerformanceCounter> MemoryCounter = new Lazy<PerformanceCounter>(() =>
        {
            return new PerformanceCounter("Memory", "% Committed Bytes in Use");
        });

        [Url("/index")]
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

        [Url("/flat-ui")]
        public Response FlatUI(Request incoming)
        {
            var name = incoming.Form.Find("Name");
            var email = incoming.Form.Find("Email");

            var cookie = new Cookie("Name", "Value").ExpiresIn(30);

            return new ViewResponse("flat-ui.html", Count);
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

            return Json(model);
        }
    }
}