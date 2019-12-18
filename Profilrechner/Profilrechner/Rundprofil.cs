using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Profilrechner
{
    class Rundprofil
    {
        private double durchmesser;
        private double laenge;
        private string material;

        CatiaConnection cc = new CatiaConnection();

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
            durchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit) * 2;
        }
        public void setLaenge(string zahl, string einheit)
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
        public double getLaenge()
        {
            return laenge;
        }
        public double getQflaeche()
        {
            return Math.PI / 4 * Math.Pow(durchmesser, 2);
        }
        public double getFlaechentraegheitsmoment()
        {
            return Math.PI / 64 * Math.Pow(durchmesser, 4);
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
        public void berechneUnbekannte(string eingabeFTM)
        {
            double FTM = eingabeMitEinheit.eingabeMitPruefung(eingabeFTM, "mm");

            if (FTM > 0)
            {
                durchmesser = Math.Pow(FTM * 64 / Math.PI, 1.0 / 4.0);
            }
        }

        public bool erzeugeCAD()
        {
            try
            {
                
                //Finde Catia Prozess
                if (cc.CATIALaeuft() && durchmesser > 0 )
                {
                    //Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere eine skizze vom rechteckprofil
                    cc.ErzeugeKreisprofilSkizze(durchmesser / 2);

                    if (laenge > 0)
                    {
                        // Extrudiere Balken
                        cc.ErzeugeVolumenAusSkizze(laenge);
                        cc.Screenshot("Rundprofil_" + Convert.ToString(durchmesser) +"mm_x_"+ Convert.ToString(laenge) + "mm");
                        return true;
                    }
                    return false;
                }
                else if(cc.CATIALaeuft())
                {
                    //erstmal nix
                    return false;
                }
                else
                {
                    MessageBox.Show("Keine laufende Catia Application. Bitte Catia starten", "Fehler",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Folgender Fehler ist aufgetreten:" + Environment.NewLine + ex, "Fehler",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);
                return false;
            }

        }

        public void speichern()
        {
            cc.Speichern("Rundprofil_" + Convert.ToString(durchmesser) + "mm_x_" + Convert.ToString(laenge) + "mm");
        }



    }
}
