using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bmpbirleştirmedeneme2
{
    public partial class CreatePoint : Form
    {
        private List<Point> pointsList = new List<Point>();

        public CreatePoint()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // PictureBox üzerinde tıklanan noktanın koordinatlarını alıyoruz.
            Point clickedPoint = e.Location;

            // Noktayı listeye ekliyoruz.
            pointsList.Add(clickedPoint);

            // Noktayı çiziyoruz (isteğe bağlı).
            DrawPoint(clickedPoint);

            // Nokta oluşturulduğunda yapılacak işlemleri burada gerçekleştirebilirsiniz.
            // Örneğin, noktaların işlenmesi, veritabanına kaydedilmesi, vb.
            int x = e.X + 60;
            int y = e.Y + 20;
            //this.Text = $"X: {x} Y: {y}";
            this.Text = e.Location.ToString();
        }

        private void DrawPoint(Point point)
        {
            // PictureBox'a noktayı çiziyoruz.
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.FillEllipse(Brushes.Red, point.X - 7, point.Y - 7, 14, 14);
            }
        }
    }
}

