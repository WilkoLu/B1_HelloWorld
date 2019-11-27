using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class TProfil
    {

        private double breiteUndHoehe;
        private double laenge;
        private double wandstaerke;
        private string profilmaterial;

        public TProfil()
        {
            breiteUndHoehe = 0;
            wandstaerke = 0;
        }


        public void setBreiteUndHoehe(string zahl, string einheit)
        {
            breiteUndHoehe = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setWandstaerke(string zahl, string einheit)
        {
            wandstaerke = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaeltesMaterial)
        {
            profilmaterial = gewaeltesMaterial;
        }

        public double getBreiteUndHoehe()
        {
            return breiteUndHoehe;
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
            return wandstaerke * (2 * breiteUndHoehe - wandstaerke);
        }
        public double getSchwerpunkt()
        {
            return wandstaerke * 0.5 * (breiteUndHoehe * wandstaerke + breiteUndHoehe * breiteUndHoehe - wandstaerke * wandstaerke) / getQflaeche();
        }
        public double getFlaechentraegheitsmomentX()
        {
            return breiteUndHoehe * wandstaerke * (wandstaerke * wandstaerke / 12 + Math.Pow(getSchwerpunkt() - wandstaerke / 2, 2)) + wandstaerke * (breiteUndHoehe - wandstaerke) * (Math.Pow(breiteUndHoehe - wandstaerke, 2) / 12 + Math.Pow((breiteUndHoehe + wandstaerke) / 2 - getSchwerpunkt(), 2));
        }
        public double getFlaechentraegheitsmomentY()
        {
            return (wandstaerke * Math.Pow(breiteUndHoehe, 3) + (breiteUndHoehe - wandstaerke) * Math.Pow(wandstaerke, 3)) / 12;
        }
        public double getVolumen()
        {
            return getQflaeche() * laenge;
        }
        public double getMasse()
        {
            return getVolumen() * Material.dichte(profilmaterial);
        }
        public double getPreis()
        {
            return getMasse() * Material.preis(profilmaterial);
        }




    }
}
