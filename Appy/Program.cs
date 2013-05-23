using System;
using System.Collections.Generic;
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
                case "exit": return;

                default:
                    UI.Say("Sorry, I didn't quite get that..");
                    Start();
                    break;
            }

            Start();
        }

        static void Bootstrap()
        {
            try
            {
                var task = new BootstrapTask(UI);
                task.Run();

                if (CompileNewProject(task.ProjectName))
                    Compile(task.ProjectPath);

            }
            catch (Exception ex)
            {
                UI.WriteException(ex);
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

                do
                {
                    task.Run();
                }
                while(Repeat());
            }
            catch (Exception ex)
            {
                UI.WriteException(ex);
            }
        }

        static bool Repeat()
        {
            var answer = UI.Ask("Would you like to (r)epeat the last command?");

            switch (answer.ToLower())
            {
                case "r":
                case "repeat":
                case "y":
                case "yes":
                    return true;

                default:
                    return false;
            }
        }    
    }
}
