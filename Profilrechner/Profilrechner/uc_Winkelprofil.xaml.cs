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
    /// Interaktionslogik für uc_Winkelprofil.xaml
    /// </summary>
    public partial class uc_Winkelprofil : UserControl
    {
        public uc_Winkelprofil()
        {
            InitializeComponent();
        }

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
            int ausgabe = 0;

            Winkelprofil meinWikelprofil = new Winkelprofil();

            meinWikelprofil.setHoehe(tb_Hoehe.Text, cb_einheitHoehe.Text);
            meinWikelprofil.setBreite(tb_Breite.Text, cb_einheitBreite.Text);
            meinWikelprofil.setWandstaerke(tb_Wandstaerke.Text, cb_einheitWandstaerke.Text);
            meinWikelprofil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinWikelprofil.setMaterial(cb_Material.Text);

            if(meinWikelprofil.getBreite() == 0 || meinWikelprofil.getHoehe() == 0 || meinWikelprofil.getWandstaerke() == 0)
            {
                //meinWikelprofil.berechneUnbekannte();

                if(meinWikelprofil.getBreite() > 0 && meinWikelprofil.getHoehe() > 0 && meinWikelprofil.getWandstaerke() > 0)
                {
                    //später
                }
                else
                {
                    ausgabe = 1;
                }
            }


            fehlerprüfungMitFarbe(meinWikelprofil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinWikelprofil.getWandstaerke(), tb_Wandstaerke);
            fehlerprüfungMitFarbe(meinWikelprofil.getBreite(), tb_Breite);
            fehlerprüfungMitFarbe(meinWikelprofil.getHoehe(), tb_Hoehe);

            if(meinWikelprofil.getWandstaerke() > meinWikelprofil.getHoehe() )
            {
                FocusManager.SetFocusedElement(this, tb_Hoehe);
                tb_Hoehe.SelectAll();
                tb_Hoehe.Background = Brushes.IndianRed;
                tb_Wandstaerke.Background = Brushes.IndianRed;
            }
            else if(meinWikelprofil.getWandstaerke() > meinWikelprofil.getBreite() )
            {
                tb_Breite.Background = Brushes.IndianRed;
                tb_Wandstaerke.Background = Brushes.IndianRed;
            }

            if(ausgabe == 0)
            {
                tb_flaechentraegheitsmomentX.Background = Brushes.Transparent;
                tb_flaechentraegheitsmomentY.Background = Brushes.Transparent;

                lbl_qflaeche.Content = Math.Round(meinWikelprofil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmomentX.Text = Math.Round(meinWikelprofil.getFlaechentraegheitsmomentX(), 3) + " mm⁴";
                tb_flaechentraegheitsmomentY.Text = Math.Round(meinWikelprofil.getFlaechentraegheitsmomentY(), 3) + " mm⁴";
                lbl_SchwerppunktX.Content = Math.Round(meinWikelprofil.getschwerpunktX(), 3) + " mm";
                lbl_SchwerppunktY.Content = Math.Round(meinWikelprofil.getschwerpunktY(), 3) + " mm";
                if(meinWikelprofil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinWikelprofil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinWikelprofil.getMasse(), 3) + " kg";
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



    }
}
