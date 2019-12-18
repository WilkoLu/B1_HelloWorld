using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Profilrechner
{
    class Winkelprofil
    {
        private double hoehe;
        private double breite;
        private double laenge;
        private double wandstaerke;
        private string profilmaterial;

        CatiaConnection cc = new CatiaConnection();

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
        public double getPreis()
        {
            return getMasse() * Material.preis(profilmaterial);
        }


        public bool erzeugeCAD(bool? radienErzeugen)
        {
            try
            {
                
                //Finde Catia Prozess
                if (cc.CATIALaeuft() && breite > 0 && hoehe > 0 && wandstaerke > 0 && breite > wandstaerke && hoehe > wandstaerke)
                {
                    //Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere eine skizze vom rechteckprofil
                    cc.ErzeugeWinkelSkizze( hoehe, breite, wandstaerke,radienErzeugen);

                    if (laenge > 0)
                    {
                        // Extrudiere Balken
                        cc.ErzeugeVolumenAusSkizze(laenge);
                        if (radienErzeugen == true)
                        {
                            cc.Screenshot("Winkelprofil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm_Radius" + Convert.ToString(wandstaerke) + "mm");
                        }
                        else
                        {
                            cc.Screenshot("Winkelprofil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm");
                        }
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
                    MessageBoxResult result = MessageBox.Show("Keine laufende Catia Application. " + Environment.NewLine + "Catia starten?", "Fehler",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Information);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            Process catia = new Process();
                            try
                            {
                                catia.StartInfo.FileName = "C:\\Program Files\\Dassault Systemes\\B28\\win_b64\\code\\bin\\CATSTART.exe";
                                catia.Start();
                                Thread.Sleep(1000);
                                catia.Kill();
                                while (cc.CATIALaeuft() == false)
                                {
                                    Thread.Sleep(1000);
                                }
                                erzeugeCAD(radienErzeugen);
                                return true;
                            }
                            catch
                            {
                                break;
                            }

                        case MessageBoxResult.No:
                            break;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Folgender Fehler ist aufgetreten" + ex, "Fehler",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);
                return false;
            }

        }

        public void speichern(bool? radienErzeugen)
        {
            if (radienErzeugen == true)
            {
                cc.Speichern("Winkelprofil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm_Radius" + Convert.ToString(wandstaerke) + "mm");
            }
            else
            {
                cc.Speichern("Winkelprofil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm");
            }

        }



    }
}
