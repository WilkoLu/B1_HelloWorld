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


        private void setHoehe(string zahl, string einheit)
        {
            hoehe = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        private void setBreite(string zahl, string einheit)
        {
            breite = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        private void setWandstaerke(string zahl, string einheit)
        {
            wandstaerke = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        private void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        private void setMaterial(string gewaeltesmaterial)
        {
            profilmaterial = gewaeltesmaterial;
        }

        private double getHoehe()
        {
            return hoehe;
        }
        private double getBreite()
        {
            return breite;
        }
        private double getWandstaerke()
        {
            return wandstaerke;
        }
        private double getLaenge()
        {
            return laenge;
        }
        private double getQflaeche()
        {
            return wandstaerke * (hoehe + breite - wandstaerke);
        }
        private double getschwerpunktX()
        {
            return wandstaerke * 0.5 * (breite * breite + hoehe * wandstaerke - wandstaerke * wandstaerke) / getQflaeche();
        }
        private double getschwerpunktY()
        {
            return wandstaerke * 0.5 * (hoehe * hoehe + breite * wandstaerke - wandstaerke * wandstaerke) / getQflaeche();
        }
        private double getFlaechentraegheitsmomentX()
        {
            return wandstaerke * hoehe * (hoehe * hoehe / 12 + Math.Pow(hoehe / 2 - getschwerpunktY(), 2)) + wandstaerke * (breite - wandstaerke) * (wandstaerke * wandstaerke / 12 + Math.Pow(getschwerpunktY() - wandstaerke / 2, 2));
        }
        private double getFlaechentraegheitsmomentY()
        {
            return wandstaerke * hoehe * (wandstaerke * wandstaerke / 12 + Math.Pow(getschwerpunktX() - wandstaerke / 2, 2)) + wandstaerke * (breite - wandstaerke) * (Math.Pow(breite - wandstaerke, 2) / 12 + Math.Pow((breite + wandstaerke) / 2 - getschwerpunktX(), 2));
        }
        private double getVolumen()
        {
            return getQflaeche() * laenge;
        }
        private double getMasse()
        {
            return getVolumen() * Material.dichte(profilmaterial);
        }







    }
}
