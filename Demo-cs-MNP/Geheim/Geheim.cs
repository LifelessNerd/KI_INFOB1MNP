using System;
using System.Drawing;
using System.Windows.Forms;

namespace Geheim
{
    public class Geheim : Form
    {
        private TextBox password;
        private bool open = false;
        private const string sleutel = "geheim";
        
        public Geheim()
        {
            this.Text = "Geheim";
            this.Paint += tekenScherm;
            this.password = new TextBox();
            this.password.Location = new Point(65, 15);
            this.password.Size = new Size(136, 20);
            this.password.PasswordChar = '*';
            this.password.TextChanged += veranderd;
            this.Controls.Add(this.password);
        }

        void veranderd(object sender, EventArgs e)
        {
            if (this.password.Text == sleutel)
            {
                open = true;
                password.Visible = false;
                this.Invalidate();
            }
        }

        void tekenScherm(object obj, PaintEventArgs pea)
        {
            if (open)
            {
                pea.Graphics.FillEllipse(Brushes.Yellow, 100, 100, 100, 100);
                pea.Graphics.FillEllipse(Brushes.Blue, 131, 135, 8, 8);
                pea.Graphics.FillEllipse(Brushes.Blue, 161, 135, 8, 8);
                pea.Graphics.DrawArc(new Pen(Color.Blue,3), 125, 125, 50, 50, 45, 90);
            }
            else
                pea.Graphics.DrawString( "please enter password", new Font("Arial", 14)
                                       , Brushes.Black, 50, 50);
        }
    }
}