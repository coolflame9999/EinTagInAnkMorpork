using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace EinTagInAnkhMorpork
{
	// Händlerklasse abgeleitet aus Lebewesen, Schaden und Lebenspunkte für Händler sind nicht vorgesehen.
	internal class Haendler : Lebewesen
	{

		// Die mit ? markierten Eigenschaften können den Wert null annehmen.

		public int? Gold { get; private set; }

		private List<Item> _inventar;

		public Haendler(string name, int startgold) : base(name)
		{

			Gold = startgold;
			_inventar = new List<Item>();
		}

		

		 // Logic für das aus lesen einer beliebigen Inventar-Json-Datei
		public void LadeInventarAusJson(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException("Inventar-JSON-Datei nicht gefunden", filePath);

			string jsonInhalt  = File.ReadAllText(filePath);

			List<Item>? items = JsonSerializer.Deserialize<List<Item>>(jsonInhalt);

			if (items == null)
				throw new Exception("Deserialisierung schlug fehl.");

			 _inventar.AddRange(items);

		}

		// Hinzfügen und Entfernen vonn Items
		public void ItemHinzufuegen(Item item)
		{
			_inventar.Add(item);
		}

		public bool ItemEntfernen(Item item)
		{
			return _inventar.Remove(item);
		}

		 // Aufruf des Inventars
		public string ZeigeInventar()
		{
			if (_inventar.Count == 0)
				return "Kein Item vorhanden";

			StringBuilder itemSb = new StringBuilder();
			for (int i = 0; i < _inventar.Count; i++)
			{
				itemSb.Append(_inventar[i].ToString());
				if (i < _inventar.Count - 1)
					itemSb.Append(", ");
			}
			return itemSb.ToString();

		}
		// Gold geben und nehmen
		public void GoldHinzufuegen(int menge)
		{
			if (menge < 0)
				throw new ArgumentException("Betrag muss positiv sein.", nameof(menge));

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

		// Ausgabe der Parameter in Konsole
		public override string ToString()
		{
			return $"Händler: {Name}\n" +
				   $"Gold: {Gold}\n" +
				   $"Inventar: {ZeigeInventar()}";
		}
	}
}