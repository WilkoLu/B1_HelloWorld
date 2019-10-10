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
            Console.WriteLine("Profilrechner Rechteckprofil");
            Console.WriteLine();
            Console.WriteLine("Querschnittsberechnung:");
            Console.WriteLine();
            Console.Write("Eingabe Breite in mm: ");
            string eingabebreite = Console.ReadLine();
            double breite = Convert.ToDouble(eingabebreite);
            Console.Write("Eingabe Hoehe in mm: ");
            string eingabehoehe = Console.ReadLine();
            Console.WriteLine();
            double hoehe = Convert.ToDouble(eingabehoehe);
            double qflaeche = breite * hoehe;
            Console.Write("Querschnittsflaeche = ");
            Console.Write(qflaeche);
            Console.WriteLine("mm²");
            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
