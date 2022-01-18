using System;
using System.Drawing;
using System.Windows.Forms;

namespace LetterTeller
{
    public class LetterTeller : Form
    {
        private TextBox invoer;
        private Label uitvoer;
        private StaafDiagram diagram;

        public LetterTeller()
        {
            this.Text = "LetterTeller";
            this.ClientSize = new Size(320, 481);
            invoer = new TextBox(); invoer.Multiline = true; 
            uitvoer = new Label();
            diagram = new StaafDiagram();
            invoer.Location  = new Point(10,  10); invoer.Size  = new Size(300, 100);
            uitvoer.Location = new Point(10, 120); uitvoer.Size = new Size( 70, 351);
            diagram.Location = new Point(90, 120); diagram.Size = new Size(210, 338);
            this.Controls.Add(invoer);
            this.Controls.Add(uitvoer);
            this.Controls.Add(diagram);

            invoer.TextChanged += berekenAntwoord;
        }

        void berekenAntwoord(object o, EventArgs ea)
        {
            TurfTab tabel = new TurfTab();
            tabel.Turf(invoer.Text);
            uitvoer.Text    = tabel.ToString();
            diagram.Waardes = tabel.Waardes;
        }
    }
}