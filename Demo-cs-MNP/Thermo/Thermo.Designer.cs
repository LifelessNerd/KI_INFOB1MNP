using System.Windows.Forms;


namespace Thermo
{
    partial class Thermo
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.minimum = new System.Windows.Forms.TrackBar();
            this.temperatuur = new System.Windows.Forms.TrackBar();
            this.maximum = new System.Windows.Forms.TrackBar();
            this.reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatuur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximum)).BeginInit();
            this.SuspendLayout();
            // 
            // minimum
            // 
            this.minimum.BackColor = System.Drawing.Color.RoyalBlue;
            this.minimum.Location = new System.Drawing.Point(10, 10);
            this.minimum.Maximum = 50;
            this.minimum.Minimum = -50;
            this.minimum.Name = "minimum";
            this.minimum.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.minimum.Size = new System.Drawing.Size(42, 227);
            this.minimum.TabIndex = 0;
            // 
            // temperatuur
            // 
            this.temperatuur.BackColor = System.Drawing.Color.White;
            this.temperatuur.Location = new System.Drawing.Point(70, 10);
            this.temperatuur.Maximum = 50;
            this.temperatuur.Minimum = -50;
            this.temperatuur.Name = "temperatuur";
            this.temperatuur.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.temperatuur.Size = new System.Drawing.Size(42, 227);
            this.temperatuur.TabIndex = 1;
            // 
            // maximum
            // 
            this.maximum.BackColor = System.Drawing.Color.IndianRed;
            this.maximum.Location = new System.Drawing.Point(133, 10);
            this.maximum.Maximum = 50;
            this.maximum.Minimum = -50;
            this.maximum.Name = "maximum";
            this.maximum.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.maximum.Size = new System.Drawing.Size(42, 227);
            this.maximum.TabIndex = 2;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(10, 244);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(168, 27);
            this.reset.TabIndex = 3;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            // 
            // Thermo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 283);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.maximum);
            this.Controls.Add(this.temperatuur);
            this.Controls.Add(this.minimum);
            this.DoubleBuffered = true;
            this.Name = "Thermo";
            this.Text = "Thermometer";
            ((System.ComponentModel.ISupportInitialize)(this.minimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatuur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}