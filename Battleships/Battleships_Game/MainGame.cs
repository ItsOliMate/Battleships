using System;
using System.Text.RegularExpressions;

namespace Battleships
{
    public class MainGame
    {
        // Grid
        
        public static int gridSize = 10;
        public static char[,] shotGrid = new char [gridSize, gridSize];
        
        public static void Game()
        {
            int hit = 0;
            int miss = 0;

            Random random = new Random();

            // Create Players Grid 
                
            void DrawGrid()
            {
                Console.Write("      A B C D E F G H I J\n     ____________________");
                Console.WriteLine();

                for (int y = 0; y < shotGrid.GetLength(1); y++)
                {
                    string currentLine = "  " + $"{y + 0} | ";
                    for (int x = 0; x < shotGrid.GetLength(0); x++)
                    {
                        char shot = shotGrid[y, x];
                        currentLine += shot + " ";
                    }
                    Console.WriteLine(currentLine);
                }
                Console.WriteLine();
            }

            for (int y = 0; y < shotGrid.GetLength(1); y++)
            {
                for (int x = 0; x < shotGrid.GetLength(0); x++)
                {
                    shotGrid[y, x] = '~';
                }
            }

            while (hit < 13)
            {
                Console.WriteLine("\nHit Count: " + hit + " | Miss Count: " + miss + "\n");

                DrawGrid();

                // Enter Coordinates

                Console.WriteLine("Enter coordinates to Attack opponents ship's (i.e. A0, F5, J9}");
                Console.WriteLine("Coordinates:");

                string playerGuess;
                int yCoordinate;
                string xCoordinate;
                
                string checkNumber = "";
                int letterCounter = 1;

                // Guess input Validator

                do
                {
                    playerGuess = Console.ReadLine().ToUpper();

                    while (string.IsNullOrEmpty(playerGuess) || playerGuess.Length != 2 || checkNumber == "" || letterCounter != 1)
                    {
                        while (playerGuess.Length != 2)
                        {
                            Console.WriteLine("Invalid entry, Must contain 1 Letter and 1 Number.\n");
                            Console.WriteLine("Enter coordinates to Attack opponents ship's (i.e. A0, F5, J9}");
                            Console.WriteLine("Coordinates:");
                            playerGuess = Console.ReadLine().ToUpper();
                        }

                        letterCounter = Regex.Matches(Convert.ToString(playerGuess[0]),@"[a-zA-Z]").Count;
                        checkNumber = Regex.Match(Convert.ToString(playerGuess[1]), @"\d+").Value;
                        
                        if (checkNumber == "")
                        {
                            Console.WriteLine("Invalid entry, Must contain a Number.\n");
                            Console.WriteLine("Enter coordinates to Attack opponents ship's (i.e. A0, F5, J9}");
                            Console.WriteLine("Coordinates:");
                            playerGuess = Console.ReadLine().ToUpper();
                        }

                        if (letterCounter != 1)
                        {
                            Console.WriteLine("Invalid entry, Must contain a Letter.\n");
                            Console.WriteLine("Enter coordinates to Attack opponents ship's (i.e. A0, F5, J9}");
                            Console.WriteLine("Coordinates:");
                            playerGuess = Console.ReadLine().ToUpper();
                        }
                        
                        foreach (char c in playerGuess)
                        {
                            if (!Char.IsLetterOrDigit(c))
                            {
                                Console.WriteLine("Invalid entry, You entered a Symbol.\n");
                                Console.WriteLine("Enter coordinates to Attack opponents ship's (i.e. A0, F5, J9}");
                                Console.WriteLine("Coordinates:");
                                playerGuess = Console.ReadLine().ToUpper();
                            }
                        }
                    }

                    yCoordinate = char.ToUpper(playerGuess[0]) - 64;
                    xCoordinate = Regex.Match(playerGuess, @"\d+").Value;

                    if (shotGrid[Convert.ToInt32(xCoordinate), yCoordinate - 1] != '~')
                    {
                        Console.WriteLine(
                            "The Coordinates Selected have already been used, please try again.\n");
                        Console.WriteLine("Enter coordinates to Attack opponents ship's (i.e. A0, F5, J9}");
                        Console.WriteLine("Coordinates:");
                    }
                } while (playerGuess.Length != 2 || string.IsNullOrEmpty(playerGuess) ||
                         shotGrid[Convert.ToInt32(xCoordinate), yCoordinate - 1] != '~' || checkNumber == "");

                // Hit or Miss

                if (PlayerSetup.Destroyer1.Contains(playerGuess) || PlayerSetup.Destroyer2.Contains(playerGuess) ||
                    PlayerSetup.BattleShip.Contains(playerGuess))
                {
                    hit++;
                    Console.WriteLine("\nHit Count: " + hit + " | Miss Count: " + miss);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("            HIT!             ");
                    Console.ResetColor();
                    Console.Beep();
                    shotGrid[Convert.ToInt32(xCoordinate), yCoordinate - 1] = 'X';
                }
                else
                {
                    miss++;
                    Console.WriteLine("\nHit Count: " + hit + " | Miss Count: " + miss);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("            MISS!            ");
                    Console.ResetColor();
                    shotGrid[Convert.ToInt32(xCoordinate), yCoordinate - 1] = 'M';
                }

                Console.WriteLine("\n");

                DrawGrid();

                Console.WriteLine("Shot Coordinates " + playerGuess);
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey(true);
                Console.WriteLine();

                if (hit == 13)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("          Game Over          ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("           You Win!          ");
                    Console.ResetColor();
                    break;
                }
            }
        }
    }
}