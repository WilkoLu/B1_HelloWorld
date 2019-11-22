using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Rechteckprofil
    {
        private double hoehe;
        private double laenge;
        private double breite;
        private string material;


        public Rechteckprofil()
        {
            laenge = 0;
            breite = 0;
            hoehe = 0;
        }


        public void setLaenge(string zahl , string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl , einheit);
        }
        public void setBreite(string zahl, string einheit)
        {
            breite = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setHoehe(string zahl, string einheit)
        {
            hoehe = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaehltesmaterial)
        {
            material = gewaehltesmaterial;
        }

        public double getQflaeche()
        {
            return hoehe * breite;
        }
        public double getFlaechenträgheitsmomentX()
        {
            return breite * Math.Pow(hoehe, 3) / 12;
        }
        public double getFlaechenträgheitsmomentY()
        {
            return hoehe * Math.Pow(breite, 3) / 12;
        }
        public double getSchwerpunktX()
        {
            return breite / 2;
        }
        public double getSchwerpunktY()
        {
            return hoehe / 2;
        }
        public double getVolumen()
        {
            return getQflaeche() * laenge;
        }
        public double getMasse()
        {
            return getVolumen() * Material.dichte(material);
        }

        public void berechneUnbekannte(double FTMX, double FTMY)
        {
            if (breite > 0)
            {
                if (FTMY > 0)
                {
                    hoehe = FTMY * 12 / Math.Pow(breite, 3);
                }
                else if (FTMX > 0)
                {
                    hoehe = Math.Pow(FTMX * 12 / breite, 1.0/3.0);
                }


            }
            else if (hoehe > 0)
            {
                if (FTMY > 0)
                {
                    breite = Math.Pow(FTMY * 12 / hoehe, 1.0 / 3.0);
                }
                else if (FTMX > 0)
                {
                    breite = FTMX * 12 / Math.Pow(hoehe, 3);
                }


            }
            else if (breite == 0 && hoehe == 0 && FTMX > 0 && FTMY > 0)
            {
                hoehe = Math.Pow(Math.Pow(FTMX, 3) * 144 / FTMY, 1.0 / 8.0);
                breite = Math.Pow(Math.Pow(FTMY, 3) * 144 / FTMX, 1.0 / 8.0);
            }


        }

        public double getBreite()
        {
        return breite;
        }
        public double getHoehe()
        {
            return hoehe;
        }

    }
}
