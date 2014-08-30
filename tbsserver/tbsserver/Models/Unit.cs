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
        public int CurrentEnergy{ get; set; }

		public Unit(UnitType unitType, int positionX, int positionY)
		{
			this.UnitType = unitType;
			this.CurrentHitpoints = UnitType.HitPoints;
            this.CurrentEnergy = UnitType.Energy;
			this.PositionX = positionX;
			this.PositionY = positionY;
		}

        public void Move(int positionX, int positionY)
        {
            SpendEnergy(positionX, positionY);
            PositionX = positionX;
            PositionY = positionY;
        }

        private void SpendEnergy(int positionX, int positionY)
        {
            var deltaX = this.PositionX - positionX;
            var deltaY = this.PositionY - positionY;
            var energySpent = Math.Abs(deltaX) + Math.Abs(deltaY);
            CurrentEnergy -= energySpent;
        }
	}


}

