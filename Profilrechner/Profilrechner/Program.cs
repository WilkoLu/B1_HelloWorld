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
                Console.WriteLine("           Welches Profil wollen sie berechnen?");
                Console.WriteLine();
                Console.WriteLine(" < 1 > Rechteckprofil");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(" Zum beenden des Programms drücken Sie 0");
                Console.WriteLine();
                Console.Write(" Auswahl: ");
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
                Console.WriteLine(" < 1 > Querschnittsflaeche");
                Console.WriteLine(" < 2 > Flaechentraegheitsmoment");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(" Zum beenden des Programms drücken Sie 0");
                Console.WriteLine();
                Console.Write(" Auswahl: ");
                menue = Convert.ToInt32(Console.ReadLine());
                if (menue == 1)
                {
                    p.Querschnittsflaeche();
                    menue = 0;
                }
                else if (menue == 2)
                {
                    p.Flaechentraegheitsmoment();
                    menue = 0;
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
            Program p = new Program();
            double breite;
            double hoehe;
            double qflaeche;

            Console.WriteLine();
            Console.WriteLine("                      Rechteckprofil");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                   Querschnittsflaeche");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();

            breite = p.EingabeMitPrüfungQuerschnitt("Breite");

            hoehe = p.EingabeMitPrüfungQuerschnitt("Hoehe");

            qflaeche = breite * hoehe;
            if (breite < 0 & hoehe < 0)
            {
                Console.Write(" Hoehe und Breite sind negativ. Trotzdem darstellen? J/N:");       // Falls beide Werte negativ sind kommt ein positives Ergebnis raus.
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
                Console.WriteLine("                  Flaeche nicht real.");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.Write("   Querschnittsflaeche: ");
                Console.Write(qflaeche);
                Console.WriteLine("mm²");
                Console.WriteLine();
            }
        Finish:
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Press B to go back to the main Menu");
            Console.WriteLine(" Press R to calculate again");
            Console.WriteLine(" Press ESC to exit Program");
        Returnbefehl:
            ConsoleKeyInfo zurueck = Console.ReadKey();                                            // Tastendruck um neu zu starten. Zu Schließen oder zurück zu gehen.
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

            Program p = new Program();
            double flaechenmomentX ;
            double flaechenmomentY ;
            double breite;
            double hoehe;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                      Rechteckprofil");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                 Flaechentraegheitsmoment");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();

            breite = p.EingabeMitPrüfung("Breite");

            hoehe = p.EingabeMitPrüfung("Hoehe");
           

            flaechenmomentX = breite * hoehe * hoehe * hoehe / 12;
            flaechenmomentY = hoehe * breite * breite * breite / 12;

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(" Das Flächenträgheitsmoment über die x achse ist {0:0.00} mm^4",
            flaechenmomentX);
            Console.WriteLine(" Das Flächenträgheitsmoment über die y achse ist {0:0.00} mm^4",
            flaechenmomentY);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Press B to go back to the main Menu");
            Console.WriteLine(" Press R to calculate again");
            Console.WriteLine(" Press ESC to exit Program");
        Returnbefehl:
            ConsoleKeyInfo zurueck = Console.ReadKey();                                            // Tastendruck um neu zu starten, menue oder beenden
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

        double EingabeMitPrüfung(string definition)
        {
            Program p = new Program();
            double zahl = 0;
            bool echteeingabe = false;
            
            while (echteeingabe == false)
            {

                Console.Write("   Eingabe {0} : ",definition);
                string eingabe = Console.ReadLine();
                echteeingabe = double.TryParse(eingabe, out zahl);                                   //True wenn Zahl eingegeben wird False wenn nicht.
                if (echteeingabe == false )                                                          //Prüfung ob Zahl eingegeben wurde oder die Zahl kleiner gleich 0 ist
                   {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("                  Fehler bei der Eingabe!");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine();
                   }
                else if (zahl <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Fehler bei der Eingabe! (Negative Zahl oder null kann nicht verwendet werden)!");    
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine();
                    echteeingabe = false;                                                 // um bei negativen zahlen in der schleife zu bleiben, damit die eingebae erneut abgefragt wird
                }
                else
                {
                    zahl = p.Einheit(zahl);
                    if (zahl == -1)                                                       //wenn nicht unterstützte einheit eingegeben wurde
                    {
                        echteeingabe = false;
                    }
                }
                

            }

            return zahl;
        }


        double Einheit(double zahl)
        {
            string einheit /*= "einheit"*/;

              Console.Write("   Eingabe Einheit: ");
              einheit = Console.ReadLine();
              Console.WriteLine();

              if (string.Compare(einheit, "mm") == 0)
              {
                  //es wird in mm gerechnet, also keine umwandlung
              }
              else if (string.Compare(einheit, "cm") == 0)
              {
                  zahl = zahl * 10;
              }
              else if (string.Compare(einheit, "dm") == 0)
              {
                  zahl = zahl * 100;
              }
              else if (string.Compare(einheit, "m") == 0)
              {
                  zahl = zahl * 1000;
              }
              else
              {
                  Console.WriteLine("----------------------------------------------------------");
                  Console.WriteLine("Diese Einheit wird nicht unterstützt, bitte andere Wählen!");
                  Console.WriteLine("----------------------------------------------------------");
                  Console.WriteLine();
                  zahl = -1;
              }

            
            return zahl;
        }

        double EingabeMitPrüfungQuerschnitt(string definition)
        {
            Program p = new Program();
            double zahl = 0;
            bool echteeingabe = false;
            
            while (echteeingabe == false)
            {

                Console.Write("   Eingabe {0} : ",definition);
                string eingabe = Console.ReadLine();
                echteeingabe = double.TryParse(eingabe, out zahl);                                   //True wenn Zahl eingegeben wird False wenn nicht.
                if (echteeingabe == false )                                                          //Prüfung ob Zahl eingegeben wurde oder die Zahl kleiner gleich 0 ist
                   {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("                  Fehler bei der Eingabe!");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine();
                   }
                else
                {
                    zahl = p.Einheit(zahl);
                    if (zahl == -1)                                                                    //wenn nicht unterstützte einheit eingegeben wurde
                    {
                        echteeingabe = false;
                    }
                }
                

            }

            return zahl;
        }




    }
}