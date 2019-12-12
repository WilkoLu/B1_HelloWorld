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

        Rechteckprofil meinRechteckprofil = new Rechteckprofil();

        private void fehlerprüfungMitFarbe(double pruefzahl,  TextBox eingabebox)
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
                eingabebox.Background = Brushes.Transparent ;
            }
        }

        private void berechnen(string welcheEingabe)
        {
            int ausgabe = 0; // ausgabe erfolgt nur wenn ausgabe 0 bleibt

            //Rechteckprofil meinRechteckprofil = new Rechteckprofil();

            meinRechteckprofil.setHoehe(tb_Hoehe.Text, cb_einheitHoehe.Text);
            meinRechteckprofil.setBreite(tb_Breite.Text, cb_einheitBreite.Text);
            meinRechteckprofil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinRechteckprofil.setMaterial(cb_Material.Text);

            if (meinRechteckprofil.getQflaeche() == 0 && welcheEingabe.Equals("Berechnen"))
            {
                meinRechteckprofil.berechneUnbekannte(tb_flaechentraegheitsmomentX.Text, tb_flaechentraegheitsmomentY.Text);
                if (meinRechteckprofil.getQflaeche() > 0)
                {
                    tb_Breite.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRechteckprofil.getBreite(), cb_einheitBreite.Text), 3) );
                    tb_Hoehe.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRechteckprofil.getHoehe(), cb_einheitHoehe.Text), 3) );
                }
                else
                {
                    fehlerprüfungMitFarbe(eingabeMitEinheit.eingabeMitPruefung(tb_flaechentraegheitsmomentX.Text , "mm"), tb_flaechentraegheitsmomentX); 
                    fehlerprüfungMitFarbe(eingabeMitEinheit.eingabeMitPruefung(tb_flaechentraegheitsmomentY.Text, "mm"), tb_flaechentraegheitsmomentY); 
                    ausgabe = 1;
                }

            }
            else if (meinRechteckprofil.getQflaeche() == 0)
            {
                ausgabe = 1;
            }

            fehlerprüfungMitFarbe(meinRechteckprofil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinRechteckprofil.getBreite(), tb_Breite);
            fehlerprüfungMitFarbe(meinRechteckprofil.getHoehe(), tb_Hoehe);

            if (ausgabe == 0)
            {
                tb_flaechentraegheitsmomentX.Background = Brushes.Transparent;
                tb_flaechentraegheitsmomentY.Background = Brushes.Transparent;

                lbl_qflaeche.Content = Math.Round(meinRechteckprofil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmomentX.Text = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentX(), 3) + " mm⁴";
                tb_flaechentraegheitsmomentY.Text = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentY(), 3) + " mm⁴";
                
                if (meinRechteckprofil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinRechteckprofil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinRechteckprofil.getMasse(), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinRechteckprofil.getPreis(), 3) + " €";
                }

            }


        }

        private void aendernTextBox(object sender, KeyEventArgs e)
        {
            berechnen(((TextBox)sender).Text);
        }

        private void aendernComboBox(object sender, EventArgs e)
        {
            berechnen(((ComboBox)sender).Text);
        }

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            berechnen(((Button)sender).Name);
        }

        private void CADerzeugen_Click(object sender, RoutedEventArgs e)
        {
            if (meinRechteckprofil.erzeugeCAD() == true)
            {
                Rechteck.Visibility = Visibility.Hidden;
                Linie_senkrecht.Visibility = Visibility.Hidden;
                Linie_waagerecht.Visibility = Visibility.Hidden;


                // meinRechteckprofil.erzeugeCAD();

                BitmapImage screenshot = new BitmapImage();
                screenshot.BeginInit();
                screenshot.UriSource = new Uri("C:/Temp/" + "Rechteckprofil_" + meinRechteckprofil.getBreite() +"mm_x_" + meinRechteckprofil.getHoehe() + "mm_x_" + meinRechteckprofil.getLaenge() + "mm.bmp", UriKind.Absolute);
                screenshot.EndInit();

                Rechtekprofil_screenshot.Source = screenshot;
            }
        }
    }
}
