using System;
using System.Drawing;
using System.Windows.Forms;

public class CirkelGroei : Form
{
    private Button kleiner, groter;
    private int straal;

    public CirkelGroei()
    {
        this.straal = 100;
        this.ClientSize = new Size(300, 300);
        this.Text   = "CirkelGroei";
        this.Paint += this.teken;
        this.kleiner = new Button();
        this.groter  = new Button();
        this.kleiner.Text     = "Kleiner";
        this.groter .Text     = "Groter";
        this.kleiner.Location = new Point( 30, 20);
        this.groter .Location = new Point(200, 20);
        this.kleiner.Click   += this.klik;
        this.groter .Click   += this.klik;
        this.Controls.Add(this.kleiner);
        this.Controls.Add(this.groter);
    }

    void klik(object sender, EventArgs e)
    {
        if (sender == this.kleiner && this.straal > 10)
            this.straal -= 10;
        if (sender == this.groter && this.straal < 150)
            this.straal += 10;
        this.Invalidate();
    }

    void teken(object obj, PaintEventArgs pea)
    {
        pea.Graphics.FillEllipse( Brushes.Green
                                , 150-this.straal, 150-this.straal
                                , 2 * this.straal, 2 * this.straal);
    }

    static void Main()
    {
        CirkelGroei cg = new CirkelGroei();
        Application.Run(cg);
    }
}
