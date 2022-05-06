using System;
using System.Text.RegularExpressions;

namespace LostArkLogger
{
	public class DamageMeterRow
	{
		public float highestDamage;
		public string skillId;
		public DateTime dmgStart;
		public long dmgPerSec;
		public ulong totalDamage;
		public string Name { get; set; }
		public string DamageSum { 
			get
            {
				return String.Format("{0:n0}", totalDamage);
			}
		}
		public float DamagePercent { get; set; }
		public string DPS 
		{ 
			get 
			{
				return FormatNumber(dmgPerSec);
			} 
		}
		public string MaxHit
		{
			get
			{
				return String.Format("{0:n0}", highestDamage) + $" ({Regex.Replace(skillId, "(?!^)([A-Z])", " $1")})";
			}
		}

		static string FormatNumber(long num)
		{
			if (num >= 100000000)
			{
				return (num / 1000000D).ToString("0.#M");
			}
			if (num >= 1000000)
			{
				return (num / 1000000D).ToString("0.##M");
			}
			if (num >= 100000)
			{
				return (num / 1000D).ToString("0.#k");
			}
			if (num >= 10000)
			{
				return (num / 1000D).ToString("0.##k");
			}

			return num.ToString("#,0");
		}
	}
}
