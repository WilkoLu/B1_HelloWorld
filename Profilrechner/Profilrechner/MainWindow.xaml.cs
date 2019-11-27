using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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

            notifyIcon();
        }


        private void tvi_Rechteckprofil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosableTab newTabItem = neuenTab(sender);

            uc_Rechteckprofil meinTabRechteckprofil = new uc_Rechteckprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }

        

        public ClosableTab neuenTab(object sender)
        {
            TreeViewItem tvi = (TreeViewItem)sender;

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

        public void notifyIcon()
        {
            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("icon.ico");
            notifyIcon.Visible = true;

            //notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_click);

            System.Windows.Forms.ContextMenu notifyIconContextMenue = new System.Windows.Forms.ContextMenu();
            notifyIconContextMenue.MenuItems.Add("Rechteckprofil", new EventHandler(ni_Rechteckprofil_Click));
            notifyIconContextMenue.MenuItems.Add("Rundprofil", new EventHandler(ni_Rundprofil_Click));
            notifyIconContextMenue.MenuItems.Add("Rohrprofil", new EventHandler(ni_Rohrprofil_Click));
            notifyIconContextMenue.MenuItems.Add("Rechteckrohr", new EventHandler(ni_Rechteckrohr_Click));
            notifyIconContextMenue.MenuItems.Add("Winkelprofil", new EventHandler(ni_Winkelprofil_Click));
            notifyIconContextMenue.MenuItems.Add("T-Profil", new EventHandler(ni_TProfil_Click));
            notifyIconContextMenue.MenuItems.Add("Doppel T-Profil", new EventHandler(ni_DoppelTProfil_Click));
            notifyIconContextMenue.MenuItems.Add("Beenden", new EventHandler(Beenden));


            notifyIcon.ContextMenu = notifyIconContextMenue;

        }

        private void ni_Rechteckprofil_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_Rechteckprofil);

            uc_Rechteckprofil meinTabRechteckprofil = new uc_Rechteckprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }
        private void ni_Rundprofil_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_Rundprofil);

            uc_Rundprofil meinTabRechteckprofil = new uc_Rundprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }
        private void ni_Rohrprofil_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_Rohrprofil);

            uc_Rohrprofil meinTabRechteckprofil = new uc_Rohrprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }
        private void ni_Rechteckrohr_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_Rechteckrohr);

            uc_Rechteckrohr meinTabRechteckprofil = new uc_Rechteckrohr();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }
        private void ni_Winkelprofil_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_Winkelprofil);

            uc_Winkelprofil meinTabRechteckprofil = new uc_Winkelprofil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }
        private void ni_TProfil_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_TProfil);

            uc_TProfil meinTabRechteckprofil = new uc_TProfil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }
        private void ni_DoppelTProfil_Click(object sender, EventArgs e)
        {
            ClosableTab newTabItem = neuenTab(tvi_DoppelTProfil);

            uc_DoppelTProfil meinTabRechteckprofil = new uc_DoppelTProfil();
            newTabItem.Content = meinTabRechteckprofil.Content;
        }

        private void Beenden(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void notifyIcon_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //this.Show();

            }
        }



    }
}
