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


        string breite, hoehe, laenge, material, qflaeche;
        int breite_zahl, hoehe_zahl, laenge_zahl, qflaeche_zahl;
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Rechteckprofil";
            //MessageBox.Show("You press 1.Profil");

        }

        private void Profil2_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Rundprofil";
        }

        private void Profil3_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Rohrprofil";
        }

        private void Profil4_Click(object sender, RoutedEventArgs e)
        {
       
            textBlock.Text = "Vierkantprofil";
            
        }

        private void Profil5_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Vierkantrohr";
            

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            breite_zahl = Convert.ToInt32(breite_eintrag.Text);
            laenge_zahl = Convert.ToInt32(laenge_eintrag.Text);

            qflaeche_zahl = breite_zahl * laenge_zahl;

            qflaeche_ausgabe.Text = Convert.ToString(qflaeche_zahl);


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            breite = breite_eintrag.Text;
            hoehe = hoehe_eintrag.Text;
            laenge = laenge_eintrag.Text;
            qflaeche = qflaeche_ausgabe.Text;


          // if (rb_stahl.Checked == false)
          //  {
          //      material = "aluminium";
          //  }
          //  else
          //  {
          //      material = "stahl";
          //  }
        }


        private void Output_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Breite: " + breite + "mm" + "\nHöhe: " + hoehe + "mm" + "\nLänge: " + laenge + "mm" + "\nQuerschnittsfläche: " + qflaeche + "mm^2");
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
