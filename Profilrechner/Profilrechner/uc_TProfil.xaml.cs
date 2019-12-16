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
    /// Interaktionslogik für uc_TProfil.xaml
    /// </summary>
    public partial class uc_TProfil : UserControl
    {
        public uc_TProfil()
        {
            InitializeComponent();
        }

        TProfil meinTProfil = new TProfil();

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
            int ausgebe = 0;

            //TProfil meinTProfil = new TProfil();

            meinTProfil.setBreiteUndHoehe(tb_BreiteUndHoehe.Text, cb_einheitBreiteUndHoehe.Text);
            meinTProfil.setWandstaerke(tb_Wandstaerke.Text, cb_einheitWandstaerke.Text);
            meinTProfil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinTProfil.setMaterial(cb_Material.Text);

            if (meinTProfil.getBreiteUndHoehe() == 0 || meinTProfil.getWandstaerke() == 0)
            {
                //meinTProfil.berechneUnbekannte

                if(meinTProfil.getBreiteUndHoehe() > 0 && meinTProfil.getWandstaerke() > 0)
                {
                    //später
                }
                else
                {
                    ausgebe = 1;
                }
            }

            fehlerprüfungMitFarbe(meinTProfil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinTProfil.getWandstaerke(), tb_Wandstaerke);
            fehlerprüfungMitFarbe(meinTProfil.getBreiteUndHoehe(), tb_BreiteUndHoehe);

            if(meinTProfil.getWandstaerke() > meinTProfil.getBreiteUndHoehe())
            {
                tb_BreiteUndHoehe.Background = Brushes.IndianRed;
                tb_Wandstaerke.Background = Brushes.IndianRed;
                ausgebe = 1;
            }

            if (meinTProfil.getWandstaerke() * 4 < meinTProfil.getBreiteUndHoehe() )//checkbox anklickbar oder nicht
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

            if (ausgebe == 0)
            {
                //tb_flaechentraegheitsmomentX.Background = Brushes.Transparent;
                //tb_flaechentraegheitsmomentY.Background = Brushes.Transparent;

                lbl_qflaeche.Content = Math.Round(meinTProfil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmomentX.Content = Math.Round(meinTProfil.getFlaechentraegheitsmomentX(), 3) + " mm⁴";
                tb_flaechentraegheitsmomentY.Content = Math.Round(meinTProfil.getFlaechentraegheitsmomentY(), 3) + " mm⁴";
                lbl_SchwerppunktY.Content = Math.Round(meinTProfil.getSchwerpunkt(), 3) + " mm";
                if(meinTProfil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinTProfil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinTProfil.getMasse(), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinTProfil.getPreis(), 3) + " €";
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

        private void CADerzeugen_Click(object sender, RoutedEventArgs e)
        {
            if(meinTProfil.erzeugeCAD(checkBoxRadius.IsChecked) == true)
            {
                TProfil_senkrecht.Visibility = Visibility.Hidden;
                TProfil_waagerecht.Visibility = Visibility.Hidden;
                Linie_senkrecht.Visibility = Visibility.Hidden;
                Linie_waagerecht.Visibility = Visibility.Hidden;

                BitmapImage screenshot = new BitmapImage();
                screenshot.BeginInit();
                if(checkBoxRadius.IsChecked == true)
                {
                    screenshot.UriSource = new Uri("C:/Temp/" + "TProfil_" + meinTProfil.getBreiteUndHoehe() + "mm_x_" + meinTProfil.getWandstaerke() + "mm_x_" + meinTProfil.getLaenge() + "mm_Radius" + meinTProfil.getWandstaerke() + "mm.bmp", UriKind.Absolute);
                }
                else
                {
                    screenshot.UriSource = new Uri("C:/Temp/" + "TProfil_" + meinTProfil.getBreiteUndHoehe() + "mm_x_" + meinTProfil.getWandstaerke() + "mm_x_" + meinTProfil.getLaenge() + "mm.bmp", UriKind.Absolute);
                }
                screenshot.EndInit();

                Rechtekprofil_screenshot.Source = CatiaConnection.BildZuschneiden(screenshot);
            }
        }
        


    }
}
