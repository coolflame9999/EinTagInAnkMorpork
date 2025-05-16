using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	//Basisklasse für alle Lebewesen
	internal abstract class Lebewesen
	{
		public string Name { get; protected set; }



		public Lebewesen(string name)
		{
			Name = name;

		}



	}

}
