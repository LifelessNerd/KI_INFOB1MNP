//  dit programma tekent drie huizen van divers formaat

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class Huizen : Form
{
    Huizen()
    {
        this.Text = "Huizen";
        this.BackColor = Color.White;
        this.ClientSize = new Size(220, 120);
        this.Paint += this.tekenScherm;
    }

    void tekenScherm(object obj, PaintEventArgs pea)
    {
        this.tekenHuis(pea.Graphics,  20, 100, 40);
        this.tekenHuis(pea.Graphics,  80, 100, 40);
        this.tekenHuis(pea.Graphics, 140, 100, 60);
    }

    void tekenHuis(Graphics gr, int x, int y, int breedte)
    {
        int topx, topy, afdak;
        topx = x + breedte / 2;
        topy = y - 3 * breedte / 2;
        afdak = breedte / 6;
        Brush br = new HatchBrush(HatchStyle.HorizontalBrick, Color.Silver, Color.Red);
        gr.FillRectangle(br, x, y - breedte, breedte, breedte);
        Pen pen = new Pen(Color.DarkRed, 3);
        gr.DrawLine(pen, x - afdak, y - breedte + afdak, topx, topy);
        gr.DrawLine(pen, topx, topy, x + breedte+afdak, y - breedte+afdak);
    }

    static void Main()
    {
        Application.Run(new Huizen());
    }
}