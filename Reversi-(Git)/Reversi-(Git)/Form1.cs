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

        public Form1()
        {
           
            InitializeComponent();
            Panel panel = new Panel();
            this.Size = new Size(800, 800);
            this.Controls.Add(panel);
            panel.Paint += this.TekenPionnen;
            panel.Paint += this.Tekenen;

            panel.Size = new Size(maxXelementen * 100, maxYelementen * 100);
            panel.BackColor = Color.Gray;

            int rowWidth = panel.Width / maxXelementen;
            int rowHeight = panel.Height / maxYelementen;

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
                            Console.WriteLine("raster with " + i + "," + j + ": 1");
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
    }
}
