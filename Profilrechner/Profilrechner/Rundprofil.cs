using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
    class Rundprofil
    {
        private double durchmesser;
        private double laenge;
        private string material;

        public Rundprofil()
        {
            durchmesser = 0;
        }

        public void setDurchmesser(string zahl, string einheit)
        {
            durchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setRadius(string zahl, string einheit)
        {
            durchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit) / 2;
        }
        public void setLaenge(string zahl , string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaeltesMaterial)
        {
            material = gewaeltesMaterial;
        }

        public double getRadius()
        {
            return durchmesser / 2;
        }
        public double getDurchmesser()
        {
            return durchmesser;
        }
        public double getQflaeche()
        {
            return Math.PI / 4 * Math.Pow(durchmesser , 2);
        }
        public double getFlaechentraegheitsmoment()
        {
            return Math.PI / 64 * Math.Pow(durchmesser , 4);
        }
        public double getVolumen()
        {
            return getQflaeche() * laenge;
        }
        public double getMasse()
        {
            return getVolumen() * Material.dichte(material);
        }

    }
}
