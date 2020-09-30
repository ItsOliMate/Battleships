using System;
using Battleships_Intro;

namespace Battleships
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool winner = false;
            
            // Intro and Instructions
            
            Intro intro = new Intro();

            while (winner == false)
            {
                // Player Setup

                PlayerSetup.Setup();
                
                // Start Game

                MainGame.Game();

                Console.WriteLine("\n         Play Again?         ");
                var replay = Console.ReadLine().ToUpper();
                
                if (replay == "Y" || replay == "YES")
                {
                    // Reset Player Coordinates
                    
                    PlayerSetup.Destroyer1.Clear();
                    PlayerSetup.Destroyer2.Clear();
                    PlayerSetup.BattleShip.Clear();
                }
                else
                {
                    winner = true;
                    break;
                }
            }
        }
    }
}