using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilberechnung
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int menue;

            do
            {
                

                Console.WriteLine("Welches Profiel wollen sie berechnen?");
                Console.WriteLine("< 1 > Rechteckprofiel");
                Console.WriteLine("zum beenden des Programms 0");
                menue = Convert.ToInt32( Console.ReadLine());
                if (menue == 1)
                {
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
            double flaechenmomentX = 0;
            double flaechenmomentY = 0;
            double breite;
            double hoehe;


            Console.Write("Bitte geben sie die breite und anschliessend die Einheit ein:");
            breite = Convert.ToDouble(Console.ReadLine());
            breite = p.Einheit(breite);

            Console.Write("Bitte geben sie die höhe und anschliessend die Einheit ein:");
            hoehe = Convert.ToDouble(Console.ReadLine());
            hoehe = p.Einheit(hoehe);



            flaechenmomentX = breite * hoehe * hoehe * hoehe / 12;
            flaechenmomentY = hoehe * breite * breite * breite / 12;


            Console.WriteLine("Das Flächenträgheitsmoment über die x achse ist {0} mm⁴",
            flaechenmomentX);
            Console.WriteLine("Das Flächenträgheitsmoment über die x achse ist {0} mm⁴",
            flaechenmomentY);

            Console.ReadKey();
        }

         double Einheit(double zahl)
        {

          string einheit = "einheit";
          int vergleich = 0; //Hilfsvariable für das vergleichen der einheiten

          vergleich = 0;

          while (vergleich == 0)
          {
             //Console.WriteLine("Bitte geben sie die Einheit ein:");
             einheit = Console.ReadLine();

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
              }
               
            }
            return zahl;


        }

    }
}



