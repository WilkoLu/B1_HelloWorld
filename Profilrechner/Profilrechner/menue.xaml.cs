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
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Menue : UserControl
    {
        public Menue()
        {
            InitializeComponent();
        }

        private void Rechteckprofil_Click(object sender, RoutedEventArgs e)
        {
            Wnd_Rechteckprofil wndRechteckprofil = new Wnd_Rechteckprofil();
            wndRechteckprofil.Show();
            //this.Hide();
        }

        private void Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
