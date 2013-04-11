﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public class ExampleController : Controller
    {
        int Count;
        PerformanceCounter CpuCounter;
        PerformanceCounter MemoryCounter;

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

        [Url("/testing")]
        public Response Testing(Request incoming)
        {
            Count++;

            return new ViewResponse("testing.html", Count);
        }

        [Url("/flat-ui")]
        public Response FlatUI(Request incoming)
        {
            var name = incoming.Form.Find("Name");
            var email = incoming.Form.Find("Email");

            var cookie = new Cookie("Name", "Value").ExpiresIn(30);

            return new ViewResponse("flat-ui.html", Count);
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
                cpuLoad = GetCpuLoad(),
                memoryLoad = GetMemoryLoad()
            };

            return Json(model);
        }

        int GetCpuLoad()
        {
            if (CpuCounter == null)
                CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            return (int)CpuCounter.NextValue();
        }

        int GetMemoryLoad()
        {
            if (MemoryCounter == null)
                MemoryCounter = new PerformanceCounter("Memory", "% Committed Bytes in Use");

            return (int)MemoryCounter.NextValue();
        }
    }
}
