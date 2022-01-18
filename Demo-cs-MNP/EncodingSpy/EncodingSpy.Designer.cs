namespace EncodingSpy
{
    partial class EncodingSpy
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
            this.invoer = new System.Windows.Forms.TextBox();
            this.codering = new System.Windows.Forms.ComboBox();
            this.regeleinde = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uitvoer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // invoer
            // 
            this.invoer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoer.Location = new System.Drawing.Point(18, 18);
            this.invoer.Multiline = true;
            this.invoer.Name = "invoer";
            this.invoer.Size = new System.Drawing.Size(240, 197);
            this.invoer.TabIndex = 0;
            this.invoer.Text = "Hallo\r\n¡Hola España!\r\nTschüß Köln!\r\n?a??µ??a ????da\r\n????ó??, ??????\r\n??, ??!\r\nNi" +
                " hao, Zhongguó\r\n€1 = ƒ2,20371";
            // 
            // codering
            // 
            this.codering.FormattingEnabled = true;
            this.codering.Location = new System.Drawing.Point(280, 41);
            this.codering.Name = "codering";
            this.codering.Size = new System.Drawing.Size(138, 21);
            this.codering.TabIndex = 1;
            this.codering.Text = "utf-8";
            // 
            // regeleinde
            // 
            this.regeleinde.FormattingEnabled = true;
            this.regeleinde.Items.AddRange(new object[] {
            "Windows",
            "Unix",
            "Apple"});
            this.regeleinde.Location = new System.Drawing.Point(435, 41);
            this.regeleinde.Name = "regeleinde";
            this.regeleinde.Size = new System.Drawing.Size(89, 21);
            this.regeleinde.TabIndex = 2;
            this.regeleinde.Text = "Windows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "encoding";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "newline";
            // 
            // uitvoer
            // 
            this.uitvoer.Location = new System.Drawing.Point(277, 79);
            this.uitvoer.Name = "uitvoer";
            this.uitvoer.Size = new System.Drawing.Size(509, 171);
            this.uitvoer.TabIndex = 5;
            this.uitvoer.Text = "label3";
            // 
            // EncodingSpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 259);
            this.Controls.Add(this.uitvoer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regeleinde);
            this.Controls.Add(this.codering);
            this.Controls.Add(this.invoer);
            this.Name = "EncodingSpy";
            this.Text = "EncodingSpy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

