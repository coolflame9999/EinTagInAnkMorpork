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
			return $"Name: {Name ?? "Nicht befüllt"}, Lebenspunkte: {Lebenspunkte?.ToString() ?? "Nicht.befüllt"}, Stärke: {Staerke?.ToString() ?? "Nicht befüllt"}, " +
				   $"Geschick: {Geschick?.ToString() ?? "Nicht befüllt"}, Intelligenz: {Intelligenz?.ToString() ?? "Nicht befüllt"}, " +
				   $"Inventar: {Inventar ?? "Nicht befüllt"}, Ausrüstungsslot 1: {AusruestungsslotEins ?? "Nicht befüllt"}, Ausrüsturngsslot 2: {AusruestungsslotZwei ?? "Nicht befüllt"}";
		}
	}
}