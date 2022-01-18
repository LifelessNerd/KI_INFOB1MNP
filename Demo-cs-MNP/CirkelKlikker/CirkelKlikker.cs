using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CirkelKlikker
{
    class CirkelKlikker : Form
    {
        const int maxAantal = 100;
        const int diameter = 15;
        const int straal = diameter / 2;

        private int[] xs, ys;
        private int aantal;

        public CirkelKlikker()
        {   this.xs = new int[maxAantal];
            this.ys = new int[maxAantal];
            this.aantal = 0;
            this.Text = "CirkelKlikker";
            this.Paint += teken;
            this.MouseClick += klik;
        }
        private void klik(object sender, MouseEventArgs mea)
        {
            if (this.aantal < maxAantal)
            {
                this.xs[aantal] = mea.X;
                this.ys[aantal] = mea.Y;
                this.aantal++;
                this.Invalidate();
            }
        }
        private void teken(object sender, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            for (int t = 0; t < aantal; t++)
            {
                gr.FillEllipse(Brushes.Black
                              , this.xs[t]-straal, this.ys[t]-straal
                              , diameter         , diameter   
                              );
            }
            if (aantal > 1)
            {
                int minX = ArrayBieb.Kleinste(this.xs, this.aantal) - straal;
                int maxX = ArrayBieb.Grootste(this.xs, this.aantal) + straal;
                int minY = ArrayBieb.Kleinste(this.ys, this.aantal) - straal;
                int maxY = ArrayBieb.Grootste(this.ys, this.aantal) + straal;
                gr.DrawRectangle( new Pen(Color.Blue,2), minX, minY, maxX-minX, maxY-minY);
            }
        }
    }
}