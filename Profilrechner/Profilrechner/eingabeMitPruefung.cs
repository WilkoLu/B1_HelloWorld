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

                string eingabe = zahl;
                bool zahlOderNicht = double.TryParse(eingabe, out rueckgabewert);
                if (zahlOderNicht == true)
                {
                    rueckgabewert = Einheitenrechner(rueckgabewert, einheit);
                }

                if (rueckgabewert == -1)
                {
                    MessageBox.Show("Die Einheit " + einheit + " wird nicht unterstützt! Bitte wählen sie eine andere.", "Einheitenfehler",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                    return 0;
                }
                else
                {
                    return rueckgabewert;
                }

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
        }
    
}

