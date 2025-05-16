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

		public int Schaden {  get; protected set; }

		public Lebensbalken Lebensanzeige { get; private set; }

		public LebewesenMitLebenUndSchaden(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, int schaden) : base(name)
		{
			Schaden = schaden;
			Lebenspunkte = lebenspunkte;
			Staerke = staerke;
			Geschick = geschick;
			Intelligenz = intelligenz;
							 
			// Erstellen eines Objekts Lebensbalken
			Lebensanzeige = new Lebensbalken(lebenspunkte);
			
		}

		

		public void Angreifen(LebewesenMitLebenUndSchaden lebewesenMitLebenUndSchaden)
		{
			Console.WriteLine($"{Name} greift {lebewesenMitLebenUndSchaden.Name} an und verursacht {Schaden} Schaden");
			lebewesenMitLebenUndSchaden.ErhalteSchaden(Schaden);
		}

		public virtual void ErhalteSchaden(int schaden)
		{

			Lebenspunkte -= schaden;

		
			if (Lebenspunkte < 0)
				Lebenspunkte = 0;

			Console.WriteLine($"{Name} erleidet {schaden} Schaden und hat nun {Lebenspunkte} Lebenspunkte.");

			
			if (Lebenspunkte <= 0)
			{
				Console.WriteLine($"{Name} wurde besiegt!");
			}
		}




	}

}
