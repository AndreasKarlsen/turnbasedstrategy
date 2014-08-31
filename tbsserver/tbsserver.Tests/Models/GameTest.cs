using NUnit.Framework;
using System;
using System.Linq;

namespace tbsserver.Tests
{
    [TestFixture()]
    public class GameTest
    {
        private Game game;

        [SetUp] 
        public void Init()
        {
            Console.WriteLine("lol");
            var player1 = new Player("Thomas");
            var player2 = new Player("Andreas");
            var game = new Game(player1);
            game.AddPlayer(player2);
            var commander = new UnitType(name: "Commander", damage: 20, attackSpeed: 2, hitPoints: 100, energy: 5, attacks: 1, energyPerAttack: 4);
            game.AddUnit(player1, commander, 10, 10);
            game.AddUnit(player2, commander, -10, -10);
            game.Start();
            this.game = game;
        }

        [Test()]
        public void IsGameStarted()
        {
            Assert.AreEqual(0, game.CurrentTurn);
            Assert.NotNull(game.CurrentPlayer);
        }

        [Test()]
        public void IsUnitsAdded()
        {
            Assert.AreEqual(2, game.Units.Count);
            Assert.AreEqual(2, game.Players.Count);
            Assert.AreEqual(1, game.Players[0].Units.Count);
            Assert.AreEqual(1, game.Players[1].Units.Count);
            Assert.AreEqual("Commander", game.Players[0].Units[0].UnitType.Name);
            Assert.AreEqual("Commander", game.Players[1].Units[0].UnitType.Name);
        }

        [Test()]
        public void IsUnitMoved()
        {
            var unit = game.Units.First();
            game.MoveUnit(unit, 9, 8);
            Assert.AreEqual(2, unit.CurrentEnergy);
        }


        [Test()]
        public void IsUnitAttacked()
        {
            var attacker = game.Units[0];
            var defender = game.Units[1];
            Assert.AreEqual(100, defender.CurrentHitpoints);
            Assert.AreEqual(1, attacker.AttacksLeft);
            Assert.AreEqual(5, attacker.CurrentEnergy);
            game.OrderUnitToAttack(attacker, defender);
            Assert.AreEqual(60, defender.CurrentHitpoints);
            Assert.AreEqual(0, attacker.AttacksLeft);
            Assert.AreEqual(5, attacker.CurrentEnergy);
            game.OrderUnitToAttack(attacker, defender);
            Assert.AreEqual(20, defender.CurrentHitpoints);
            Assert.AreEqual(0, attacker.AttacksLeft);
            Assert.AreEqual(1, attacker.CurrentEnergy);
        }

        [Test()]
        public void TestIfTurnHasEnded()
        {
            var attacker = game.CurrentPlayer.Units[0];
            var defender = game.Players.First(p=>p != game.CurrentPlayer).Units[0];
            Assert.AreEqual(100, defender.CurrentHitpoints);
            Assert.AreEqual(1, attacker.AttacksLeft);
            Assert.AreEqual(5, attacker.CurrentEnergy);
            game.OrderUnitToAttack(attacker, defender);
            Assert.AreEqual(60, defender.CurrentHitpoints);
            Assert.AreEqual(0, attacker.AttacksLeft);
            Assert.AreEqual(5, attacker.CurrentEnergy);
            game.OrderUnitToAttack(attacker, defender);
            Assert.AreEqual(20, defender.CurrentHitpoints);
            Assert.AreEqual(0, attacker.AttacksLeft);
            Assert.AreEqual(1, attacker.CurrentEnergy);

            game.EndTurn();
            Assert.AreEqual(1, game.CurrentTurn);
            Assert.AreEqual(false, (game.CurrentPlayer == attacker.Player));

            game.EndTurn();
            Assert.AreEqual(2, game.CurrentTurn);
            Assert.AreEqual(true, (game.CurrentPlayer == attacker.Player));
            Assert.AreEqual(1, attacker.AttacksLeft);
            Assert.AreEqual(5, attacker.CurrentEnergy);
        }
    }
}