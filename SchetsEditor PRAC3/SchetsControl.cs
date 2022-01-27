using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace SchetsEditor
{   public class SchetsControl : UserControl
    {   private Schets schets;
        private Color penkleur;

        public Color PenKleur
        { get { return penkleur; }
        }
        public Schets Schets
        { get { return schets;   }
        }
        public SchetsControl()
        {   this.BorderStyle = BorderStyle.Fixed3D;
            this.schets = new Schets();
            this.Paint += this.teken;
            this.Resize += this.veranderAfmeting;
            this.veranderAfmeting(null, null);

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        private void teken(object o, PaintEventArgs pea)
        {   schets.Teken(pea.Graphics);
        }
        private void veranderAfmeting(object o, EventArgs ea)
        {   schets.VeranderAfmeting(this.ClientSize);
            this.Invalidate();
        }
        public Graphics MaakBitmapGraphics()
        {   Graphics g = schets.BitmapGraphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            return g;
        }
        public void Schoon(object o, EventArgs ea)
        {   schets.Schoon();
            this.Invalidate();
        }
        public void Roteer(object o, EventArgs ea)
        {   schets.VeranderAfmeting(new Size(this.ClientSize.Height, this.ClientSize.Width));
            schets.Roteer();
            this.Invalidate();
        }
        //Verander kleur met een mooi menutje
        public void VeranderKleur(object obj, EventArgs ea)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penkleur = colorDialog.Color;
            }
            else 
            { 
                penkleur = Color.Black; 
            }
        }
        public void VeranderKleurViaMenu(object obj, EventArgs ea)
        {   string kleurNaam = ((ToolStripMenuItem)obj).Text;
            penkleur = Color.FromName(kleurNaam);
        }
        //Opslaan
        public void Opslaan(object obj, EventArgs ea)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Opslaan als";
            saveDialog.Filter = "Tekstfiles|*.txt|Alle files|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != null)
            {
                StreamWriter writer = new StreamWriter(saveDialog.OpenFile());

                for (int i = 0; i < schets.getekendeObjectenLijst.Count; i++)
                {
                    writer.WriteLine(schets.getekendeObjectenLijst[i].ToString());
                    //De .ToString is een eigen mehtode die in eigen format naar string converteert
                }
                //writer.Dispose();

                writer.Close();
            }
        }
        public void Openen(object obj, EventArgs ea)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Open...";
            openDialog.Filter = "Tekstfiles|*.txt|Alle files|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Invalidate();
                schets.Schoon();
                
                StreamReader reader = new StreamReader(openDialog.OpenFile());
                for (int i = 0; i < File.ReadAllLines(openDialog.FileName).Length; i++)
                {
                    schets.getekendeObjectenLijst.Add(ToShape(reader.ReadLine()));
                    //toShape pakt een string uit de file, converteert deze naar GetekendeObjecten-object
                    //Deze objecten gaan vervolgens in de lijst
                }
                Graphics gr = MaakBitmapGraphics();
                foreach (GetekendeObjecten getekendObject in schets.getekendeObjectenLijst)
                {
                    getekendObject.Teken(getekendObject, gr);
                }
                Invalidate();
            }

        }
        public GetekendeObjecten ToShape(string input)
            //Split de string van de file meerdere keren en op verschillende manier om alle info eruit te halen
            //en op een mooie manier op te slaan zodat ze direct weer gebruikt kunnen worden om een object te maken
        {
            string[] pr = input.Split('|'); //properties
            string[] p1 = pr[1].Split(',');
            string[] p2 = pr[2].Split(',');
            Point pt1 = new Point(int.Parse(p1[0]), int.Parse(p1[1]));
            Point pt2 = new Point(int.Parse(p2[0]), int.Parse(p2[1]));
            string[] vkList = pr[3].Split(',');
            Rectangle vierkant = new Rectangle(int.Parse(vkList[0]), int.Parse(vkList[1]), int.Parse(vkList[2]), int.Parse(vkList[3]));
            string[] kleur = pr[4].Split(',');
            Brush brush = new SolidBrush(Color.FromArgb(int.Parse(kleur[0]), int.Parse(kleur[1]), int.Parse(kleur[2])));
            GetekendeObjecten getekendeObjecten = new GetekendeObjecten(pr[0],pt1,pt2,vierkant, brush, true);
            return getekendeObjecten;
        }
    }
}
