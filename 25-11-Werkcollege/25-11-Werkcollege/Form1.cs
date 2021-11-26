using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25_11_Werkcollege
{
    public partial class Mandelbrot : Form
    {
        public Mandelbrot()
        {
            
        }

        private (double, double) okBoxClicked(object sender, EventArgs e)
        {
            
            double d1 = 2;
            double d2 = 2;
            return (d1, d2);
        }
    }
}
