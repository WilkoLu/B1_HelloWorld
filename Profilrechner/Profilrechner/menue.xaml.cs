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
    public partial class Menue : Window
    {
        public Menue()
        {
            InitializeComponent();
        }
        private void Rechteckprofil_Click(object sender, RoutedEventArgs e)
        {
            Rechteckprofil wnd = new Rechteckprofil();
            wnd.Show();
            this.Hide();
            
        }

        private void Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
