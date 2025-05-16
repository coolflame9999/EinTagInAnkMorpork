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
			Handeln();
		

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
				Console.WriteLine("ja / nein");
				string? antwort = Console.ReadLine();

				Console.Clear();

				// Entscheidung, ob man Spielen will, wenn ja, spurng auf laden oder neues Spiel, ansonsten Wirt Programm beendet.
				if (antwort == "ja")
				{
					Console.WriteLine("Möchten sie einen Spielstand laden oder ein neues Spiel starten?");
					Console.WriteLine("neu / laden");
					string? neuesSpiel = Console.ReadLine();

					
					switch (neuesSpiel)
					{
						case "laden":
							Console.WriteLine("Gespeichertes Spiel wird geladen");
							Console.ReadKey();
							break;
						case "neu":
							TextAusgeben("INTRO", "INTRO ENDE");
							Console.WriteLine("Neues Spiel wird erstellt");
							Console.ReadKey();
							CharakterAuswahl();
							break;
						default:
							break;
					}
				}
				else
				{	// Beendet Spiel
					Console.WriteLine("Spiel wird beendet.");
					Environment.Exit(0);
				}

			}
		}
		 // Erstellt Händler-Objekt und lädt Inventar aus Json-Datei
		public static void Handeln()
		{
			Haendler tmsidr = new("TMSIDR Schnapper", 100);
			Console.WriteLine(tmsidr.ToString());
			Console.WriteLine("\nHändler-Daten:");
		}
		// Auswahl des Charakters
		public static void CharakterAuswahl()
		{
			// Zwischenausgabe
			TextAusgeben("ALLE WACHRAUM", "ALLE WACHRAUM ENDE");

			Console.WriteLine("Wähle einen Charakter: (k)arotte, (m)umm oder (n)obby");

			// Auswahl des Charakters
			string? auswahlSpieler = Console.ReadLine();

			switch (auswahlSpieler)
			{	
				case "k":
					// Beginn mit der Figur
					TextAusgeben("KAROTTE WACHRAUM", "KAROTTE WACHRAUM ENDE");
					LadenDesCharakterPfads();

					break;
				case "m":

					Console.WriteLine("Nicht freigeschaltet");
					CharakterAuswahl();
					/*Hauptcharakter mumm = new("Sam", 90, 80, 70, 80, 10, null, null, "leer", "leer");
					Console.WriteLine($"\t{mumm.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(mumm);*/
					break;
				case "n":

					Console.WriteLine("Nicht freigeschaltet");
					CharakterAuswahl();
					/*Hauptcharakter nobby = new("Nobby", 20, 40, 90, 60, 10, null, null, "leer", "leer");
					Console.WriteLine($"\t{nobby.Lebensanzeige.HerzenErstellen()}");
					Console.WriteLine();
					Console.WriteLine(nobby);*/
					break;
				default:
					break;
			}
		}
		 // Textausgabe Methode Lädt Text aus Dokument und gibt den Text zwischen den Markern aus.
		public static void TextAusgeben(string startMarker, string endMarker)
		{
			try
			{

				Textausgabe fenster = new Textausgabe("./ContentFenster.txt");

				// Formatierte Ausgabe des Dokuments in TypeWriter Stil.
				fenster.FindeTextAbschnitt(startMarker, endMarker, false, 80);
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		// Lädt die benötigten Objekte und Ausgabe der in den Parametern festgelegten Werte.
		public static void LadenDesCharakterPfads()
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();

			// Erstellen der benötigten Objekte
			Hauptcharakter karotte = new("Karotte", 100, 90, 80, 90, 10, null, 100, "leer", "leer");
			Haendler tmsidr = new("Treib-mich-selbst-in-den-Ruin Schnapper", 100);
			Gegner ursula = new("Ursula", 150, 130, 80, 70, 13, null);

			Console.WriteLine($"\t{ursula.Lebensanzeige.HerzenErstellen()}");
			Console.WriteLine(ursula);
			Console.WriteLine($"\t{karotte.Lebensanzeige.HerzenErstellen()}");
			Console.WriteLine(karotte);
			Console.WriteLine();
			Console.WriteLine(tmsidr);
			try
			{	 // Laden des Inventars aus der JSon Datei
				tmsidr.LadeInventarAusJson("./inventar.json");

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
