using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;



namespace Profilrechner
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Program();
        }


        public Program()
        {
            Window fenster = new Window();
            Menue hauptfenster = new Menue();

            fenster.Content = hauptfenster;
            fenster.Title = "Rechteckprofil";

            notifyIcon();

            fenster.SizeToContent = SizeToContent.WidthAndHeight;
            fenster.Width = hauptfenster.Width;
            fenster.Height = hauptfenster.Height;

            fenster.ShowDialog();
            fenster.Hide();
            
           
        }

        

        public void notifyIcon()
        {
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

        private void f55(object sender, EventArgs e)
        {
            Wnd_Rechteckprofil wndRechteckprofil = new Wnd_Rechteckprofil();
            wndRechteckprofil.Show();
        }
        private void Beenden(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void notifyIcon_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                
                
            }
        }

    }
}