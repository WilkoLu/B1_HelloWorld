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
            bool echtebreite = double.TryParse(eingabebreite, out breite);
            if(echtebreite == false)
                {
                Console.WriteLine();
                Console.WriteLine("     Fehler in der Matrix!");
                }
            Console.WriteLine();
            Console.Write("   Eingabe Hoehe in mm: ");
            string eingabehoehe = Console.ReadLine();
            double hoehe;
            bool echtehoehe = double.TryParse(eingabehoehe, out hoehe);
            if(echtehoehe == false)
                {
                Console.WriteLine();
                Console.WriteLine("     Fehler in der Matrix!");
                }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            double qflaeche = breite * hoehe;
            Console.Write("   Querschnittsflaeche = ");
            if (qflaeche <= 0)
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
