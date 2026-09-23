namespace lab22;

public partial class Form1 : Form
{
    private Button loadButton;

    private PictureBox redImage;
    private PictureBox greenImage;
    private PictureBox blueImage;

    private PictureBox redHistogram;
    private PictureBox greenHistogram;
    private PictureBox blueHistogram;

    public Form1()
    {
        Text = "Выделение каналов RGB и гистограммы";
        Width = 1200;
        Height = 800;
        StartPosition = FormStartPosition.CenterScreen;

        loadButton = new Button();
        loadButton.Text = "Загрузить изображение";
        loadButton.Dock = DockStyle.Fill;
        loadButton.Click += LoadButton_Click;

        TableLayoutPanel mainTable = new TableLayoutPanel();
        mainTable.Dock = DockStyle.Fill;
        mainTable.RowCount = 3;
        mainTable.ColumnCount = 3;

        mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

        mainTable.Controls.Add(loadButton, 0, 0);
        mainTable.SetColumnSpan(loadButton, 3);

        redImage = CreatePictureBox();
        greenImage = CreatePictureBox();
        blueImage = CreatePictureBox();

        redHistogram = CreatePictureBox();
        greenHistogram = CreatePictureBox();
        blueHistogram = CreatePictureBox();

        mainTable.Controls.Add(CreateGroup("Красный канал (R)", redImage), 0, 1);
        mainTable.Controls.Add(CreateGroup("Зелёный канал (G)", greenImage), 1, 1);
        mainTable.Controls.Add(CreateGroup("Синий канал (B)", blueImage), 2, 1);

        mainTable.Controls.Add(CreateGroup("Гистограмма R", redHistogram), 0, 2);
        mainTable.Controls.Add(CreateGroup("Гистограмма G", greenHistogram), 1, 2);
        mainTable.Controls.Add(CreateGroup("Гистограмма B", blueHistogram), 2, 2);

        Controls.Add(mainTable);
    }

    private PictureBox CreatePictureBox()
    {
        PictureBox pictureBox = new PictureBox();
        // Заставляет рамку изображение растягиваться на весь размер родительского контейнера
        pictureBox.Dock = DockStyle.Fill;
        // Растягивание и сжатие изображения с сохранением пропорций
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.BorderStyle = BorderStyle.FixedSingle;

        return pictureBox;
    }

    private GroupBox CreateGroup(string title, Control control)
    {
        GroupBox group = new GroupBox();
        group.Text = title;
        group.Dock = DockStyle.Fill;
        group.Controls.Add(control);
        return group;
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        // Загрузка изображения с диска в оперативную память
        using (Bitmap source = new Bitmap(dialog.FileName))
        {
            // Выделение места в памяти под 3 пустые картинки
            Bitmap rBitmap = new Bitmap(source.Width, source.Height);
            Bitmap gBitmap = new Bitmap(source.Width, source.Height);
            Bitmap bBitmap = new Bitmap(source.Width, source.Height);

            // Инициализация массивов для гистограммы
            // a[i] = количество пикселей с интенсивностью i
            int[] rHistogram = new int[256];
            int[] gHistogram = new int[256];
            int[] bHistogram = new int[256];

            // Проход по горизонтали
            for (int y = 0; y < source.Height; y++)
            {
                // Проход по вертикали
                for (int x = 0; x < source.Width; x++)
                {
                    // Получение структуры Color, которая содержит информацию о цвете пикселя
                    // r(0-255), g(0-255), b(0-255)
                    Color pixel = source.GetPixel(x, y);

                    // Покраска пикселя в красный, зелёный и синий каналы
                    // непрозрачность, красный, зелёный, синий
                    rBitmap.SetPixel(x, y, Color.FromArgb(255, pixel.R, 0, 0));
                    gBitmap.SetPixel(x, y, Color.FromArgb(255, 0, pixel.G, 0));
                    bBitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0, pixel.B));

                    // a[i] = количество пикселей с интенсивностью i
                    rHistogram[pixel.R]++;
                    gHistogram[pixel.G]++;
                    bHistogram[pixel.B]++;
                }
            }

            SetImage(redImage, rBitmap);
            SetImage(greenImage, gBitmap);
            SetImage(blueImage, bBitmap);

            SetImage(redHistogram, CreateHistogram(rHistogram, Color.Red));
            SetImage(greenHistogram, CreateHistogram(gHistogram, Color.Green));
            SetImage(blueHistogram, CreateHistogram(bHistogram, Color.Blue));
        }
    }

    private void SetImage(PictureBox pictureBox, Bitmap newImage)
    {
        // Стирание старого изображения из памяти, если оно есть
        if (pictureBox.Image != null)
            pictureBox.Image.Dispose();

        pictureBox.Image = newImage;
    }

    private Bitmap CreateHistogram(int[] values, Color color)
    {
        int width = 512;
        int height = 280;

        // Создание пустого изображения
        Bitmap bitmap = new Bitmap(width, height);

        // Создание движка g для рисования на изображении bitmap
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.Clear(Color.White);

            int left = 40;
            int top = 20;
            int bottom = 30;
            int chartWidth = width - left - 10;
            int chartHeight = height - top - bottom;

            // Максимальное значение графика для дальнейшнего масштабирования
            // Ограничитель, чтобы длинный столбик не вышел за границы графика
            int max = 0;

            for (int i = 0; i < 256; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            if (max == 0)
                return bitmap;

            // Вертикальная ось 
            g.DrawLine(Pens.Black, left, top, left, height - bottom);
            // Горизонтальная ось
            g.DrawLine(Pens.Black, left, height - bottom, width - 10, height - bottom);

            for (int i = 0; i < 256; i++)
            {
                // Высота на экране = (кол-во пикселей данного оттенка / доступная высота окна) * макс число пикселей
                int barHeight = values[i]  * chartHeight / max;

                // Сколько отступить для текущего оттенка
                // Отступ + текущий шаг * доступная ширина графика / 256 частей
                int x = left + i * chartWidth / 256;
                // Отступ для следующего оттенка
                int nextX = left + (i + 1) * chartWidth / 256;

                g.FillRectangle(new SolidBrush(color), x, height - bottom - barHeight, Math.Max(1, nextX - x), barHeight);
            }

            g.DrawString("0", Font, Brushes.Black, left - 5, height - 25);
            g.DrawString("255", Font, Brushes.Black, width - 35, height - 25);
        }

        return bitmap;
    }
}