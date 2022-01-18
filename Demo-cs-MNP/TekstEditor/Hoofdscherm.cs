using System;
using System.Drawing;
using System.Windows.Forms;

namespace TekstEditor
{
    public class Hoofdscherm : Form
    {
        public Hoofdscherm()
        {
            MenuStrip menuStrip;
            menuStrip = new MenuStrip();
            ToolStripDropDownItem menu;
            menu = new ToolStripMenuItem("File");
            menu.DropDownItems.Add("Nieuw",   null, this.nieuw);
            menu.DropDownItems.Add("Open...", null, this.open);
            menu.DropDownItems.Add("Exit",    null, this.afsluiten);
            menuStrip.Items.Add(menu);
            this.Controls.Add(menuStrip);

            this.Text = "Tekst Editor";
            this.ClientSize = new Size(600, 400);
            this.IsMdiContainer = true;
            this.MainMenuStrip = menuStrip;
        }

        private void nieuw(object sender, EventArgs e)
        {
            Tekst t = new Tekst();
            t.MdiParent = this;
            t.Show();
        }
        private void open(object sender, EventArgs e)
        {
            OpenFileDialog dialoog = new OpenFileDialog();
            dialoog.Filter = "Tekstfiles|*.txt|Alle files|*.*";
            dialoog.Title = "Tekst openen...";
            if (dialoog.ShowDialog() == DialogResult.OK)
            {
                Tekst t = new Tekst();
                t.MdiParent = this;
                t.LeesVanFile(dialoog.FileName);
                t.Show();
            }
        }
        private void afsluiten(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
