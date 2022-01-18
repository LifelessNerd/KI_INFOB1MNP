using System.Drawing;
using System.Windows.Forms;
using CirkelKlikker;

namespace LetterTeller
{
    public partial class StaafDiagram : UserControl
    {
        private int[] waardes;

        public StaafDiagram()
        {
            this.Paint += teken;
        }

        public int[] Waardes 
        {   set 
            {   this.waardes = value; 
                this.Invalidate(); 
            } 
        }

        private void teken(object o, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            if (waardes != null)
            {
                int max = ArrayBieb.Grootste(waardes);
                if (max < 10) 
                    max = 10;
                float balkH    = (float)this.Height / waardes.Length;
                float balkUnit = (float)this.Width / max;

                for (int t = 0; t < waardes.Length; t++)
                    gr.FillRectangle(Brushes.Blue, 0, t * balkH, balkUnit * waardes[t], balkH-1);
            }
        }
    }
}