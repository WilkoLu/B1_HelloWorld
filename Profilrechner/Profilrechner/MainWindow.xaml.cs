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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public int indexVomTab = 0;

        public MainWindow()
        {
            InitializeComponent();
            Width = 215;
            TabControl.Visibility = Visibility.Hidden;
            MinHeight = 200;
            MinWidth = 215;
        }

        


        private void tvi_Rechteckprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = new ClosableTab()
            {
                Title = "Rechteckprofil"
            };
            
            TabControl.Items.Add(newTabItem);
            


            if (Width < 575)
            {
                Width = 600;
            }
            if (Height < 500)
            {
                Height = 525;
            }
            MinWidth = 575;
            MinHeight = 500;

            if (indexVomTab == 0)
            {
                TabControl.Visibility = Visibility.Visible;
            }

            newTabItem.Focus();

            uc_Rechteckprofil meinTabRechteckprofil = new uc_Rechteckprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;

        }



        private void btn_CloseTab_Click(object sender, RoutedEventArgs e)
        {
            TabControl.Items.Remove(TabControl.SelectedItem);
            indexVomTab--;
            if (indexVomTab == 0)
            {
                TabControl.Visibility = Visibility.Hidden;
                MinHeight = 200;
                MinWidth = 215;
                Width = 215;
            }
        }

    }
}
