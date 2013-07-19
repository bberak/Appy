using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.Core
{
    public static class Debug
    {
        public static void Write(string output, params object[] args)
        {
            var reset = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(output, args);
            Console.ForegroundColor = reset;
        }

        public static void WriteLine(string output, params object[] args)
        {
            Write(output + Environment.NewLine, args);
        }
    }
}
