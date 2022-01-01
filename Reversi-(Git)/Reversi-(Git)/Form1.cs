using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi__Git_
{
    public partial class Form1 : Form
    {
        int maxElementen = 6;
        int[,] raster = new int[6, 6]; //TODO: fixen dat dit ook kan met variabelen (die hierboven)
        bool Speler1Zet = true;
        Panel speelveldPanel = new Panel();
        Panel scorePanel = new Panel();

        //Kleuren
        SolidBrush speler1Kleur = new SolidBrush(Color.FromArgb(77, 69, 68));
        SolidBrush speler2Kleur = new SolidBrush(Color.FromArgb(212, 191, 188));

        public Form1()
        {
           
            InitializeComponent();   
            //Speelveld 
            this.Size = new Size(800, 800);
            this.Controls.Add(speelveldPanel);
            speelveldPanel.Paint += this.TekenPionnen;
            speelveldPanel.Paint += this.Tekenen;
            speelveldPanel.MouseClick += this.Klik;

            speelveldPanel.Size = new Size(maxElementen * 100, maxElementen * 100);
            speelveldPanel.BackColor = Color.Gray;

            int rowWidth = speelveldPanel.Width / maxElementen;
            int rowHeight = speelveldPanel.Height / maxElementen;

            //Scorepanel 
            scorePanel.Size = new Size(600, 100);
            scorePanel.Location = new Point(0, (maxElementen * 100) + 10);
            scorePanel.BackColor = Color.FromArgb(60, 19, 50, 80);
            scorePanel.Paint += this.TekenScorepanel;
            this.Controls.Add(scorePanel);

            

            raster[2, 2] = 1;
            raster[3, 3] = 1;
            raster[3, 2] = 2;
            raster[2, 3] = 2;
            //Print mechanisme
            for (int i = 0; i < raster.GetLength(0); i++)
            {
                for (int j = 0; j < raster.GetLength(1); j++)
                {
                    Console.Write(raster[i, j].ToString() + " ");
                }
                Console.WriteLine("");
            }
            //Print mechanisme

            speelveldPanel.Invalidate();
            scorePanel.Invalidate();

        }

        public void TekenScorepanel(object sender, PaintEventArgs pea)
        {
            int speler1Stenen = 0;
            int speler2Stenen = 0;

            Graphics g = pea.Graphics;
            g.FillEllipse(speler1Kleur, 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);
            g.DrawEllipse(Pens.Black, 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);
            g.FillEllipse(speler2Kleur, scorePanel.Width - scorePanel.Height + 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);
            g.DrawEllipse(Pens.Black, scorePanel.Width - scorePanel.Height + 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);

            for (int i = 0; i < maxElementen; i++)
            {
                for (int j = 0; j < maxElementen; j++)
                {
                    if (raster[i,j] == 1)
                    {
                        speler1Stenen++;
                    } 
                    else if (raster[i,j] == 2)
                    {
                        speler2Stenen++;
                    }

                }
            }
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            Font drawFont = new Font("Arial", 16);

            g.DrawString(speler1Stenen.ToString(), new Font("Arial", 32) ,Brushes.White, 50, scorePanel.Height /2 , format);
            g.DrawString(speler2Stenen.ToString(), new Font("Arial", 32), Brushes.Black, scorePanel.Width - 50, scorePanel.Height / 2, format);

        }

        public void TekenPionnen(object sender, PaintEventArgs pea)
        {
            //Waarde van array = 0; leeg. = 1 van sp1 = 2 van sp2.
            Graphics g = pea.Graphics;
            for (int i = 0; i < maxElementen; i++)
            {
                for (int j = 0; j < maxElementen; j++) 
                {                                    
                    switch(raster[i,j])
                    {
                        case 0:
                            Console.WriteLine("raster with " + i + "," + j + ": 0");
                            break;
                        case 1:
                            Rectangle speler1 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(speler1Kleur, speler1);
                            break;
                        case 2:
                            Rectangle speler2 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(speler2Kleur, speler2);
                            break;
                    
                    }

                }
            }
            scorePanel.Invalidate();
        }
        public void Tekenen(object sender, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            for(int i = 1; i <= maxElementen; i++ )
            {
                Point point1 = new Point(100 * i, 0);
                Point point2 = new Point(100 * i, maxElementen * 100);
                g.DrawLine(Pens.Black, point1, point2);
            }
            for(int i = 1; i <= maxElementen; i++ )
            {
                Point point1 = new Point(0, 100 * i);
                Point point2 = new Point(maxElementen * 100, 100 * i);
                g.DrawLine(Pens.Black, point1, point2);
            }
        }
        public void Klik(object sender, MouseEventArgs mea)
        {
            Console.WriteLine("je moeder");
            int KlikX = mea.X;
            int KlikY = mea.Y;
            int RasterX = KlikX / 100;
            int RasterY = KlikY / 100;
            Point klikPunt = new Point(RasterX, RasterY);
            Console.WriteLine(KlikX + " gaat naar " + RasterX);
            Console.WriteLine(KlikY + " gaat naar " + RasterY);

            if (CheckZetLegaal(klikPunt))
            {

                if (Speler1Zet)
                {
                    raster[RasterX, RasterY] = 1;
                    Speler1Zet = false;
                }
                else
                {
                    raster[RasterX, RasterY] = 2;
                    Speler1Zet = true;
                }
                speelveldPanel.Invalidate();
            } else {
                Console.WriteLine("Zet mag niet!");
                // code met graphics zo van: kan niet idioot
            }
        }
        public bool CheckZetLegaal(Point klikPunt)
        {
            bool zetLegaal = false;
            // rijtje checks
            bool duplicateLocatie = duplicateLocatieCheck(klikPunt);
            
            //
            if (duplicateLocatie)
            {
                zetLegaal = true;
            }
            return zetLegaal;
        }

        public bool duplicateLocatieCheck(Point klikPunt)
        {
            bool zetLegaal = false;
            if (raster[klikPunt.X, klikPunt.Y] == 0 || raster[klikPunt.X, klikPunt.Y] == 3)
            {
                zetLegaal = true;
            }
            return zetLegaal;
        }
    }
}
