using System;
using System.Collections.Generic;

namespace tbsserver
{
	public class Unit
	{
		public Guid ID { get; set; }
		public UnitType UnitType { get; set; }
		public Game Game{ get; set; }
		public Player Player{ get; set; }
		public int PositionX{ get; set; }
		public int PositionY{ get; set; }
		public double CurrentHitpoints{ get; set; }

		public Unit(UnitType unitType, int positionX, int positionY)
		{
			this.UnitType = unitType;
			this.CurrentHitpoints = UnitType.HitPoints;
			this.PositionX = positionX;
			this.PositionY = positionY;
		}

	}


}

