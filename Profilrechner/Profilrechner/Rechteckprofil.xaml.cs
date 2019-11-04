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


            hoehe = eingabeMitPruefung(eingabeHoehe.Text, einheitHoehe.Text);
            breite = eingabeMitPruefung(eingabeBreite.Text, einheitBreite.Text);
            laenge = eingabeMitPruefung(eingabeLaenge.Text, einheitLaenge.Text);

            qflaeche = hoehe * breite;
            lbl_qflaeche.Content = qflaeche + " mm²";
            flaechenträgheitsmomentX = breite * Math.Pow(hoehe, 3) / 12;
            lbl_flaechentraegheitsmomentX.Content = flaechenträgheitsmomentX + " mm⁴";
            flaechenträgheitsmomentY = hoehe * Math.Pow(breite, 3) / 12;
            lbl_flaechentraegheitsmomentY.Content = flaechenträgheitsmomentY + " mm⁴";
            volumen = laenge * qflaeche;
            lbl_volumen.Content = volumen + " mm³";

            if (rb_stahl.IsChecked == true)
            {
                masse = volumen * 7.85 * Math.Pow(10, -6);
                lbl_masse.Content = masse + " kg";
            }
            else if (rb_aluminium.IsChecked == true)
            {
                masse = volumen * 2.7 * Math.Pow(10, -6);
                lbl_masse.Content = masse + " kg";
            }


        }

        public static double eingabeMitPruefung(string zahl, string einheit)
        {
            double rueckgabewert;

            string eingabe = zahl;
            bool zahlOderNicht = double.TryParse(eingabe, out rueckgabewert);
            if (zahlOderNicht == true)
            {
               rueckgabewert = Einheitenrechner(rueckgabewert, einheit);
            }
            
            if (rueckgabewert == -1)
            {
                MessageBox.Show("Die Einheit " + einheit + " wird nicht unterstützt! Bitte wählen sie eine andere.","Einheitenfehler",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                return 0;
            }
            else
            {
                return rueckgabewert;
            }

        }

        public static double Einheitenrechner(double zahl,string einheit)
        {

            if (einheit.Equals("mm"))
            {
                //es wird in mm gerechnet, also keine umwandlung
            }
            else if (einheit.Equals("cm"))
            {
                zahl = zahl * 10;
            }
            else if (einheit.Equals("dm"))
            {
                zahl = zahl * 100;
            }
            else if (einheit.Equals("m"))
            {
                zahl = zahl * 1000;
            }
            else if (einheit.Equals("km"))
            {
                zahl = zahl * 1000000;
            }
            else if (einheit.Equals("inch") || einheit.Equals("Inch") || einheit.Equals("zoll") || einheit.Equals("Zoll"))
            {
                zahl = zahl * 25.4;
            }
            else if (einheit.Equals("ft"))
            {
                zahl = zahl * 304.8;
            }
            else
            {
                zahl = -1;
            }


            return zahl;
        }




    }
}
