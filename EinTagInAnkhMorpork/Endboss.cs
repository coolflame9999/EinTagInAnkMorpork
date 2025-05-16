using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{	 // Ableitung von Gegner, da es nur ein größerer Gegner mit mehr Leben ist.
	internal class Endboss : Gegner
	{
		public string Spezialattacke { get; set; }

		public Endboss(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, int schaden, string laesstGegenstandFallen, string spezialattacke) : base(name, lebenspunkte, staerke, geschick, intelligenz, schaden, laesstGegenstandFallen)
		{
			Spezialattacke = spezialattacke;
		}

		/*public override void Angreifen()
		{
			base.Angreifen();
		}
		public override bool SchadenErhalten()
		{
			return base.SchadenErhalten();
		}*/
	}
}
