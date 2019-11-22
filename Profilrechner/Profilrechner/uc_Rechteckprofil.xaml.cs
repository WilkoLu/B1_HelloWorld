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

        private void berechnen()
        {
            int ausgabe = 0; // ausgabe erfolgt nur wenn ausgabe 0 bleibt

            Rechteckprofil meinRechteckprofil = new Rechteckprofil();

            meinRechteckprofil.setHoehe(tb_Hoehe.Text, cb_einheitHoehe.Text);
            meinRechteckprofil.setBreite(tb_Breite.Text, cb_einheitBreite.Text);
            meinRechteckprofil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinRechteckprofil.setMaterial(cb_Material.Text);

            if (meinRechteckprofil.getQflaeche() == 0)
            {
                meinRechteckprofil.berechneUnbekannte(tb_flaechentraegheitsmomentX.Text, tb_flaechentraegheitsmomentY.Text);
                if (meinRechteckprofil.getQflaeche() > 0)
                {
                    tb_Breite.Text = Convert.ToString(meinRechteckprofil.getBreite());
                    tb_Hoehe.Text = Convert.ToString(meinRechteckprofil.getHoehe());
                }
                else
                {
                    ausgabe = 1;
                }

            }

            fehlerprüfungMitFarbe(meinRechteckprofil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinRechteckprofil.getBreite(), tb_Breite);
            fehlerprüfungMitFarbe(meinRechteckprofil.getHoehe(), tb_Hoehe);

            if (ausgabe == 0)
            {
                lbl_qflaeche.Content = Math.Round(meinRechteckprofil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmomentX.Text = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentX(), 3) + " mm⁴";
                tb_flaechentraegheitsmomentY.Text = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentY(), 3) + " mm⁴";
                lbl_schwerpunktX.Content = Math.Round(meinRechteckprofil.getSchwerpunktX(), 3) + "mm";
                lbl_schwerpunktY.Content = Math.Round(meinRechteckprofil.getSchwerpunktY(), 3) + "mm";

                if (meinRechteckprofil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinRechteckprofil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinRechteckprofil.getMasse(), 3) + " kg";
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
    }
}
