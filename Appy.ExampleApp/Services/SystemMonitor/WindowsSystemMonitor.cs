using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.ExampleApp
{
    public class WindowsSystemMonitor : ISystemMonitor, IDisposable
    {
        Lazy<PerformanceCounter> CpuCounter;
        Lazy<PerformanceCounter> MemoryCounter;

        public WindowsSystemMonitor()
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

        public float GetCpuLoad()
        {
            return CpuCounter.Value.NextValue();
        }

        public float GetMemoryLoad()
        {
            return MemoryCounter.Value.NextValue();
        }

        public void Dispose()
        {
            if (CpuCounter.IsValueCreated)
                CpuCounter.Value.Dispose();

            if (MemoryCounter.IsValueCreated)
                MemoryCounter.Value.Dispose();
        }
    }
}
