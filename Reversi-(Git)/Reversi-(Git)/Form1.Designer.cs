namespace Reversi__Git_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.RestartButton = new System.Windows.Forms.ToolStripSplitButton();
            this.RestartText = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.GeenZettenButton = new System.Windows.Forms.ToolStripButton();
            this.GeenZettenText = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.HulpButton = new System.Windows.Forms.ToolStripButton();
            this.HulpText = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestartButton,
            this.RestartText,
            this.toolStripSeparator3,
            this.GeenZettenButton,
            this.GeenZettenText,
            this.toolStripSeparator4,
            this.HulpButton,
            this.HulpText});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(696, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // RestartButton
            // 
            this.RestartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RestartButton.Image = ((System.Drawing.Image)(resources.GetObject("RestartButton.Image")));
            this.RestartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(32, 22);
            this.RestartButton.ToolTipText = "Klik hier om een nieuw spel te starten.";
            this.RestartButton.ButtonClick += new System.EventHandler(this.RestartButton_ButtonClick);
            // 
            // RestartText
            // 
            this.RestartText.Name = "RestartText";
            this.RestartText.Size = new System.Drawing.Size(65, 22);
            this.RestartText.Text = "Nieuw spel";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // GeenZettenButton
            // 
            this.GeenZettenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GeenZettenButton.Image = ((System.Drawing.Image)(resources.GetObject("GeenZettenButton.Image")));
            this.GeenZettenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GeenZettenButton.Name = "GeenZettenButton";
            this.GeenZettenButton.Size = new System.Drawing.Size(23, 22);
            this.GeenZettenButton.Text = "Geen zetten meer?";
            this.GeenZettenButton.Click += new System.EventHandler(this.GeenZettenButton_Click);
            // 
            // GeenZettenText
            // 
            this.GeenZettenText.Name = "GeenZettenText";
            this.GeenZettenText.Size = new System.Drawing.Size(104, 22);
            this.GeenZettenText.Text = "Geen zetten meer?";
            this.GeenZettenText.ToolTipText = "Klik hier als je, als je aan zet bent, geen zetten meer ziet.";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // HulpButton
            // 
            this.HulpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HulpButton.Image = ((System.Drawing.Image)(resources.GetObject("HulpButton.Image")));
            this.HulpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HulpButton.Name = "HulpButton";
            this.HulpButton.Size = new System.Drawing.Size(23, 22);
            this.HulpButton.Text = "Klik hier voor de spelregels.";
            this.HulpButton.Click += new System.EventHandler(this.HulpButton_Click);
            // 
            // HulpText
            // 
            this.HulpText.Name = "HulpText";
            this.HulpText.Size = new System.Drawing.Size(33, 22);
            this.HulpText.Text = "Hulp";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(696, 565);
            this.Controls.Add(this.toolStrip2);
            this.Name = "Form1";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel RestartText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton GeenZettenButton;
        private System.Windows.Forms.ToolStripLabel GeenZettenText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton HulpButton;
        private System.Windows.Forms.ToolStripLabel HulpText;
        private System.Windows.Forms.ToolStripSplitButton RestartButton;
    }
}

