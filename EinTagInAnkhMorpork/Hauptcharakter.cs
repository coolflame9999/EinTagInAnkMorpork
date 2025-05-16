using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{

	// Hauptcharakter Klasse Ableitung aus LebewesenMitLebenUndSchaden.
		// Hat Leben und kann Schaden austeilen und erhalten, kann Items ausrüsten und hat Inventar
	internal class Hauptcharakter : LebewesenMitLebenUndSchaden
	{

		public int? Anzahl { get; set; }
		public int? Gold { get; private set; }
		public string? AusruestungsslotEins { get; set; }
		public string? AusruestungsslotZwei { get; set; }

		private List<Item> _inventar;


		public Hauptcharakter(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, int schaden, int? anzahl, int? gold, string ausruestungsslotEins, string ausruestungsslotZwei) : base(name, lebenspunkte, staerke, geschick, intelligenz, schaden)
		{

			Anzahl = anzahl;
			Gold = gold;
			AusruestungsslotEins = ausruestungsslotEins;
			AusruestungsslotZwei = ausruestungsslotZwei;
			_inventar = new List<Item>();
		}

		// Item nehmen und entfernen von Items und Anzeige des Inventars
		public void ItemHinzufuegen(Item item)
		{
			_inventar.Add(item);
		}
		
		public bool ItemEntfernen(Item item)
		{
			return _inventar.Remove(item);
		}

		// Sammelt alle Einträge aus der Liste _inventar erstellt daraus Zeichenketten und gibt dies am Ende als einen String aus
		public string InventarAnzeigen()
		{
			if (_inventar.Count == 0)
				return "Keine items vorhanden";
			StringBuilder itemSb = new StringBuilder();
			bool first = true;
			foreach (Item item in _inventar)
			{
				if (!first)
					itemSb.Append(", ");
				itemSb.Append(item.Name);
				first = false;

				
			}
			return itemSb.ToString();
		}

		// Gold hinzufügen und entfernen
		public void GoldHinzufuegen(int menge)
		{
			if (menge < 0)
				throw new ArgumentException("Betrag muss positiv sein.", nameof(menge));
			Gold += menge;
		}

		public bool GoldAusgeben(int menge)
		{
			if (menge < 0)
				throw new ArgumentException("Betrag muss positiv sein", nameof(menge));
			if (Gold >= menge)
			{
				Gold -= menge;
				return true;
			}
			return false;
		}

		// Schaden austeilen und erhalten.
		public void Angreifen(Gegner ziel)
		{
			Console.WriteLine($"{Name} greift {ziel.Name} an und verursacht {Schaden} Schaden!");
			ziel.ErhalteSchaden(Schaden);
		}

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
		 // Formatierte Ausgabe der Parameter in der Konsole.
		public override string ToString()
		{
			int breiteTotal = Console.WindowWidth;
			string linie1 = $" Name:{Name ?? "Nicht befüllt"}";
			string linie2 = $"Lebenspunkte:{Lebenspunkte.ToString() ?? "Nicht.befüllt"}";
			string linie3 = $"Stärke:{Staerke.ToString() ?? "Nicht befüllt"}";
			string linie4 = $"Geschick:{Geschick.ToString() ?? "Nicht befüllt"}";
			string linie5 = $"Intelligenz:{Intelligenz.ToString() ?? "Nicht befüllt"}";
			string linie6 = $"Gold: {Gold.ToString() ?? "Leer"}";
			string linie7 = $"Ausrüstungsslot 1:{AusruestungsslotEins ?? "Nicht befüllt"}";
			string linie8 = $"Ausrüstungsslot 2:{AusruestungsslotZwei ?? "Nicht befüllt"}";



			return linie1.PadLeft(breiteTotal - 2) + "\n" +
					linie2.PadLeft(breiteTotal - 5) + "\n" +
					linie3.PadLeft(breiteTotal - 4) + "\n" +
					linie4.PadLeft(breiteTotal - 4) + "\n" +
					linie5.PadLeft(breiteTotal - 4) + "\n" + "\n" + "\n" +
					linie6.PadLeft(breiteTotal - 4) + "\n" +
					linie7.PadLeft(breiteTotal - 4) + "\n" +
					linie8.PadLeft(breiteTotal - 4) + "\n";
					
		}
	}
}