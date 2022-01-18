using System;
using System.Drawing;
using System.Windows.Forms;

namespace BitmapEditor
{
    public class Hoofdscherm : Form
    {
        MenuStrip menuStrip;
        BitmapControl viewer;

        public Hoofdscherm()
        {   this.Text = "Bitmap Editor";
            this.Resize += this.vergroten;
            viewer = new BitmapControl();
            menuStrip = new MenuStrip();

            ToolStripDropDownItem menu;
            menu = new ToolStripDropDownButton("File");
            menu.DropDownItems.Add("Close",   null, this.afsluiten);
            menuStrip.Items.Add(menu);
            menu = new ToolStripMenuItem("Move");
            menu.DropDownItems.Add("Left",    null, viewer.uitvoeren);
            menu.DropDownItems.Add("Right",   null, viewer.uitvoeren);
            menu.DropDownItems.Add("Up",      null, viewer.uitvoeren);
            menu.DropDownItems.Add("Down",    null, viewer.uitvoeren);
            menuStrip.Items.Add(menu);
            menu = new ToolStripMenuItem("Edit");
            menu.DropDownItems.Add("Clear",   null, viewer.uitvoeren);
            menu.DropDownItems.Add("Invert",  null, viewer.uitvoeren);
            menu.DropDownItems.Add("Bold",    null, viewer.uitvoeren);
            menu.DropDownItems.Add("Outline", null, viewer.uitvoeren);
            menuStrip.Items.Add(menu);
            menu = new ToolStripMenuItem("Life");
            menu.DropDownItems.Add("Step",    null, viewer.uitvoeren);
            menu.DropDownItems.Add("Start",   null, viewer.starten);
            menu.DropDownItems.Add("Stop",    null, viewer.stoppen);
            menuStrip.Items.Add(menu);

            this.Controls.Add(menuStrip);
            this.Controls.Add(viewer);
            this.vergroten(null, null);
        }

        private void vergroten(object sender, EventArgs e)
        {   int w = this.ClientSize.Width - 20;
            int h = this.ClientSize.Height - 50;
            viewer.Size = new Size(w, h);
            viewer.Location = new Point(10, 40);
        }

        private void afsluiten(object sender, EventArgs e)
        {   this.Close();
        }
    }
}