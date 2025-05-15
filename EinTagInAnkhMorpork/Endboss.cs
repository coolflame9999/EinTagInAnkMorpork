using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	internal class Endboss : Gegner
	{
		public string Spezialattacke { get; set; }

		public Endboss(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, int schaden, string laesstGegenstandFallen, string spezialattacke) : base(name, lebenspunkte, staerke, geschick, intelligenz, schaden, laesstGegenstandFallen)
		{
			Spezialattacke = spezialattacke;
		}

		public override void Angreifen()
		{
			base.Angreifen();
		}
		public override bool SchadenErhalten()
		{
			return base.SchadenErhalten();
		}
	}
}
