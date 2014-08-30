using System;
using System.Collections.Generic;

namespace tbsserver
{
	public class UnitType
	{
		public Guid ID{ get; set; }

		public string Name{ get; set; }

		public double Damage{ get; set; }

		public double AttackSpeed{ get; set; }

		public double HitPoints{ get; set; }

		public UnitType(string name, double damage, double attackSpeed, double hitPoints){
			this.Name = name;
			this.Damage = damage;
			this.AttackSpeed = attackSpeed;
			this.HitPoints = hitPoints;
		}

	}
}

