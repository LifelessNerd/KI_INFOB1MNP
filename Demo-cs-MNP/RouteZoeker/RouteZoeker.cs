using System.Drawing;
using System.Windows.Forms;
using System;

namespace RouteZoeker
{
    public class RouteZoeker : Form
    {
        private Netwerk netwerk;
        private Pad pad;
        private Stad stad1;

        public RouteZoeker()
        {
            this.ClientSize = new Size(660, 680);
            this.Text = "RouteZoeker";
            this.BackColor = Color.White;
            this.MouseClick += klik;
            this.Paint += teken;

            netwerk = new Netwerk();
            netwerk.Lees("../../Spoor.txt");
        }

        private void klik(object o, MouseEventArgs mea)
        {
            Stad s = netwerk.VindStad(mea.Location);
            if (s != null)
            {
                if (stad1 == null)
                    stad1 = s;
                else
                {
                    pad = netwerk.ZoekPad(stad1, s, false);
                    stad1 = null;
                }
                this.Invalidate();
            }
        }

        private void teken(object o, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            netwerk.Teken(gr);
            if (pad != null) pad.Teken(gr, Brushes.Red, new Pen(Brushes.Red,3));
            if (stad1 != null) stad1.Teken(gr, Brushes.Blue);
        }
    }
}