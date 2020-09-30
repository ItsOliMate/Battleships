using System;
using System.Collections.Generic;

namespace Battleships
{
    public class PlayerSetup
    {
        // Ships

        public static List<string> BattleShip = new List<string>();
        public static List<string> Destroyer1 = new List<string>();
        public static List<string> Destroyer2 = new List<string>();

        public static void Setup()
        {

            Random random = new Random();

            // Destroyer 1 Random Coordinates

            char playersCoordinates1 = RandomLetter.GetLetter(0, 3);
            int playersCoordinates2 = random.Next(2, 7);
            
            Destroyer1.Add(playersCoordinates1 + Convert.ToString(playersCoordinates2 - 1));
            Destroyer1.Add(playersCoordinates1 + Convert.ToString(playersCoordinates2));
            Destroyer1.Add(playersCoordinates1 + Convert.ToString(playersCoordinates2 + 1));
            Destroyer1.Add(playersCoordinates1 + Convert.ToString(playersCoordinates2 + 2));

            // Battleship Random Coordinates

            char playersCoordinates3 = RandomLetter.GetLetter(4, 6);
            int playersCoordinates4 = random.Next(2, 7);
            
            BattleShip.Add(playersCoordinates3 + Convert.ToString(playersCoordinates4 - 2));
            BattleShip.Add(playersCoordinates3 + Convert.ToString(playersCoordinates4 - 1));
            BattleShip.Add(playersCoordinates3 + Convert.ToString(playersCoordinates4));
            BattleShip.Add(playersCoordinates3 + Convert.ToString(playersCoordinates4 + 1));
            BattleShip.Add(playersCoordinates3 + Convert.ToString(playersCoordinates4 + 2));

            // // Destroyer 2 Random Coordinates

            var playersCoordinates5 = RandomLetter.GetLetter(6, 9);
            var playersCoordinates6 = random.Next(2, 7);

            Destroyer2.Add(playersCoordinates5 + Convert.ToString(playersCoordinates6 - 1));
            Destroyer2.Add(playersCoordinates5 + Convert.ToString(playersCoordinates6));
            Destroyer2.Add(playersCoordinates5 + Convert.ToString(playersCoordinates6 + 1));
            Destroyer2.Add(playersCoordinates5 + Convert.ToString(playersCoordinates6 + 2));
        }
    }
}

static class RandomLetter
{
    static Random _random = new Random();
    public static char GetLetter(int rangeFrom, int rangeTo)
    {
        int num = _random.Next(rangeFrom , rangeTo);
        char let = (char)('A' + num);
        return let;
    }
}