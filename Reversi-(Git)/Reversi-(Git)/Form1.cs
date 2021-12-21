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
        public Form1()
        {
            InitializeComponent();
            Panel panel = new Panel();
            this.Size = new Size(800, 800);
            this.Controls.Add(panel);

            int maxXelementen = 6;
            int maxYelementen = 6;

            panel.Size = new Size(maxXelementen * 100, maxYelementen * 100);
            panel.BackColor = Color.Gray;

            int rowWidth = panel.Width / maxXelementen;
            int rowHeight = panel.Height / maxYelementen;

            int[,] raster = new int[maxXelementen, maxYelementen];

            for (int i = 0; i < maxXelementen; i++)
            {
                for (int j = 0; j < maxYelementen; j++) {

                    raster[i, j] = raster[i, j];
                    
                }
            }

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

            //MaakSpeelveld(panel);

        }
        public void MaakSpeelveld(Panel panel)
        {
            
        }
    }
}
