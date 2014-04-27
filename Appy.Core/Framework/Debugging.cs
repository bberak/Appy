using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Core.Framework
{
    public static class Debugging
    {
        public static void Write(string output, params object[] args)
        {
            var reset = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(output, args);
            Console.ForegroundColor = reset;
        }

        public static void WriteIf(bool condition, string output, params object[] args)
        {
            if (condition)
                Write(output, args);
        }

        public static void WriteLine(string output, params object[] args)
        {
            Write(output + Environment.NewLine, args);
        }

        public static void WriteLineIf(bool condition, string output, params object[] args)
        {
            if (condition)
                WriteLine(output, args);
        }
    }
}
