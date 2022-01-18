using System;
using System.IO;
using System.Net;
using LetterTeller;

namespace Taalherkenning
{
    class RelTurfTab : TurfTab
    {
        bool teltmee = true;

        public RelTurfTab()
        {
        }

        private double relatief(int i)
        {   return ((double)this.tellers[i]) / this.totaal;
        }

        public double Verschil(RelTurfTab andere)
        {   if (this.totaal > 0)
            {
                double totaal = 0.0;
                for (int t = 0; t < 26; t++)
                    totaal += Math.Abs(this.relatief(t) - andere.relatief(t));
                return totaal/26;
            }
            else return 1.0;
        }

        public void Lees(string naam)
        {   TextReader reader;
            String regel;

            if (naam.StartsWith("http://") || naam.StartsWith("https://"))
                 reader = new StreamReader(new WebClient().OpenRead(naam));
            else reader = new StreamReader(naam);
            while ((regel = reader.ReadLine()) != null)
                this.Turf(regel);
            reader.Close();
        }
        protected override void turf(char c)
        {   if      (c == '<') teltmee = false;
            else if (c == '>') teltmee = true;
            else if (teltmee) base.turf(c);
        }
    }
}
