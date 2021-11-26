namespace _25_11_Werkcollege
{
    partial class Mandelbrot
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.middenX = new System.Windows.Forms.Label();
            this.middenY = new System.Windows.Forms.Label();
            this.schaal = new System.Windows.Forms.Label();
            this.max = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.xBox = new System.Windows.Forms.TextBox();
            this.yBox = new System.Windows.Forms.TextBox();
            this.schaalBox = new System.Windows.Forms.TextBox();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.resultaatBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 290);
            this.panel1.TabIndex = 0;
            // 
            // middenX
            // 
            this.middenX.AutoSize = true;
            this.middenX.Location = new System.Drawing.Point(36, 24);
            this.middenX.Name = "middenX";
            this.middenX.Size = new System.Drawing.Size(44, 16);
            this.middenX.TabIndex = 1;
            this.middenX.Text = "label1";
            // 
            // middenY
            // 
            this.middenY.AutoSize = true;
            this.middenY.Location = new System.Drawing.Point(36, 59);
            this.middenY.Name = "middenY";
            this.middenY.Size = new System.Drawing.Size(44, 16);
            this.middenY.TabIndex = 2;
            this.middenY.Text = "label2";
            // 
            // schaal
            // 
            this.schaal.AutoSize = true;
            this.schaal.Location = new System.Drawing.Point(323, 24);
            this.schaal.Name = "schaal";
            this.schaal.Size = new System.Drawing.Size(44, 16);
            this.schaal.TabIndex = 3;
            this.schaal.Text = "label3";
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.Location = new System.Drawing.Point(323, 59);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(44, 16);
            this.max.TabIndex = 4;
            this.max.Text = "label4";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(560, 24);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(110, 51);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(86, 24);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(100, 22);
            this.xBox.TabIndex = 6;
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(86, 56);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(100, 22);
            this.yBox.TabIndex = 7;
            // 
            // schaalBox
            // 
            this.schaalBox.Location = new System.Drawing.Point(373, 24);
            this.schaalBox.Name = "schaalBox";
            this.schaalBox.Size = new System.Drawing.Size(100, 22);
            this.schaalBox.TabIndex = 7;
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(373, 59);
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(100, 22);
            this.maxBox.TabIndex = 8;
            // 
            // resultaatBox
            // 
            this.resultaatBox.Location = new System.Drawing.Point(560, 82);
            this.resultaatBox.Name = "resultaatBox";
            this.resultaatBox.Size = new System.Drawing.Size(100, 22);
            this.resultaatBox.TabIndex = 9;
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 449);
            this.Controls.Add(this.resultaatBox);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.schaalBox);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.max);
            this.Controls.Add(this.schaal);
            this.Controls.Add(this.middenY);
            this.Controls.Add(this.middenX);
            this.Controls.Add(this.panel1);
            this.Name = "Mandelbrot";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label middenX;
        private System.Windows.Forms.Label middenY;
        private System.Windows.Forms.Label schaal;
        private System.Windows.Forms.Label max;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox schaalBox;
        private System.Windows.Forms.TextBox maxBox;
        private System.Windows.Forms.TextBox resultaatBox;
    }
}

