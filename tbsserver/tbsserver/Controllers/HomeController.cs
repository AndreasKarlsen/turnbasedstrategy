using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace tbsserver.Controllers
{
	public class HomeController : Controller
	{
        private Game game;

		public ActionResult Index ()
		{
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";

            Console.WriteLine ("lol");
            var player1 = new Player ("Thomas");
            var player2 = new Player ("Andreas");
            var game = new Game (player1);
            game.AddPlayer (player2);
            var commander = new UnitType ("Commander", 20, 2, 100, 5);
            game.AddUnit (player1, commander, 10, 10);
            game.AddUnit (player2, commander, -10, -10);
            game.Start ();
            this.game = game;

            ViewData["Player1Name"] = game.Players[0].Name;

			return View ();
		}
	}
}

