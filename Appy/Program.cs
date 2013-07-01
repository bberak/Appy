using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                case "compile": Compile(); break;

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

                if (CompileNewProject(task.Settings.AppName))
                    Compile(task.Settings.AppFolder);

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

        static bool CompileNewProject(string projectName)
        {
            var answer = UI.Ask("Do you wan't to (c)ompile " + projectName + "?");

            switch (answer.ToLower())
            {
                case "c":
                case "compile":
                case "y":
                case "yes":
                    return true;

                default:
                    return false;
            }
        }

        static void Compile(string projectPath = "")
        {
            try
            {
                var task = string.IsNullOrEmpty(projectPath) ? new CompileTask(UI) : new CompileTask(projectPath);
                projectPath = task.Settings.AppFolder;
                task.Run();

                UI.Say("Compilation complete.");

                Run(task.Settings.ExeOutputFile);
            }
            catch (Exception ex)
            {
                UI.WriteException(ex);
            }
            finally
            {
                if (CompileAgain())
                    Compile(projectPath);
                else
                    Start();
            }
        }

        static bool CompileAgain()
        {
            var answer = UI.Ask("Would you like to (c)ompile again?");

            switch (answer.ToLower())
            {
                case "c":
                case "compile":
                case "y":
                case "yes":
                    return true;

                default:
                    return false;
            }
        }

        static void Run(string exePath)
        {
            var answer = UI.Ask("Would you like to (r)un you app?");

            switch (answer.ToLower())
            {
                case "r":
                case "run":
                case "y":
                case "yes":
                    ProcessStartInfo startInfo = new ProcessStartInfo(exePath);
                    startInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(exePath);
                    Process.Start(startInfo);
                    return;

                default:
                    return;
            }
        }
    }
}
