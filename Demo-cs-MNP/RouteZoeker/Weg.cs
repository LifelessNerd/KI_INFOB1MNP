using System.Drawing;

namespace RouteZoeker
{
    class Weg
    {
        public Stad Doel;
        public int Kosten;

        public Weg(Stad doel, int kosten)
        {   this.Doel = doel;
            this.Kosten = kosten;
        }
        public void Teken(Graphics gr, Pen pen, Stad stad)
        {   gr.DrawLine(pen, stad.Plek, this.Doel.Plek);
        }
    }
}