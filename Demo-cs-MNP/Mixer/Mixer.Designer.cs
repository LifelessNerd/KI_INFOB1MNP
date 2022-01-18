namespace Mixer
{
    partial class Mixer
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
            this.zwart = new System.Windows.Forms.Button();
            this.rood = new System.Windows.Forms.TrackBar();
            this.groen = new System.Windows.Forms.TrackBar();
            this.blauw = new System.Windows.Forms.TrackBar();
            this.mengkleur = new System.Windows.Forms.Panel();
            this.cijfers = new System.Windows.Forms.Label();
            this.wit = new System.Windows.Forms.Button();
            this.grijs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blauw)).BeginInit();
            this.SuspendLayout();
            // 
            // zwart
            // 
            this.zwart.Location = new System.Drawing.Point(12, 173);
            this.zwart.Name = "zwart";
            this.zwart.Size = new System.Drawing.Size(80, 42);
            this.zwart.TabIndex = 0;
            this.zwart.Text = "Zwart";
            this.zwart.UseVisualStyleBackColor = true;
            this.zwart.Click += new System.EventHandler(this.zwart_Click);
            // 
            // rood
            // 
            this.rood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rood.Location = new System.Drawing.Point(12, 12);
            this.rood.Maximum = 255;
            this.rood.Name = "rood";
            this.rood.Size = new System.Drawing.Size(270, 42);
            this.rood.TabIndex = 1;
            this.rood.TickFrequency = 16;
            this.rood.Scroll += new System.EventHandler(this.rood_Scroll);
            // 
            // groen
            // 
            this.groen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groen.Location = new System.Drawing.Point(12, 60);
            this.groen.Maximum = 255;
            this.groen.Name = "groen";
            this.groen.Size = new System.Drawing.Size(270, 42);
            this.groen.TabIndex = 2;
            this.groen.TickFrequency = 16;
            this.groen.Scroll += new System.EventHandler(this.rood_Scroll);
            // 
            // blauw
            // 
            this.blauw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.blauw.Location = new System.Drawing.Point(12, 108);
            this.blauw.Maximum = 255;
            this.blauw.Name = "blauw";
            this.blauw.Size = new System.Drawing.Size(270, 42);
            this.blauw.TabIndex = 3;
            this.blauw.TickFrequency = 16;
            this.blauw.Scroll += new System.EventHandler(this.rood_Scroll);
            // 
            // mengkleur
            // 
            this.mengkleur.BackColor = System.Drawing.Color.Black;
            this.mengkleur.Location = new System.Drawing.Point(311, 13);
            this.mengkleur.Name = "mengkleur";
            this.mengkleur.Size = new System.Drawing.Size(241, 136);
            this.mengkleur.TabIndex = 4;
            // 
            // cijfers
            // 
            this.cijfers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cijfers.Location = new System.Drawing.Point(311, 166);
            this.cijfers.Name = "cijfers";
            this.cijfers.Size = new System.Drawing.Size(240, 32);
            this.cijfers.TabIndex = 5;
            this.cijfers.Text = "(0,0,0)";
            // 
            // wit
            // 
            this.wit.Location = new System.Drawing.Point(208, 173);
            this.wit.Name = "wit";
            this.wit.Size = new System.Drawing.Size(74, 40);
            this.wit.TabIndex = 6;
            this.wit.Text = "Wit";
            this.wit.UseVisualStyleBackColor = true;
            this.wit.Click += new System.EventHandler(this.wit_Click);
            // 
            // grijs
            // 
            this.grijs.Location = new System.Drawing.Point(115, 173);
            this.grijs.Name = "grijs";
            this.grijs.Size = new System.Drawing.Size(68, 42);
            this.grijs.TabIndex = 7;
            this.grijs.Text = "Grijs";
            this.grijs.UseVisualStyleBackColor = true;
            this.grijs.Click += new System.EventHandler(this.grijs_Click);
            // 
            // Mixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 227);
            this.Controls.Add(this.grijs);
            this.Controls.Add(this.wit);
            this.Controls.Add(this.cijfers);
            this.Controls.Add(this.mengkleur);
            this.Controls.Add(this.blauw);
            this.Controls.Add(this.groen);
            this.Controls.Add(this.rood);
            this.Controls.Add(this.zwart);
            this.Name = "Mixer";
            this.Text = "Mixer";
            ((System.ComponentModel.ISupportInitialize)(this.rood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blauw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button zwart;
        private System.Windows.Forms.TrackBar rood;
        private System.Windows.Forms.TrackBar groen;
        private System.Windows.Forms.TrackBar blauw;
        private System.Windows.Forms.Panel mengkleur;
        private System.Windows.Forms.Label cijfers;
        private System.Windows.Forms.Button wit;
        private System.Windows.Forms.Button grijs;
    }
}