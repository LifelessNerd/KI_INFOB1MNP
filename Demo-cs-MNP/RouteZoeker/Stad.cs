using System.Collections.Generic;
using System.Drawing;

namespace RouteZoeker
{
    class Stad : IComparer<Weg>
    {
        public string Naam;
        public ICollection<Weg> Wegen;
        public Point Plek;
        private static Font font = new Font("Tahoma", 10);

        public Stad(string naam, Point plek)
        {
            this.Naam = naam;
            this.Plek = plek;
            this.Wegen = new LinkedList<Weg>();
        }
        public void BouwWeg(Stad doel, int kosten)
        {
            this.Wegen.Add(new Weg(doel, kosten));
        }
        public void Teken(Graphics gr, Brush brush)
        {
            gr.FillRectangle(brush, new Rectangle(this.Plek-new Size(5,5), new Size(10,10)));
            gr.DrawString(this.Naam, font, brush, this.Plek+new Size(6,-15));
        }

        // Implementatie van IComparer:
        // orden twee wegen in *dalende* volgorde
        // wat betreft de hemelsbrede afstand van hun doel tot deze Stad

        public int Compare(Weg a, Weg b)
        {
            return this.afstand(b.Doel) - this.afstand(a.Doel);
        }
        int afstand(Stad a)
        {
            return Stad.afstand(a.Plek, this.Plek);
        }
        static int afstand(Point a, Point b)
        {
            return kwadraat(a.X - b.X) + kwadraat(a.Y + b.Y);
            // Pythagoras zegt dat we ook nog de wortel moeten trekken,
            // maar dat doen we lekker niet, omdat het alleen om de ordening
            // van de afstanden gaat. Die verandert niet door het worteltrekken.
        }
        static int kwadraat(int x)
        {
            return x * x;
        }
    }
}