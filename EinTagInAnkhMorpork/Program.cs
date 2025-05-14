namespace EinTagInAnkhMorpork
{
    internal class Program
    {
		static void Main(string[] args)
		{	// 	Konfiguriert die Console auf UTF-8 für die Korrekte Darstellung von Unicode-Zeichen. 
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			try
			{
				Textausgabe fenster = new Textausgabe("C:/Users/micha/OneDrive/Desktop/LuGProbeProjekt/StartProjekt/EinTagInAnkhMorpork/Content/ContentFenster.txt");
				fenster.ScheibTextWieSchreibmaschine(50);
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
			
			

			SpielStarten();
			Console.ReadKey();
		}
		// Methode zum Spielstart
		public static void SpielStarten()
		{

			bool spielen = true;

			while (spielen)
			{
				// ´Möchte man spielen? Noch offen ob sinnvoll
				Console.WriteLine("Möchten Sie spielen?");
				string? antwort = Console.ReadLine();

				Console.Clear();

				// Entscheidung, ob man Spielen will, wenn ja, spurng auf laden oder neues Spiel, ansonsten Wirt Programm beendet.
				if (antwort == "ja")
				{
					Console.WriteLine("Möchten sie einen Spielstand laden oder ein neues Spiel starten?");
					string? neuesSpiel = Console.ReadLine();

					switch (neuesSpiel)
					{
						case "laden":
							Console.WriteLine("Gespeichertes Spiel wird geladen");
							Console.ReadKey();
							break;
						case "neu":
							Console.WriteLine("Neues Spiel wird erstellt");
							Console.ReadKey();
							CharakterAuswahl();
							break;
						default:
							break;
					}
				}
				else
				{
					Environment.Exit(0);
				}


			}
		}

		public static void CharakterAuswahl()
		{
			Console.WriteLine("Wähle einen Charakter: (K)arotte, (M)umm oder (N)obby");

			string? auswahlSpieler = Console.ReadLine();

			switch (auswahlSpieler)
			{
				case "k":
					Hauptcharakter karotte = new("Karotte Eisengieserson", 100, 90, 80, 90, null, null, null, null);
					Console.WriteLine($"\t{karotte.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(karotte);
					break;
				case "m":
					Hauptcharakter mumm = new("Samuel Mumm", 90, 80, 70, 80, null, null, null, null);
					Console.WriteLine($"\t{mumm.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(mumm);
					break;
				case "n":
					Hauptcharakter nobby = new("Nobby Nobbs", 20, 40, 90, 60, null, null, null, null);
					Console.WriteLine($"\t{nobby.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(nobby);
					break;
				default:
					break;
			}
		}

	}
}
