using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Common
{
    public class ConsoleUserInterface : IUserInterface
    {
        List<ConsoleColor> AcceptableColors;

        public ConsoleUserInterface()
        {
            Console.WindowWidth = 98;

            Console.WindowHeight = 48;

            PopulateAcceptableColors();
        }

        void PopulateAcceptableColors()
        {
            Array allColors = Enum.GetValues(typeof(ConsoleColor));

            AcceptableColors = allColors.OfType<ConsoleColor>().ToList();
            AcceptableColors.Remove(ConsoleColor.Black);
            AcceptableColors.Remove(ConsoleColor.DarkGreen);
            AcceptableColors.Remove(ConsoleColor.DarkBlue);
            AcceptableColors.Remove(ConsoleColor.DarkGray);
        }

        public void Splash()
        {
            List<string> header = new List<string>();
            header.Add(@"          _____                    _____                    _____                _____          ");
            header.Add(@"         /\    \                  /\    \                  /\    \              |\    \         ");
            header.Add(@"        /::\    \                /::\    \                /::\    \             |:\____\        ");
            header.Add(@"       /::::\    \              /::::\    \              /::::\    \            |::|   |        ");
            header.Add(@"      /::::::\    \            /::::::\    \            /::::::\    \           |::|   |        ");
            header.Add(@"     /:::/\:::\    \          /:::/\:::\    \          /:::/\:::\    \          |::|   |        ");
            header.Add(@"    /:::/__\:::\    \        /:::/__\:::\    \        /:::/__\:::\    \         |::|   |        ");
            header.Add(@"   /::::\   \:::\    \      /::::\   \:::\    \      /::::\   \:::\    \        |::|   |        ");
            header.Add(@"  /::::::\   \:::\    \    /::::::\   \:::\    \    /::::::\   \:::\    \       |::|___|______  ");
            header.Add(@" /:::/\:::\   \:::\    \  /:::/\:::\   \:::\____\  /:::/\:::\   \:::\____\      /::::::::\    \ ");
            header.Add(@"/:::/  \:::\   \:::\____\/:::/  \:::\   \:::|    |/:::/  \:::\   \:::|    |    /::::::::::\____\");
            header.Add(@"\::/    \:::\  /:::/    /\::/    \:::\  /:::|____|\::/    \:::\  /:::|____|   /:::/~~~~/~~      ");
            header.Add(@" \/____/ \:::\/:::/    /  \/_____/\:::\/:::/    /  \/_____/\:::\/:::/    /   /:::/    /         ");
            header.Add(@"          \::::::/    /            \::::::/    /            \::::::/    /   /:::/    /          ");
            header.Add(@"           \::::/    /              \::::/    /              \::::/    /   /:::/    /           ");
            header.Add(@"           /:::/    /                \::/____/                \::/____/    \::/    /            ");
            header.Add(@"          /:::/    /                  ~~                       ~~           \/____/             ");
            header.Add(@"         /:::/    /                                                                             ");
            header.Add(@"        /:::/    /                                                                              ");
            header.Add(@"        \::/    /                                                                               ");
            header.Add(@"         \/____/                                                                  By Boris Berak");
            header.Add(@"                                                                                                ");

            Random rng = new Random(Environment.TickCount);

            foreach (string line in header)
            {
                int r = rng.Next(AcceptableColors.Count);
                ConsoleColor randomColor = (ConsoleColor)AcceptableColors[r];
                ChangeColor(randomColor);
                Console.WriteLine(line);
            }
        }

        void ChangeColor(ConsoleColor newColor)
        {
            Console.ForegroundColor = newColor;
        }

        public string Ask(string question)
        {
            ChangeColor(ConsoleColor.Gray);

            PrintLineBreak();

            Console.Write(question + " ");

            ChangeColor(ConsoleColor.Cyan);

            return Console.ReadLine();
        }

        public bool Ask(string yesNoQuestion, string yesOptions)
        {
            string answer = Ask(yesNoQuestion);

            foreach (var item in yesOptions.Replace(" ", "").Split(','))
            {
                if (answer.ToLower() == item.ToLower())
                    return true;
            }

            return false;
        }

        void PrintLineBreak()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        public void Say(string something)
        {
            ChangeColor(ConsoleColor.Gray);

            PrintLineBreak();

            Console.WriteLine(something);
        }

        public void WriteException(Exception ex)
        {
            ChangeColor(ConsoleColor.Red);

            PrintLineBreak();

            Console.WriteLine(ex);
        }

        public void Wait()
        {
            Console.ReadLine();
        }
    }
}
