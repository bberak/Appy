using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public interface IUserInterface
    {
        void Splash();

        void WriteException(Exception ex);

        string Ask(string question);

        bool Ask(string yesNoQuestion, string yesOptions);

        void Say(string something);

        void Wait();
    }
}
