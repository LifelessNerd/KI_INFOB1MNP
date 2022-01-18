using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;

namespace Parabool
{
    public partial class Parabool : Form
    {
        // In de door de designer gegenereerde andere helft van de partial class:
        // Panel grafiek;
        // TextBox aBox, bBox, cBox;
        // Label label1, label2, label3, nulpunten;

        public Parabool()
        {
            InitializeComponent();
            box_TextChanged(aBox, null);
        }

        private double a, b, c;

        private double functie(double x)
        {
            return a * x * x + b * x + c;
        }

        private void grafiek_Paint(object sender, PaintEventArgs pea)
        {
            int xMid = grafiek.Width / 2;
            int yMid = grafiek.Height / 2;
            double schaal = 0.03;
            Graphics gr = pea.Graphics;
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            // assen
            gr.DrawLine(Pens.Red, 0, yMid, grafiek.Width, yMid);
            gr.DrawLine(Pens.Red, xMid, 0, xMid, grafiek.Height);

            // grafiek
            int xPixel, yPixel, yVorigePixel;
            double xWaarde, yWaarde;
            Pen pen = new Pen(Color.Blue,3);
            yVorigePixel = 0;
            for (xPixel = -1; xPixel < grafiek.Width; xPixel++)
            {
                xWaarde = (xPixel - xMid) * schaal;
                yWaarde = this.functie(xWaarde);
                yPixel = (int)(yMid - (yWaarde / schaal));
                if (xPixel > 0)
                    gr.DrawLine(pen, xPixel-1, yVorigePixel, xPixel, yPixel);
                yVorigePixel = yPixel;
            }
        }

        private string oplossingen()
        {
            double discr, noemer, wortel;
            discr = b * b - 4 * a * c;
            noemer = 2 * a;
            if (noemer == 0)
                return "rechte lijn!";
            if (discr < 0)
                return "geen nulpunten";
            if (discr == 0)
                return "een nulpunt: " + -b / noemer;
            wortel = Math.Sqrt(discr);
            return   "twee nulpunten: "
                   + ((-b - wortel) / noemer ).ToString(CultureInfo.InvariantCulture)
                   + " en " 
                   + ((-b + wortel) / noemer ).ToString(CultureInfo.InvariantCulture);
        }

        private void box_TextChanged(object box, EventArgs ea)
        {
            try
            {
                a = double.Parse(aBox.Text, CultureInfo.InvariantCulture);
                b = double.Parse(bBox.Text, CultureInfo.InvariantCulture);
                c = double.Parse(cBox.Text, CultureInfo.InvariantCulture);
                ((TextBox)box).BackColor = Color.White;
                grafiek.Invalidate();
                nulpunten.Text = this.oplossingen();
            }
            catch (Exception e)
            {
                ((TextBox)box).BackColor = Color.Red;
                nulpunten.Text = e.Message;
            }
        }
    }
}