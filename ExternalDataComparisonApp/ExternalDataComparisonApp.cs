using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExternalDataComparisonApp
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
            // Load data from the external CSV file.
            LoadDataFromCSV("data.csv");

            // Draw the points on the PictureBox.
            DrawPointsOnPictureBox();
        }

        private void LoadDataFromCSV(string fileName)
        {
            // Read the CSV file and populate the pointDataList with the extracted data.
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 3 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    Color color;
                    if (Enum.TryParse(parts[2], out KnownColor knownColor))
                    {
                        color = Color.FromKnownColor(knownColor);
                    }
                    else
                    {
                        color = Color.Black; // Default color if the specified color is not recognized.
                    }

                    pointDataList.Add(new PointData(x, y, color));
                }
            }
        }

        private void DrawPointsOnPictureBox()
        {
            // Draw the points on the PictureBox.
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Clear the PictureBox.
                g.Clear(Color.Red);

                // Draw each point on the PictureBox.
                foreach (PointData pointData in pointDataList)
                {
                    Brush pointBrush = new SolidBrush(pointData.Color);
                    g.FillEllipse(pointBrush, pointData.X - 2, pointData.Y - 2, 5, 5);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataFromCSV("data.csv");

            DrawPointsOnPictureBox();
        }
    }
    public class PointData
    {
        public PointData(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

    }
}
