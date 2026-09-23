namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_upload = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBoxRgb = new PictureBox();
            pictureBoxNtcs = new PictureBox();
            pictureBoxSrgb = new PictureBox();
            label3 = new Label();
            pictureBoxDiff = new PictureBox();
            label4 = new Label();
            pictureBoxNtcsHist = new PictureBox();
            pictureBoxSHist = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNtcs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSrgb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDiff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNtcsHist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSHist).BeginInit();
            SuspendLayout();
            // 
            // btn_upload
            // 
            btn_upload.Location = new Point(784, 1227);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(455, 87);
            btn_upload.TabIndex = 0;
            btn_upload.Text = "Загрузить изображение";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(684, 59);
            label1.Name = "label1";
            label1.Size = new Size(128, 32);
            label1.TabIndex = 2;
            label1.Text = "NTCS RGB:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 59);
            label2.Name = "label2";
            label2.Size = new Size(63, 32);
            label2.TabIndex = 3;
            label2.Text = "RGB:";
            // 
            // pictureBoxRgb
            // 
            pictureBoxRgb.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxRgb.Location = new Point(12, 117);
            pictureBoxRgb.Name = "pictureBoxRgb";
            pictureBoxRgb.Size = new Size(489, 427);
            pictureBoxRgb.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRgb.TabIndex = 4;
            pictureBoxRgb.TabStop = false;
            // 
            // pictureBoxNtcs
            // 
            pictureBoxNtcs.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxNtcs.Location = new Point(519, 117);
            pictureBoxNtcs.Name = "pictureBoxNtcs";
            pictureBoxNtcs.Size = new Size(479, 427);
            pictureBoxNtcs.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxNtcs.TabIndex = 5;
            pictureBoxNtcs.TabStop = false;
            // 
            // pictureBoxSrgb
            // 
            pictureBoxSrgb.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxSrgb.Location = new Point(1023, 117);
            pictureBoxSrgb.Name = "pictureBoxSrgb";
            pictureBoxSrgb.Size = new Size(487, 427);
            pictureBoxSrgb.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSrgb.TabIndex = 6;
            pictureBoxSrgb.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1222, 59);
            label3.Name = "label3";
            label3.Size = new Size(73, 32);
            label3.TabIndex = 7;
            label3.Text = "sRGB:";
            // 
            // pictureBoxDiff
            // 
            pictureBoxDiff.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxDiff.Location = new Point(1530, 117);
            pictureBoxDiff.Name = "pictureBoxDiff";
            pictureBoxDiff.Size = new Size(480, 427);
            pictureBoxDiff.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxDiff.TabIndex = 8;
            pictureBoxDiff.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1715, 59);
            label4.Name = "label4";
            label4.Size = new Size(130, 32);
            label4.TabIndex = 9;
            label4.Text = "Difference:";
            // 
            // pictureBoxNtcsHist
            // 
            pictureBoxNtcsHist.Location = new Point(164, 602);
            pictureBoxNtcsHist.Name = "pictureBoxNtcsHist";
            pictureBoxNtcsHist.Size = new Size(818, 619);
            pictureBoxNtcsHist.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxNtcsHist.TabIndex = 10;
            pictureBoxNtcsHist.TabStop = false;
            // 
            // pictureBoxSHist
            // 
            pictureBoxSHist.Location = new Point(1044, 602);
            pictureBoxSHist.Name = "pictureBoxSHist";
            pictureBoxSHist.Size = new Size(818, 619);
            pictureBoxSHist.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSHist.TabIndex = 11;
            pictureBoxSHist.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(493, 567);
            label5.Name = "label5";
            label5.Size = new Size(173, 32);
            label5.TabIndex = 12;
            label5.Text = "NTCS RGB hist:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1378, 567);
            label6.Name = "label6";
            label6.Size = new Size(118, 32);
            label6.TabIndex = 13;
            label6.Text = "sRGB hist:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2062, 1326);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBoxSHist);
            Controls.Add(pictureBoxNtcsHist);
            Controls.Add(label4);
            Controls.Add(pictureBoxDiff);
            Controls.Add(label3);
            Controls.Add(pictureBoxSrgb);
            Controls.Add(pictureBoxNtcs);
            Controls.Add(pictureBoxRgb);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_upload);
            Name = "Form1";
            Text = "RGB convert to gray";
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNtcs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSrgb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDiff).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNtcsHist).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSHist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_upload;
        private Label label1;
        private Label label2;
        private PictureBox pictureBoxRgb;
        private PictureBox pictureBoxNtcs;
        private PictureBox pictureBoxSrgb;
        private Label label3;
        private PictureBox pictureBoxDiff;
        private Label label4;
        private PictureBox pictureBoxNtcsHist;
        private PictureBox pictureBoxSHist;
        private Label label5;
        private Label label6;
    }
}
