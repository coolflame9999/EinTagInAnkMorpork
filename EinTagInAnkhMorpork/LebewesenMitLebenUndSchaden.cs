using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	// Abstracte Klasse, die Eigenschaften und Lebenspunkte haben, sowie Schaden verursachen und erhalten können
	internal abstract class LebewesenMitLebenUndSchaden : Lebewesen
	{

		public int Lebenspunkte { get; set; }

		public int Staerke { get; set; }

		public int Geschick { get; set; }
		public int Intelligenz { get; set; }

		public Lebensbalken Lebensanzeige { get; private set; }

		public LebewesenMitLebenUndSchaden(string name, int lebenspunkte, int staerke, int geschick, int intelligenz) : base(name)
		{
			Lebenspunkte = lebenspunkte;
			Staerke = staerke;
			Geschick = geschick;
			Intelligenz = intelligenz;
							 
	
			Lebensanzeige = new Lebensbalken(lebenspunkte);
			
		}

		

		public abstract void VerursacheSchaden();
		public void SchadenErhalten(int schaden)
		{
			Lebenspunkte -= schaden;
		}

		

	}

}
