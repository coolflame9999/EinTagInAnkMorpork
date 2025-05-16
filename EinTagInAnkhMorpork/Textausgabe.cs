using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	// Textausgabe Klasse
	internal class Textausgabe
	{
		// Nur Lesezugriff: Der geladene Text
		private readonly string _text;

		private const int LeftMarginSpaces = 4;

		private const int RightMarginSpaces = 2;

		// Konstruktor: Lädt den Text aus der angegebenen Datei
		public Textausgabe(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException("Datei nicht gefunden.", filePath);

			_text = File.ReadAllText(filePath);
		}

		// Diese Methode kombiniert den Schreibmaschinen-Effekt und seitenweises Umblättern.
		// Es wird seitenweise (jeweils das obere Drittel der Konsole) ausgegeben.
		public void SchreibTextWieSchreibmaschineOberesDrittel(string text, int pauseInMillisekunden = 50)
		{
			int maxBreite = Console.WindowWidth;
			int availableWidth = maxBreite - LeftMarginSpaces - RightMarginSpaces; ;
			int maxZeilen = Console.WindowHeight / 3;

			// Erzeuge einen umgebrochenen Text, der sich an der Konsole orientiert.
			string umbruchText = Zeilenumbruch(text, availableWidth);
			// Teile den umgebrochenen Text in einzelne Zeilen
			string[] zeilen = umbruchText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

			int aktuelleZeile = 0; // Index der aktuellen Zeile

			// Solange noch Zeilen vorhanden sind:
			while (aktuelleZeile < zeilen.Length)
			{
				Console.Clear(); // Bildschirm leeren, damit nur die aktuelle Seite sichtbar ist
				int zeilenAufSeite = 0;

				Console.WriteLine();
				Console.WriteLine();

				// Auf dieser Seite werden maximal 'maxZeilen' Zeilen ausgegeben
				while (zeilenAufSeite < maxZeilen && aktuelleZeile < zeilen.Length)
				{
					// Gib die aktuelle Zeile Zeichen für Zeichen aus (Schreibmaschinen-Effekt)
					string aktuelleZeileText = zeilen[aktuelleZeile];
					Console.SetCursorPosition(LeftMarginSpaces, Console.CursorTop);
					foreach (char b in aktuelleZeileText)
					{
						Console.Write(b);
						Thread.Sleep(pauseInMillisekunden);
					}
					Console.WriteLine();
					zeilenAufSeite++;
					aktuelleZeile++;
				}

				// Falls noch weitere Zeilen vorhanden sind, Hinweis anzeigen und auf Tastendruck warten
				if (aktuelleZeile < zeilen.Length)
				{
					Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tWeiter");
					Console.ReadKey(true);
				}
			}
		}

		// public Methode FindeTextAbschnitt()
		public void FindeTextAbschnitt(string startMarker, string endMarker, bool enthaeltMarker = false, int pauseInMillisekunden = 50)
		{
			string[] zeilen = _text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
			StringBuilder abschnittSb = new StringBuilder();
			bool auslesen = false;

			foreach (string zeile in zeilen)
			{
				if (!auslesen && zeile.Contains(startMarker))
				{
					auslesen = true;
					if (enthaeltMarker)
						abschnittSb.Append(zeile);
					continue;

				}

				if (auslesen)
				{
					if (zeile.Contains(endMarker))
					{
						if (enthaeltMarker)
							abschnittSb.Append(zeile);
						break;
					}
					abschnittSb.AppendLine(zeile);
				}
			}
			SchreibTextWieSchreibmaschineOberesDrittel(abschnittSb.ToString(), pauseInMillisekunden);
		}

		// Private Methode für den einfachen Wortumbruch.
		// Der Text wird in Absätze und Wörter aufgeteilt und so in Zeilen formatiert, 
		// dass die maximale Breite (maxBreite) nicht überschritten wird.
		private string Zeilenumbruch(string text, int maxBreite)
		{
			// Aufteilen in Absätze (bereits vorhandene Zeilenumbrüche werden beachtet)
			string[] absaetze = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
			StringBuilder ergebnis = new StringBuilder();



			foreach (string absatz in absaetze)
			{


				// Aufteilen jedes Absatzes in Wörter
				string[] woerter = absatz.Split(' ');
				// Verwende einen StringBuilder (Klasse für das zusammenfügen oder verändern von Zeichenfolgen) als Puffer für die aktuelle Zeile
				StringBuilder zeile = new StringBuilder();

				foreach (string wort in woerter)
				{
					// Prüfen: Ist das Hinzufügen des nächsten Wortes (plus eventuell Leerzeichen) 
					// länger als die maximale Breite?
					if (zeile.Length + (zeile.Length > 0 ? 1 : 0) + wort.Length > maxBreite)
					{
						// Zeile abschließen und zum Ergebnis hinzufügen
						ergebnis.AppendLine(zeile.ToString());
						zeile.Clear();
					}

					// Falls die Zeile bereits Inhalt hat, ein Leerzeichen hinzufügen
					if (zeile.Length > 0)
						zeile.Append(" ");

					// Das aktuelle Wort zur Zeile hinzufügen
					zeile.Append(wort);
				}
				// Den restlichen Zeileninhalt anhängen

				ergebnis.AppendLine(zeile.ToString());
			}


			return ergebnis.ToString();
		}
	}
}
