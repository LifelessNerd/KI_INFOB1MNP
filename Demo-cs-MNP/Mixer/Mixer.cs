using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mixer
{
    public partial class Mixer : Form
    {
        public Mixer()
        {
            InitializeComponent();
        }

        private void rood_Scroll(object sender, EventArgs e)
        {
            this.toonKleur();
        }

        private void zwart_Click(object sender, EventArgs e)
        {
            this.reset(0);
        }
        private void grijs_Click(object sender, EventArgs e)
        {
            this.reset(128);
        }
        private void wit_Click(object sender, EventArgs e)
        {
            this.reset(255);
        }

        private void reset(int waarde)
        {
            rood.Value = waarde;
            groen.Value = waarde;
            blauw.Value = waarde;
            this.toonKleur();
        }
        void toonKleur()
        {
            mengkleur.BackColor = Color.FromArgb(rood.Value, groen.Value, blauw.Value);
            cijfers.Text = "(" + rood.Value + ", " + groen.Value + ", " + blauw.Value + ")";
        }
    }
}
