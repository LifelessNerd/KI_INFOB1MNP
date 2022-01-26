using System.Drawing;

namespace SchetsEditor
{
    public class GetekendVierkant
    {

        public Rectangle vierkant { get; set; }
        public Brush kleur { get; set; }
        public bool gevuld { set; get; }

        public GetekendVierkant(Rectangle vierkant, Brush kleur, bool gevuld)
        {
            this.gevuld = gevuld;

            this.vierkant = vierkant;
            this.kleur = kleur;

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