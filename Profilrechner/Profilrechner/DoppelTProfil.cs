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
    class DoppelTProfil
    {

        private double breite;
        private double hoehe;
        private double laenge;
        private double steg;
        private string profilmaterial;

        CatiaConnection cc = new CatiaConnection();

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
        public double getQflaeche(bool? radienErzeugen = false)
        {
            if (radienErzeugen == true)
            {
                return ((breite * steg) * 2 + steg * (hoehe - 2 * steg) + steg * steg * 16 - Math.PI * Math.Pow(steg * 2, 2));
            }
            else
            {
                return ((breite * steg) * 2 + steg * (hoehe - 2 * steg));
            }

        }

        public double getFlaechentraegheitsmomentX()
        {
            double schwerpunktRadien = Math.Pow(steg * 2, 2) * steg - (Math.PI / 4) * Math.Pow(steg * 2, 2) * (steg * 2 - (0.6002 * (steg * 2) * Math.Cos(45))) / Math.Pow(steg * 2, 2) - (Math.PI / 4) * Math.Pow(steg * 2, 2);

            return (((breite * Math.Pow(hoehe, 3)) - (breite - steg) * Math.Pow(hoehe - steg * 2, 3)) / 12);
        }
        public double getFlaechentraegheitsmomentY()
        {
            return ((2 * steg * Math.Pow(breite, 3)) + (hoehe - steg * 2) * Math.Pow(steg, 3)) / 12;
        }
        public double getVolumen(bool? radienErzeugen = false)
        {
            return getQflaeche(radienErzeugen) * laenge;
        }
        public double getMasse(bool? radienErzeugen = false)
        {
            return getVolumen(radienErzeugen) * Material.dichte(profilmaterial);
        }
        public double getPreis(bool? radienErzeugen = false)
        {
            return getMasse(radienErzeugen) * Material.preis(profilmaterial);
        }

        public bool erzeugeCAD()
        {
            try
            {
                //Finde Catia Prozess
                if (cc.CATIALaeuft() && breite > 0 && hoehe > 0 && steg > 0 && breite > steg && hoehe > steg*2)
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
                    MessageBoxResult result = MessageBox.Show("Keine laufende Catia Application. " + Environment.NewLine + "Catia starten?", "Fehler",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Information);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            
                            try
                            {
                                Process catia = new Process();
                                catia.StartInfo.FileName = "C:\\Program Files\\Dassault Systemes\\B28\\win_b64\\code\\bin\\CATSTART.exe";
                                catia.Start();
                                Thread.Sleep(1000);
                                catia.Kill();
                                while(cc.CATIALaeuft()==false)
                                {
                                    Thread.Sleep(1000);
                                }
                                erzeugeCAD();
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
                        cc.Screenshot("TProfil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(steg) + "mm_x_" + Convert.ToString(laenge) + "mm_" + "Radius" + Convert.ToString(steg * 2) + "mm");
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
                                erzeugeCADRadius();
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
                MessageBox.Show("Folgender Fehler ist aufgetreten:" + Environment.NewLine + ex, "Fehler",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);
                return false;
            }

        }

        public void speichern(bool? radienErzeugen)
        {
            if(radienErzeugen == true)
            {
                cc.Speichern("TProfil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(steg) + "mm_x_" + Convert.ToString(laenge) + "mm_" + "Radius" + Convert.ToString(steg * 2) + "mm");
            }
            else
            {
                cc.Speichern("TProfil_" + Convert.ToString(breite) + "mm_x_" + Convert.ToString(hoehe) + "mm_x_" + Convert.ToString(steg) + "mm_x_" + Convert.ToString(laenge) + "mm");
            }
            
        }

    }
}
