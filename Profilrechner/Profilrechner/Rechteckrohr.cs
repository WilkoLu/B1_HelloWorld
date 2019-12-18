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
    class Rechteckrohr
    {
        private double hoehe;
        private double laenge;
        private double breite;
        private double wandstaerke;
        private double qflaeche;
        private string material;

        CatiaConnection cc = new CatiaConnection();

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

        public bool erzeugeCAD(bool? radienErzeugen)
        {
            try
            {
               
                //Finde Catia Prozess
                if (cc.CATIALaeuft() && breite > 0 && hoehe > 0 && wandstaerke > 0 && breite > wandstaerke*2 && hoehe > wandstaerke*2)
                {
                    //Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere eine skizze vom rechteckprofil
                    cc.ErzeugeRechteckrohrSkizze(hoehe, breite, wandstaerke, radienErzeugen);

                    if (laenge > 0)
                    {
                        // Extrudiere Balken
                        cc.ErzeugeVolumenAusSkizze(laenge);
                        if (radienErzeugen == true)
                        {
                            cc.Screenshot("Rechteckrohr_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm_Radius" + Convert.ToString(wandstaerke) + "mm");
                        }
                        else
                        {
                            cc.Screenshot("Rechteckrohr_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm");
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
                cc.Speichern("Rechteckrohr_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm_Radius" + Convert.ToString(wandstaerke) + "mm");
            }
            else
            {
                cc.Speichern("Rechteckrohr_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(wandstaerke) + "mm_x_" + Convert.ToString(laenge) + "mm");
            }

        }


    }
}

