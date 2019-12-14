using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using INFITF;
using MECMOD;
using PARTITF;
using System.Threading;


namespace Profilrechner
{
    class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;


        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application) catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            // hsp_catiaPart.Part.set_Name("Rechteckprofil");
            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }

        public void ErzeugeRechteckprofilSkizze(Double b, Double h)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteck");
            
            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b / 2, h / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, h / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, -h / 2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-b / 2, -h / 2);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b / 2, h / 2, b / 2, h / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, h / 2, b / 2, -h / 2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, -h / 2, -b / 2, -h / 2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-b / 2, -h / 2, -b / 2, h / 2);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            //referenzen

            //*
            Reference ref1 = hsp_catiaPart.Part.CreateReferenceFromObject(catLine2D1);
            Reference ref2 = hsp_catiaPart.Part.CreateReferenceFromObject(catLine2D2);
            Reference ref3 = hsp_catiaPart.Part.CreateReferenceFromObject(catLine2D3);
            Reference ref4 = hsp_catiaPart.Part.CreateReferenceFromObject(catLine2D4);

            Constraints consts1 = hsp_catiaProfil.Constraints;
            Constraint const1 = consts1.AddBiEltCst(CatConstraintType.catCstTypeVerticality, ref2, ref4);
            const1.Mode = CatConstraintMode.catCstModeDrivingDimension;
            Constraints consts2 = hsp_catiaProfil.Constraints;
            Constraint const2 = consts2.AddBiEltCst(CatConstraintType.catCstTypeHorizontality, ref1, ref3);
            const2.Mode = CatConstraintMode.catCstModeDrivingDimension;

            Reference ref11 = hsp_catiaPart.Part.CreateReferenceFromObject(catLine2D1);
            //Constraints consts11 = hsp_catiaProfil.Constraints;
            Constraint const11 = consts1.AddMonoEltCst(CatConstraintType.catCstTypeLength, ref11);
            const11.Mode = CatConstraintMode.catCstModeDrivingDimension;
            // length1 = const11.Dimension;

            //*/


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeKreisprofilSkizze(Double r)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Kreis");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            //Point2D catPoint2D1 = catFactory2D1.CreatePoint(0 ,0);
            //Point2D catPoint2D2 = catFactory2D1.CreatePoint(0,r);

            // dann die Linien
            Circle2D catCircel2D1 = catFactory2D1.CreateCircle(0 , 0, r, 0, 0);
            //catCircel2D1.StartPoint = catPoint2D1;
            //catCircel2D1.EndPoint = catPoint2D2;


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeRohrprofilSkizze(Double aussenR, double innenR)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Kreisring");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            //Point2D catPoint2D1 = catFactory2D1.CreatePoint(0 ,0);
            //Point2D catPoint2D2 = catFactory2D1.CreatePoint(0,r);

            // dann die Linien
            Circle2D catCircel2D1 = catFactory2D1.CreateCircle(0, 0, aussenR, 0, 0);
            Circle2D catCircel2D2 = catFactory2D1.CreateCircle(0, 0, innenR, 0, 0);
            //catCircel2D1.StartPoint = catPoint2D1;
            //catCircel2D1.EndPoint = catPoint2D2;


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeTProfilSkizze(Double hb, Double w, Double sp)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("TProfil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-hb / 2, sp);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(hb / 2, sp);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(hb / 2, sp-w);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(w / 2, sp-w);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(w / 2, -(hb-sp));
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(-w / 2, -(hb-sp));
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(-w / 2, sp-w);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(-hb / 2, sp-w);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-hb / 2, sp, hb / 2, sp);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(hb / 2, sp, hb / 2, sp - w);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(hb / 2, sp - w, w / 2, sp - w);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(w / 2, sp - w, w / 2, -hb - sp);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(w / 2, -hb - sp, -w / 2, -hb - sp);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(-w / 2, -hb - sp, -w / 2, sp - w);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(-w / 2, sp - w, -hb / 2, sp - w);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(-hb / 2, sp - w, -hb / 2, sp);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeWinkelSkizze(Double h, Double b, Double w)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Winkelprofil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0 , h);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(w , h);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(w , w);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(b , w);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(b , 0);
            

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, 0, 0, h);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, h, w, h);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(w, h, w, w);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(w, w, b, w);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(b, w, b, 0);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(b, 0, 0, 0);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D1;


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeDoppelTProfilmitRadienausSkizze(Double h, Double b, Double s)
        {
            #region Profil mit Radien
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("DoppelTProfil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b / 2, -h / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, -h / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, (-h / 2) + s);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint((b / 2) - (s / 2) - (s * 2), (-h / 2) + s); //Radiuspunkt 1 Anfang
            Point2D catPoint2D5 = catFactory2D1.CreatePoint((b / 2) - (s / 2) - (s * 2), (-h / 2) + s + s * 2); //Radiuspunkt 1 Mittelpunkt
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(s / 2, (-h / 2) + s + s * 2); //Radiuspunkt 1 Ende
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(s / 2, (h / 2) - s - s * 2); //Radiuspunkt 2 Anfang
            Point2D catPoint2D8 = catFactory2D1.CreatePoint((b / 2) - (s / 2) - (s * 2), (h / 2) - s - s * 2); //Radiuspunkt 2 Mittelpunkt
            Point2D catPoint2D9 = catFactory2D1.CreatePoint((b / 2) - (s / 2) - (s * 2), (h / 2) - s); //Radiuspunkt 2 Ende
            Point2D catPoint2D10 = catFactory2D1.CreatePoint(b / 2, (h / 2) - s);
            Point2D catPoint2D11 = catFactory2D1.CreatePoint(b / 2, h / 2);
            Point2D catPoint2D12 = catFactory2D1.CreatePoint(-b / 2, h / 2);
            Point2D catPoint2D13 = catFactory2D1.CreatePoint(-b / 2, (h / 2) - s);
            Point2D catPoint2D14 = catFactory2D1.CreatePoint((-b / 2) + (s / 2) + (s * 2), (h / 2) - s); //Radiuspunkt 3 Anfang
            Point2D catPoint2D15 = catFactory2D1.CreatePoint((-b / 2) + (s / 2) + (s * 2), (h / 2) - s - s * 2); //Radiuspunkt 3 Mittelpunkt
            Point2D catPoint2D16 = catFactory2D1.CreatePoint((-s / 2), (h / 2) - s - s * 2); //Radiuspunkt 3 Ende
            Point2D catPoint2D17 = catFactory2D1.CreatePoint((-s / 2), (-h / 2) + s + s * 2); //Radiuspunkt 4 Anfang
            Point2D catPoint2D18 = catFactory2D1.CreatePoint((-b / 2) + (s / 2) + (s * 2), (-h / 2) + s + s * 2); //Radiuspunkt 4 Mittelpunkt
            Point2D catPoint2D19 = catFactory2D1.CreatePoint((-b / 2) + (s / 2) + (s * 2), (-h / 2) + s); //Radiuspunkt 4 Ende
            Point2D catPoint2D20 = catFactory2D1.CreatePoint(-b / 2, (-h / 2) + s);

            // dann die Linien und Kreise
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b / 2, -h / 2, b / 2, -h / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, -h / 2, b / 2, (-h / 2) + s);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, (-h / 2) + s, (b / 2) + (s / 2) + (s * 2), (-h / 2) + s);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Circle2D circle2D1 = catFactory2D1.CreateCircle((b / 2) - (s / 2) - (s * 2), (-h / 2) + s + s * 2, s * 2, 3.141593, 4.712237);
            circle2D1.CenterPoint = catPoint2D5;
            circle2D1.EndPoint = catPoint2D4;
            circle2D1.StartPoint = catPoint2D6;

            Line2D catLine2D4 = catFactory2D1.CreateLine(s / 2, (-h / 2) + s + s * 2, s / 2, (h / 2) - s - s * 2);
            catLine2D4.StartPoint = catPoint2D6;
            catLine2D4.EndPoint = catPoint2D7;

            Circle2D circle2D2 = catFactory2D1.CreateCircle((b / 2) - (s / 2) - (s * 2), (h / 2) - s - s * 2, s * 2, 1.570796, 3.141593);
            circle2D2.CenterPoint = catPoint2D8;
            circle2D2.EndPoint = catPoint2D7;
            circle2D2.StartPoint = catPoint2D9;

            Line2D catLine2D5 = catFactory2D1.CreateLine((b / 2) - (s / 2) - (s * 2), (h / 2) - s, b / 2, (h / 2) - s);
            catLine2D5.StartPoint = catPoint2D9;
            catLine2D5.EndPoint = catPoint2D10;

            Line2D catLine2D6 = catFactory2D1.CreateLine(b / 2, (h / 2) - s, b / 2, h / 2);
            catLine2D6.StartPoint = catPoint2D10;
            catLine2D6.EndPoint = catPoint2D11;

            Line2D catLine2D7 = catFactory2D1.CreateLine(b / 2, h / 2, -b / 2, h / 2);
            catLine2D7.StartPoint = catPoint2D11;
            catLine2D7.EndPoint = catPoint2D12;

            Line2D catLine2D8 = catFactory2D1.CreateLine(-b / 2, h / 2, -b / 2, (h / 2) - s);
            catLine2D8.StartPoint = catPoint2D12;
            catLine2D8.EndPoint = catPoint2D13;

            Line2D catLine2D9 = catFactory2D1.CreateLine(-b / 2, (h / 2) - s, (-b / 2) + (s / 2) + (s * 2), (h / 2) - s);
            catLine2D9.StartPoint = catPoint2D13;
            catLine2D9.EndPoint = catPoint2D14;

            Circle2D circle2D3 = catFactory2D1.CreateCircle((-b / 2) + (s / 2) + (s * 2), (h / 2) - s - s * 2, s * 2, 0, 1.570796);
            circle2D3.CenterPoint = catPoint2D15;
            circle2D3.EndPoint = catPoint2D14;
            circle2D3.StartPoint = catPoint2D16;

            Line2D catLine2D10 = catFactory2D1.CreateLine((-s / 2), (h / 2) - s - s * 2, (-s / 2), (-h / 2) + s + s * 2);
            catLine2D10.StartPoint = catPoint2D16;
            catLine2D10.EndPoint = catPoint2D17;

            Circle2D circle2D4 = catFactory2D1.CreateCircle((-b / 2) + (s / 2) + (s * 2), (-h / 2) + s + s * 2, s * 2, 4.712846, 6.283185);
            circle2D4.CenterPoint = catPoint2D18;
            circle2D4.EndPoint = catPoint2D17;
            circle2D4.StartPoint = catPoint2D19;

            Line2D catLine2D11 = catFactory2D1.CreateLine((-b / 2) + (s / 2) + (s * 2), (-h / 2) + s, -b / 2, (-h / 2) + s);
            catLine2D11.StartPoint = catPoint2D19;
            catLine2D11.EndPoint = catPoint2D20;

            Line2D catLine2D12 = catFactory2D1.CreateLine(-b / 2, (-h / 2) + s, -b / 2, -h / 2);
            catLine2D12.StartPoint = catPoint2D20;
            catLine2D12.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update(); 
            #endregion
        }

        public void ErzeugeDoppelTProfilSkizze(Double h, Double b, Double s)
        {
            #region Ohne Radien
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("DoppelTProfil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b / 2, -h / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, -h / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, (-h / 2) + s);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(s / 2, (-h / 2) + s);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(s / 2, (h / 2) - s);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(b / 2, (h / 2) - s);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(b / 2, h / 2);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(-b / 2, h / 2);
            Point2D catPoint2D9 = catFactory2D1.CreatePoint(-b / 2, (h / 2) - s);
            Point2D catPoint2D10 = catFactory2D1.CreatePoint(-s / 2, (h / 2) - s);
            Point2D catPoint2D11 = catFactory2D1.CreatePoint(-s / 2, (-h / 2) + s);
            Point2D catPoint2D12 = catFactory2D1.CreatePoint(-b / 2, (-h / 2) + s);


            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b / 2, -h / 2, b / 2, -h / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, -h / 2, b / 2, (-h / 2) + s);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, (-h / 2) + s, s / 2, (-h / 2) + s);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(s / 2, (-h / 2) + s, s / 2, (h / 2) - s);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(s / 2, (h / 2) - s, b / 2, (h / 2) - s);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(b / 2, (h / 2) - s, b / 2, h / 2);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(b / 2, h / 2, -b / 2, h / 2);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(-b / 2, h / 2, -b / 2, (h / 2) - s);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D9;

            Line2D catLine2D9 = catFactory2D1.CreateLine(-b / 2, (h / 2) - s, -s / 2, (h / 2) - s);
            catLine2D9.StartPoint = catPoint2D9;
            catLine2D9.EndPoint = catPoint2D10;

            Line2D catLine2D10 = catFactory2D1.CreateLine(-s / 2, (h / 2) - s, -s / 2, (-h / 2) + s);
            catLine2D10.StartPoint = catPoint2D10;
            catLine2D10.EndPoint = catPoint2D11;

            Line2D catLine2D11 = catFactory2D1.CreateLine(-s / 2, (-h / 2) + s, -b / 2, (-h / 2) + s);
            catLine2D11.StartPoint = catPoint2D11;
            catLine2D11.EndPoint = catPoint2D12;

            Line2D catLine2D12 = catFactory2D1.CreateLine(-b / 2, (-h / 2) + s, -b / 2, -h / 2);
            catLine2D12.StartPoint = catPoint2D12;
            catLine2D12.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update(); 
            #endregion
        }


        public void ErzeugeVolumenAusSkizze(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, l/2);
            catPad1.IsSymmetric = true;

            // Block umbenennen
            catPad1.set_Name("DoppelTProfil_" + l);

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void Radien(Double s)
        {
            #region Radius Doppel T Träger TEST1
            MECMOD.PartDocument partDocument1 = hsp_catiaApp.ActiveDocument as MECMOD.PartDocument;

            MECMOD.Part part1 = partDocument1.Part;

            PARTITF.ShapeFactory shapeFactory1 = part1.ShapeFactory as PARTITF.ShapeFactory;

            INFITF.Reference reference1 = part1.CreateReferenceFromName("");

            PARTITF.ConstRadEdgeFillet constRadEdgeFillet1 = shapeFactory1.AddNewEdgeFilletWithConstantRadius(reference1, CatFilletEdgePropagation.catTangencyFilletEdgePropagation, 2 * s);

            constRadEdgeFillet1.EdgePropagation = CatFilletEdgePropagation.catTangencyFilletEdgePropagation;

            MECMOD.Bodies bodies1 = part1.Bodies;

            MECMOD.Body body1 = bodies1.Item("Hauptkörper");

            MECMOD.Shapes shapes1 = body1.Shapes;

            PARTITF.Pad pad1 = shapes1.Item("DoppelTProfil_" + 1000) as PARTITF.Pad;

            // Kanten können noch nicht gefunden werden mit dem Code aus dem Makro!

            INFITF.Reference reference2 = part1.CreateReferenceFromBRepName("REdge: (Edge: (Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 4))); None: (); Cf11: ()); Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 3))); None: (); Cf11: ()); None: (Limits1: (); Limits2: ()); Cf11: ()); WithTemporaryBody; WithoutBuildError; WithSelectingFeatureSupport; MFBRepVersion_CXR15)", pad1);

            constRadEdgeFillet1.AddObjectToFillet(reference2);

            constRadEdgeFillet1.EdgePropagation = CatFilletEdgePropagation.catTangencyFilletEdgePropagation;

            INFITF.Reference reference3 = part1.CreateReferenceFromBRepName("REdge: (Edge: (Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 11))); None: (); Cf11: ()); Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 10))); None: (); Cf11: ()); None: (Limits1: (); Limits2: ()); Cf11: ()); WithTemporaryBody; WithoutBuildError; WithSelectingFeatureSupport; MFBRepVersion_CXR15)", pad1);

            constRadEdgeFillet1.AddObjectToFillet(reference3);

            constRadEdgeFillet1.EdgePropagation = CatFilletEdgePropagation.catTangencyFilletEdgePropagation;

            INFITF.Reference reference4 = part1.CreateReferenceFromBRepName("REdge: (Edge: (Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 5))); None: (); Cf11: ()); Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 4))); None: (); Cf11: ()); None: (Limits1: (); Limits2: ()); Cf11: ()); WithTemporaryBody; WithoutBuildError; WithSelectingFeatureSupport; MFBRepVersion_CXR15)", pad1);

            constRadEdgeFillet1.AddObjectToFillet(reference4);

            constRadEdgeFillet1.EdgePropagation = CatFilletEdgePropagation.catTangencyFilletEdgePropagation;

            INFITF.Reference reference5 = part1.CreateReferenceFromBRepName("REdge: (Edge: (Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 10))); None: (); Cf11: ()); Face: (Brp: (Pad.1; 0:(Brp: (Sketch.1; 9))); None: (); Cf11: ()); None: (Limits1: (); Limits2: ()); Cf11: ()); WithTemporaryBody; WithoutBuildError; WithSelectingFeatureSupport; MFBRepVersion_CXR15)", pad1);

            constRadEdgeFillet1.AddObjectToFillet(reference5);

            constRadEdgeFillet1.EdgePropagation = CatFilletEdgePropagation.catTangencyFilletEdgePropagation;

            part1.Update();

            #endregion
        }


        public void Screenshot(string bildname)
        {

            object[] arr1 = new object[3];
            hsp_catiaApp.ActiveWindow.ActiveViewer.GetBackgroundColor(arr1); 
            Console.WriteLine("Col: " + arr1[0] + " " + arr1[1] + " " + arr1[2]); // Normale Farbe speichern

            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe(); // Alles einpassen
            hsp_catiaApp.StartCommand("* Iso"); // in die ISO drehen
            System.Threading.Thread.Sleep(2000); //Zeit um in die ISO zu drehen
            hsp_catiaApp.StartCommand("CompassDisplayOff"); //Kompass ausblenden
            hsp_catiaApp.StartCommand("Spezifikationen"); //Specification Tree ausblenden

            #region Achsensystem ausblenden
            MECMOD.PartDocument partDocument1 = hsp_catiaPart.Application.ActiveDocument as MECMOD.PartDocument;
            partDocument1 = hsp_catiaApp.ActiveDocument as MECMOD.PartDocument;

            INFITF.Selection selection1 = hsp_catiaPart.Selection;
            selection1 = partDocument1.Selection;

            INFITF.VisPropertySet visPropertySet1;
            visPropertySet1 = selection1.VisProperties;

            MECMOD.Part part1 = partDocument1.Part;
            MECMOD.AxisSystems axisSystems1 = part1.AxisSystems;

            MECMOD.AxisSystem axisSystem1;
            axisSystem1 = axisSystems1.Item("Absolutes Achsensystem");

            axisSystems1 = axisSystem1.Parent as MECMOD.AxisSystems;

            selection1.Add(axisSystem1);

            visPropertySet1.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
            #endregion

            object[] arr2 = new object[] { 1, 1, 1 };
            hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(arr2); // Hintergrund weiß machen

            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatBMP, "C:\\Temp\\" + bildname + ".bmp"); // Screenshot machen

            #region Alles wieder einblenden und Hintergrund zurücksetzen
            hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(arr1);
            hsp_catiaApp.StartCommand("CompassDisplayOn");
            hsp_catiaApp.StartCommand("Spezifikationen");
            visPropertySet1.SetShow(CatVisPropertyShow.catVisPropertyShowAttr);
            selection1.Clear(); 
            #endregion

        }

        public void ScreenshotRadius(string bildname)
        {

            object[] arr1 = new object[3];
            hsp_catiaApp.ActiveWindow.ActiveViewer.GetBackgroundColor(arr1);
            Console.WriteLine("Col: " + arr1[0] + " " + arr1[1] + " " + arr1[2]); // Normale Farbe speichern

            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe(); // Alles einpassen
            hsp_catiaApp.StartCommand("* Iso"); // in die ISO drehen
            System.Threading.Thread.Sleep(2000); //Zeit um in die ISO zu drehen
            hsp_catiaApp.StartCommand("CompassDisplayOff"); //Kompass ausblenden
            hsp_catiaApp.StartCommand("Spezifikationen"); //Specification Tree ausblenden

            #region Achsensystem ausblenden
            MECMOD.PartDocument partDocument1 = hsp_catiaPart.Application.ActiveDocument as MECMOD.PartDocument;
            partDocument1 = hsp_catiaApp.ActiveDocument as MECMOD.PartDocument;

            INFITF.Selection selection1 = hsp_catiaPart.Selection;
            selection1 = partDocument1.Selection;

            INFITF.VisPropertySet visPropertySet1;
            visPropertySet1 = selection1.VisProperties;

            MECMOD.Part part1 = partDocument1.Part;
            MECMOD.AxisSystems axisSystems1 = part1.AxisSystems;

            MECMOD.AxisSystem axisSystem1;
            axisSystem1 = axisSystems1.Item("Absolutes Achsensystem");

            axisSystems1 = axisSystem1.Parent as MECMOD.AxisSystems;

            selection1.Add(axisSystem1);

            visPropertySet1.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
            #endregion

            object[] arr2 = new object[] { 1, 1, 1 };
            hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(arr2); // Hintergrund weiß machen

            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatBMP, "C:\\Temp\\" + bildname + ".bmp"); // Screenshot machen

            #region Alles wieder einblenden und Hintergrund zurücksetzen
            hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(arr1);
            hsp_catiaApp.StartCommand("CompassDisplayOn");
            hsp_catiaApp.StartCommand("Spezifikationen");
            visPropertySet1.SetShow(CatVisPropertyShow.catVisPropertyShowAttr);
            selection1.Clear();
            #endregion

        }
    }
}
