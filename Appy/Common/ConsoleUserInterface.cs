using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void Write(object output, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.ForegroundColor = color;
            Console.Write(output);
        }

        public void WriteLine(string output = "")
        {
            Write(output + Environment.NewLine);
        }

        public void WriteException(Exception ex)
        {
            Write(ex, ConsoleColor.Red);
            WriteLine();
        }

        public string ReadLine(ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            return Console.ReadLine();
        }

        public string Ask(string question)
        {
            Write(question);
            return ReadLine();
        }
    }
}
