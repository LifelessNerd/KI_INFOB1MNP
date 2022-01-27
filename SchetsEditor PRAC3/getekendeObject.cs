using System.Collections.Generic;
using System.Drawing;

namespace SchetsEditor
{
    public class GetekendeObjecten
    {
        public string type { set; get; }
        public Rectangle vierkant { get; set; }
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public Brush kleur { get; set; }
        public bool gevuld { set; get; }
        public List<GetekendeObjecten> penLijntjes { set; get; }
        public List<char> karakters { set; get; }

        //Overload voor vierkanten
        public GetekendeObjecten(string type, Point p1, Point p2, Rectangle vierkant, Brush kleur, bool gevuld)
        {
            this.type = type;
            this.p1 = p1;
            this.p2 = p2;
            this.gevuld = gevuld;
            this.vierkant = vierkant;
            this.kleur = kleur;

        }
        //Overload voor lijnen
        public GetekendeObjecten(string type, Point p1, Point p2, Brush kleur)
        {
            this.type = type;
            this.p1 = p1;
            this.p2 = p2;
            this.kleur = kleur;
        }
        //Overload voor pen
        public GetekendeObjecten(string type, List<GetekendeObjecten> penLijntjes, Brush kleur)
        {
            this.type=type;
            this.penLijntjes = penLijntjes;
            this.kleur=kleur;
        }
        //Overload voor text - TODO: Hoe wordt tekst gedrawt? 
        //Miss ook nog coords nodig?
        public GetekendeObjecten(string type, List<char> karakters, Brush kleur)
        {
            this.type= type;
            this.karakters = karakters;
            this.kleur = kleur;
        }
        public void Teken(GetekendeObjecten getekendObject, Graphics gr)
        {
            if (getekendObject.type == "vlak")
            {
                gr.FillRectangle(kleur, vierkant);
            }
            if (getekendObject.type == "lijn")
            {
                gr.DrawLine(new Pen(getekendObject.kleur, 3), getekendObject.p1, getekendObject.p2);
            }
        }
    } 
    public class GetekendeLijntjes
    {
        public int x { set; get; }
        public int y { set; get; }
        public Color kleur { set; get; }

        public GetekendeLijntjes(int x, int y, Color kleur)
        {
            this.x = x;
            this.y = y;
            this.kleur = kleur;
        }
    }
    public class Tekst
    {
        public int x { get; set; }
        public int y { get; set; }
        public Color kleur { set; get; }
        public SizeF sizeF { get; set; }

        public Tekst(int x, int y, Color kleur, SizeF sizeF)
        {
            this.x=x;
            this.y=y;
            this.kleur=kleur;
            this.sizeF = sizeF;
        }
    }

}