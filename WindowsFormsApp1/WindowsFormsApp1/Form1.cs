using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Panel panel = new Panel();
            this.Size = new Size(800, 800);
            this.Controls.Add(panel);
           
            int MaxXelementen = 6;
            int MaxYelementen = 6;
            panel.Size = new Size(MaxXelementen * 100, MaxYelementen * 100);
            panel.BackColor = Color.Gray;
            int[,] RasterElementen;
            int[] RasterX;
            for(int i = 0; i < MaxXelementen; i++)
            {
                int[] RasterX;
                RasterX[i] = i;
            }
            MaakSpeelveld(panel);


        }
        public void MaakSpeelveld(Panel panel)
        {
            RadioButton rb = new RadioButton();
        }
    }
}
