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
            Console.WriteLine();
            Console.WriteLine("             Profilrechner Rechteckprofil");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("                 Querschnittsflaeche");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.Write("   Eingabe Breite in mm: ");
            string eingabebreite = Console.ReadLine();
            double breite;
            bool echtebreite = double.TryParse(eingabebreite, out breite);                       //True wenn Zahl eingegeben wird False wenn nicht.
            if(echtebreite == false)                                                             //Prüfung ob Zahl eingegeben wurde
                {
                Console.WriteLine();
                Console.WriteLine("     Fehler in der Matrix!");
                }
            Console.WriteLine();
            Console.Write("   Eingabe Hoehe in mm: ");
            string eingabehoehe = Console.ReadLine();
            double hoehe; 
            bool echtehoehe = double.TryParse(eingabehoehe, out hoehe);                          //True wenn Zahl eingegeben wird False wenn nicht.
            if(echtehoehe == false)                                                              //Prüfung ob Zahl eingegeben wurde
                {
                Console.WriteLine();
                Console.WriteLine("     Fehler in der Matrix!");
                }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            double qflaeche = breite * hoehe;
            Console.Write("   Querschnittsflaeche = ");
            if (qflaeche <= 0)                                                                   // Prüfung ob Flaeche real ist. Flaechen sind immer Positiv und nicht null.
                {
                Console.WriteLine ("Wert nicht real.");
                }
            else 
                {
                Console.Write (qflaeche);
                Console.WriteLine ("mm²");
                }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
