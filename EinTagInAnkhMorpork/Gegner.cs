using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{	 // Ableitung von LebewesenMitLebenUndSchaden
	internal class Gegner : LebewesenMitLebenUndSchaden
	{	 //Bestimmter Goldbertrag
		private int laesstGoldFallen = 0;
		

		// Bestimmte Gegenstände
		public string? LaesstGegenstandFallen {  get; set; }
		public Gegner(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, int schaden, string? laesstGegenstandFallen) : base(name, lebenspunkte,staerke, geschick, intelligenz, schaden)
		{
		   LaesstGegenstandFallen = laesstGegenstandFallen;
		   
		}
		// Schaden austeilen
		public void Angreifen(Hauptcharakter ziel)
		{
			Console.WriteLine($"{Name} greift {ziel.Name} an und verursacht {Schaden} Schaden!");
			ziel.ErhalteSchaden(Schaden);
		}

		// Schaden erhalten
		public override void ErhalteSchaden(int schaden)
		{
			// Schadenswert von den Lebenspunkten abziehen
			Lebenspunkte -= schaden;

			// Sicherstellen, dass die Lebenspunkte nicht unter 0 fallen
			if (Lebenspunkte < 0)
				Lebenspunkte = 0;

			Console.WriteLine($"{Name} erleidet {schaden} Schaden und hat nun {Lebenspunkte} Lebenspunkte.");

			// Falls die Lebenspunkte 0 oder weniger erreichen, wurde der Charakter besiegt
			if (Lebenspunkte <= 0)
			{
				Console.WriteLine($"{Name} wurde besiegt!");
			}
		}
		 // Parameter die angezeigt werden sollen
		public override string ToString()
		{
			int breiteTotal = Console.WindowWidth;
			string linie1 = $" Name:{Name ?? "Nicht befüllt"}";
			string linie2 = $"Lebenspunkte:{Lebenspunkte.ToString() ?? "Nicht.befüllt"}";
			string linie3 = $"Stärke:{Staerke.ToString() ?? "Nicht befüllt"}";
			string linie4 = $"Geschick:{Geschick.ToString() ?? "Nicht befüllt"}";
			string linie5 = $"Intelligenz:{Intelligenz.ToString() ?? "Nicht befüllt"}";
			


			 // Formatierung für die Ausgabe in der Konsole.
			return linie1.PadLeft(breiteTotal - 2) + "\n" +
					linie2.PadLeft(breiteTotal - 5) + "\n" +
					linie3.PadLeft(breiteTotal - 4) + "\n" +
					linie4.PadLeft(breiteTotal - 4) + "\n" +
					linie5.PadLeft(breiteTotal - 4);
				
		}






	}
	
}
