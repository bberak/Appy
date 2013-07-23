using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy
{
    class Program
    {
        static IUserInterface UI;

        static void Main(string[] args)
        {
            UI = new ConsoleUserInterface();

            UI.Splash();

            Start();
        }

        static void Start()
        {
            var answer = UI.Ask("Would you like to (b)ootstrap, (c)ompile or (e)xit?");

            switch (answer.ToLower())
            {
                case "b":
                case "bootstrap": Bootstrap(); break;

                case "c":
                case "compile": Compile(new CompileTask(UI)); break;

                case "e":
                case "x":
                case "exit": Environment.Exit(0); break;

                default:
                    UI.Say("Sorry, I didn't quite get that..");
                    Start();
                    break;
            }
        }

        static void Bootstrap()
        {
            try
            {
                var task = new BootstrapTask(UI);
                task.Run();

                UI.Say("Bootstrap complete.");

                if (UI.Ask("Do you wan't to (c)ompile " + task.Settings.AppName + "?", "c,compile,y,yes"))
                    Compile(new CompileTask(UI, task.Settings.AppFolder));
            }
            catch (Exception ex)
            {
                UI.WriteException(ex);
            }
            finally
            {
                Start();
            }
        }

        static void Compile(CompileTask task)
        {
            try
            {
                task.Run();

                UI.Say("Compilation complete.");

                if (UI.Ask("Would you like to (r)un you app?", "y,yes,r,run"))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(task.Settings.ExeOutputFile);
                    startInfo.WorkingDirectory = Path.GetDirectoryName(task.Settings.ExeOutputFile);
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                UI.WriteException(ex);
            }
            finally
            {
                if (UI.Ask("Would you like to (c)ompile again?", "c,compile,y,yes"))
                    Compile(task);
                else
                    Start();
            }
        }
    }
}
