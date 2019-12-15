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
    /// Interaktionslogik für uc_Rohrprofil.xaml
    /// </summary>
    public partial class uc_Rohrprofil : UserControl
    {
        public uc_Rohrprofil()
        {
            InitializeComponent();
        }

        Rohrprofil meinRohrprofil = new Rohrprofil();

        private void aendernTextBox(object sender, KeyEventArgs e)
        {
            berechnen(((TextBox)sender).Name);
        }

        private void aendernComboBox(object sender, EventArgs e)
        {
            berechnen(((ComboBox)sender).Name);
        }

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            berechnen(((Button)sender).Name);
        }

        private void berechnen(string welcheEingabe)
        {
            int ausgebe = 0;

            //Rohrprofil meinRohrprofil = new Rohrprofil();

            if (welcheEingabe.Equals("tb_aussendurchmesser") || welcheEingabe.Equals("cb_einheitAussendurchmesser"))
            {
                meinRohrprofil.setAussendurchmesser(tb_aussendurchmesser.Text, cb_einheitAussendurchmesser.Text);
                tb_aussenradius.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getAussenradius() , cb_einheitAussenradius.Text),3));
            }
            else if(welcheEingabe.Equals("tb_aussenradius") || welcheEingabe.Equals("cb_einheitAussenradius"))
            {
                meinRohrprofil.setAussenradius(tb_aussenradius.Text, cb_einheitAussenradius.Text);
                tb_aussendurchmesser.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getAussendurchmesser(), cb_einheitAussendurchmesser.Text),3));
            }
            else if (welcheEingabe.Equals("tb_innendurchmesser") || welcheEingabe.Equals("cb_einheitInnendurchmesser"))
            {
                meinRohrprofil.setInnendurchmesser(tb_innendurchmesser.Text, cb_einheitInnendurchmesser.Text);
                tb_innenradius.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getInnenradius(), cb_einheitInnenradius.Text),3));
            }
            else if (welcheEingabe.Equals("tb_innenradius") || welcheEingabe.Equals("cb_einheitInnenradius"))
            {
                meinRohrprofil.setInnenradius(tb_innenradius.Text, cb_einheitInnenradius.Text);
                tb_innendurchmesser.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getInnendurchmesser(), cb_einheitInnendurchmesser.Text),3));
            }
            
            meinRohrprofil.setAussendurchmesser(tb_aussendurchmesser.Text , cb_einheitAussendurchmesser.Text);
            meinRohrprofil.setInnendurchmesser(tb_innendurchmesser.Text, cb_einheitInnendurchmesser.Text);
            

            meinRohrprofil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinRohrprofil.setMaterial(cb_Material.Text);

            if ((meinRohrprofil.getInnendurchmesser() == 0 || meinRohrprofil.getAussendurchmesser() == 0) && welcheEingabe.Equals("Berechnen"))
            {
                meinRohrprofil.berechneUnbekannte(tb_flaechentraegheitsmoment.Text);

                if (meinRohrprofil.getInnendurchmesser() > 0 && meinRohrprofil.getAussendurchmesser() > 0)
                {
                    tb_innendurchmesser.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getInnendurchmesser(), cb_einheitInnendurchmesser.Text), 3));
                    tb_innenradius.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getInnenradius(), cb_einheitInnenradius.Text), 3));
                    tb_aussendurchmesser.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getAussendurchmesser(), cb_einheitAussendurchmesser.Text), 3));
                    tb_aussenradius.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRohrprofil.getAussenradius(), cb_einheitAussenradius.Text), 3));
                }
                else
                {
                    ausgebe = 1;
                }
            }

            fehlerprüfungMitFarbe(meinRohrprofil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinRohrprofil.getInnenradius(), tb_innenradius);
            fehlerprüfungMitFarbe(meinRohrprofil.getInnendurchmesser(), tb_innendurchmesser);
            fehlerprüfungMitFarbe(meinRohrprofil.getAussenradius(), tb_aussenradius);
            fehlerprüfungMitFarbe(meinRohrprofil.getAussendurchmesser(), tb_aussendurchmesser);

            if(meinRohrprofil.getInnendurchmesser() == 0)
            {
                if(welcheEingabe.Equals("Berechnen") == false)
                {
                    ausgebe = 1;
                }
            }

            if (meinRohrprofil.getAussendurchmesser() > 0 && welcheEingabe.Equals("Berechnen"))
            {
                tb_aussendurchmesser.Background = Brushes.IndianRed;
            }
            else if (meinRohrprofil.getInnendurchmesser() > 0 && welcheEingabe.Equals("Berechnen"))
            {
                tb_innendurchmesser.Background = Brushes.IndianRed;
            }

            if (meinRohrprofil.getInnendurchmesser() > meinRohrprofil.getAussendurchmesser())
            {
                tb_aussendurchmesser.Background = Brushes.IndianRed;
                tb_innendurchmesser.Background = Brushes.IndianRed;
                tb_aussenradius.Background = Brushes.IndianRed;
                tb_innenradius.Background = Brushes.IndianRed;

                ausgebe = 1;
            }

            if (ausgebe == 0)
            {
                tb_aussendurchmesser.Background = Brushes.Transparent;
                tb_innendurchmesser.Background = Brushes.Transparent;

                tb_flaechentraegheitsmoment.Background = Brushes.White;
                lbl_qflaeche.Content = Math.Round(meinRohrprofil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmoment.Text = Math.Round(meinRohrprofil.getFlaechentraegheitsmoment(), 3) + " mm⁴";
                if (meinRohrprofil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinRohrprofil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinRohrprofil.getMasse(), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinRohrprofil.getPreis(), 3) + " €";
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
            meinRohrprofil.erzeugeCAD();
            if(meinRohrprofil.erzeugeCAD() == true)
            {
                Kreis_aussen.Visibility = Visibility.Hidden;
                Kreis_innen.Visibility = Visibility.Hidden;

                BitmapImage screenshot = new BitmapImage();
                screenshot.BeginInit();
                screenshot.UriSource = new Uri("C:/Temp/" + "Rohrprofil_" + meinRohrprofil.getAussendurchmesser() + "mm_x_" + meinRohrprofil.getInnendurchmesser() + "mm_x_" + meinRohrprofil.getLaenge() + "mm.bmp", UriKind.Absolute);
                screenshot.EndInit();

                
                Rohrprofil_screenshot.Source = CatiaConnection.BildZuschneiden(screenshot);
            }
        }


        
    }
}
