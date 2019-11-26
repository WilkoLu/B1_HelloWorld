using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Winkelprofil
    {
        private double hoehe;
        private double breite;
        private double laenge;
        private double wandstaerke;
        private string profilmaterial;

        public Winkelprofil()
        {
            hoehe = 0;
            breite = 0;
            wandstaerke = 0;
        }


        public void setHoehe(string zahl, string einheit)
        {
            hoehe = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setBreite(string zahl, string einheit)
        {
            breite = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setWandstaerke(string zahl, string einheit)
        {
            wandstaerke = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaeltesmaterial)
        {
            profilmaterial = gewaeltesmaterial;
        }

        public double getHoehe()
        {
            return hoehe;
        }
        public double getBreite()
        {
            return breite;
        }
        public double getWandstaerke()
        {
            return wandstaerke;
        }
        public double getLaenge()
        {
            return laenge;
        }
        public double getQflaeche()
        {
            return wandstaerke * (hoehe + breite - wandstaerke);
        }
        public double getschwerpunktX()
        {
            return wandstaerke * 0.5 * (breite * breite + hoehe * wandstaerke - wandstaerke * wandstaerke) / getQflaeche();
        }
        public double getschwerpunktY()
        {
            return wandstaerke * 0.5 * (hoehe * hoehe + breite * wandstaerke - wandstaerke * wandstaerke) / getQflaeche();
        }
        public double getFlaechentraegheitsmomentX()
        {
            return wandstaerke * hoehe * (hoehe * hoehe / 12 + Math.Pow(hoehe / 2 - getschwerpunktY(), 2)) + wandstaerke * (breite - wandstaerke) * (wandstaerke * wandstaerke / 12 + Math.Pow(getschwerpunktY() - wandstaerke / 2, 2));
        }
        public double getFlaechentraegheitsmomentY()
        {
            return wandstaerke * hoehe * (wandstaerke * wandstaerke / 12 + Math.Pow(getschwerpunktX() - wandstaerke / 2, 2)) + wandstaerke * (breite - wandstaerke) * (Math.Pow(breite - wandstaerke, 2) / 12 + Math.Pow((breite + wandstaerke) / 2 - getschwerpunktX(), 2));
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
