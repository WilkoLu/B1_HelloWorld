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
                return 20;
            }
            else if (material.Equals("Aluminium"))
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

    }
}