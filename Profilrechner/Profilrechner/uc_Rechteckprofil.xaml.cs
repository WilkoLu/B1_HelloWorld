using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Profilrechner
{
    /// <summary>
    /// Interaktionslogik für uc_Rechteckprofil.xaml
    /// </summary>
    public partial class uc_Rechteckprofil : UserControl
    {
        public uc_Rechteckprofil()
        {
            InitializeComponent();
        }

        private void Berechnen(object sender, RoutedEventArgs e)
        {
            int ausgabe = 0;

            Rechteckprofil meinRechteckprofil = new Rechteckprofil();

            meinRechteckprofil.setHoehe(eingabeMitEinheit.eingabeMitPruefung(eingabeHoehe.Text, einheitHoehe.Text));
            meinRechteckprofil.setBreite(eingabeMitEinheit.eingabeMitPruefung(eingabeBreite.Text, einheitBreite.Text));
            meinRechteckprofil.setLaenge(eingabeMitEinheit.eingabeMitPruefung(eingabeLaenge.Text, einheitLaenge.Text));

            if (meinRechteckprofil.getQflaeche() == 0)
            {
                meinRechteckprofil.berechneUnbekannte(eingabeMitEinheit.eingabeMitPruefung(lbl_flaechentraegheitsmomentX.Text, "mm"), eingabeMitEinheit.eingabeMitPruefung(lbl_flaechentraegheitsmomentY.Text, "mm"));
                if (meinRechteckprofil.getQflaeche() > 0)
                {
                    eingabeBreite.Text = Convert.ToString(meinRechteckprofil.getBreite());
                    eingabeHoehe.Text = Convert.ToString(meinRechteckprofil.getHoehe());
                }
                else
                {
                    ausgabe = 1;

                    if (meinRechteckprofil.getHoehe() == 0)
                    {
                        eingabeMitEinheit.Fehlerausgabe(eingabeHoehe.Text);
                        FocusManager.SetFocusedElement(this, eingabeHoehe);
                        eingabeHoehe.SelectAll();
                    }
                    else if (meinRechteckprofil.getBreite() == 0)
                    {
                        eingabeMitEinheit.Fehlerausgabe(eingabeBreite.Text);
                        FocusManager.SetFocusedElement(this, eingabeBreite);
                        eingabeBreite.SelectAll();
                    }
                }
            }

            if (meinRechteckprofil.getVolumen() == 0 && meinRechteckprofil.getQflaeche() > 0)
            {
                eingabeMitEinheit.Fehlerausgabe(eingabeLaenge.Text, 0);
                if (eingabeLaenge.Text.Equals("") == false)
                { 
                FocusManager.SetFocusedElement(this, eingabeLaenge);
                eingabeLaenge.SelectAll();
                }
            }
            
            if (ausgabe == 0)
            {
                lbl_qflaeche.Content = Math.Round(meinRechteckprofil.getQflaeche(), 3) + " mm²";
                lbl_flaechentraegheitsmomentX.Text = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentX(), 3) + " mm⁴";
                lbl_flaechentraegheitsmomentY.Text = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentY(), 3) + " mm⁴";
                lbl_schwerpunktX.Content = Math.Round(meinRechteckprofil.getSchwerpunktX(), 3) + "mm";
                lbl_schwerpunktY.Content = Math.Round(meinRechteckprofil.getSchwerpunktY(), 3) + "mm";

                if (meinRechteckprofil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinRechteckprofil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinRechteckprofil.getMasse(cb_Material.Text), 3) + " kg";
                }
            }
            
        }

        
        
    }
}
