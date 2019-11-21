using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Profilrechner
{
        class eingabeMitEinheit
        {
            public static double eingabeMitPruefung(string zahl, string einheit) 
            { 
                double rueckgabewert;

                
                bool zahlOderNicht = double.TryParse(zahl, out rueckgabewert);
                if (zahlOderNicht == true && rueckgabewert > 0)
                {
                    rueckgabewert = Einheitenrechner(rueckgabewert, einheit);
                }
                else if (zahlOderNicht == true && rueckgabewert < 0)
                {
                rueckgabewert = 0;
                }

                 return rueckgabewert;
            }

            public static double Einheitenrechner(double zahl, string einheit)
            {

                if (einheit.Equals("mm"))
                {
                    //es wird in mm gerechnet, also keine umwandlung
                }
                else if (einheit.Equals("cm"))
                {
                    zahl = zahl * 10;
                }
                else if (einheit.Equals("dm"))
                {
                    zahl = zahl * 100;
                }
                else if (einheit.Equals("m"))
                {
                    zahl = zahl * 1000;
                }
                else if (einheit.Equals("km"))
                {
                    zahl = zahl * 1000000;
                }
                else if (einheit.Equals("inch") || einheit.Equals("Inch") || einheit.Equals("zoll") || einheit.Equals("Zoll"))
                {
                    zahl = zahl * 25.4;
                }
                else if (einheit.Equals("ft"))
                {
                    zahl = zahl * 304.8;
                }
                else
                {
                    zahl = -1;
                }


                return zahl;
            }

            public static void Fehlerausgabe(string eingabe , int pflichteingabe = 1)
            { //pflichteingabe 0 mitübergeben wenn keine fehlermeldung kommen soll ohne eingabe

                double negativ;//unnötig braucht tryParse aber

                bool zahlOderNicht = double.TryParse(eingabe, out negativ);
                if (zahlOderNicht == true)
                { 
                    MessageBox.Show("Mit negativen Zahlen kann nicht gerechnet werden. Bitte geben sie eine positive Zahl ein.", "Einheitenfehler",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                }
                else
                { 
                    if (eingabe.Equals(""))
                    {
                        if (pflichteingabe == 1)
                        {
                        MessageBox.Show("Bitte geben sie mindestens Höhe und Breite ein.", "Eingabefehler",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                        }
                    }
                    else
                    {
                    MessageBox.Show("Mit " + eingabe + " kann nicht gerechnet werden. Bitte geben sie eine Zahl ein.", "Eingabefehler",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                    }
                }

            }



        }
    
}

