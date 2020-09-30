using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace Battleships.Test
{
    public class Tests
    {

        // Test ships have created random coordinates

        [Test]
        public void TestRandomShipCoordinates()
        {
            // Arrange
            Random random = new Random();
            char testCoordinate1 = RandomLetter.GetLetter(0, 9);
            int testCoordinate2 = random.Next(2, 7);
            
            var ship = PlayerSetup.BattleShip;
            var coordinates = testCoordinate1 + Convert.ToString(testCoordinate2);

            // Act
            ship.Add(testCoordinate1 + Convert.ToString(testCoordinate2));

            // Assert
            Assert.That(ship,Contains.Item(coordinates));
        }
        
        // Test Generated ship coordinates are correctly calculated
        
        [TestCase("A", 0)]
        [TestCase("E", 5)]
        [TestCase("J", 9)]
        public void TestGeneratedShipCoordinates(string testCoordinate1, int testCoordinate2)
        {
            // Arrange
            var ship = PlayerSetup.BattleShip;
            var coordinates = testCoordinate1 + Convert.ToString(testCoordinate2 + 1);

            // Act
            ship.Add(testCoordinate1 + Convert.ToString(testCoordinate2 + 1));
            
            // Assert
            Assert.That(ship,Contains.Item(coordinates));

        }
        
        // Test shots on ships hit correctly
        
        [TestCase("A",0)]
        [TestCase("E",5)]
        [TestCase("J",9)]
        public void TestShotsHit(string testCoordinate1, int testCoordinate2)
        {
            // Arrange
            var ship = PlayerSetup.BattleShip;
            var grid = MainGame.shotGrid;
            var playerGuess = testCoordinate1 + testCoordinate2;
            int yCoordinate;

            // Act
            ship.Add(testCoordinate1 + Convert.ToString(testCoordinate2));
            
            yCoordinate = char.ToUpper(playerGuess[0]) - 64;

            if (ship.Contains(playerGuess))
                grid[yCoordinate -1, testCoordinate2] = 'X'; 
            
            // Assert
            Assert.That(grid[yCoordinate -1 , testCoordinate2], Is.EqualTo('X'));

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
}