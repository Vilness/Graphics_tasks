using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private Bitmap? ntcs_rgb;
        private Bitmap? s_rgb;
        private Bitmap? diff;
        public Form1()
        {
            InitializeComponent();            
        }

        //Переводит rgb в оттенки серого
        private Bitmap GrayConvert(Bitmap rgb_img, double kr, double kg, double kb)
        {
            Rectangle rect = new Rectangle(0, 0, rgb_img.Width, rgb_img.Height);
            
            Bitmap result = rgb_img.Clone(rect, PixelFormat.Format32bppArgb);
            
            BitmapData data = result.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );

            int bytesCount = Math.Abs(data.Stride) * result.Height;

            byte[] pixels = new byte[bytesCount];

            // Копируем данные изображения из unmanaged-памяти в обычный byte[]
            Marshal.Copy(
                data.Scan0,
                pixels,
                0,
                bytesCount
            );

            for (int y = 0; y < result.Height; y++)
            {
                for (int x = 0; x < result.Width; x++)
                {
                    int index = y * data.Stride + x * 4;

                    byte b = pixels[index];
                    byte g = pixels[index + 1];
                    byte r = pixels[index + 2];

                    int gray = (int)(
                        kr * r +
                        kg * g +
                        kb * b
                    );

                    pixels[index] = (byte)gray;       // B
                    pixels[index + 1] = (byte)gray;   // G
                    pixels[index + 2] = (byte)gray;   // R

                    // pixels[index + 3] — Alpha, не трогаем
                }
            }

            // Возвращаем изменённые данные обратно в Bitmap
            Marshal.Copy(
                pixels,    
                0,
                data.Scan0,               
                bytesCount
            );

            result.UnlockBits(data);

            return result;
        }

        private Bitmap ntscGrayConvert(Bitmap rgb_img) {
            return GrayConvert(rgb_img, 0.299, 0.587, 0.114);
        }

        private Bitmap sGrayConvert(Bitmap rgb_img) {
            return GrayConvert(rgb_img, 0.2126, 0.7152, 0.0722);
        }

        //Считает разность изображений
        private Bitmap getDifference(Bitmap img1, Bitmap img2) { 
            Bitmap res = new Bitmap(img1.Width, img1.Height);

            for (int y = 0; y < img1.Height; y++) {
                for (int x = 0; x < img1.Width; x++) {
                    Color pixel1 = img1.GetPixel(x, y);
                    Color pixel2 = img2.GetPixel(x, y);

                    int diff = Math.Abs(pixel1.R - pixel2.R);

                    res.SetPixel(
                        x,
                        y,
                        Color.FromArgb(diff, diff, diff)
                    );
                }
            }
            return res;
        }

        //Формирует данные гистограммы
        private int[] getHist(Bitmap img)
        {
            int[] hist = new int[256];

            for (int y = 0; y < img.Height; y++) {
                for (int x = 0; x < img.Width; x++) {
                    Color pixel = img.GetPixel(x, y);

                    int intens = pixel.R;
                    hist[intens]++;
                }
            }
            return hist;
        }

        //Получение изображения гистограммы
        private Bitmap DrawHistogram(int[] histogram, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int max = histogram.Max();
            if (max == 0)
                return bmp;

            float barWidth = width / 256f;
            for (int i = 0; i < 256; i++) {
                float h = histogram[i] * (height - 1) / (float)max;

                g.FillRectangle(
                    Brushes.Black,
                    i * barWidth,
                    height - h,
                    Math.Max(1, barWidth),
                    h
                );
            }
            return bmp;
        }

        //Загрузка файла, потом перевод в оттенки серого, отрисовка гистограммы
        private void btn_upload_Click(object sender, EventArgs e)
        {
            //Загрузка файла через интерфейс пользователя
            using OpenFileDialog file_dialog = new OpenFileDialog();

            file_dialog.Title = "Выберите изображение";

            file_dialog.Filter =
                "Изображения (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (file_dialog.ShowDialog() != DialogResult.OK)
                return;
            
            //Конвертация и вывод на форму

            //Оригинальное
            Bitmap rgb_img = new Bitmap(file_dialog.FileName);

            pictureBoxRgb.Image?.Dispose();
            pictureBoxRgb.Image = new Bitmap(rgb_img);

            //ntcs rgb
            ntcs_rgb?.Dispose();
            ntcs_rgb = ntscGrayConvert(rgb_img);
            
            pictureBoxNtcs.Image?.Dispose();
            pictureBoxNtcs.Image = new Bitmap(ntcs_rgb);

            //s rgb
            s_rgb?.Dispose();
            s_rgb = sGrayConvert(rgb_img);

            pictureBoxSrgb.Image?.Dispose();
            pictureBoxSrgb.Image = new Bitmap(s_rgb);

            //diff
            diff?.Dispose();
            diff = getDifference(ntcs_rgb, s_rgb);

            pictureBoxDiff.Image?.Dispose();
            pictureBoxDiff.Image = new Bitmap(diff);

            //Гистограммы интенсивности
            int[] ntcs_hist = getHist(ntcs_rgb);

            pictureBoxNtcsHist.Image?.Dispose();
            pictureBoxNtcsHist.Image = DrawHistogram(ntcs_hist, ntcs_rgb.Width, ntcs_rgb.Height);

            int[] s_hist = getHist(s_rgb);

            pictureBoxSHist.Image?.Dispose();
            pictureBoxSHist.Image = DrawHistogram(s_hist, s_rgb.Width, s_rgb.Height);
        }        
    }
}
