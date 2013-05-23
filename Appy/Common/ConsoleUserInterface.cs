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

        public void Splash()
        {
            Console.WindowWidth = 98;

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

            Array allColors = Enum.GetValues(typeof(ConsoleColor));
            List<ConsoleColor> acceptableColors = allColors.OfType<ConsoleColor>().ToList();
            acceptableColors.Remove(ConsoleColor.Black);
            acceptableColors.Remove(ConsoleColor.DarkGreen);
            acceptableColors.Remove(ConsoleColor.DarkBlue);
            acceptableColors.Remove(ConsoleColor.DarkGray);
            Random random = new Random();
            
            foreach (string line in header)
            {
                ConsoleColor randomColor = (ConsoleColor)acceptableColors[random.Next(acceptableColors.Count)];
                Console.ForegroundColor = randomColor;
                Console.WriteLine(line);
            }
        }
    }
}
