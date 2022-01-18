using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EncodingSpy
{
    public partial class EncodingSpy : Form
    {   private TextBox invoer;
        private ComboBox codering, regeleinde;
        private Label uitvoer;

        public EncodingSpy()
        {   InitializeComponent();
            foreach (EncodingInfo info in Encoding.GetEncodings())
                codering.Items.Add(info.Name);
            invoer.TextChanged += verander;
            codering.TextChanged += verander;
            regeleinde.TextChanged += verander;
            this.verander(null, null);
        }
        private void verander(object o, EventArgs ea)
        {   Encoding e = Encoding.GetEncoding(codering.Text);
            Stream s1 = new FileStream("test1.txt", FileMode.Create);
            StreamWriter w1 = new StreamWriter(s1, e);
            switch (regeleinde.Text)
            {   case "Unix":  w1.NewLine = "\n";   break;
                case "Apple": w1.NewLine = "\r";   break;
                default:      w1.NewLine = "\r\n"; break;
            }
            foreach(string regel in invoer.Lines)
                w1.WriteLine(regel);
            w1.Close();

            Stream s2 = new FileStream("test1.txt", FileMode.Open);
            uitvoer.Text = "";
            int a=0, n = 0, b;
            while ((b = s2.ReadByte()) != -1)
            {   if (n == 0)
                {   a = b;
                    switch(codering.Text)
                    {case "utf-8":     if (b>=0xE0) n=3; else if (b>=0x80) n=2; break;
                     case "utf-16":
                     case "utf-16BE":  n = 2; break;
                     case "utf-32":
                     case "utf-32BE":  n = 4; break;
                    }
                    if (n > 0) uitvoer.Text += "(";
                }
                uitvoer.Text += String.Format("{0:X2}", b);
                if (n > 0)
                {   n--;
                    if (n == 0)
                    {   uitvoer.Text += ")";
                        if (codering.Text=="utf-16BE" || codering.Text=="utf-32BE") a = b;
                    }
                }
                uitvoer.Text += " ";
                if (n==0 && (a==10 || (a==13&& regeleinde.Text=="Apple"))) uitvoer.Text += "\n";
            }
            s2.Close();
        }
    }
}
