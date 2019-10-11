using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Begin:
            Console.WriteLine();
            Console.WriteLine("               Profilrechner Rechteckprofil");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                   Querschnittsflaeche");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.Write("   Eingabe Breite in mm: ");
            string eingabebreite = Console.ReadLine();
            double breite;
            bool echtebreite = double.TryParse(eingabebreite, out breite);                       //True wenn Zahl eingegeben wird False wenn nicht.
            if(echtebreite == false || breite <= 0)                                              //Prüfung ob Zahl eingegeben wurde oder die Zahl kleiner gleich 0 ist
                {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("                 !Fehler bei der Breite!");
                Console.WriteLine("----------------------------------------------------------");
                }
            Console.WriteLine();
            Console.Write("   Eingabe Hoehe in mm: ");
            string eingabehoehe = Console.ReadLine();
            double hoehe; 
            bool echtehoehe = double.TryParse(eingabehoehe, out hoehe);                          //True wenn Zahl eingegeben wird False wenn nicht.
            if(echtehoehe == false || hoehe <= 0)                                                //Prüfung ob Zahl eingegeben wurde oder die Zahl kleiner gleich 0 ist
                {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("                 !Fehler bei der Hoehe!");
                Console.WriteLine("----------------------------------------------------------");
                }
            Console.WriteLine();
            double qflaeche = breite * hoehe;
            if (breite < 0 & hoehe < 0)
                {
                Console.Write("Hoehe und Breite sind negativ. Trotzdem darstellen? J/N:");       // Falls beide Werte negativ sind kommt ein positives Ergebnis raus.
                ConsoleKeyInfo eingabekey = Console.ReadKey();                                   // Ist das der Fall kann der Benutzer sich entscheiden ob es weitergeht.
                Console.WriteLine();
                if (eingabekey.Key == ConsoleKey.N)
                    {
                    Console.WriteLine();
                    goto Finish;
                    }
                }
            if (qflaeche <= 0)                                                                    // Prüfung ob Flaeche real ist. Flaechen sind immer Positiv und nicht null.
                {
                Console.WriteLine ("   Wert nicht real.");
                Console.WriteLine();
                }
            else 
                {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.Write ("Querschnittsflaeche: ");
                Console.Write (qflaeche);
                Console.WriteLine ("mm²");
                Console.WriteLine ();
                }
            Finish:
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press b to return");
            Abfrage:
            ConsoleKeyInfo zurueck = Console.ReadKey();                                            // Tastendruck um neu zu starten
            if (zurueck.Key == ConsoleKey.B)
                {
                Console.Clear();
                goto Begin;
                }
            else 
                {
                goto Abfrage;
                }

        }
    }
}
