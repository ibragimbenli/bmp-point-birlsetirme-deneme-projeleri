using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SCADAApp
{
    public partial class MainForm : Form
    {
        private List<PointData> pointDataList = new List<PointData>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Verileri alıp pointDataList'e ekleyin.
            // Bu örnek için rastgele veriler oluşturuyoruz.
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(pictureBox.Width);
                int y = random.Next(pictureBox.Height);
                bool isRed = random.NextDouble() > 0.5; // Rastgele kırmızı veya yeşil renk seçimi.

                pointDataList.Add(new PointData(x, y, isRed));
            }

            // PictureBox'ı yeniden çizmek için Invalidate() çağırıyoruz.
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // PictureBox'ı boyamak için Paint olayını kullanıyoruz.
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Önceki noktaları temizliyoruz.
                g.Clear(Color.Red);

                // Noktaları çiziyoruz ve şartlı olarak renklendiriyoruz.
                foreach (PointData pointData in pointDataList)
                {
                    Brush pointBrush = pointData.IsRed ? Brushes.Red : Brushes.Green;
                    g.FillEllipse(pointBrush, pointData.X - 2, pointData.Y - 2, 5, 5);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(pictureBox.Width);
                int y = random.Next(pictureBox.Height);
                bool isRed = random.NextDouble() > 0.5; // Rastgele kırmızı veya yeşil renk seçimi.

                pointDataList.Add(new PointData(x-100, y-100, isRed));
            }

            // PictureBox'ı yeniden çizmek için Invalidate() çağırıyoruz.
            pictureBox.Invalidate();
        }
    }

    public class PointData
    {
        public PointData(int x, int y, bool isRed)
        {
            X = x;
            Y = y;
            IsRed = isRed;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsRed { get; set; }
    }
}
