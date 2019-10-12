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
            Program p = new Program();
            int menue;

            do
            {
                Console.WriteLine();
                Console.WriteLine("                       Profilrechner");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("          Welches Profil wollen sie berechnen?");
                Console.WriteLine();
                Console.WriteLine("< 1 > Rechteckprofil");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Zum beenden des Programms drücken Sie 0");
                Console.WriteLine();
                Console.Write("Auswahl: ");
                menue = Convert.ToInt32(Console.ReadLine());
                
                if (menue == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("                      Rechteckprofil");
                    Console.WriteLine("----------------------------------------------------------");
                    p.Rechteckprofil();
                }
                else
                {
                    Console.WriteLine("Fehler bei der Eingabe");
                }

            } while (menue != 0);
            }

        void Rechteckprofil()
            {
            Program p = new Program();
            int menue;

            do
            {


                Console.WriteLine("              Was wollen Sie berechnen?");
                Console.WriteLine();
                Console.WriteLine("< 1 > Querschnittsflaeche");
                Console.WriteLine("< 2 > Flaechentraegheitsmoment");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Zum beenden des Programms drücken Sie 0");
                Console.WriteLine();
                Console.Write("Auswahl: ");
                menue = Convert.ToInt32(Console.ReadLine());
                if (menue == 1)
                {
                    p.Querschnittsflaeche();
                    menue = 0;
                }
                else if (menue == 2)
                    {
                    p.Flaechentraegheitsmoment();
                    }
                else
                {
                    Console.WriteLine("Fehler bei der Eingabe");
                }

            } while (menue != 0);
            }
            void Querschnittsflaeche()
            {


            BeginQuerschnittsflaeche:
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                      Rechteckprofil");
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
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine ("                  Flaeche nicht real.");
                }
            else 
                {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.Write ("   Querschnittsflaeche: ");
                Console.Write (qflaeche);
                Console.WriteLine ("mm²");
                Console.WriteLine ();
                }
            Finish:
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press B to go back to the main Menu");
            Console.WriteLine("Press R to calculate again");
            Console.WriteLine("Press ESC to exit Program");
            Returnbefehl:
            ConsoleKeyInfo zurueck = Console.ReadKey();                                            // Tastendruck um neu zu starten.
            if (zurueck.Key == ConsoleKey.B)
                {
                Console.Clear();
                goto End;
                }
            else if (zurueck.Key == ConsoleKey.Escape)
                {
                Environment.Exit(0);
                }
            else if (zurueck.Key == ConsoleKey.R)
                {
                Console.Clear();
                goto BeginQuerschnittsflaeche;
                }
            else 
                {
                goto Returnbefehl;
                }
            End:;
                       
        }
        void Flaechentraegheitsmoment()            
        {
            BeginFlaechentraegheitsmoment:
            Console.Clear();
            Program p = new Program();
            double flaechenmomentX = 0;
            double flaechenmomentY = 0;
            double breite;
            double hoehe;

            Console.WriteLine();
            Console.WriteLine("                      Rechteckprofil");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                 Flaechentraegheitsmoment");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.Write("   Eingabe Breite: ");
            breite = Convert.ToDouble(Console.ReadLine());
            breite = p.Einheit(breite);

            Console.Write("   Eingabe Hoehe: ");
            hoehe = Convert.ToDouble(Console.ReadLine());
            hoehe = p.Einheit(hoehe);

            flaechenmomentX = breite * hoehe * hoehe * hoehe / 12;
            flaechenmomentY = hoehe * breite * breite * breite / 12;

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Das Flächenträgheitsmoment über die x achse ist {0} mm⁴",
            flaechenmomentX);
            Console.WriteLine("Das Flächenträgheitsmoment über die y achse ist {0} mm⁴",
            flaechenmomentY);

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press B to go back to the main Menu");
            Console.WriteLine("Press R to calculate again");
            Console.WriteLine("Press ESC to exit Program");
            Returnbefehl:
            ConsoleKeyInfo zurueck = Console.ReadKey();                                            // Tastendruck um neu zu starten.
            if (zurueck.Key == ConsoleKey.B)
                {
                Console.Clear();
                goto End;
                }
            else if (zurueck.Key == ConsoleKey.Escape)
                {
                Environment.Exit(0);
                }
            else if (zurueck.Key == ConsoleKey.R)
                {
                Console.Clear();
                goto BeginFlaechentraegheitsmoment;
                }
            else 
                {
                goto Returnbefehl;
                }
            End:;
        }

         double Einheit(double zahl)
        {

            string einheit = "einheit";
            int vergleich = 0; //Hilfsvariable für das vergleichen der einheiten

            vergleich = 0;

            while (vergleich == 0)
            {
                //Console.WriteLine("Bitte geben sie die Einheit ein:");
                Console.Write("   Eingabe Einheit: ");
                einheit = Console.ReadLine();
                Console.WriteLine();

                if (string.Compare(einheit, "mm") == 0)
                {
                    //es wird in mm erechnet, also keine umwandlung
                    vergleich = 1;
                }
                else if (string.Compare(einheit, "cm") == 0)
                {
                    zahl = zahl * 10;
                    vergleich = 1;
                }
                else if (string.Compare(einheit, "dm") == 0)
                {
                    zahl = zahl * 100;
                    vergleich = 1;
                }
                else if (string.Compare(einheit, "m") == 0)
                {
                    zahl = zahl * 1000;
                    vergleich = 1;
                }
                else
                {
                    Console.WriteLine("Die eingegebene Einheit wird nicht unterstützt, andere wählen");
                    Console.WriteLine();
                }

            }
            return zahl;
            }
    }
}
