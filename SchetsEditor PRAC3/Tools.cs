using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SchetsEditor
{
    public interface ISchetsTool
    {
        void MuisVast(SchetsControl s, Point p);
        void MuisDrag(SchetsControl s, Point p);
        void MuisLos(SchetsControl s, Point p);
        void Letter(SchetsControl s, char c);


    }
    public abstract class StartpuntTool : ISchetsTool
    {
        protected Point startpunt;
        protected Brush kwast;

        

        public virtual void MuisVast(SchetsControl s, Point p)
        {   
            startpunt = p;
            
        }
        public virtual void MuisLos(SchetsControl s, Point p)
        {   kwast = new SolidBrush(s.PenKleur);
        }
        public abstract void MuisDrag(SchetsControl s, Point p);
        public abstract void Letter(SchetsControl s, char c);
    }

    public class TekstTool : StartpuntTool
    {
        public override string ToString() { return "tekst"; }

        public override void MuisDrag(SchetsControl s, Point p) { }

        public override void Letter(SchetsControl s, char c)
        {
            if (c >= 32)
            {
                Graphics gr = s.MaakBitmapGraphics();
                Font font = new Font("Tahoma", 40);
                string tekst = c.ToString();
                SizeF sz = 
                gr.MeasureString(tekst, font, this.startpunt, StringFormat.GenericTypographic);
                gr.DrawString   (tekst, font, kwast, this.startpunt, StringFormat.GenericTypographic);
                // gr.DrawRectangle(Pens.Black, startpunt.X, startpunt.Y, sz.Width, sz.Height);
                startpunt.X += (int)sz.Width;
                s.Invalidate();
            }
        }
    }

    public abstract class TweepuntTool : StartpuntTool
    {
        public static Rectangle Punten2Rechthoek(Point p1, Point p2)
        {   return new Rectangle( new Point(Math.Min(p1.X,p2.X), Math.Min(p1.Y,p2.Y))
                                , new Size (Math.Abs(p1.X-p2.X), Math.Abs(p1.Y-p2.Y))
                                );

        }
        public static Pen MaakPen(Brush b, int dikte)
        {   Pen pen = new Pen(b, dikte);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            return pen;
        }
        public override void MuisVast(SchetsControl s, Point p)
        {   base.MuisVast(s, p);
            kwast = Brushes.Gray;
        }
        public override void MuisDrag(SchetsControl s, Point p)
        {   s.Refresh();
            this.Bezig(s.CreateGraphics(), this.startpunt, p);
        }
        public override void MuisLos(SchetsControl s, Point p)
        {   base.MuisLos(s, p);
            this.Compleet(s.MaakBitmapGraphics(), this.startpunt, p, s);
            s.Invalidate();

        }
        public override void Letter(SchetsControl s, char c)
        {
        }
        public abstract void Bezig(Graphics g, Point p1, Point p2);
        
        public virtual void Compleet(Graphics g, Point p1, Point p2, SchetsControl s)
        {   this.Bezig(g, p1, p2);

            
        }
    }

    public class RechthoekTool : TweepuntTool
    {
        public override string ToString() { return "kader"; }

        public override void Bezig(Graphics g, Point p1, Point p2)
        {   g.DrawRectangle(MaakPen(kwast,3), TweepuntTool.Punten2Rechthoek(p1, p2));
            
        }
        public override void Compleet(Graphics g, Point p1, Point p2, SchetsControl s)
        {
            base.Compleet(g, p1, p2, s);
            //Toegevoegd
            GetekendeObjecten getekendObject = new GetekendeObjecten(this.ToString(), p1, p2, Punten2Rechthoek(p1, p2), kwast, false );
            s.Schets.getekendeObjectenLijst.Add(getekendObject);
            //Maakt nieuw object aan met properties en voegt hem toe aan lijst
        }


    }
    
    public class VolRechthoekTool : RechthoekTool
    {
        public override string ToString() { return "vlak"; }

        public override void Compleet(Graphics g, Point p1, Point p2, SchetsControl s)
        {   g.FillRectangle(kwast, TweepuntTool.Punten2Rechthoek(p1, p2));
            GetekendeObjecten getekendObject = new GetekendeObjecten(this.ToString(), p1, p2, Punten2Rechthoek(p1, p2), kwast, true);
            s.Schets.getekendeObjectenLijst.Add(getekendObject);
            //Maakt nieuw object aan met properties en voegt hem toe aan lijst
        }

    }

    public class LijnTool : TweepuntTool
    {
        public override string ToString() { return "lijn"; }

        public override void Bezig(Graphics g, Point p1, Point p2)
        {   g.DrawLine(MaakPen(this.kwast,3), p1, p2);
        }
        //Compleet toegevoegd..deze was er eerst niet, waarom niet? hopelijk functioneert het alsnog
        //ja dat doet het dank moeder maria
        public override void Compleet(Graphics g, Point p1, Point p2, SchetsControl s)
        {
            base.Compleet(g, p1, p2, s);
            GetekendeObjecten getekendObject = new GetekendeObjecten(this.ToString(), p1, p2, kwast);
            s.Schets.getekendeObjectenLijst.Add(getekendObject);
            //Maakt nieuw object aan met properties en voegt hem toe aan lijst
        }
    }

    public class PenTool : LijnTool
    {
        public override string ToString() { return "pen"; }
        public override void MuisDrag(SchetsControl s, Point p)
        {   this.MuisLos(s, p);
            this.MuisVast(s, p);
        }
        //Compleet zelf toegveoegd hopelijk werkt het yes
        public override void Compleet(Graphics g, Point p1, Point p2, SchetsControl s)
        {
            base.Compleet(g, p1, p2, s);
            //TODO: Hier graag op een of andere manier een lijst met lijntjes krijgen en die erin stoppen, waar haal ik die vandaan?
            GetekendeObjecten getekendObject = new GetekendeObjecten(this.ToString(), p1, p2, Punten2Rechthoek(p1, p2), kwast, false);
            s.Schets.getekendeObjectenLijst.Add(getekendObject);
            //Maakt nieuw object aan met properties en voegt hem toe aan lijst

        }
    }
    public class GumTool : PenTool
    {
        public override string ToString() { return "gum"; }

        public override void MuisDrag(SchetsControl s, Point p)
        {
            base.MuisDrag(s, p);
        }
        public override void Compleet(Graphics g, Point p1, Point p2, SchetsControl s)
        {


            //Checkt of er op een vierkant geklikt wordt
            for (int i = s.Schets.getekendeObjectenLijst.Count; i > 0; i--)
            {
                GetekendeObjecten getekendObject0 = s.Schets.getekendeObjectenLijst[i - 1];
                if (getekendObject0.type == "rechthoek" || getekendObject0.type == "vlak") //vlak werkt niet?
                {
                    if (p1.X >= getekendObject0.vierkant.X && p1.X <= getekendObject0.vierkant.X + getekendObject0.vierkant.Width)
                    {
                        if (p1.Y >= getekendObject0.vierkant.Y && p1.Y <= getekendObject0.vierkant.Y + getekendObject0.vierkant.Height)
                        {
                            //Zo ja, verwijder het object van de lijst en teken alles opnieuw
                            s.Schets.getekendeObjectenLijst.Remove(getekendObject0);
                            Graphics gr = Graphics.FromImage(s.Schets.bitmap);
                            gr.FillRectangle(Brushes.White, 0, 0, s.Schets.bitmap.Width, s.Schets.bitmap.Height);
                            foreach (GetekendeObjecten getekendObject in s.Schets.getekendeObjectenLijst)
                            {

                                getekendObject.Teken(getekendObject, g);

                            }

                        }
                    }
                }
                //Zie uitleg vierkant hierboven
                if (getekendObject0.type == "lijn")
                {
                    if (p1.X >= getekendObject0.p1.X && p1.X <= getekendObject0.p1.X + 20)
                    {
                        s.Schets.getekendeObjectenLijst.Remove(getekendObject0);
                        Graphics gr = Graphics.FromImage(s.Schets.bitmap);
                        gr.FillRectangle(Brushes.White, 0, 0, s.Schets.bitmap.Width, s.Schets.bitmap.Height);
                        foreach (GetekendeObjecten getekendVierkant in s.Schets.getekendeObjectenLijst)
                        {

                            getekendVierkant.Teken(getekendVierkant, g);

                        }
                    }
                }
                //if (getekendObject0.type == "vlak")
                {
                    
                    {
                        // too bad
                    }
                }
            }

            {
                //
            }
            
        }
    }
}
