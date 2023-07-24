using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DotRepresentationApp
{
    public partial class DotRepresentationApp : Form
    {
        private List<int> dataPoints = new List<int> { -5, 10, 7, -3, 2, 8, -1, 4, -6, 9, 10, 7, -3, 2, 8, -1, 4, -6, 9 };

        public DotRepresentationApp()
        {
            InitializeComponent();
        }

        private void DotRepresentationApp_Load(object sender, EventArgs e)
        {
            DrawDotsOnPictureBox();
        }

        private void DrawDotsOnPictureBox()
        {
            // Draw the dots on the PictureBox.
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Clear the PictureBox.
                g.Clear(Color.Red);

                // Draw each dot on the PictureBox.
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    int x = 30 + i * 30;
                    int y = 50;

                    // Determine the color based on the data condition.
                    Color dotColor = dataPoints[i] < 0 ? Color.Red : Color.Black;

                    Brush dotBrush = new SolidBrush(dotColor);
                    g.FillEllipse(dotBrush, x - 2, y - 2, 10, 10);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawDotsOnPictureBox();
        }
    }
}
