using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Material
    {
        
        public static double dichte(string material)
        {

            if (material.Equals("Stahl"))
            {
                return 7.85 * Math.Pow(10, -6);
            }
            else if (material.Equals("Aluminium"))
            {
                return 2.7 * Math.Pow(10, -6);
            }
            else if (material.Equals("Messing"))
            {
                return 8.73 * Math.Pow(10, -6);
            }
            else if (material.Equals("Edelstahl"))
            {
                return 7.95 * Math.Pow(10, -6);
            }
            else if (material.Equals("HARDOX"))
            {
                return 8.2 * Math.Pow(10, -6);
            }
            else
            {
                return 0;
            }
        }


        public static double preis(string material)
        {

            if (material.Equals("Stahl"))
            {
                return 1.5;
            }
            else if (material.Equals("Aluminium"))
            {
                return 8.32;
            }
            else if (material.Equals("Messing"))
            {
                return 2.75;
            }
            else if (material.Equals("Edelstahl"))
            {
                return 7.5;
            }
            else if (material.Equals("HARDOX"))
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }

    }
}