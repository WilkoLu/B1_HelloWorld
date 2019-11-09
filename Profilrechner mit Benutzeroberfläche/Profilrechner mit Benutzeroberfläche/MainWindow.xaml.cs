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
