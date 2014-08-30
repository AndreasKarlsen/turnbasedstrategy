using NUnit.Framework;
using System;
using System.Linq;

namespace tbsserver.Tests
{
    [TestFixture()]
    public class GameTest
    {
        private Game game;

        [TestFixtureSetUp] 
        public void Init()
        {
            Console.WriteLine("lol");
            var player1 = new Player("Thomas");
            var player2 = new Player("Andreas");
            var game = new Game(player1);
            game.AddPlayer(player2);
            var commander = new UnitType("Commander", 20, 2, 100, energy: 5);
            game.AddUnit(player1, commander, 10, 10);
            game.AddUnit(player2, commander, -10, -10);
            game.Start();
            this.game = game;
        }

        [Test()]
        public void IsGameStarted()
        {
            Assert.AreEqual(game.CurrentTurn, 0);
            Assert.NotNull(game.CurrentPlayer);
        }

        [Test()]
        public void IsUnitsAdded()
        {
            Assert.AreEqual(game.Units.Count, 2);
            Assert.AreEqual(game.Players.Count, 2);
            Assert.AreEqual(game.Players[0].Units.Count, 1);
            Assert.AreEqual(game.Players[1].Units.Count, 1);
            Assert.AreEqual(game.Players[0].Units[0].UnitType.Name, "Commander");
            Assert.AreEqual(game.Players[1].Units[0].UnitType.Name, "Commander");
        }

        [Test()]
        public void IsUnitMoved()
        {
            var unit = game.Units.First();
            game.MoveUnit(unit, 9, 8);
            Assert.AreEqual(2, unit.CurrentEnergy);
        }



    }
}