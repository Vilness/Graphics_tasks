using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap previewSource;
        private Bitmap previewResult;

        public Form1()
        {
            InitializeComponent();

            btnOpen.Click += btnOpen_Click;
            btnSave.Click += btnSave_Click;
            trackBarH.Scroll += trackBar_Scroll;
            trackBarS.Scroll += trackBar_Scroll;
            trackBarV.Scroll += trackBar_Scroll;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            using Bitmap loaded = new Bitmap(dialog.FileName);

            originalImage?.Dispose();
            previewSource?.Dispose();
            previewResult?.Dispose();

            originalImage = loaded.Clone(
                new Rectangle(0, 0, loaded.Width, loaded.Height),
                PixelFormat.Format32bppArgb);

            double ratio = Math.Min(
                (double)pictureBox1.Width / originalImage.Width,
                (double)pictureBox1.Height / originalImage.Height);
            if (ratio > 1.0) ratio = 1.0;

            int pw = Math.Max(1, (int)(originalImage.Width * ratio));
            int ph = Math.Max(1, (int)(originalImage.Height * ratio));

            previewSource = new Bitmap(pw, ph, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(previewSource))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, pw, ph);
            }

            previewResult = new Bitmap(pw, ph, PixelFormat.Format32bppArgb);

            trackBarH.Value = 0;
            trackBarS.Value = 0;
            trackBarV.Value = 0;

            UpdatePreview();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (previewSource == null || previewResult == null) return;

            ProcessBitmap(previewSource, previewResult);
            pictureBox1.Image = previewResult;
            pictureBox1.Update();
        }

        private void ProcessBitmap(Bitmap source, Bitmap destination)
        {
            int width = source.Width;
            int height = source.Height;

            double hueShift = trackBarH.Value;
            double satShift = trackBarS.Value / 100.0;
            double valShift = trackBarV.Value / 100.0;

            Rectangle rect = new Rectangle(0, 0, width, height);

            BitmapData srcData = source.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = destination.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try
            {
                int stride = srcData.Stride;
                int rowBytes = width * 4;
                byte[] srcRow = new byte[stride];
                byte[] dstRow = new byte[stride];

                for (int y = 0; y < height; y++)
                {
                    IntPtr srcPtr = IntPtr.Add(srcData.Scan0, y * stride);
                    IntPtr dstPtr = IntPtr.Add(dstData.Scan0, y * stride);

                    Marshal.Copy(srcPtr, srcRow, 0, stride);

                    for (int x = 0; x < width; x++)
                    {
                        int i = x * 4;

                        double b = srcRow[i] / 255.0;
                        double g = srcRow[i + 1] / 255.0;
                        double r = srcRow[i + 2] / 255.0;

                        RgbToHsv(r, g, b, out double h, out double s, out double v);

                        h = (h + hueShift) % 360;
                        if (h < 0) h += 360;

                        s = Math.Clamp(s + satShift, 0, 1);
                        v = Math.Clamp(v + valShift, 0, 1);

                        HsvToRgb(h, s, v, out double nr, out double ng, out double nb);

                        dstRow[i] = ToByte(nb * 255);
                        dstRow[i + 1] = ToByte(ng * 255);
                        dstRow[i + 2] = ToByte(nr * 255);
                        dstRow[i + 3] = srcRow[i + 3];
                    }

                    Marshal.Copy(dstRow, 0, dstPtr, rowBytes);
                }
            }
            finally
            {
                source.UnlockBits(srcData);
                destination.UnlockBits(dstData);
            }
        }

        private void RgbToHsv(double r, double g, double b, out double h, out double s, out double v)
        {
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            v = max;
            s = max == 0 ? 0 : delta / max;

            h = delta == 0
                ? 0
                : max switch
                {
                    _ when max == r => 60 * (((g - b) / delta)),
                    _ when max == g => 60 * ((b - r) / delta + 2),
                    _ => 60 * ((r - g) / delta + 4)
                };

            if (h < 0) h += 360;
        }

        private void HsvToRgb(double h, double s, double v, out double r, out double g, out double b)
        {
            double c = v * s; // Chrome 
            double x = c * (1 - Math.Abs(h / 60 % 2 - 1)); // 2ая компонента
            double m = v - c; // туманность

            int sector = (int)(h / 60);

            (double r, double g, double b) rgb = sector switch
            {
                0 => (c, x, 0),
                1 => (x, c, 0),
                2 => (0, c, x),
                3 => (0, x, c),
                4 => (x, 0, c),
                _ => (c, 0, x)
            };

            r = rgb.r + m;
            g = rgb.g + m;
            b = rgb.b + m;
        }

        private byte ToByte(double value)
        {
            return (byte)Math.Clamp((int)Math.Round(value), 0, 255);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Сначала откройте изображение.");
                return;
            }

            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "PNG|*.png",
                DefaultExt = "png",
                FileName = "измененный"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            using Bitmap fullResult = new Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format32bppArgb);
            ProcessBitmap(originalImage, fullResult);
            fullResult.Save(dialog.FileName, ImageFormat.Png);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            originalImage?.Dispose();
            previewSource?.Dispose();
            previewResult?.Dispose();
            base.OnFormClosed(e);
        }
    }
}