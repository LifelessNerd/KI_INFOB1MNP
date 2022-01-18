using System.Windows.Forms;
using System.Drawing;

class HalloWin1
{
    static void Main()
    {
        Form scherm;
        scherm = new Form();
        scherm.Text = "Hallo";
        scherm.BackColor = Color.Yellow;
        scherm.Size = new Size(200,100);
        Application.Run(scherm);
    }
}