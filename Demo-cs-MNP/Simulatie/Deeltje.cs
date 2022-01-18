using System.Drawing;

namespace Simulatie
{
    class Deeltje
    {
        private int x, y, dx, dy;
        private Brush brush;

        public Deeltje(Brush brush, int x, int y, int dx, int dy)
        {
            this.brush = brush;
            this.x     = x;
            this.y     = y;
            this.dx    = dx;
            this.dy    = dy;
        }
        public void DoeStap(Size hok)
        {
            this.x += this.dx;
            this.y += this.dy;

            if (this.x < 0)
            {
                this.x = -this.x;
                this.dx = -this.dx;
            }
            else if (this.x >= hok.Width)
            {
                this.x = 2 * hok.Width - this.x;
                this.dx = -this.dx;
            }
            if (this.y < 0)
            {
                this.y = -this.y;
                this.dy = -this.dy;
            }
            else if (this.y >= hok.Height)
            {
                this.y = 2 * hok.Height - this.y;
                this.dy = -this.dy;
            }
        }

        public void TekenDeeltje(Graphics gr)
        {
            gr.FillEllipse(this.brush, this.x-4, this.y-4, 9, 9);
        }
    }
}
