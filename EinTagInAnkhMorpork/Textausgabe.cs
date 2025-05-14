using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EinTagInAnkhMorpork
{
	internal class Textausgabe
	{	 // Nur lesezugriff
		private readonly string _text;
		 // Text auslesen aus der angegebenen Datei
		public Textausgabe(string filePath)
		{
			if (!File.Exists(filePath))

				throw new FileNotFoundException("Datei nicht gefunden.", filePath);
			_text = File.ReadAllText(filePath);
		}
				// Schreibmaschinen-Effekt, Anpassung des Zeilenumbruch an die Breite der Konsole
		public void ScheibTextWieSchreibmaschine(int pauseInMillisekunden = 50)
		{
			int maxBreite = Console.WindowWidth;
			  // Einfacher Wortumbruch !!! nochmal drüber gehen, da Wort abgehackt wird!!
			string umbruchText = Zeilenumbruch(_text, maxBreite);
			   // Ausgabe Zeichen für Zeichen, mit verzögerung
			foreach (char b in umbruchText)
			{
				Console.Write(b);
				Thread.Sleep(pauseInMillisekunden);
			}
		}
				  // Methode übernimmt den Wortumbruch
				  // teilt den Text in Absätze und dann in Wörter.
				  // Sammelt Wörter bzw. Zeiche, bis die breite der Konsole
				  // erreicht ist und springt in eine neue Zeile
		private string Zeilenumbruch(string text, int maxBreite)
		{	// Teilt den Text in Absätze (Zeilenumbrüche werden respektiert
			string[] absaetze = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
			StringBuilder ergebnis = new StringBuilder();

			foreach (string absatz in absaetze)
			{	 // Teilt jeden Absatz in Wörter
				string[] woerter = absatz.Split(' ');
					StringBuilder zeile = new StringBuilder();
				foreach (string wort in woerter)
				{

					// Falls das hinzufügen eines neuen Wortes (mit zusätzlichem Leerzeichen) die maximale Breite überschreitet
					// wird der aktuelle Zeilepuffer ausgegeben.
					if (zeile.Length + wort.Length + (zeile.Length > 0 ? 1 : 0) > maxBreite)
					{

						ergebnis.AppendLine(zeile.ToString());
						zeile.Clear();
					}

					if (zeile.Length > 0)
						zeile.Append(" ");

					zeile.Append(wort);
				}
				// Fertige Zeile abschließen.
				ergebnis.AppendLine(zeile.ToString());
			}

			return ergebnis.ToString();
		}
		
	}
}
