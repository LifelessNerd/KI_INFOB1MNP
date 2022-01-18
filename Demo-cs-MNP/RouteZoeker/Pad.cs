using System.Drawing;

namespace RouteZoeker
{
    class Pad
    {
        public Stad Hier;
        public Pad Rest;
        public int Kosten;

        public Pad(Stad hier, Pad rest, int k)
        {   this.Hier = hier;
            this.Rest = rest;
            this.Kosten = k;
            if (rest != null) 
                this.Kosten += rest.Kosten;
        }
        public bool Bevat(Stad s)
        {   if (this.Hier == s) return true;
            if (this.Rest == null) return false;
            return Rest.Bevat(s);
        }
        public void Teken(Graphics gr, Brush brush, Pen pen)
        {   this.Hier.Teken(gr,brush);
            if (this.Rest != null)
            {   gr.DrawLine(pen, Hier.Plek, Rest.Hier.Plek);
                this.Rest.Teken(gr, brush, pen);
            }
        }
    }
}