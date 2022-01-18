using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDemo
{
    public class CollectionDemo : Form
    {
        TextBox invoer;
        ICollection<String> alles;

        public CollectionDemo()
        {
            // Kies een mogelijke implementatie:...
            //alles = new List<String>();
            //alles = new HashSet<String>();
            alles = new SortedSet<String>();

            invoer = new TextBox(); invoer.Location = new Point(10, 10); invoer.Size = new Size(100, 14);
            Button knop = new Button(); knop.Location = new Point(130, 10); knop.Text = "Toevoegen";
            this.Controls.Add(invoer);
            this.Controls.Add(knop);
            knop.Click += klik;
            this.Paint += teken;
        }
        private void klik(object o, EventArgs ea)
        {
            alles.Add(invoer.Text);
            invoer.Text = "";
            this.Invalidate();
        }
        private void teken(object o, PaintEventArgs pea)
        {
            int y = 40;
            Font font = new Font("Tahoma", 12);
            foreach( String s in alles )
            {
                pea.Graphics.DrawString(s, font, Brushes.Black, new Point(10, y));
                y += 20;
            }
        }
    }
}
