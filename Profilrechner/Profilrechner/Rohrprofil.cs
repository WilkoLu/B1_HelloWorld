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
    class Rohrprofil
    {
        private double innendurchmesser;
        private double aussendurchmesser;
        private double laenge;
        private string profilmaterial;

        CatiaConnection cc = new CatiaConnection();

        public Rohrprofil()
        {
            aussendurchmesser = 0;
            innendurchmesser = 0;
        }

        public void setInnendurchmesser(string zahl , string einheit)
        {
            innendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setInnenradius(string zahl, string einheit)
        {
            innendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit) * 2;
        }
        public void setAussendurchmesser(string zahl, string einheit)
        {
            aussendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setAussenradius(string zahl, string einheit)
        {
            aussendurchmesser = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit) * 2;
        }
        public void setLaenge(string zahl, string einheit)
        {
            laenge = eingabeMitEinheit.eingabeMitPruefung(zahl, einheit);
        }
        public void setMaterial(string gewaeltesmaterial)
        {
            profilmaterial = gewaeltesmaterial;
        }

        public double getInnendurchmesser()
        {
            return innendurchmesser;
        }
        public double getInnenradius()
        {
            return innendurchmesser / 2;
        }
        public double getAussendurchmesser()
        {
            return aussendurchmesser;
        }
        public double getAussenradius()
        {
            return aussendurchmesser / 2;
        }
        public double getLaenge()
        {
            return laenge;
        }
        public double getQflaeche()
        {
            return Math.PI / 4 * (Math.Pow(aussendurchmesser, 2) - Math.Pow(innendurchmesser, 2));
        }
        public double getFlaechentraegheitsmoment()
        {
            return Math.PI / 64 * (Math.Pow(aussendurchmesser, 4) - Math.Pow(innendurchmesser, 4));
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
        public void berechneUnbekannte(string eingabeFTM)
        {
            double FTM = eingabeMitEinheit.eingabeMitPruefung(eingabeFTM, "mm");

            if(FTM > 0)
            {
                if(aussendurchmesser > 0)
                {
                    innendurchmesser = Math.Pow(Math.Pow(aussendurchmesser , 4) - FTM * 64 / Math.PI , 1.0 / 4.0);
                }
                else if (innendurchmesser > 0)
                {
                    aussendurchmesser = Math.Pow(FTM * 64 / Math.PI + Math.Pow(innendurchmesser, 4), 1.0 / 4.0);
                }
            }
        }

        public bool erzeugeCAD()
        {
            try
            {
                
                //Finde Catia Prozess
                if (cc.CATIALaeuft() && innendurchmesser > 0 && aussendurchmesser > innendurchmesser)
                {
                    //Öffne ein neues Part
                    cc.ErzeugePart();

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();

                    // Generiere eine skizze vom rechteckprofil
                    cc.ErzeugeRohrprofilSkizze( aussendurchmesser / 2, innendurchmesser / 2);

                    if (laenge > 0)
                    {
                        // Extrudiere Balken
                        cc.ErzeugeVolumenAusSkizze(laenge);
                        cc.Screenshot("Rohrprofil_" + Convert.ToString(aussendurchmesser) + "mm_x_" + Convert.ToString(innendurchmesser) + "mm_x_" + Convert.ToString(laenge) + "mm");
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
                                Thread.Sleep(12000);
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

        public void speichern()
        {
            cc.Speichern("Rohrprofil_" + Convert.ToString(aussendurchmesser) + "mm_x_" + Convert.ToString(innendurchmesser) + "mm_x_" + Convert.ToString(laenge) + "mm");
        }


               


    }
}
