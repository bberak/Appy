using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void WriteException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(ex);
        }

        public string Ask(string question)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write(question + " ");

            Console.ForegroundColor = ConsoleColor.Cyan;

            return Console.ReadLine();
        }

        public void Say(string something)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(something);
        }

        public void Wait()
        {
            Console.ReadLine();
        }
    }
}
