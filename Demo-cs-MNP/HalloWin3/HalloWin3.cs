using System.Windows.Forms;
using System.Drawing;

class HalloForm : Form
{
    public HalloForm()
    {
        this.Text = "Hallo";
        this.BackColor = Color.Yellow;
        this.Size = new Size(200, 100);
        this.Paint += this.tekenScherm;
    }

    void tekenScherm(object obj, PaintEventArgs pea)
    {
        pea.Graphics.DrawString( "Hallo!"
                               , new Font("Tahoma", 30)
                               , Brushes.Blue
                               , 10, 10
                               );
    }
}

class HalloWin3
{
    static void Main()
    {
        HalloForm scherm;
        scherm = new HalloForm();
        Application.Run(scherm);
    }
}