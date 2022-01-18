using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TekstEditor
{
    public class Tekst : Form
    {
        TextBox invoer;
        Label status;

        public Tekst()
        {
            MenuStrip menuStrip;
            menuStrip = new MenuStrip();
            invoer = new TextBox();
            status = new Label();
            
            ToolStripDropDownItem menu;
            menu = new ToolStripMenuItem("File");
            menu.MergeAction = MergeAction.MatchOnly;
            menuStrip.Items.Add(menu);
            menu.DropDownItems.Add("Opslaan", null, this.opslaan);
            menu.DropDownItems.Add("Opslaan &als...", null, this.opslaanAls);
            menu.DropDownItems.Add("Sluiten", null, this.sluiten);
            menu = new ToolStripMenuItem("Zoek");
            menu.DropDownItems.Add("Zoek", null, this.zoek);
            menu.DropDownItems.Add("Vervang", null, this.vervang);
            menuStrip.Items.Add(menu);
            menuStrip.Visible = false;
            this.Controls.Add(menuStrip);

            invoer.Multiline = true;
            invoer.WordWrap = false;
            invoer.ScrollBars = ScrollBars.Both;
            invoer.Font = new Font("Courier New", 12);
            invoer.TextChanged += verander;
            this.Controls.Add(invoer);
            this.Controls.Add(status);

            this.ClientSize = new Size(500, 300);
            this.Resize += vergroot;
            this.vergroot(null, null);
        }
        private void vergroot(object o, EventArgs ea)
        {   invoer.Location = new Point(10, 10);
            invoer.Size = this.ClientSize - new Size(20, 30);
            status.Location = new Point(10, this.ClientSize.Height - 15);
        }
        private void verander(object o, EventArgs ea)
        {   status.Text = invoer.Text.Length.ToString() + " karakters";
        }
        private void sluiten(object sender, EventArgs e)
        {   this.Close();
        }
        private void zoekOfVervang(bool ookVervangen)
        {
            ZoekDialoog dialoog;
            dialoog = new ZoekDialoog(ookVervangen);
            if (dialoog.ShowDialog(this) == DialogResult.OK)
            {
                string alles = this.invoer.Text;
                string zoek = dialoog.ZoekText.Text;
                int pos = alles.IndexOf(zoek);
                if (pos >= 0)
                {
                    if (ookVervangen)
                    {   string vervang = dialoog.VervangText.Text;
                        this.invoer.Text = alles.Replace(zoek, vervang);
                        zoek = vervang;
                    }
                    this.invoer.Select(pos, zoek.Length);
                }
            }
        }
        private void zoek(object o, EventArgs ea)
        {
            this.zoekOfVervang(false);
        }
        private void vervang(object o, EventArgs ea)
        {
            this.zoekOfVervang(true);
        }
        private void opslaan(object o, EventArgs ea)
        {   if (this.Text == "")
                opslaanAls(o, ea);
            else schrijfNaarFile();
        }
        private void opslaanAls(object o, EventArgs ea)
        {   SaveFileDialog dialoog = new SaveFileDialog();
            dialoog.Filter = "Tekstfiles|*.txt|Alle files|*.*";
            dialoog.Title = "Tekst opslaan als...";
            if (dialoog.ShowDialog() == DialogResult.OK)
            {
                this.Text = dialoog.FileName;
                this.schrijfNaarFile();
            }
        }
        private void schrijfNaarFile()
        {   StreamWriter writer = new StreamWriter(this.Text);
            writer.Write(this.invoer.Text);
            writer.Close();
        }
        public void LeesVanFile(string naam)
        {   StreamReader reader = new StreamReader(naam);
            this.invoer.Text = reader.ReadToEnd();
            reader.Close();
            this.Text = naam;
        }
    }
}
