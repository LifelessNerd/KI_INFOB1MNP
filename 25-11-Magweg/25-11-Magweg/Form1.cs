using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25_11_Magweg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1920,1080);
        }
        private void okButtonClicked(object sender, EventArgs e)
        {
            
        }
        public int mandelBrotBerekening(int x, int y)
        {
            
            return x*y;
        } 
    }
} 
