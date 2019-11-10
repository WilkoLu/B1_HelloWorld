using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner_mit_Benutzeroberfläche
{
    class Doppel_T_Träger
    {
        private double hoehe;
        private double laenge;
        private double breite;

        public Doppel_T_Träger()
        {
            laenge = 0;
            breite = 0;
            hoehe = 0;
        }


        public void setLaenge(double zahl)
        {
            laenge = zahl;
        }
        public void setBreite(double zahl)
        {
            breite = zahl;
        }
        public void setHoehe(double zahl)
        {
            hoehe = zahl;
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
        public double getVolumen()
        {
            return getQflaeche() * laenge;
        }
        public double getMasse(string gewaeltesmaterial)
        {
            return getVolumen() * Material.dichte(gewaeltesmaterial);
        }
    }
}