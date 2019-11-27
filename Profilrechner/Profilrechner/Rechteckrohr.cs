using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Rechteckrohr
    {
        private double hoehe;
        private double laenge;
        private double breite;
        private double wandstaerke;
        private double qflaeche;
        private string material;


        public Rechteckrohr()
        {
            laenge = 0;
            breite = 0;
            hoehe = 0;
            wandstaerke = 0;
            qflaeche = 0;
        }


        public void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setBreite(string zahl, string einheit)
        {
            breite = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setHoehe(string zahl, string einheit)
        {
            hoehe = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setWandstaerke(string zahl, string einheit)
        {
            wandstaerke = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setQflaeche(string zahl, string einheit)
        {
            qflaeche = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaehltesMaterial)
        {
            material = gewaehltesMaterial;
        }

        public double getQflaeche()
        {
            return qflaeche = breite * hoehe - ((breite - wandstaerke * 2) * (hoehe - wandstaerke * 2));
        }
        public double getFlaechenträgheitsmomentX()
        {
            return (breite * hoehe * hoehe * hoehe - ((breite - wandstaerke * 2) * (hoehe - wandstaerke * 2) * (hoehe - wandstaerke * 2) * (hoehe - wandstaerke * 2))) / 12;
        }
        public double getFlaechenträgheitsmomentY()
        {
            return (hoehe * breite * breite * breite - ((hoehe - wandstaerke * 2) * (breite - wandstaerke * 2) * (breite - wandstaerke * 2) * (breite - wandstaerke * 2))) / 12;
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
        public double getPreis()
        {
            return getMasse() * Material.preis(material);
        }


        public double getBreite()
        {
            return breite;
        }
        public double getHoehe()
        {
            return hoehe;
        }
        public double getLaenge()
        {
            return laenge;
        }

        public double getWandstärke()
        {
            return wandstaerke;
        }

    }
}

