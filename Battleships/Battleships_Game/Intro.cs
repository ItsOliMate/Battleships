using System;

namespace Battleships_Intro
{
    public class Intro
    {
        public Intro()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("         BATTLESHIPS         ");
            Console.ResetColor();
            Console.WriteLine("\n    Welcome to Battleships  \n");
            Console.WriteLine(@"               __/__");
            Console.WriteLine(@"         _____/_____|");
            Console.WriteLine(@"_______ /_____\______\______");
            Console.WriteLine(@"\             < < <         |");
            Console.WriteLine(@"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("         Instructions        ");
            Console.ResetColor();
            Console.WriteLine("\n\n - Hit = X\n - Miss = M\n - Sea = ~\n\nType in the X and Y coordinates to chose the desired location.\nOnce all of the ships have been destroyed you will win.\n");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey(true);
        }
    }
}
