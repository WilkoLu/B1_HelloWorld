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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();

            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("icon.ico");
            notifyIcon.Visible = true;

            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_click);

            notifyIcon.ShowBalloonTip(400, "Profilrechner", "Erfolgreich gestartet", System.Windows.Forms.ToolTipIcon.Info);

            System.Windows.Forms.ContextMenu notifyIconContextMenue = new System.Windows.Forms.ContextMenu();
            notifyIconContextMenue.MenuItems.Add("Rechteckprofil", new EventHandler(f55));
            notifyIconContextMenue.MenuItems.Add("profil2", new EventHandler(f55));
            notifyIconContextMenue.MenuItems.Add("Rechteckprofil6", new EventHandler(f55));
            notifyIconContextMenue.MenuItems.Add("Rechteckprofil345345", new EventHandler(f55));
            notifyIconContextMenue.MenuItems.Add("Beenden", new EventHandler(Beenden));
            

            notifyIcon.ContextMenu = notifyIconContextMenue;

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
        private void f55(object sender, EventArgs e)
        {
            Rechteckprofil wnd = new Rechteckprofil();
            wnd.Show();
        }
        private void Beenden(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void notifyIcon_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Show();
            }
        }

        
    }
}
