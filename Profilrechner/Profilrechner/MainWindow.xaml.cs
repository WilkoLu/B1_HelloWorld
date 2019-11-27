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
        int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            Width = 193;
            TabControl.Visibility = Visibility.Hidden;
            MinHeight = 400;
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
            index++;
            newTabItem.Title = Convert.ToString(tvi.Header) + " (" + index + ")";
            
            TabControl.Items.Add(newTabItem);

            if (Width < 900)
            {
                Width = 900;
            }
            if (Height < 550)
            {
                Height = 550;
            }
            MinWidth = 900;
            MinHeight = 550;

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

        private void tvi_Rundprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_Rundprofil meinTabRundprofil = new uc_Rundprofil();
            newTabItem.Content = meinTabRundprofil.Content;
        }

        private void Rohrprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_Rohrprofil meinTabRohrprofil = new uc_Rohrprofil();
            newTabItem.Content = meinTabRohrprofil.Content;
        }

        private void Winkelprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_Winkelprofil meinTabWinkelprofil = new uc_Winkelprofil();
            newTabItem.Content = meinTabWinkelprofil.Content;
        }

        private void TProfil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_TProfil meinTProfil = new uc_TProfil();
            newTabItem.Content = meinTProfil.Content;
        }

        private void DoppelTProfil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_DoppelTProfil meinDoppelTProfil = new uc_DoppelTProfil();
            newTabItem.Content = meinDoppelTProfil.Content;
        }

        private void Rechteckrohr_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_Rechteckrohr meinRechteckrohr = new uc_Rechteckrohr();
            newTabItem.Content = meinRechteckrohr.Content;
        }
    }
}
