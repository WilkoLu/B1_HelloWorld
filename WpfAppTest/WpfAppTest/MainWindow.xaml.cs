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

namespace WpfAppTest
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


        string breite, hoehe, laenge, material, qflaeche, volumen, masse, horizontales_ftm, vertikales_ftm;
        int breite_zahl, hoehe_zahl, laenge_zahl, qflaeche_zahl, volumen_zahl;
        int i;
        
        

        private void Profil1_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
            textBlock.Text = "Rechteckprofil";
            //MessageBox.Show("You press 1.Profil");

        }

        private void Profil2_Click(object sender, RoutedEventArgs e)
        {
            i = 2;
            textBlock.Text = "Rundprofil";
        }

        private void Profil3_Click(object sender, RoutedEventArgs e)
        {
            i = 3;
            textBlock.Text = "Rohrprofil";
        }

        private void Profil4_Click(object sender, RoutedEventArgs e)
        {
            i = 4;

            textBlock.Text = "Vierkantprofil";
            
        }

        private void Profil5_Click(object sender, RoutedEventArgs e)
        {
            i = 5;
            textBlock.Text = "Vierkantrohr";
            

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            if (i == 1)
            {
                breite_zahl = Convert.ToInt32(breite_eintrag.Text);
                hoehe_zahl = Convert.ToInt32(hoehe_eintrag.Text);
                laenge_zahl = Convert.ToInt32(laenge_eintrag.Text);

                qflaeche_zahl = breite_zahl * hoehe_zahl;

                qflaeche_ausgabe.Text = Convert.ToString(qflaeche_zahl);

                volumen_zahl = qflaeche_zahl * laenge_zahl;

                volumen_ausgabe.Text = Convert.ToString(volumen_zahl);

                }
                else if (i == 2)
            {
                MessageBox.Show("                    FEHLER!!!" + "\n" + "\n" + "\nDieses Profil ist noch in Arbeit");

            }

            else if (i == 3)
            {

                MessageBox.Show("                    FEHLER!!!" + "\n" + "\n" + "\nDieses Profil ist noch in Arbeit");

            }

            else if (i == 4)
            {

                MessageBox.Show("                    FEHLER!!!" + "\n" + "\n" + "\nDieses Profil ist noch in Arbeit");

            }

            else if (i == 5)
            {

                MessageBox.Show("                    FEHLER!!!" + "\n" + "\n" + "\nDieses Profil ist noch in Arbeit");

            }

            else if (i == 0)
                {

                MessageBox.Show("                    FEHLER!!!" + "\n" + "\n" +  "\nSie müssen ein Profil auswählen");

                }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            breite = breite_eintrag.Text;
            hoehe = hoehe_eintrag.Text;
            laenge = laenge_eintrag.Text;
            qflaeche = qflaeche_ausgabe.Text;
            volumen = volumen_ausgabe.Text;


           if (rb_stahl.IsChecked == false)
            {
                material = "aluminium";
            }
            else
            {
                material = "stahl";
            }
        }


        private void Output_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Breite: " + breite + "mm" + "\nHöhe: " + hoehe + "mm" + "\nLänge: " + laenge + "mm" + "\nQuerschnittsfläche: " + qflaeche + "mm^2" + "\nVolumen: " + volumen + "mm^3" + "\nMasse: " + masse + "g" + "\nhorizontales FTM: " + horizontales_ftm + "mm^4" + "\nvertikales FTM: " + vertikales_ftm + "mm^4");
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
