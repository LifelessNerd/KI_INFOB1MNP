using System;

namespace BitmapEditor
{
    public class Bitmap
    {
        private bool[,] vakjes;

        public Bitmap(int br, int h)
        {   vakjes = new bool[br, h];
        }
        public Bitmap(Bitmap ander)
        {   vakjes = new bool[ander.Breedte, ander.Hoogte];
            this.Kopieer(ander);
        }
        public int Breedte
        {   get { return vakjes.GetLength(0); }
        }
        public int Hoogte
        {   get { return vakjes.GetLength(1); }
        }
        public void veranderKleur(int x, int y, bool b)
        {   vakjes[x, y] = b;
        }
        public bool vraagKleur(int x, int y)
        {   return vakjes[x, y];
        }
        private void combineer(Bitmap ander, Func<bool,bool,bool> comb)
        {   for (int x = 0; x < this.Breedte; x++)
                for (int y = 0; y < this.Hoogte; y++)
                    this.veranderKleur(x, y, comb(this.vraagKleur(x, y) , ander.vraagKleur(x, y)));
        }
        private void Kopieer(Bitmap ander)
        {   this.combineer(ander, (a, b) => b);
        }
        public void Clear()
        {   this.combineer(this, (a, b) => false);
        }
        public void Invert()
        {   this.combineer(this, (a, b) => !a);
        }
        public void Bold()
        {   Bitmap ander = new Bitmap(this);
            ander.Left();
            this.combineer(ander, (a, b) => a || b);
            ander.Kopieer(this);
            ander.Down();
            this.combineer(ander, (a, b) => a || b);
        }
        public void Outline()
        {   Bitmap ander = new Bitmap(this);
            ander.Left();
            ander.Down();
            this.combineer(ander, (a, b) => a != b);
        }
        public void Left()
        {   for (int y = 0; y < this.Hoogte; y++)
            {   for (int x = 1; x < this.Breedte; x++)
                    this.veranderKleur(x - 1, y, this.vraagKleur(x, y));
                this.veranderKleur(this.Breedte - 1, y, false);
            }
        }
        public void Right()
        {   for (int y = 0; y < this.Hoogte; y++)
            {   for (int x = this.Breedte-1; x >0; x--)
                    this.veranderKleur(x, y, this.vraagKleur(x-1, y));
                this.veranderKleur(0, y, false);
            }
        }
        public void Up()
        {   for (int x = 0; x < this.Breedte; x++)
            {   for (int y = 1; y < this.Hoogte; y++)
                    this.veranderKleur(x, y-1, this.vraagKleur(x, y));
                this.veranderKleur(x, this.Hoogte - 1, false);
            }
        }
        public void Down()
        {   for (int x = 0; x < this.Breedte; x++)
            {   for (int y = this.Hoogte-1; y >0; y--)
                    this.veranderKleur(x, y, this.vraagKleur(x, y-1));
                this.veranderKleur(x, 0, false);
            }
        }
        public void Life()
        {   Bitmap old = new Bitmap(this);
            for (int y=0; y<Hoogte; y++)
                for (int x = 0; x < Breedte; x++)
                {   int n = old.buren(x,y);
                    this.veranderKleur(x, y, n == 3 || (old.vraagKleur(x, y) && n == 2));
                }
        }
        private int buren(int x, int y)
        {   int x0 = x - 1; if (x0 < 0) x0 += Breedte;
            int y0 = y - 1; if (y0 < 0) y0 += Hoogte;
            int x1 = x + 1; if (x1 >= Breedte) x1 -= Breedte;
            int y1 = y + 1; if (y1 >= Hoogte ) y1 -= Hoogte;
            int n = 0;
            if (this.vraagKleur(x0,y0)) n++;
            if (this.vraagKleur(x ,y0)) n++;
            if (this.vraagKleur(x1,y0)) n++;
            if (this.vraagKleur(x0,y )) n++;
            if (this.vraagKleur(x1,y )) n++;
            if (this.vraagKleur(x0,y1)) n++;
            if (this.vraagKleur(x ,y1)) n++;
            if (this.vraagKleur(x1,y1)) n++;
            return n;
        }
    }
}