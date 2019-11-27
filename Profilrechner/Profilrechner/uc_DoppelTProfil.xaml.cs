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
    public partial class uc_DoppelTProfil : UserControl
    {
        public uc_DoppelTProfil()
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
            int ausgebe = 0;

            DoppelTProfil meinDoppelTProfil = new DoppelTProfil();

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

            if (meinDoppelTProfil.getSteg() > meinDoppelTProfil.getBreite() || meinDoppelTProfil.getSteg() > meinDoppelTProfil.getHoehe()/2)
            {
                tb_Breite.Background = Brushes.IndianRed;
                tb_Hoehe.Background = Brushes.IndianRed;
                tb_Steg.Background = Brushes.IndianRed;
                ausgebe = 1;
            }

            if(ausgebe == 0)
            {
                tb_flaechentraegheitsmomentX.Background = Brushes.Transparent;
                tb_flaechentraegheitsmomentY.Background = Brushes.Transparent;

                lbl_qflaeche.Content = Math.Round(meinDoppelTProfil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmomentX.Text = Math.Round(meinDoppelTProfil.getFlaechentraegheitsmomentX(), 3) + " mm⁴";
                tb_flaechentraegheitsmomentY.Text = Math.Round(meinDoppelTProfil.getFlaechentraegheitsmomentY(), 3) + " mm⁴";
                if(meinDoppelTProfil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinDoppelTProfil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinDoppelTProfil.getMasse(), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinDoppelTProfil.getPreis(), 3) + " €";
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
