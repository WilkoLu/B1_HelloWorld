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
    /// Interaktionslogik für uc_Rundprofil.xaml
    /// </summary>
    public partial class uc_Rundprofil : UserControl
    {
        public uc_Rundprofil()
        {
            InitializeComponent();

        }

        Rundprofil meinRundprofil = new Rundprofil();

        private void aendernTextBox(object sender, KeyEventArgs e)
        {
            berechnen(((TextBox)sender).Name);
        }

        private void aendernComboBox(object sender, EventArgs e)
        {
            berechnen(((ComboBox)sender).Name);
        }

        private void berechnen(string welcheEingabe)
        {
            int ausgabe = 0;

            //Rundprofil meinRundprofil = new Rundprofil();

            if (welcheEingabe.Equals("tb_Durchmsser") || welcheEingabe.Equals("cb_einheitDurchmesser"))
            {
                meinRundprofil.setDurchmesser(tb_Durchmsser.Text, cb_einheitDurchmesser.Text);
                tb_Radius.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRundprofil.getRadius(), cb_einheitRadius.Text), 3) );
            }
            else if (welcheEingabe.Equals("tb_Radius") || welcheEingabe.Equals("cb_einheitRadius"))
            {
                meinRundprofil.setRadius(tb_Radius.Text, cb_einheitRadius.Text);
                tb_Durchmsser.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRundprofil.getDurchmesser(), cb_einheitDurchmesser.Text), 3 ) );
            }
            else
            {
                meinRundprofil.setDurchmesser(tb_Durchmsser.Text, cb_einheitDurchmesser.Text);
            }

            meinRundprofil.setLaenge(tb_Laenge.Text , cb_einheitLaenge.Text);
            meinRundprofil.setMaterial(cb_Material.Text);

            if (meinRundprofil.getQflaeche() == 0 && welcheEingabe.Equals("Berechnen"))
            {
                meinRundprofil.berechneUnbekannte(tb_flaechentraegheitsmoment.Text);

                if(meinRundprofil.getQflaeche() > 0)
                {
                    tb_Durchmsser.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRundprofil.getDurchmesser(), cb_einheitDurchmesser.Text), 3));
                    tb_Radius.Text = Convert.ToString(Math.Round(eingabeMitEinheit.Einheitenrueckrechner(meinRundprofil.getRadius(), cb_einheitRadius.Text), 3));
                }
                else
                {
                    ausgabe = 1;
                }
            }

            fehlerprüfungMitFarbe(meinRundprofil.getFlaechentraegheitsmoment(), tb_flaechentraegheitsmoment);
            fehlerprüfungMitFarbe(meinRundprofil.getLaenge(), tb_Laenge);
            fehlerprüfungMitFarbe(meinRundprofil.getRadius(), tb_Radius);
            fehlerprüfungMitFarbe(meinRundprofil.getDurchmesser(), tb_Durchmsser);

            if (ausgabe == 0)
            {
                tb_flaechentraegheitsmoment.Background = Brushes.Transparent;
                lbl_qflaeche.Content = Math.Round(meinRundprofil.getQflaeche(), 3) + " mm²";
                tb_flaechentraegheitsmoment.Text = Math.Round(meinRundprofil.getFlaechentraegheitsmoment(), 3) + " mm⁴";
                if (meinRundprofil.getVolumen() > 0)
                {
                    lbl_volumen.Content = Math.Round(meinRundprofil.getVolumen(), 3) + " mm³";
                    lbl_masse.Content = Math.Round(meinRundprofil.getMasse(), 3) + " kg";
                    lbl_preis.Content = Math.Round(meinRundprofil.getPreis(), 3) + " €";
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

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            berechnen(((Button)sender).Name);
        }

        private void CADerzeugen_Click(object sender, RoutedEventArgs e)
        {
            meinRundprofil.erzeugeCAD();
        }
    }
}
