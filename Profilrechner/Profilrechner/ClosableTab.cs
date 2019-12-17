using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Profilrechner
{
    



    public class ClosableTab : TabItem
    {
        MainWindow mainWindow;

        TabControl TabPage;

        // Constructor
        public ClosableTab(MainWindow mainWindow)
        {
            // Kommunitkation with MainWindow

            this.mainWindow = mainWindow;

            // Create an instance of the usercontrol
            ClosableHeader closableTabHeader = new ClosableHeader();

            // Assign the usercontrol to the tab header
            this.Header = closableTabHeader;

            // Attach to the CloseableHeader events (Mouse Enter/Leave, Button Click, and Label resize)
            closableTabHeader.btn_close.MouseEnter += new MouseEventHandler(btn_close_MouseEnter);
            closableTabHeader.btn_close.MouseLeave += new MouseEventHandler(btn_close_MouseLeave);
            closableTabHeader.btn_close.Click += new RoutedEventHandler(btn_close_Click);
            closableTabHeader.lbl_TabTitle.SizeChanged += new SizeChangedEventHandler(label_TabTitle_SizeChanged);
        }



        /// <summary>
        /// Property - Set the Title of the Tab
        /// </summary>
        public string Title
        {
            set
            {
                ((ClosableHeader)this.Header).lbl_TabTitle.Content = value;
            }
        }




        //
        // - - - Overrides  - - -
        //


        // Override OnSelected - Show the Close Button
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((ClosableHeader)this.Header).btn_close.Visibility = Visibility.Visible;
        }

        // Override OnUnSelected - Hide the Close Button
        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((ClosableHeader)this.Header).btn_close.Visibility = Visibility.Hidden;
            
        }

        // Override OnMouseEnter - Show the Close Button
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((ClosableHeader)this.Header).btn_close.Visibility = Visibility.Visible;
        }

        // Override OnMouseLeave - Hide the Close Button (If it is NOT selected)
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((ClosableHeader)this.Header).btn_close.Visibility = Visibility.Hidden;
            }
        }





        //
        // - - - Event Handlers  - - -
        //


        // Button MouseEnter - When the mouse is over the button - change color to Red
        void btn_close_MouseEnter(object sender, MouseEventArgs e)
        {
            Image red = new Image();
            BitmapImage red2 = new BitmapImage();
            red2.BeginInit();
            red2.UriSource = new Uri("Bilder/close_button2red.png" , UriKind.Relative);
            red2.EndInit();
            red.Source = red2;

            ((ClosableHeader)this.Header).close_button_png.Source = red2;
        }

        // Button MouseLeave - When mouse is no longer over button - change color back to black
        void btn_close_MouseLeave(object sender, MouseEventArgs e)
        {
            Image red = new Image();
            BitmapImage red1 = new BitmapImage();
            red1.BeginInit();
            red1.UriSource = new Uri("Bilder/close_button2.png" , UriKind.Relative);
            red1.EndInit();
            red.Source = red1;

            ((ClosableHeader)this.Header).close_button_png.Source = red1;
        }


        // Button Close Click - Remove the Tab - (or raise an event indicating a "CloseTab" event has occurred)
        void btn_close_Click(object sender, RoutedEventArgs e)
        {
            TabPage = (TabControl)this.Parent;
            ((TabControl)this.Parent).Items.Remove(this);
            int ii = (TabPage).Items.Count;
            if (ii == 0)
            {
                mainWindow.MinHeight = 400;
                mainWindow.MinWidth = 193;
                mainWindow.Width = 193;
                mainWindow.Height = 550;

                mainWindow.Title = "  Stabil Profil";
            }
        }


        // Label SizeChanged - When the Size of the Label changes (due to setting the Title) set position of button properly
        void label_TabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((ClosableHeader)this.Header).btn_close.Margin = new Thickness(((ClosableHeader)this.Header).lbl_TabTitle.ActualWidth + 5, 3, 4, 0);
        }





    }
}
