using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialAutomationApp
{
    public partial class IndustrialAutomationApp : Form
    {
        private List<Point> pointsList = new List<Point>();
        private bool isRedState = false;

        public IndustrialAutomationApp()
        {
            InitializeComponent();
        }

        private void IndustrialAutomationApp_Load(object sender, EventArgs e)
        {
            // Timer'ı başlatarak duruma bağlı olarak nokta renklerini güncellemeyi sağlıyoruz.
            timer.Interval = 1000; // 1 saniye
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Timer her tetiklendiğinde duruma bağlı olarak nokta rengini değiştiriyoruz.
            isRedState = !isRedState;

            // PictureBox'ı yeniden çizmek için Invalidate() çağırıyoruz.
            pictureBox1.Invalidate();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // PictureBox'ı boyamak için Paint olayını kullanıyoruz.

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                // Önceki noktaları temizliyoruz.
                g.Clear(Color.Black);

                // Noktaları çiziyoruz.
                foreach (Point point in pointsList)
                {
                    // Duruma bağlı olarak nokta rengini belirliyoruz.
                    Brush pointBrush = isRedState ? Brushes.Red : Brushes.Green;
                    g.FillEllipse(pointBrush, point.X - 2, point.Y - 2, 5, 5);
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // PictureBox üzerinde tıklanan noktanın koordinatlarını alıyoruz.
            Point clickedPoint = e.Location;

            // Noktayı listeye ekliyoruz.
            pointsList.Add(clickedPoint);

            // PictureBox'ı yeniden çizmek için Invalidate() çağırıyoruz.
            pictureBox1.Invalidate();

            // Nokta oluşturulduğunda yapılacak işlemleri burada gerçekleştirebilirsiniz.
            // Örneğin, noktaların işlenmesi, veritabanına kaydedilmesi, vb.
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            timer.Interval = 100; // 1 saniye
            timer.Start();
        }
        
    }
}
