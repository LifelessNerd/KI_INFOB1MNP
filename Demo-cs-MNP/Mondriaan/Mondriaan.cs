/*  dit programma tekent een Mondriaan-achtige
    "compositie met rood en blauw"
 */

using System.Windows.Forms;
using System.Drawing;

class Mondriaan : Form
{
    Mondriaan()
    {
        this.Text = "Mondriaan";
        this.BackColor = Color.White;
        this.ClientSize = new Size(200, 100);
        this.Paint += this.tekenScherm;
    }

    void tekenScherm(object obj, PaintEventArgs pea)
    {
        int breedte, hoogte, balk, x1, x2, x3, y1, y2;

        breedte = pea.ClipRectangle.Width;
        hoogte = pea.ClipRectangle.Height;
        x1 = 10; x2 = 50; x3 = 90;
        y1 = 40; y2 = 70;
        balk = 10;

        // zwarte balken
        pea.Graphics.FillRectangle(Brushes.Black, x1, 0, balk, hoogte);
        pea.Graphics.FillRectangle(Brushes.Black, x2, 0, balk, hoogte);
        pea.Graphics.FillRectangle(Brushes.Black, x3, 0, balk, hoogte);
        pea.Graphics.FillRectangle(Brushes.Black, 0, y1, breedte, balk);
        pea.Graphics.FillRectangle(Brushes.Black, 0, y2, breedte, balk);

        // gekleurde vlakken
        pea.Graphics.FillRectangle(Brushes.Blue, 0, y1 + balk, x1, y2 - (y1 + balk));
        pea.Graphics.FillRectangle(Brushes.Red, x3+balk, 0, breedte-(x3+balk), y1);
    }

    static void Main()
    {
        Application.Run( new Mondriaan());
    }
}