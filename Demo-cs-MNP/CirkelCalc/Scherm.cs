using System.Windows.Forms;
using System.Drawing;
using System;

namespace CirkelCalc
{
    class Scherm : Form
    {
        private TextBox invoer;
        private Label   uitkomst;
    
        public Scherm()
        {
            Label tekst;
            Button knop;

                 tekst    = new Label();
                 knop     = new Button();
            this.invoer   = new TextBox();
            this.uitkomst = new Label();

                 tekst   .Location = new Point( 65, 10);
                 knop    .Location = new Point( 20, 30);
            this.invoer  .Location = new Point(110, 6);
            this.uitkomst.Location = new Point(110, 34);
                 tekst   .Size     = new Size ( 35, 20);
                 knop    .Size     = new Size ( 80, 20);
            this.invoer  .Size = new Size(80, 20);
            this.uitkomst.Size = new Size(120, 20);
                 tekst   .Text     = "straal:";
                 knop    .Text     = "oppervlakte:";
                 knop    .Click   += this.bereken;

            this.Text = "CirkelCalc";
            this.ClientSize = new Size(240, 60);
            this.Controls.Add(tekst);
            this.Controls.Add(knop);
            this.Controls.Add(this.invoer);
            this.Controls.Add(this.uitkomst);
        }

        private void bereken(object sender, System.EventArgs e)
        {
            double straal = double.Parse(invoer.Text);
            double opp    = this.oppervlakte(straal);
            uitkomst.Text = opp.ToString();
        }
        private double kwadraat(double x)
        {
            return x * x;
        }
        private double oppervlakte(double r)
        {
            return Math.PI * this.kwadraat(r);
        }
    }
}