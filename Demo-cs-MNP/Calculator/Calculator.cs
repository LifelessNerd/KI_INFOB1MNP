using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public class Calculator : Form
    {
        Label resultaat;
        TableLayoutPanel paneel;
        Processor proc;

        public Calculator()
        {
            proc = new Processor();
            this.Text = "Calculator";

            paneel = new TableLayoutPanel();
            paneel.Dock = DockStyle.Fill;
            paneel.ColumnCount = 4;
            for (int t = 0; t < 4; t++)
                paneel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            for (int t = 0; t < 5; t++)
                paneel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            resultaat = new Label();
            resultaat.BackColor = Color.LightYellow;
            resultaat.Text = proc.Scherm;
            resultaat.TextAlign = ContentAlignment.MiddleRight;
            resultaat.Dock = DockStyle.Fill;
            resultaat.AutoSize = true;
            resultaat.Resize += veranderFont;

            paneel.Controls.Add(resultaat);
            paneel.SetColumnSpan(resultaat, 4);

            for (int n = 0; n < 16; n++)
            {
                Button knop = new Button();
                knop.Dock = DockStyle.Fill;
                knop.Text = "789/456*123+0C=-"[n].ToString();
                knop.Click    += this.klik;
                knop.KeyPress += this.toets;
                knop.Resize   += this.veranderFont;
                paneel.Controls.Add(knop);
            }
            this.Controls.Add(paneel);
        }

        private void verwerk(char c)
        {
            switch (c)
            {
                case 'c':
                case 'C': proc.Schoon(); break;
                case '=': proc.Reken(); break;
                case '+':
                case '-':
                case '*':
                case '/': proc.Operatie(c); break;
                default:  if (c>='0' && c<='9')
                              proc.Cijfer(c - '0'); 
                          break;
            }
            resultaat.Text = proc.Scherm;
        }

        private void klik(object o, EventArgs ea)
        {
            verwerk( ((Button)o).Text[0] );
        }

        private void toets(object o, KeyPressEventArgs kpea)
        {
            verwerk(kpea.KeyChar);
        }

        private void veranderFont(object o, EventArgs ea)
        {
            Control c = (Control)o;
            int h = c.Height / 2;
            if (c == resultaat) h = c.Height / 3;
            c.Font = new Font("Tahoma", h);
        }
    }
}