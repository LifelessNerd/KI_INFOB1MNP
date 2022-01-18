using System;
using System.Windows.Forms;

namespace Rente
{
    public partial class Rente : Form
    {
        public Rente()
        {
            InitializeComponent();
            bedragTekst.Text = "100";
            renteTekst .Text = "5";
        }

        private void rekenKnop_Click(object sender, EventArgs e)
        {
            double bedrag = double.Parse(bedragTekst.Text);
            double rente  = double.Parse(renteTekst.Text);
            resultaat.Text = "";
            int jaar;
            for (jaar = 0; jaar <= 10; jaar++)
            {
                resultaat.Text += "Na " + jaar + " jaar: " + bedrag + "\n";
                bedrag *= (1 + 0.01 * rente);
            }
        }
        // gegenereerde declaraties in de andere helft van de partial class:
        // TextBox bedragTekst;
        // TextBox renteTekst;
        // Button rekenKnop;   met rekenKnop_Click als Click-event-handler
        // Label resultaat;
    }
}
