namespace Rente
{
    partial class Rente
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bedragTekst = new System.Windows.Forms.TextBox();
            this.renteTekst = new System.Windows.Forms.TextBox();
            this.rekenKnop = new System.Windows.Forms.Button();
            this.resultaat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bedrag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rentepercentage:";
            // 
            // bedragTekst
            // 
            this.bedragTekst.Location = new System.Drawing.Point(112, 6);
            this.bedragTekst.Name = "bedragTekst";
            this.bedragTekst.Size = new System.Drawing.Size(54, 20);
            this.bedragTekst.TabIndex = 2;
            this.bedragTekst.Text = "100";
            // 
            // renteTekst
            // 
            this.renteTekst.Location = new System.Drawing.Point(113, 32);
            this.renteTekst.Name = "renteTekst";
            this.renteTekst.Size = new System.Drawing.Size(53, 20);
            this.renteTekst.TabIndex = 3;
            this.renteTekst.Text = "5";
            // 
            // rekenKnop
            // 
            this.rekenKnop.Location = new System.Drawing.Point(111, 67);
            this.rekenKnop.Name = "rekenKnop";
            this.rekenKnop.Size = new System.Drawing.Size(55, 21);
            this.rekenKnop.TabIndex = 4;
            this.rekenKnop.Text = "Bereken";
            this.rekenKnop.UseVisualStyleBackColor = true;
            this.rekenKnop.Click += new System.EventHandler(this.rekenKnop_Click);
            // 
            // resultaat
            // 
            this.resultaat.AutoSize = true;
            this.resultaat.Location = new System.Drawing.Point(199, 9);
            this.resultaat.Name = "resultaat";
            this.resultaat.Size = new System.Drawing.Size(0, 13);
            this.resultaat.TabIndex = 5;
            // 
            // Rente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 155);
            this.Controls.Add(this.resultaat);
            this.Controls.Add(this.rekenKnop);
            this.Controls.Add(this.renteTekst);
            this.Controls.Add(this.bedragTekst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Rente";
            this.Text = "Rente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bedragTekst;
        private System.Windows.Forms.TextBox renteTekst;
        private System.Windows.Forms.Button rekenKnop;
        private System.Windows.Forms.Label resultaat;

    }
}

