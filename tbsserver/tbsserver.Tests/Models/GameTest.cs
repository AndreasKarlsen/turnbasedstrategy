using NUnit.Framework;
using System;

namespace tbsserver.Tests
{
	[TestFixture ()]
	public class GameTest
	{
		private Game game;

		[TestFixtureSetUp] 
		public void Init()
		{
			Console.WriteLine ("lol");
			var player1 = new Player ("Thomas");
			var player2 = new Player ("Andreas");
			var game = new Game (player1);
			game.AddPlayer (player2);
			var commander = new UnitType ("Commander", 20, 2, 100);
			game.AddUnit (player1, commander, 10, 10);
			game.AddUnit (player2, commander, -10, -10);
			game.Start ();
			this.game = game;
		}

		[Test ()]
		public void IsGameStarted ()
		{
			Assert.AreEqual (game.CurrentTurn, 0);
			Assert.NotNull (game.CurrentPlayer);
		}

		[Test()]
		public void IsUnitsAdded()
		{
			Assert.AreEqual (game.Units.Count, 2);
			Assert.AreEqual (game.Players.Count, 2);
			Assert.AreEqual (game.Players [0].Units.Count, 1);
			Assert.AreEqual (game.Players [1].Units.Count, 1);
		}


	}
}