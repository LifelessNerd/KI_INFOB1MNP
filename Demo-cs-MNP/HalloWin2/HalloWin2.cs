using System.Windows.Forms;
using System.Drawing;

class HalloForm : Form
{
    public HalloForm()
    {
        this.Text = "Hallo";
        this.BackColor = Color.Yellow;
        this.Size = new Size(200, 100);

        Label groet;
        groet = new Label();
        groet.Text = "Hallo allemaal";
        groet.Location = new Point(30, 20);

        this.Controls.Add(groet);
    }
}

class HalloWin2
{
    static void Main()
    {
        HalloForm scherm;
        scherm = new HalloForm();
        Application.Run(scherm);
    }
}