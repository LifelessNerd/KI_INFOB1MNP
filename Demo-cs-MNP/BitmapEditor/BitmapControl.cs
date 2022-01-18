using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace BitmapEditor
{
    public partial class BitmapControl : UserControl
    {
        private Bitmap model;
        
        public BitmapControl()
        {
            model = new Bitmap(20, 20);
            this.Paint      += teken;
            this.Resize     += vergroot;
            this.MouseClick += klik;
            this.MouseMove  += beweeg;
        }
        public int Diameter
        {   get
            {   Size s = this.ClientSize;
                return Math.Min(s.Width / model.Breedte, s.Height / model.Hoogte);
            }
        }
        private void teken(object sender, PaintEventArgs e)
        {
            int w = model.Breedte;
            int h = model.Hoogte;
            int d = this.Diameter;
            for (int y = 0; y <= h; y++)
                e.Graphics.DrawLine(Pens.Blue, 0, y * d, w * d, y * d);
            for (int x = 0; x <= w; x++)
                e.Graphics.DrawLine(Pens.Blue, x * d, 0, x * d, h * d);
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Brush b;
                    if (model.vraagKleur(x, y))
                        b = Brushes.Red;
                    else b = Brushes.White;
                    e.Graphics.FillRectangle(b, x * d + 1, y * d + 1, d - 1, d - 1);
                }
            }
            int rx = w * d + 1;
            int ry = h * d + 1;

            Brush bg = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(bg, rx, 0, this.Width - rx, this.Height);
            e.Graphics.FillRectangle(bg, 0, ry, this.Width, this.Height - ry);
        }
        override protected void OnPaintBackground(PaintEventArgs e)
        {
        }
        private void vergroot(object sender, EventArgs e)
        {    this.Invalidate();
        }
        private void klik(object sender, MouseEventArgs mea)
        {
            int d = this.Diameter;
            int x = mea.X / d;
            int y = mea.Y / d;
            if (x >= 0 && x < model.Breedte && y >= 0 && y < model.Hoogte)
                model.veranderKleur(x, y, mea.Button == MouseButtons.Left);
            this.Invalidate();
        }
        private void beweeg(object sender, MouseEventArgs mea)
        {
            if (mea.Button == MouseButtons.Left || mea.Button==MouseButtons.Right)
                this.klik(sender, mea);
        }
        public void uitvoeren(object sender, EventArgs e)
        {
            switch (sender.ToString())
            {
                case "Clear":   this.model.Clear();   break;
                case "Invert":  this.model.Invert();  break;
                case "Bold":    this.model.Bold();    break;
                case "Outline": this.model.Outline(); break;
                case "Left":    this.model.Left();    break;
                case "Right":   this.model.Right();   break;
                case "Up":      this.model.Up();      break;
                case "Down":    this.model.Down();    break;
                case "Step":    this.model.Life();    break;
            }
            this.Invalidate();
        }

        private Thread animatie;

        public void starten(object sender, EventArgs e)
        {
            animatie = new Thread(animatieFunctie);
            animatie.Start();
        }
        public void stoppen(object sender, EventArgs e)
        {
            animatie = null;
        }
        private void animatieFunctie()
        {
            while (animatie!=null)
            {
                this.model.Life();
                this.Invalidate();
                Thread.Sleep(50);
            }
        }
    }
}