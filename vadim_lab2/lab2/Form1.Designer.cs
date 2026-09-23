namespace lab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.labelH = new System.Windows.Forms.Label();
            this.trackBarS = new System.Windows.Forms.TrackBar();
            this.labelS = new System.Windows.Forms.Label();
            this.trackBarV = new System.Windows.Forms.TrackBar();
            this.labelV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(560, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(590, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(180, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(590, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // trackBarH
            // 
            this.trackBarH.Location = new System.Drawing.Point(590, 110);
            this.trackBarH.Maximum = 180;
            this.trackBarH.Minimum = -180;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(180, 45);
            this.trackBarH.TabIndex = 3;
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(590, 92);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(32, 15);
            this.labelH.TabIndex = 4;
            this.labelH.Text = "Hue";
            // 
            // trackBarS
            // 
            this.trackBarS.Location = new System.Drawing.Point(590, 180);
            this.trackBarS.Maximum = 100;
            this.trackBarS.Minimum = -100;
            this.trackBarS.Name = "trackBarS";
            this.trackBarS.Size = new System.Drawing.Size(180, 45);
            this.trackBarS.TabIndex = 5;
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Location = new System.Drawing.Point(590, 162);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(61, 15);
            this.labelS.TabIndex = 6;
            this.labelS.Text = "Saturation";
            // 
            // trackBarV
            // 
            this.trackBarV.Location = new System.Drawing.Point(590, 250);
            this.trackBarV.Maximum = 100;
            this.trackBarV.Minimum = -100;
            this.trackBarV.Name = "trackBarV";
            this.trackBarV.Size = new System.Drawing.Size(180, 45);
            this.trackBarV.TabIndex = 7;
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Location = new System.Drawing.Point(590, 232);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(36, 15);
            this.labelV.TabIndex = 8;
            this.labelV.Text = "Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.labelV);
            this.Controls.Add(this.trackBarV);
            this.Controls.Add(this.labelS);
            this.Controls.Add(this.trackBarS);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.trackBarH);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Фильтр HSV";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.TrackBar trackBarS;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.TrackBar trackBarV;
        private System.Windows.Forms.Label labelV;
    }
}
