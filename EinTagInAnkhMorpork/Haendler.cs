using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	// Händlerklasse
	internal class Haendler : Lebewesen
	{

		// Die mit ? markierten Eigenschaften können den Wert null annehmen.
		public string? ItemEins { get; set; }
		public string? ItemZwei { get; set; }
		public string? ItemDrei { get; set; }

		public int? Gold { get; set; }

		public Haendler(string name, string itemEins, string itemZwei, string itemDrei, int gold) : base(name)
		{
			ItemEins = itemEins;
			ItemZwei = itemZwei;
			ItemDrei = itemDrei;
			Gold = gold;
		}

		public void Verkaufen()
		{
			Console.WriteLine("Verkauft");
		}

		public void Kaufen()
		{
			Console.WriteLine("Gekauft");
		}

		// Null Handling mit dem ?? wird geprüft, ob die Eigenschaft befüllt ist, wenn nicht steht rechts ein Platzhaltertext.
		// Bei zahl-Datentypen müssen diese zuvor mit <EIGENSCHAFTSBEZEICHNER>?.ToString() Methode umgewandelt werden.
		public override string ToString()
		{
			return $"Name: {Name ?? "Nicht befüllt"}, Item 1: {ItemEins ?? "Nicht.befüllt"}, Item 2: {ItemZwei ?? "Nicht befüllt"}, " +
				   $"Item 3: {ItemDrei ?? "Nicht befüllt"}, Gold: {Gold?.ToString() ?? "Nicht befüllt"}";
		}
	}

}
