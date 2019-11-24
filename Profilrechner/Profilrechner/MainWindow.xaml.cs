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
            Width = 193;
            TabControl.Visibility = Visibility.Hidden;
            MinHeight = 200;
            MinWidth = 193;
        }


        private void tvi_Rechteckprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_Rechteckprofil meinTabRechteckprofil = new uc_Rechteckprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;
            
        }

        public ClosableTab neuenTab(object sender)
        {
            TreeViewItem tvi = (TreeViewItem)trv_Profilauswahl.SelectedItem;

            ClosableTab newTabItem = new ClosableTab()
            {
                Title = Convert.ToString(tvi.Header)
            };
            
            TabControl.Items.Add(newTabItem);

            if (Width < 575)
            {
                Width = 600;
            }
            if (Height < 475)
            {
                Height = 475;
            }
            MinWidth = 575;
            MinHeight = 475;

            if (indexVomTab == 0)
            {
                TabControl.Visibility = Visibility.Visible;
            }

            newTabItem.Focus();
            
            return newTabItem;
        }

        private void btn_CloseTab_Click(object sender, RoutedEventArgs e)
        {
            TabControl.Items.Remove(TabControl.SelectedItem);
            indexVomTab--;
            if (indexVomTab == 0)
            {
                TabControl.Visibility = Visibility.Hidden;
                MinHeight = 200;
                MinWidth = 193;
                Width = 193;
            }
        }


    }
}
