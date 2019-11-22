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

        private void btn_Berechnen_Click(object sender, RoutedEventArgs e)
        {
            
            int ausgabe = 0; // ausgabe erfolgt nur wenn ausgabe 0 bleibt

            Rechteckprofil meinRechteckprofil = new Rechteckprofil();

            meinRechteckprofil.setHoehe(tb_Hoehe.Text, cb_einheitHoehe.Text);
            meinRechteckprofil.setBreite(tb_Breite.Text, cb_einheitBreite.Text);
            meinRechteckprofil.setLaenge(tb_Laenge.Text, cb_einheitLaenge.Text);
            meinRechteckprofil.setMaterial(cb_Material.Text);

            if (meinRechteckprofil.getQflaeche() == 0)
            {
                meinRechteckprofil.berechneUnbekannte(eingabeMitEinheit.eingabeMitPruefung(tb_flaechentraegheitsmomentX.Text, "mm"), eingabeMitEinheit.eingabeMitPruefung(tb_flaechentraegheitsmomentY.Text, "mm"));
                if (meinRechteckprofil.getQflaeche() > 0)
                {
                    tb_Breite.Text = Convert.ToString(meinRechteckprofil.getBreite());
                    tb_Hoehe.Text = Convert.ToString(meinRechteckprofil.getHoehe());
                }
                else
                {
                    ausgabe = 1;

                    if (meinRechteckprofil.getHoehe() == 0)
                    {
                        eingabeMitEinheit.Fehlerausgabe(tb_Hoehe.Text);
                        FocusManager.SetFocusedElement(this, tb_Hoehe);
                        tb_Hoehe.SelectAll();
                    }
                    else if (meinRechteckprofil.getBreite() == 0)
                    {
                        eingabeMitEinheit.Fehlerausgabe(tb_Breite.Text);
                        FocusManager.SetFocusedElement(this, tb_Breite);
                        tb_Breite.SelectAll();
                    }
                }
            }

            if (meinRechteckprofil.getVolumen() == 0 && meinRechteckprofil.getQflaeche() > 0)
            {
                eingabeMitEinheit.Fehlerausgabe(tb_Laenge.Text, 0);
                if (tb_Laenge.Text.Equals("") == false)
                { 
                FocusManager.SetFocusedElement(this, tb_Laenge);
                tb_Laenge.SelectAll();
                }
            }
            
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

        
        
    }
}
