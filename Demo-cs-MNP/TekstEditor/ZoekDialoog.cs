using System;
using System.Drawing;
using System.Windows.Forms;

namespace TekstEditor
{
    public class ZoekDialoog : Form
    {
        public TextBox ZoekText, VervangText;
        Button ok, cancel;
        Label zoekLabel, vervangLabel;

        public ZoekDialoog(bool ookVervang)
        {
            ZoekText     = new TextBox();
            VervangText  = new TextBox();
            ok           = new Button();
            cancel       = new Button();
            zoekLabel    = new Label();
            vervangLabel = new Label();

            zoekLabel.Text    = "Zoek:";    zoekLabel.AutoSize = true;
            vervangLabel.Text = "Vervang:"; vervangLabel.AutoSize = true;
            ok.Text           = "OK";
            cancel.Text       = "Cancel";

            zoekLabel.Location    = new Point(10, 10);
            vervangLabel.Location = new Point(10, 40);
            ZoekText.Location     = new Point(70, 10); ZoekText.Size    = new Size(130, 20);
            VervangText.Location  = new Point(70, 40); VervangText.Size = new Size(130, 20);
            ok.Location           = new Point(50, 80);
            cancel.Location       = new Point(140, 80);

            this.Controls.Add(zoekLabel);
            this.Controls.Add(ZoekText);
            if (ookVervang)
            {
                this.Controls.Add(vervangLabel);
                this.Controls.Add(VervangText);
            }
            this.Controls.Add(ok);
            this.Controls.Add(cancel);

            this.ClientSize = new Size(220, 120);
            this.AcceptButton = ok;
            this.CancelButton = cancel;
            ok.Click += ok_Click;
        }
        void ok_Click(object o, EventArgs ea)
        {   this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
