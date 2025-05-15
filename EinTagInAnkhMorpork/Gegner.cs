using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	internal class Gegner : LebewesenMitLebenUndSchaden
	{
		private int laesstGoldFallen = 0;


		public string? LaesstGegenstandFallen {  get; set; }
		public Gegner(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, int schaden, string? laesstGegenstandFallen) : base(name, lebenspunkte,staerke, geschick, intelligenz, schaden)
		{
		   LaesstGegenstandFallen = laesstGegenstandFallen;
		   
		}

		public override void Angreifen()
		{
			throw new NotImplementedException();
		}

		public override bool SchadenErhalten()
		{
			throw new NotImplementedException();
		}
	}
}
