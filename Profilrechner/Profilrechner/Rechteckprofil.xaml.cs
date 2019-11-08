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
    public partial class Rechteckprofil : Window
    {
        public Rechteckprofil()
        {
            InitializeComponent();

            
        }

        private void Berechnen(object sender, RoutedEventArgs e)
        {
            
            double qflaeche = 0;
            double volumen;
            double masse;
            double hoehe;
            double laenge = 0;
            double breite = 0;
            double flaechenträgheitsmomentX;
            double flaechenträgheitsmomentY;
            

            hoehe = eingabeMitEinheit.eingabeMitPruefung(eingabeHoehe.Text, einheitHoehe.Text);
            breite = eingabeMitEinheit.eingabeMitPruefung(eingabeBreite.Text, einheitBreite.Text);
            laenge = eingabeMitEinheit.eingabeMitPruefung(eingabeLaenge.Text, einheitLaenge.Text);

            qflaeche = hoehe * breite;
            lbl_qflaeche.Content = Math.Round(qflaeche ,3)  + " mm²" ; 
             flaechenträgheitsmomentX = breite * Math.Pow(hoehe, 3) / 12;
            lbl_flaechentraegheitsmomentX.Content = Math.Round(flaechenträgheitsmomentX , 3) + " mm⁴";
            flaechenträgheitsmomentY = hoehe * Math.Pow(breite, 3) / 12;
            lbl_flaechentraegheitsmomentY.Content = Math.Round(flaechenträgheitsmomentY , 3) + " mm⁴";
            volumen = laenge * qflaeche;
            lbl_volumen.Content = Math.Round(volumen , 3) + " mm³";

            masse = volumen * Material.dichte(cb_Material.Text);
            lbl_masse.Content = Math.Round(masse , 3) + " kg";
            

        }

        private void zuruek_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow.Show();
        }
    }
}
