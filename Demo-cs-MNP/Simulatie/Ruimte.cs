using System.Drawing;
using System.Windows.Forms;

namespace Simulatie
{
    class Ruimte : UserControl
    {
        Deeltje d1, d2, d3;

        public Ruimte()
        {
            this.BackColor = Color.LightYellow;
            d1 = new Deeltje(Brushes.Red,    30, 40, 10,  10);
            d2 = new Deeltje(Brushes.Green, 100, 80,  5, -10);
            d3 = new Deeltje(Brushes.Blue,  200, 60,  8,   2);
            this.Paint += this.tekenRuimte;
        }

        public void DoeStap()
        {
            d1.DoeStap(this.Size);
            d2.DoeStap(this.Size);
            d3.DoeStap(this.Size);
            this.Invalidate();
        }

        private void tekenRuimte(object o, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            d1.TekenDeeltje(gr);
            d2.TekenDeeltje(gr);
            d3.TekenDeeltje(gr);            
        }
    }
}
