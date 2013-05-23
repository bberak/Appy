using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public interface IUserInterface
    {
        void WriteException(Exception ex);

        string Ask(string question);

        void Say(string something);

        void Wait();
    }
}
