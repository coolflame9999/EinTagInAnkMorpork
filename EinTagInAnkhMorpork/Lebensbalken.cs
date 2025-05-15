using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	internal class Lebensbalken
	{
		
		public int VolleLebenspunkte {  get; private set; }
		public int AktuelleLebenspunkte {  get; private set; }

		public int PunktProHerz {  get; private set; }
		// Setzt beide Eigenschaften auf den Wert des eingegebenen Parameters.
		public Lebensbalken(int vollerLebensbalken, int punktProHerz = 10) // Lebenspunkte pro Herz
		{
			VolleLebenspunkte = vollerLebensbalken;
			AktuelleLebenspunkte = vollerLebensbalken;
			PunktProHerz = punktProHerz;
		}
		 // Fügt Schaden hinzu
		public void SchadenErhalten(int schaden)
		{
			AktuelleLebenspunkte -= schaden;
			if (AktuelleLebenspunkte < 0)
				AktuelleLebenspunkte = 0;
		}
		   // Heilt den Lebensbalken
		public void Heilen(int heilung)
		{
			AktuelleLebenspunkte += heilung;
			if (AktuelleLebenspunkte > VolleLebenspunkte)
				AktuelleLebenspunkte = VolleLebenspunkte;
		}
		   // Darstellung des Lebensbalken in Herzform
		public string HerzenErstellen()
		{
			//Menge der Herzen, die angezeigt werden sollen
			int maximaleHerzen = VolleLebenspunkte / PunktProHerz;
			if (VolleLebenspunkte % PunktProHerz != 0)
				maximaleHerzen++;										

			int gefuellteHerzen = AktuelleLebenspunkte / PunktProHerz;
			if (AktuelleLebenspunkte % PunktProHerz !=0)
				gefuellteHerzen++;

			int leereHerzen = maximaleHerzen - gefuellteHerzen;

			string volleHerzen =new string('\u2665', gefuellteHerzen);
			string leereHerzenStr = new string('\u2661', leereHerzen);

			int startX = Console.WindowWidth - (volleHerzen.Length + leereHerzenStr.Length) - 10;

			Console.SetCursorPosition(startX, Console.CursorTop);

			return volleHerzen + leereHerzenStr;

		}
	}
}
