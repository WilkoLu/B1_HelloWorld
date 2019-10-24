using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner_Gewicht
{
    class Program
    {
        static void Main(string[] args)
        {
                int menu;
                double Stahl;
                double Aluminium;
                double Gewicht;
            Console.Write("Gewicht berechnen J/N");
            ConsoleKeyInfo eingabekey=Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            if (eingabekey == ConsoleKey.J())
            {
                Console.WriteLine("Material:");
                Console.WriteLine();
                Console.WriteLine("<1> Stahl");
                Console.WriteLine("<2> Aluminium");
                Console.WriteLine();

                if (menu == 1);
                { Gewicht = 7.85 * Volumen;

                    Console.Writeline("Gewicht:");
                    Console.Write(Gewicht);
                    Console.WriteLine("kg");
                    Console.WriteLine();

                }
                else if (menu == 2) ;
                { Gewicht= 2.7*Volumen
                        Console.WriteLine("Gewicht:");
                    Console.Write(Gewicht);
                        Console.WriteLine("kg");
                    Console.WriteLine();
                        }



        }
    }
}
