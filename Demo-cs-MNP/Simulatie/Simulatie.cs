using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Simulatie
{
    public class Simulatie : Form
    {
        private Ruimte r1, r2, r3;
        private Button stap, auto;
        private Thread animatie;

        public Simulatie()
        {
            this.ClientSize = new Size(406, 280); this.Text = "Simulatie";
            r1 = new Ruimte(); r1.Location = new Point( 10,  10); r1.Size = new Size( 80, 150);
            r2 = new Ruimte(); r2.Location = new Point(100,  10); r2.Size = new Size(296, 120);
            r3 = new Ruimte(); r3.Location = new Point( 10, 170); r3.Size = new Size(386, 100);
            stap = new Button(); stap.Location = new Point(100, 140); stap.Text = "Stap";
            auto = new Button(); auto.Location = new Point(200, 140); auto.Text = "Start";
            this.Controls.Add(r1);   this.Controls.Add(r2);   this.Controls.Add(r3);
            this.Controls.Add(stap); this.Controls.Add(auto);
            this.stap.Click += stap_Click;
            this.auto.Click += auto_Click;
        }
        private void stap_Click(object o, EventArgs ea)
        {
            r1.DoeStap();
            r2.DoeStap();
            r3.DoeStap();
        }
        private void auto_Click(object o, EventArgs ea)
        {
            if (animatie == null)
            {   animatie = new Thread(this.run);
                animatie.Start();
                auto.Text = "Stop";
            }
            else
            {   animatie = null;
                auto.Text = "Start";
            }
        }
        private void run()
        {
            while (animatie!=null)
            {   this.stap_Click(this, null);
                Thread.Sleep(50);
            }
        }
    }
}