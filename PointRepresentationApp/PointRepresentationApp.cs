using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PointRepresentationApp
{
    public partial class PointRepresentationApp : Form
    {
        private List<int> dataPoints = new List<int> { -5, 10, 7, -3, 2, 8, -1, 4, -6, 9, 11, 15, 23, 56, -5 };
        private int lowerLimit = -3;
        private int upperLimit = 5;

        public PointRepresentationApp()
        {
            InitializeComponent();
        }

        private void PointRepresentationApp_Load(object sender, EventArgs e)
        {
            DrawDotsOnPictureBox();
        }

        private void DrawDotsOnPictureBox()
        {
            //PictureBox üzerinde noktaları oluştur.
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                // Clear the PictureBox.
                g.Clear(Color.White);

                // PictureBox üzerinde her noktayı yerleştir.
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    int x = 30 + i * 30;
                    int y = 50;

                    // Veri durumuna göre rengi belirleyelim.
                    Color dotColor = GetDotColor(dataPoints[i]);

                    Brush dotBrush = new SolidBrush(dotColor);
                    g.FillEllipse(dotBrush, x - 2, y - 2, 15, 15);
                }
            }
        }

        private Color GetDotColor(int value)
        {
            //şarta göre rengi belirleyelim
            if (value < lowerLimit)
            {
                return Color.Red;
            }
            else if (value > upperLimit)
            {
                return Color.Black;
            }
            else
            {
                return Color.Gray; 
            }
        }
        private void btnCreateDot_Click(object sender, EventArgs e)
        {
            DrawDotsOnPictureBox();
        }
    }
}
