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
                    //raster = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
                }
            }
            Console.WriteLine(String.Join(" ", raster.Cast<int>()));

            //MaakSpeelveld(panel);

        }
        public void MaakSpeelveld(Panel panel)
        {
            RadioButton rb = new RadioButton();
        }
    }
}
