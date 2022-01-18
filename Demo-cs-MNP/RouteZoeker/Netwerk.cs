using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RouteZoeker
{
    class Netwerk
    {
        public ICollection<Stad> Steden;

        public Netwerk()
        {
            Steden = new LinkedList<Stad>();
        }
        public void Teken(Graphics gr)
        {
            foreach (Stad stad in this.Steden)
            {
                stad.Teken(gr, Brushes.Black);
                foreach (Weg weg in stad.Wegen)
                    weg.Teken(gr, Pens.Black, stad);
            }
        }
        private void bouwStad(string naam, Point plek)
        {
            Steden.Add(new Stad(naam, plek));
        }
        private void bouwWeg(string naam1, string naam2, int prijs)
        {
            Stad stad1 = this.vindStad(naam1);
            Stad stad2 = this.vindStad(naam2);
            stad1.BouwWeg(stad2, prijs);
            stad2.BouwWeg(stad1, prijs);
        }
        private Stad vindStad(string naam)
        {
            foreach (Stad stad in this.Steden)
            {
                if (stad.Naam == naam)
                    return stad;
            }
            return null;
        }
        public Stad VindStad(Point p)
        {
            foreach (Stad stad in this.Steden)
            {
                if (Math.Abs(p.X - stad.Plek.X) < 5 && Math.Abs(p.Y - stad.Plek.Y) < 5)
                    return stad;
            }
            return null;
        }
        public void Lees(string filenaam)
        {
            int nr = 0;
            StreamReader sr = new StreamReader(filenaam);
            string regel;
            string[] woorden;
            char[] separators = { ' ' };
            while ((regel = sr.ReadLine()) != null)
            {
                nr++;
                woorden = regel.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (woorden.Length == 4)
                {
                    if (woorden[0] == "stad")
                        this.bouwStad( woorden[1]
                                     , new Point( int.Parse(woorden[2])
                                                , int.Parse(woorden[3])));
                    else if (woorden[0] == "weg")
                        this.bouwWeg(woorden[1], woorden[2], int.Parse(woorden[3]));
                }
            }
        }
        public Pad ZoekPad(Stad van, Stad naar, bool slim)
        {
            Stack<Pad> paden = new Stack<Pad>();
            Pad beste = null;

            paden.Push(new Pad(van, null, 0));

            while (paden.Count > 0)
            {
                Pad pad = paden.Pop();
                if (pad.Hier == naar)
                {
                    if (beste == null || pad.Kosten < beste.Kosten)
                        beste = pad;
                }
                ICollection<Weg> wegen;
                if (slim)
                     wegen = new SortedSet<Weg>(pad.Hier.Wegen, naar);
                else wegen = pad.Hier.Wegen;

                foreach (Weg weg in wegen)
                {
                    if (  !pad.Bevat(weg.Doel) 
                       && (beste==null || pad.Kosten+weg.Kosten<=beste.Kosten)
                       )
                        paden.Push( new Pad(weg.Doel, pad, weg.Kosten) );
                }
            }
            return beste;
        }
    }
}