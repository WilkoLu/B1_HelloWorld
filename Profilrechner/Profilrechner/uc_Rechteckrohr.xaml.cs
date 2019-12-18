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
    /// Interaktionslogik für uc_Rechteckrohr.xaml
    /// </summary>
    public partial class uc_Rechteckrohr : UserControl
    {
        public uc_Rechteckrohr()
        {
            InitializeComponent();
        }

        Rechteckrohr meinRechteckrohr = new Rechteckrohr();

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

        private void berechnen()
        {
            int ausgabe = 0; // ausgabe erfolgt nur wenn ausgabe 0 bleibt

            tooltipFuerProflExportieren.Visibility = Visibility.Visible;
            CADexportieren.IsEnabled = false;

            meinRechteckrohr.setHoehe(tb_Hoehe.Text, cb_einheitHoehe.Text);
            meinRechteckrohr.setBreite(tb_Breite.Text, cb_einheitBreite.Text);
            meinRechteckrohr.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinRechteckrohr.setWandstaerke(tb_Wandstärke.Text, cb_einheitWandstärke.Text);
            meinRechteckrohr.setMaterial(cb_Material.Text);

            if (meinRechteckrohr.getQflaeche() == 0)
            {
                ausgabe = 1;
            }

            fehlerprüfungMitFarbe(meinRechteckrohr.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinRechteckrohr.getBreite(), tb_Breite);
            fehlerprüfungMitFarbe(meinRechteckrohr.getHoehe(), tb_Hoehe);
            fehlerprüfungMitFarbe(meinRechteckrohr.getWandstärke(), tb_Wandstärke);

            if (meinRechteckrohr.getWandstärke() > meinRechteckrohr.getBreite() / 2)
            {
                tb_Breite.Background = Brushes.IndianRed;
                tb_Wandstärke.Background = Brushes.IndianRed;
                ausgabe = 1;
            }

            if (meinRechteckrohr.getWandstärke() > meinRechteckrohr.getHoehe() / 2)
            {
                tb_Hoehe.Background = Brushes.IndianRed;
                tb_Wandstärke.Background = Brushes.IndianRed;
                ausgabe = 1;
            }

            if (meinRechteckrohr.getWandstärke() * 8 < meinRechteckrohr.getBreite() 
                && meinRechteckrohr.getWandstärke() * 8 < meinRechteckrohr.getHoehe() )//checkbox anklickbar oder nicht
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

            if (ausgabe == 0)
            {

                lbl_qflaeche.Content = Math.Round(meinRechteckrohr.getQflaeche(), 3) + " mm²";
                lbl_flaechentraegheitsmomentX.Content = Math.Round(meinRechteckrohr.getFlaechenträgheitsmomentX(), 3) + " mm⁴";
                lbl_flaechentraegheitsmomentY.Content = Math.Round(meinRechteckrohr.getFlaechenträgheitsmomentY(), 3) + " mm⁴";

                if (meinRechteckrohr.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinRechteckrohr.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinRechteckrohr.getMasse(), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinRechteckrohr.getPreis(), 3) + " €";
                }

            }


        }

        private void aendernTextBox(object sender, KeyEventArgs e)
        {
            berechnen();
        }

        private void aendernComboBox(object sender, EventArgs e)
        {
            berechnen();
        }


        private void CADerzeugen_Click(object sender, RoutedEventArgs e)
        {
            if (meinRechteckrohr.erzeugeCAD(checkBoxRadius.IsChecked) == true)
            {
                Rohr_aussen.Visibility = Visibility.Hidden;
                Rohr_innen.Visibility = Visibility.Hidden;
                Linie_senkrecht.Visibility = Visibility.Hidden;
                Linie_waagerecht.Visibility = Visibility.Hidden;

                BitmapImage screenshot = new BitmapImage();
                screenshot.BeginInit();
                if (checkBoxRadius.IsChecked == true)
                {
                    screenshot.UriSource = new Uri("C:/Temp/" + "Rechteckrohr_" + meinRechteckrohr.getBreite() + "mm_x_" + meinRechteckrohr.getHoehe() + "mm_x_" + meinRechteckrohr.getWandstärke() + "mm_x_" + meinRechteckrohr.getLaenge() + "mm_Radius" + meinRechteckrohr.getWandstärke() + "mm.bmp", UriKind.Absolute);
                }
                else
                {
                    screenshot.UriSource = new Uri("C:/Temp/" + "Rechteckrohr_" + meinRechteckrohr.getBreite() + "mm_x_" + meinRechteckrohr.getHoehe() + "mm_x_" + meinRechteckrohr.getWandstärke() + "mm_x_" + meinRechteckrohr.getLaenge() + "mm.bmp", UriKind.Absolute);
                }
                screenshot.EndInit();

                Rechtekrohr_screenshot.Source = CatiaConnection.BildZuschneiden(screenshot);
                tooltipFuerProflExportieren.Visibility = Visibility.Hidden;
                CADexportieren.IsEnabled = true;
            }
        }

        private void CADexportieren_Click(object sender, RoutedEventArgs e)
        {
            meinRechteckrohr.speichern(checkBoxRadius.IsChecked);
        }


    }
}
