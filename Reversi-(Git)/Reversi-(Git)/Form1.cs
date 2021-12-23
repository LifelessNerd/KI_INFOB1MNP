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
        int maxXelementen = 6;
        int maxYelementen = 6;
        int[,] raster = new int[6, 6]; //TODO: fixen dat dit ook kan met variabelen (die hierboven)
        bool Speler1Zet = true;
        Panel panel = new Panel();

        public Form1()
        {
           
            InitializeComponent();           
            this.Size = new Size(800, 800);
            this.Controls.Add(panel);
            panel.Paint += this.TekenPionnen;
            panel.Paint += this.Tekenen;
            panel.MouseClick += this.Klik;

            panel.Size = new Size(maxXelementen * 100, maxYelementen * 100);
            panel.BackColor = Color.Gray;

            int rowWidth = panel.Width / maxXelementen;
            int rowHeight = panel.Height / maxYelementen;

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

            panel.Invalidate();

        }
        public void TekenPionnen(object sender, PaintEventArgs pea)
        {
            //Waarde van array = 0; leeg. = 1 van sp1 = 2 van sp2.
            Graphics g = pea.Graphics;
            for (int i = 0; i < maxXelementen; i++)
            {
                for (int j = 0; j < maxYelementen; j++) 
                {                                    
                    switch(raster[i,j])
                    {
                        case 0:
                            Console.WriteLine("raster with " + i + "," + j + ": 0");
                            break;
                        case 1:
                            Rectangle speler1 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(Brushes.Black, speler1);
                            break;
                        case 2:
                            Rectangle speler2 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(Brushes.White, speler2);
                            break;
                    
                    }

                }
            }
        }
        public void Tekenen(object sender, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            for(int i = 1; i <= maxXelementen; i++ )
            {
                Point point1 = new Point(100 * i, 0);
                Point point2 = new Point(100 * i, maxYelementen * 100);
                g.DrawLine(Pens.Black, point1, point2);
            }
            for(int i = 1; i <= maxYelementen; i++ )
            {
                Point point1 = new Point(0, 100 * i);
                Point point2 = new Point(maxXelementen * 100, 100 * i);
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
            Console.WriteLine(KlikX + " gaat naar " + RasterX);
            Console.WriteLine(KlikY + " gaat naar " + RasterY);
            if(Speler1Zet)
            {
                raster[RasterX, RasterY] = 1;
                Speler1Zet = false;            
            }    
            else()
            {
                raster[RasterX, RasterY] = 2;
                Speler1Zet=true;
            }
            panel.Invalidate();
        }
    }
}
