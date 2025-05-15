using System.Collections.Concurrent;
using System.Data;
using System.Text.Json;
namespace EinTagInAnkhMorpork
{
    internal class Program
    {
		static void Main(string[] args)
		{   // 	Konfiguriert die Console auf UTF-8 für die Korrekte Darstellung von Unicode-Zeichen. 
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			SpielStarten();















			/*List<Item> inventar = new List<Item>()
			{
				new Item()  { Name = "Schwert", Preis = 50},
				new Item()  { Name = "Handschuhe", Preis = 60},
				new Item()  { Name = "Helm", Preis = 80},

			};

			JsonSerializerOptions options = new JsonSerializerOptions
			{
				WriteIndented = true
			};
			string jsonContent = JsonSerializer.Serialize(inventar, options);
			string filePath = @"C:\Users\micha\OneDrive\Desktop\LuGProbeProjekt\StartProjekt\EinTagInAnkhMorpork\bin\Debug\net9.0\inventar.json";

			File.WriteAllText(filePath, jsonContent);

			Console.WriteLine("JSON Datei wurde erfolgreich erstellt: " + filePath); ;
*/
			Haendler tmsidr = new("TMSIDR Schnapper", 100);
			Hauptcharakter karotte = new("Karotte", 100, 80, 40, 80, null, null, 50, "leer", "leer");

			

			Console.WriteLine("\nHändler-Daten:");
			Console.WriteLine(tmsidr.ToString());


			/*try
			{
				Textausgabe fenster = new Textausgabe("C:/Users/micha/OneDrive/Desktop/LuGProbeProjekt/StartProjekt/EinTagInAnkhMorpork/Content/ContentFenster.txt");
				string startMarker = "NOBBY";
				string endMarker = "NOBBY ENDE";
				fenster.FindeTextAbschnitt(startMarker, endMarker, false, 50);



			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
*/


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
							Intro();
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
					PfadKarotteVerlaesstStation();
					LadenDesCharakterPfads();
					
					break;
				case "m":
					Hauptcharakter mumm = new("Sam", 90, 80, 70, 80, null, null, null, "leer", "leer");
					Console.WriteLine($"\t{mumm.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(mumm);
					break;
				case "n":
					Hauptcharakter nobby = new("Nobby", 20, 40, 90, 60, null, null, null, "leer", "leer");
					Console.WriteLine($"\t{nobby.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(nobby);
					break;
				default:
					break;
			}
		} 
		public static void Intro()
		{
			try
			{
				Textausgabe fenster = new Textausgabe("C:/Users/micha/OneDrive/Desktop/LuGProbeProjekt/StartProjekt/EinTagInAnkhMorpork/Content/ContentFenster.txt");
				string startMarker = "INTRO";
				string endMarker = "INTRO ENDE";
				fenster.FindeTextAbschnitt(startMarker, endMarker, false, 50);



			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void PfadKarotteVerlaesstStation()
		{
			try
			{
				Textausgabe fenster = new Textausgabe("C:/Users/micha/OneDrive/Desktop/LuGProbeProjekt/StartProjekt/EinTagInAnkhMorpork/Content/ContentFenster.txt");
				string startMarker = "KAROTTE";
				string endMarker = "KAROTTE ENDE";
				fenster.FindeTextAbschnitt(startMarker, endMarker, false, 80);



			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public static void LadenDesCharakterPfads()
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Hauptcharakter karotte = new("Karotte", 100, 90, 80, 90, null, null, 100, "leer", "leer");
			Haendler tmsidr = new("Treib-mich-selbst-in-den-Ruin Schnapper", 100);
			Console.WriteLine($"\t{karotte.Lebensanzeige.HerzenErstellen()}");
			Console.WriteLine(karotte);
			Console.WriteLine();
			Console.WriteLine(tmsidr);
			try
			{
				tmsidr.LadeInventarAusJson(@"C:\Users\micha\OneDrive\Desktop\LuGProbeProjekt\StartProjekt\EinTagInAnkhMorpork\bin\Debug\net9.0\inventar.json");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Laden des Inventarts: " + ex.Message);
			}

			Console.WriteLine("Inventar:");
			Console.WriteLine(tmsidr.ZeigeInventar());

		}

	}
}
