using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Profilrechner
{
    class ClosableTab
    {
        public ClosableTab()
        {
            TabItem newTabItem = new TabItem();
            ClosableHeader closableHeader = new ClosableHeader();
            closableHeader.lbl_TabTitle.Content = "Rechteckprofilsuperlang";
            newTabItem.Header = closableHeader;

        }

        

        void btn_close_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}
