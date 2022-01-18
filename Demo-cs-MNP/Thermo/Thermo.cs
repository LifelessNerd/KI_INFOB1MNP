using System;
using System.Windows.Forms;

namespace Thermo
{
    public partial class Thermo : Form
    {
        private TrackBar minimum;
        private TrackBar temperatuur;
        private TrackBar maximum;
        private Button reset;

        public Thermo()
        {
            InitializeComponent();
            this.temperatuur.Scroll += temperatuur_Scroll;
            this.reset.Click        += reset_Click;
        }

        private void temperatuur_Scroll(object sender, EventArgs e)
        {
            int x = this.temperatuur.Value;
            if (x < this.minimum.Value)
                this.minimum.Value = x;
            if (x > this.maximum.Value)
                this.maximum.Value = x;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.minimum.Value = this.temperatuur.Value;
            this.maximum.Value = this.temperatuur.Value;
        }
    }
}
