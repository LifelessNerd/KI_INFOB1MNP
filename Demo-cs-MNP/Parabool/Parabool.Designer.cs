namespace Parabool
{
    partial class Parabool
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
            this.grafiek = new System.Windows.Forms.Panel();
            this.aBox = new System.Windows.Forms.TextBox();
            this.bBox = new System.Windows.Forms.TextBox();
            this.cBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nulpunten = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grafiek
            // 
            this.grafiek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grafiek.Location = new System.Drawing.Point(202, 14);
            this.grafiek.Name = "grafiek";
            this.grafiek.Size = new System.Drawing.Size(369, 307);
            this.grafiek.TabIndex = 0;
            this.grafiek.Paint += new System.Windows.Forms.PaintEventHandler(this.grafiek_Paint);
            // 
            // aBox
            // 
            this.aBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aBox.Location = new System.Drawing.Point(53, 22);
            this.aBox.Name = "aBox";
            this.aBox.Size = new System.Drawing.Size(99, 29);
            this.aBox.TabIndex = 1;
            this.aBox.Text = "0.5";
            this.aBox.TextChanged += new System.EventHandler(this.box_TextChanged);
            // 
            // bBox
            // 
            this.bBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBox.Location = new System.Drawing.Point(54, 66);
            this.bBox.Name = "bBox";
            this.bBox.Size = new System.Drawing.Size(99, 29);
            this.bBox.TabIndex = 2;
            this.bBox.Text = "1";
            this.bBox.TextChanged += new System.EventHandler(this.box_TextChanged);
            // 
            // cBox
            // 
            this.cBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBox.Location = new System.Drawing.Point(54, 115);
            this.cBox.Name = "cBox";
            this.cBox.Size = new System.Drawing.Size(99, 29);
            this.cBox.TabIndex = 3;
            this.cBox.Text = "-3";
            this.cBox.TextChanged += new System.EventHandler(this.box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "b:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "c:";
            // 
            // nulpunten
            // 
            this.nulpunten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nulpunten.Location = new System.Drawing.Point(27, 170);
            this.nulpunten.Name = "nulpunten";
            this.nulpunten.Size = new System.Drawing.Size(159, 150);
            this.nulpunten.TabIndex = 7;
            this.nulpunten.Text = "nulpunten";
            // 
            // Parabool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 333);
            this.Controls.Add(this.nulpunten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBox);
            this.Controls.Add(this.bBox);
            this.Controls.Add(this.aBox);
            this.Controls.Add(this.grafiek);
            this.Name = "Parabool";
            this.Text = "Parabool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel grafiek;
        private System.Windows.Forms.TextBox aBox;
        private System.Windows.Forms.TextBox bBox;
        private System.Windows.Forms.TextBox cBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nulpunten;
    }
}

