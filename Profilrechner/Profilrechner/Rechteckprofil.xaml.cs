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
using System.Windows.Shapes;


namespace Profilrechner
{
    /// <summary>
    /// Interaktionslogik für Rechteckprofil.xaml
    /// </summary>
    public partial class Wnd_Rechteckprofil : Window
    {
        public Wnd_Rechteckprofil()
        {
            InitializeComponent();
        }

        private void Berechnen(object sender, RoutedEventArgs e)
        {
            int ausgabe = 0;

            Rechteckprofil meinRechteckprofil = new Rechteckprofil();

            meinRechteckprofil.setHoehe ( eingabeMitEinheit.eingabeMitPruefung(eingabeHoehe.Text, einheitHoehe.Text));
            meinRechteckprofil.setBreite ( eingabeMitEinheit.eingabeMitPruefung(eingabeBreite.Text, einheitBreite.Text));
            meinRechteckprofil.setLaenge ( eingabeMitEinheit.eingabeMitPruefung(eingabeLaenge.Text, einheitLaenge.Text));

            if (meinRechteckprofil.getQflaeche() == 0)
            {
                meinRechteckprofil.berechneUnbekannte(eingabeMitEinheit.eingabeMitPruefung(lbl_flaechentraegheitsmomentX.Text, "mm") , eingabeMitEinheit.eingabeMitPruefung(lbl_flaechentraegheitsmomentY.Text, "mm"));
                if (meinRechteckprofil.getQflaeche() > 0)
                { 
                eingabeBreite.Text = Convert.ToString( meinRechteckprofil.getBreite() );
                eingabeHoehe.Text = Convert.ToString(meinRechteckprofil.getHoehe());
                }
                else
                {
                    ausgabe = 1;

                    if (meinRechteckprofil.getHoehe() == 0)
                    {
                        MessageBox.Show("Mit " + eingabeHoehe.Text + " kann nicht gerechnet werden. Bitte geben sie eine Zahl ein.", "Einheitenfehler",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                        
                        FocusManager.SetFocusedElement(this, eingabeHoehe);
                        eingabeHoehe.SelectAll();
                    }
                    else if (meinRechteckprofil.getBreite() == 0)
                    {
                        MessageBox.Show("Mit " + eingabeBreite.Text + " kann nicht gerechnet werden. Bitte geben sie eine Zahl ein.", "Einheitenfehler",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                        FocusManager.SetFocusedElement(this, eingabeBreite);
                        eingabeBreite.SelectAll();
                    }
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
            else if (ausgabe == 1)
            {
                //nix
            }
            

        }


        private void zuruek_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow.Show();
        }
    }
}
