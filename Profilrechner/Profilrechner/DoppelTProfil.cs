using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            return ((breite * steg) * 2 + steg * (hoehe - 2 * steg));
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
        public double getPreis()
        {
            return getMasse() * Material.preis(profilmaterial);
        }

        public bool erzeugeCAD()
        {
            try
            {
                CatiaConnection cc = new CatiaConnection();

                //Finde Catia Prozess
                if (cc.CATIALaeuft() && breite > 0 && hoehe > 0 && steg > 0 && breite > steg && hoehe > steg)
                {
                    //Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere eine skizze vom rechteckprofil
                    cc.ErzeugeDoppelTProfilSkizze(hoehe, breite, steg);

                    if (laenge > 0)
                    {
                        // Extrudiere Balken
                        cc.ErzeugeVolumenAusSkizze(laenge);
                        // cc.Radien(steg);
                        cc.Screenshot("TProfil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(steg) + "mm_x_" + Convert.ToString(laenge) + "mm");
                        return true;
                    }
                    return false;
                }
                else if (cc.CATIALaeuft())
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
        public bool erzeugeCADRadius()
        {
            try
            {
                CatiaConnection cc = new CatiaConnection();

                //Finde Catia Prozess
                if (cc.CATIALaeuft() && breite > 0 && hoehe > 0 && steg > 0 && breite > steg && hoehe > steg)
                {
                    //Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere eine skizze vom rechteckprofil
                    cc.ErzeugeDoppelTProfilmitRadienausSkizze(hoehe, breite, steg);

                    if (laenge > 0)
                    {
                        // Extrudiere Balken
                        cc.ErzeugeVolumenAusSkizze(laenge);
                       // cc.Radien(steg);
                        cc.Screenshot("TProfil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(steg) + "mm_x_" + Convert.ToString(laenge) + "mm_" +"Radius"+Convert.ToString(steg*2)+"mm");
                        return true;
                    }
                    return false;
                }
                else if (cc.CATIALaeuft())
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
    }
}
