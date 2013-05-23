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

            var answer = ui.Ask("Would you like to (b)ootstrap, (c)ompile or (e)xit?");

            switch (answer.ToLower())
            {
                case "b":
                case "bootstrap": Bootstrap(ui); break;

                case "c":
                case "compile": Compile(ui); break;

                case "e":
                case "exit": return;

                default:
                    ui.Say("Sorry, I didn't quite get that..");
                    Main(args);
                    break;
            }
        }

        static void Bootstrap(IUserInterface ui)
        {
            try
            {
                new BootstrapTask(ui).Run();
            }
            catch (Exception ex)
            {
                ui.WriteException(ex);
            }
            finally
            {
                ui.Wait();
            }
        }

        static void Compile(IUserInterface ui)
        {
            try
            {
                new CompileTask(ui).Run();
            }
            catch (Exception ex)
            {
                ui.WriteException(ex);
            }
            finally
            {
                ui.Wait();
            }
        }
    }
}
