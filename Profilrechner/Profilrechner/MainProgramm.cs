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
        static void Main (string[] args)
        {
            new Program();
        }


        public Program()
        {
            Window fenster = new Window();
            Menue hauptfenster = new Menue();
            
            fenster.Content = hauptfenster.Content;
            
            fenster.ShowDialog();
        }
    }
}