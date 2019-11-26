using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Rohrprofil
    {
        private double innendurchmesser;
        private double aussendurchmesser;
        private double laenge;
        private string profilmaterial;

        public Rohrprofil()
        {
            aussendurchmesser = 0;
            innendurchmesser = 0;
        }

        public void setInnendurchmesser(string zahl , string einheit)
        {
            innendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setInnenradius(string zahl, string einheit)
        {
            innendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit) * 2;
        }
        public void setAussendurchmesser(string zahl, string einheit)
        {
            aussendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setAussenradius(string zahl, string einheit)
        {
            aussendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit) * 2;
        }
        public void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaeltesmaterial)
        {
            profilmaterial = gewaeltesmaterial;
        }

        public double getInnendurchmesser()
        {
            return innendurchmesser;
        }
        public double getInnenradius()
        {
            return innendurchmesser / 2;
        }
        public double getAussendurchmesser()
        {
            return aussendurchmesser;
        }
        public double getAussenradius()
        {
            return aussendurchmesser / 2;
        }
        public double getLaenge()
        {
            return laenge;
        }
        public double getQflaeche()
        {
            return Math.PI / 4 * (Math.Pow(aussendurchmesser, 2) - Math.Pow(innendurchmesser, 2));
        }
        public double getFlaechentraegheitsmmoment()
        {
            return Math.PI / 64 * (Math.Pow(aussendurchmesser, 4) - Math.Pow(innendurchmesser, 4));
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
