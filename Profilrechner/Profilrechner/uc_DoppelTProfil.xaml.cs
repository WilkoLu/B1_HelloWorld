
using Microsoft.Win32;
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
    /// Interaktionslogik für uc_DoppelTProfil.xaml
    /// </summary>
    public partial class uc_DoppelTProfil : UserControl
    {
        public uc_DoppelTProfil()
        {
            InitializeComponent();
        }

        DoppelTProfil meinDoppelTProfil = new DoppelTProfil();

        private void aendernTextBox(object sender, KeyEventArgs e)
        {
            berechnen(((TextBox)sender).Text);
        }

        private void aendernComboBox(object sender, EventArgs e)
        {
            berechnen(((ComboBox)sender).Text);
        }


        private void berechnen(string welcheEingabe)
        {
            CADexportieren.IsEnabled = false;
            int ausgebe = 0;

            meinDoppelTProfil.setBreite(tb_Breite.Text, cb_einheitBreite.Text);
            meinDoppelTProfil.setHoehe(tb_Hoehe.Text, cb_einheitHoehe.Text);
            meinDoppelTProfil.setSteg(tb_Steg.Text, cb_einheitSteg.Text);
            meinDoppelTProfil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinDoppelTProfil.setMaterial(cb_Material.Text);

            if (meinDoppelTProfil.getBreite() == 0 || meinDoppelTProfil.getSteg() == 0 || meinDoppelTProfil.getHoehe() == 0)
            {
                //meinTProfil.berechneUnbekannte

                if(meinDoppelTProfil.getBreite() > 0 && meinDoppelTProfil.getSteg() > 0 && meinDoppelTProfil.getHoehe() > 0)
                {
                    //später
                }
                else
                {
                    ausgebe = 1;
                }
            }

            fehlerprüfungMitFarbe(meinDoppelTProfil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinDoppelTProfil.getSteg(), tb_Steg);
            fehlerprüfungMitFarbe(meinDoppelTProfil.getBreite(), tb_Breite);
            fehlerprüfungMitFarbe(meinDoppelTProfil.getHoehe(), tb_Hoehe);

            if (meinDoppelTProfil.getSteg() > 0 && meinDoppelTProfil.getSteg() >= meinDoppelTProfil.getBreite() )
            {
                tb_Breite.Background = Brushes.IndianRed;
                tb_Steg.Background = Brushes.IndianRed;
                ausgebe = 1;
            }
            else if(meinDoppelTProfil.getSteg() > 0 && meinDoppelTProfil.getSteg() * 2 >= meinDoppelTProfil.getHoehe())
            {
                tb_Hoehe.Background = Brushes.IndianRed;
                tb_Steg.Background = Brushes.IndianRed;
                ausgebe = 1;
            }

            if (meinDoppelTProfil.getSteg()*2 < (meinDoppelTProfil.getBreite()-meinDoppelTProfil.getSteg())/2 
                && meinDoppelTProfil.getSteg() * 2 < (meinDoppelTProfil.getHoehe() - meinDoppelTProfil.getSteg()*2) / 2)
            {
                checkBoxRadius.IsEnabled = true;
                tooltipFuerCheckbox.Visibility = Visibility.Hidden;
            }
            else
            {
                checkBoxRadius.IsChecked = false;
                checkBoxRadius.IsEnabled = false;
                tooltipFuerCheckbox.Visibility = Visibility.Visible;
            }


            if(ausgebe == 0)
            {
                //tb_flaechentraegheitsmomentX.Background = Brushes.Transparent;
                //tb_flaechentraegheitsmomentY.Background = Brushes.Transparent;

                lbl_qflaeche.Content = Math.Round(meinDoppelTProfil.getQflaeche(checkBoxRadius.IsChecked), 3) + " mm²";
                tb_flaechentraegheitsmomentX.Content = Math.Round(meinDoppelTProfil.getFlaechentraegheitsmomentX(), 3) + " mm⁴";
                tb_flaechentraegheitsmomentY.Content = Math.Round(meinDoppelTProfil.getFlaechentraegheitsmomentY(), 3) + " mm⁴";
                if(meinDoppelTProfil.getVolumen(checkBoxRadius.IsChecked) > 0)
                {
                    lbl_volumen.Content = Math.Round(meinDoppelTProfil.getVolumen(checkBoxRadius.IsChecked), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinDoppelTProfil.getMasse(checkBoxRadius.IsChecked), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinDoppelTProfil.getPreis(checkBoxRadius.IsChecked), 3) + " €";
                }
            }


        }



        private void fehlerprüfungMitFarbe(double pruefzahl, TextBox eingabebox)
        {
            if (pruefzahl == 0)
            {
                if (eingabeMitEinheit.Fehlerpruefung(eingabebox.Text))
                {
                    FocusManager.SetFocusedElement(this, eingabebox);
                    eingabebox.SelectAll();
                    eingabebox.Background = Brushes.IndianRed;
                }

            }
            else
            {
                eingabebox.Background = Brushes.Transparent;
            }
        }
        
        public void CADerzeugen_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxRadius.IsChecked == false)
            {
                if (meinDoppelTProfil.erzeugeCAD() == true)
                {
                    Rechteck_oben.Visibility = Visibility.Hidden;
                    Rechteck_senkrecht.Visibility = Visibility.Hidden;
                    Rechteck_unten.Visibility = Visibility.Hidden;
                    Linie_waagerecht.Visibility = Visibility.Hidden;
                    Linie_senkrecht.Visibility = Visibility.Hidden;

                    BitmapImage screenshot = new BitmapImage();
                    screenshot.BeginInit();
                    screenshot.UriSource = new Uri("C:/Temp/" + "TProfil_" + meinDoppelTProfil.getBreite() + "mm_x_" + meinDoppelTProfil.getHoehe() + "mm_x_" + meinDoppelTProfil.getSteg() + "mm_x_" + meinDoppelTProfil.getLaenge() + "mm.bmp", UriKind.Absolute);
                    screenshot.EndInit();
                    Rechtekprofil_screenshot.Source = CatiaConnection.BildZuschneiden(screenshot);
                    CADexportieren.IsEnabled = true;
                }

            }
            else
            {
                if (meinDoppelTProfil.erzeugeCADRadius() == true)
                {
                    Rechteck_oben.Visibility = Visibility.Hidden;
                    Rechteck_senkrecht.Visibility = Visibility.Hidden;
                    Rechteck_unten.Visibility = Visibility.Hidden;
                    Linie_waagerecht.Visibility = Visibility.Hidden;
                    Linie_senkrecht.Visibility = Visibility.Hidden;

                    BitmapImage screenshot = new BitmapImage();
                    screenshot.BeginInit();
                    screenshot.UriSource = new Uri("C:/Temp/" + "TProfil_" + meinDoppelTProfil.getBreite() + "mm_x_" + meinDoppelTProfil.getHoehe() + "mm_x_" + meinDoppelTProfil.getSteg() + "mm_x_" + meinDoppelTProfil.getLaenge() + "mm_" + "Radius" + meinDoppelTProfil.getSteg() * 2 + "mm.bmp", UriKind.Absolute);
                    screenshot.EndInit();
                    Rechtekprofil_screenshot.Source = CatiaConnection.BildZuschneiden(screenshot);
                    CADexportieren.IsEnabled = true;
                }
            }
        }

        private void checkedChanged(object sender, RoutedEventArgs e)
        {
            berechnen("Checkbox");
        }

        private void CADexportieren_Click(object sender, RoutedEventArgs e)
        {
            
            meinDoppelTProfil.speichern(checkBoxRadius.IsChecked);
        }
    }
}
