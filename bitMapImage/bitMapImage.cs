using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitMapImage
{
    public partial class bitMapImage : Form
    {
        public bitMapImage()
        {
            InitializeComponent();
        }

        Bitmap image1;

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                // Retrieve the image.
                image1 = new Bitmap(@"C:\Users\ibrahim.benli\Desktop\testBMP\bmpfoto"
                     + @"\music.jpg", true);
                pictureBox1.Image = new Bitmap(@"C:\Users\ibrahim.benli\Desktop\testBMP\bmpfoto"
                    + @"\music.jpg", true);
                int x, y;

                // Loop through the images pixels to reset color.
                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }
                // Set the PictureBox to display the image.
                pictureBox1.Width = image1.Width;
                pictureBox1.Height = image1.Height;
                pictureBox2.Width = image1.Width;
                pictureBox2.Height = image1.Height;
                pictureBox2.Image = image1;

                // Display the pixel format in Label1.
                label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." + "Check the path to the image file.");
            }
        }
    }
}
