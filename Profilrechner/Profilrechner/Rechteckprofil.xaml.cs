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
using System.Windows.Shapes;


namespace Profilrechner
{
    /// <summary>
    /// Interaktionslogik für Rechteckprofil.xaml
    /// </summary>
    public partial class Wnd_Rechteckprofil : Window
    {
        public Wnd_Rechteckprofil()
        {
            InitializeComponent();
        }

        private void Berechnen(object sender, RoutedEventArgs e)
        {
            Rechteckprofil meinRechteckprofil = new Rechteckprofil();

            meinRechteckprofil.setHoehe ( eingabeMitEinheit.eingabeMitPruefung(eingabeHoehe.Text, einheitHoehe.Text));
            meinRechteckprofil.setBreite ( eingabeMitEinheit.eingabeMitPruefung(eingabeBreite.Text, einheitBreite.Text));
            meinRechteckprofil.setLaenge ( eingabeMitEinheit.eingabeMitPruefung(eingabeLaenge.Text, einheitLaenge.Text));

            lbl_qflaeche.Content = Math.Round(meinRechteckprofil.getQflaeche() ,3)  + " mm²" ; 
            lbl_flaechentraegheitsmomentX.Content = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentX() , 3) + " mm⁴";
            lbl_flaechentraegheitsmomentY.Content = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentY() , 3) + " mm⁴";
            lbl_volumen.Content = Math.Round(meinRechteckprofil.getVolumen() , 3) + " mm³";
            lbl_masse.Content = Math.Round(meinRechteckprofil.getMasse(cb_Material.Text) , 3) + " kg";
            
        }

        private void zuruek_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow.Show();
        }
    }
}
