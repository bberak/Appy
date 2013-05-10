using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public interface IUserInterface
    {
        void Write(object output, ConsoleColor color); 

        void WriteLine(string output);

        string ReadLine(ConsoleColor color);

        string Ask(string question);
    }
}
