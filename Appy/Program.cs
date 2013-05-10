using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUserInterface();

            try
            {
                new BootstrapTask(ui).Run();
            }
            catch (Exception ex)
            {
                ui.WriteException(ex);
                ui.ReadLine();
            }
        }
    }
}
