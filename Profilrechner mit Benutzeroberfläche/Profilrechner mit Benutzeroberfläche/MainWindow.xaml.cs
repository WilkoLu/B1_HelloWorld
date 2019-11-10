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

namespace Profilrechner_mit_Benutzeroberfläche
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            doppeltträger.Visibility = Visibility.Visible;
            lbl_hoehe.Visibility = Visibility.Visible;
            tbx_hoehe.Visibility = Visibility.Visible;
            tbx_breite.Visibility = Visibility.Visible;
            lbl_breite.Visibility = Visibility.Visible;
            lbl_qflaeche.Visibility = Visibility.Visible;
        }

        public void Berechnen(object sender, RoutedEventArgs e)
        {
            Doppel_T_Träger meinDoppel_T_Träger = new Doppel_T_Träger();

            meinDoppel_T_Träger.setHoehe (eingabeMitEinheit.eingabeMitPruefung(tbx_hoehe.Text, tbx_hoehe.Text));
            meinDoppel_T_Träger.setBreite (eingabeMitEinheit.eingabeMitPruefung(tbx_breite .Text, tbx_breite .Text));
            // meinDoppel_T_Träger.setLaenge (eingabeMitEinheit.eingabeMitPruefung(eingabeLaenge.Text, einheitLaenge.Text));

            lbl_qflaeche.Content = Math.Round(meinDoppel_T_Träger.getQflaeche(), 3) + " mm²";
            /* lbl_flaechentraegheitsmomentX.Content = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentX(), 3) + " mm⁴";
            lbl_flaechentraegheitsmomentY.Content = Math.Round(meinRechteckprofil.getFlaechenträgheitsmomentY(), 3) + " mm⁴";
            lbl_volumen.Content = Math.Round(meinRechteckprofil.getVolumen(), 3) + " mm³";
            lbl_masse.Content = Math.Round(meinRechteckprofil.getMasse(cb_Material.Text), 3) + " kg";
            **/
        }

        private void Rechteckrohr_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rechteckrohr.Header = "Test";
        }

        private void Rohrprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rohrprofil.Header = "Test";
        }
    }
}
