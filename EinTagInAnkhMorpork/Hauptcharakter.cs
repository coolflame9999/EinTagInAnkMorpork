using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{

	// Hauptcharakter Klasse
	internal class Hauptcharakter : LebewesenMitLebenUndSchaden
	{

		public string? Inventar { get; set; }
		public int? Anzahl { get; set; }
		public string? AusruestungsslotEins { get; set; }
		public string? AusruestungsslotZwei { get; set; }

		public Hauptcharakter(string name, int lebenspunkte, int staerke, int geschick, int intelligenz, string? inventar, int? anzahl, string? ausruestungsslotEins, string? ausruestungsslotZwei) : base(name, lebenspunkte, staerke, geschick, intelligenz)
		{
			Inventar = inventar;
			Anzahl = anzahl;
			AusruestungsslotEins = ausruestungsslotEins;
			AusruestungsslotZwei = ausruestungsslotZwei;
		}

		public override void VerursacheSchaden()
		{

		}

		public override string ToString()
		{
			return $" Name:\t\t{Name ?? "Nicht befüllt"}\n Lebenspunkte:\t{Lebenspunkte.ToString() ?? "Nicht.befüllt"}\n Stärke:\t{Staerke.ToString() ?? "Nicht befüllt"}\n " +
				   $"Geschick:\t{Geschick.ToString() ?? "Nicht befüllt"}\n Intelligenz:\t{Intelligenz.ToString() ?? "Nicht befüllt"}\n " +
				   $"\n Inventar:\t\t{Inventar ?? "Nicht befüllt"}\n Ausrüstungsslot 1:\t{AusruestungsslotEins ?? "Nicht befüllt"}\n Ausrüstungsslot 2:\t{AusruestungsslotZwei ?? "Nicht befüllt"}";
		}
	}
}