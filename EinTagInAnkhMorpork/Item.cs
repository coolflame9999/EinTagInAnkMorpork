using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	// Item-Klasse Preis und Bezeichnung
	public class Item
	{
		public string Name { get; set; }
		public int Preis { get; set; }

		public Item(string name, int preis)
		{
			Name = name;
			Preis = preis;
		}

		public Item() { }

		public override string ToString()
		{
	
			return $"  {Name}  {Preis}";
			
		}
	}
}
