using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Profilrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int menue;

            do
            {
                Console.WriteLine();
                Console.WriteLine("                       Profilrechner");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("          Welches Profil wollen sie berechnen?");
                Console.WriteLine();
                Console.WriteLine(" < 1 > Rechteckprofil");
                Console.WriteLine(" < 2 > Rundprofil");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(" Zum beenden des Programms drücken Sie 0");
                Console.WriteLine();
                Console.Write(" Auswahl: ");

                string eingabe = Console.ReadLine();
                bool zahlOderNicht = int.TryParse(eingabe, out menue);

                if (zahlOderNicht == true)
                {

                    if (menue == 1)
                    {
                        Rechteckprofil();
                    }
                    else if (menue == 2)
                    {
                        Rundprofil();
                    }
                    else if (menue == 0)
                    {
                        //nichts damit kein fehler ausgegeben wird
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("             !Fehler bei der Eingabe!");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("             !Fehler bei der Eingabe!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    menue = -1;//damit das programm bei buchstaben nicht beendet wir

                }

            } while (menue != 0);
        }


        public static void Rechteckprofil()
        {

        BeginQuerschnittsflaecheVolumen:
            Console.Clear();
            double breite;
            double laenge;
            double volumen;
            double qflaeche;
            double hoehe;
            double flaechenmomentX;
            double flaechenmomentY;

            Console.WriteLine();
            Console.WriteLine("                      Rechteckprofil");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();


            breite = EingabeMitPrüfung("Breite");
            hoehe = EingabeMitPrüfung("Höhe");

            qflaeche = breite * hoehe;
            flaechenmomentX = breite * hoehe * hoehe * hoehe / 12;
            flaechenmomentY = hoehe * breite * breite * breite / 12;


            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.Write("   Querschnittsflaeche: ");
            Console.Write(qflaeche);
            Console.WriteLine("mm²");
            Console.WriteLine();
            Console.WriteLine("   Das horizontale FTM: {0:0.00} mm^4",
            flaechenmomentX);
            Console.WriteLine("     Das vertikale FTM: {0:0.00} mm^4",
            flaechenmomentY);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.Write("   Volumen berechnen? J/N: ");
            ConsoleKeyInfo eingabekey = Console.ReadKey();                                   // Ist das der Fall kann der Benutzer sich entscheiden ob es weitergeht.
            Console.WriteLine();
            Console.WriteLine();
            if (eingabekey.Key == ConsoleKey.J)
            {
                laenge = EingabeMitPrüfung("Länge");

                volumen = qflaeche * laenge;


                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.Write("   Volumen: ");
                Console.Write(volumen);
                Console.WriteLine("mm³");
                Console.WriteLine();

            

            int menu;
            double Gewicht;
            Console.Write("   Gewicht berechnen J/N");
            ConsoleKeyInfo eingabekey2 = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
                if (eingabekey2.Key == ConsoleKey.J)
                {
                    Console.WriteLine("   Material:");
                    Console.WriteLine();
                    Console.WriteLine("   <1> Stahl");
                    Console.WriteLine("   <2> Aluminium");
                    Console.WriteLine();
                    Console.Write("   Auswahl: ");

                    string eingabe = Console.ReadLine();
                    bool zahlOderNicht = int.TryParse(eingabe, out menu);

                    if (menu == 1)
                    {
                        Gewicht = 7.85 * volumen;

                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine();
                        Console.Write("   Gewicht: ");
                        Console.Write(Gewicht);
                        Console.WriteLine("kg");
                        Console.WriteLine();
                        

                    }
                    else if (menu == 2) 
                    {
                        Gewicht = 2.7 * volumen;

                        Console.Write("   Gewicht: ");
                        Console.Write(Gewicht);
                        Console.WriteLine("kg");
                        Console.WriteLine();
                    }
                }
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
                goto BeginQuerschnittsflaecheVolumen;
            }
            else
            {
                goto Returnbefehl;
            }
        End:;

        }


        public static void Rundprofil()
        {
            double qflaeche;
            double flaechentraegheitsmoment;
            double volumen;
            double masse;
            double dichte = 0;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                      Rundprofil");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();


            double durchmesser = EingabeMitPrüfung("Durchmesser");

            double laenge = EingabeMitPrüfung("Länge", 1);

            if (laenge > 0)
            {
                dichte = Material("Dichte");
            }

            qflaeche = Math.PI * Math.Pow(durchmesser, 2) / 4;
            flaechentraegheitsmoment = Math.PI * Math.Pow(durchmesser, 4) / 64;
            volumen = qflaeche * laenge;
            masse = volumen * dichte;

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.Write("     Querschnittsfläche: {0:0.000} mm²", qflaeche);
            Console.WriteLine();
            Console.Write("                    FTM: {0:0.000} mm^4", flaechentraegheitsmoment);
            Console.WriteLine();
            if (volumen > 0)
            {
                Console.Write("                Volumen: {0:0.000} mm³", volumen);
                Console.WriteLine();
            }
            if (masse > 0)
            {
                Console.Write("                  Masse: {0:0.000} kg", masse);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static double Material(string eigenschaft)
        {
            int menue;
            double rueckgabe = 0;

            do
            {
                
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("         Aus welchem Material ist das Profil?");
                Console.WriteLine();
                Console.WriteLine(" < 1 > Stahl");
                Console.WriteLine(" < 2 > Aluminium");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                Console.Write(" Auswahl: ");

                string eingabe = Console.ReadLine();
                bool zahlOderNicht = int.TryParse(eingabe, out menue);

                Console.WriteLine();

                if (zahlOderNicht == true)
                {
                    if (menue == 1)//Stahl
                    {
                        if (string.Compare(eigenschaft, "Dichte") == 0 || string.Compare(eigenschaft, "dichte") == 0)
                        {
                            rueckgabe = 7.85 * Math.Pow(10, -6);
                        }
                        else if (string.Compare(eigenschaft, "Kosten") == 0 || string.Compare(eigenschaft, "kosten") == 0)
                        {
                            rueckgabe = 10;
                        }
                        menue = 0;
                    }
                    else if (menue == 2)//Aluminium
                    {
                        if (string.Compare(eigenschaft, "Dichte") == 0 || string.Compare(eigenschaft, "dichte") == 0)
                        {
                            rueckgabe = 2.7 * Math.Pow(10, -6);
                        }
                        else if (string.Compare(eigenschaft, "Kosten") == 0 || string.Compare(eigenschaft, "kosten") == 0)
                        {
                            rueckgabe = 11;
                        }
                        menue = 0;
                    }
                    else
                    {
                        menue = 0;
                        rueckgabe = 0;
                    }
                }
                else
                {
                    menue = 0;
                    rueckgabe = 0;
                }

            } while (menue != 0);


            return (rueckgabe);
        }

        public static double EingabeMitPrüfung(string definition, int eingabeErforderlich = 0)
        {                  //wenn bei eingabeErforderlich 1 mitgegeben wird muss keine zahl eingegeben werden und null wird zurückgegeben 
            double zahl = 0;
            bool echteeingabe = false;

            while (echteeingabe == false)
            {

                Console.Write("   Eingabe {0} : ", definition);
                string eingabe = Console.ReadLine();
                echteeingabe = double.TryParse(eingabe, out zahl);                                   //True wenn Zahl eingegeben wird False wenn nicht.
                if (echteeingabe == false)                                                          //Prüfung ob Zahl eingegeben wurde oder die Zahl kleiner gleich 0 ist
                {
                    if (eingabeErforderlich == 1)
                    {
                        echteeingabe = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("                  Fehler bei der Eingabe!");
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine();
                    }
                }
                else if (zahl <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("!Fehler bei der Eingabe!(keine negativen Zahlen oder Null)");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine();
                    echteeingabe = false;                                                 // um bei negativen zahlen in der schleife zu bleiben, damit die eingebae erneut abgefragt wird
                }
                else
                {
                    zahl = Einheit(zahl);
                    if (zahl == -1)                                                       //wenn nicht unterstützte einheit eingegeben wurde muss neu abgefragt werden
                    {
                        echteeingabe = false;
                    }
                }


            }

            return zahl;
        }


        public static double Einheit(double zahl)
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
            else if (string.Compare(einheit, "km") == 0)
            {
                zahl = zahl * 1000000;
            }
            else if (string.Compare(einheit, "inch") == 0 || string.Compare(einheit, "Inch") == 0 || string.Compare(einheit, "zoll") == 0 || string.Compare(einheit, "Zoll") == 0)
            {
                zahl = zahl * 25.4;
            }
            else if (string.Compare(einheit, "ft") == 0)
            {
                zahl = zahl * 304.8;
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Diese Einheit wird nicht unterstützt! Bitte andere Wählen!");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
                zahl = -1;
            }


            return zahl;
        }


    }
}