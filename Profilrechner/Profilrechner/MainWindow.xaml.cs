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
        private int indexVomTab = 0;

        public MainWindow()
        {
            InitializeComponent();
            Width = 215;
            TabControl.Visibility = Visibility.Hidden;
            btn_CloseTab.Visibility = Visibility.Hidden;
            MinHeight = 200;
            MinWidth = 215;
        }

        


        private void tvi_Rechteckprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ClosableTab newTabItem = new ClosableTab();

            TabItem newTabItem = new TabItem();
            ClosableHeader myClosableHeader = new ClosableHeader();
            myClosableHeader.lbl_TabTitle.Content = "Rechteckprofil";
            newTabItem.Header = myClosableHeader;


            TabControl.Items.Add(newTabItem);
            TabControl.SelectedItem = TabControl.Items.CurrentItem;

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
            btn_CloseTab.Visibility = Visibility.Visible;
            }
            

            uc_Rechteckprofil meinTabRechteckprofil = new uc_Rechteckprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;

            TabControl.SelectedIndex = indexVomTab;
            indexVomTab++;
        }

        public void aendereHaeder()
        {
            int test = TabControl.Items.IndexOf(TabControl.SelectedItem);
            Button.Content = test;
            TabControl.Items.Remove(TabControl.SelectedItem);
        }


        public void closeTab(int indexVomTab)
        {
            TabControl.Items.Remove(indexVomTab);
        }


        private void btn_closeTab(object sender, RoutedEventArgs e)
        {
            //nix
        }

        private void btn_CloseTab_Click(object sender, RoutedEventArgs e)
        {
            int test = TabControl.Items.IndexOf(TabControl.SelectedItem);
            Button.Content = test;
            TabControl.Items.Remove(TabControl.SelectedItem);
            indexVomTab--;
            if (indexVomTab == 0)
            {
                TabControl.Visibility = Visibility.Hidden;
                btn_CloseTab.Visibility = Visibility.Hidden;
                MinHeight = 200;
                MinWidth = 215;
                Width = 215;
            }
        }

    }
}
