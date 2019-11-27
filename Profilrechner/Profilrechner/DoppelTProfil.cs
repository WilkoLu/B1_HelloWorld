using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class DoppelTProfil
    {

        private double breite;
        private double hoehe;
        private double laenge;
        private double steg;
        private string profilmaterial;

        public DoppelTProfil()
        {
            breite = 0;
            hoehe = 0;
            steg = 0;
        }


        public void setBreite(string zahl, string einheit)
        {
            breite = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setHoehe(string zahl, string einheit)
        {
            hoehe = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setSteg(string zahl, string einheit)
        {
            steg = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaeltesMaterial)
        {
            profilmaterial = gewaeltesMaterial;
        }

        public double getBreite()
        {
            return breite;
        }
        public double getHoehe()
        {
            return hoehe;
        }
        public double getSteg()
        {
            return steg;
        }
        public double getLaenge()
        {
            return laenge;
        }
        public double getQflaeche()
        {
            return ((breite*steg)*2+steg*(hoehe-2*steg));
        }
       
        public double getFlaechentraegheitsmomentX()
        {
            return (((breite * Math.Pow(hoehe, 3)) - (breite - steg) * Math.Pow(hoehe - steg * 2, 3)) / 12);
        }
        public double getFlaechentraegheitsmomentY()
        {
            return ((2 * steg * Math.Pow(breite, 3)) + (hoehe - steg * 2) * Math.Pow(steg, 3)) / 12;
        }
        public double getVolumen()
        {
            return getQflaeche() * laenge;
        }
        public double getMasse()
        {
            return getVolumen() * Material.dichte(profilmaterial);
        }





    }
}
