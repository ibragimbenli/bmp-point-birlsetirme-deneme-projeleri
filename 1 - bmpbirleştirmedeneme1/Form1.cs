using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmpO = (Bitmap)pictureBox1.Image;
            Bitmap bmpB = (Bitmap)pictureBox2.Image;
            Graphics g = Graphics.FromImage(bmpO);
            g.DrawImage(bmpB, 50, 50, bmpO.Size.Width, bmpO.Size.Height);
            g.Dispose();
            pictureBox3.Image = bmpO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color yellow = Color.Yellow;
            Color green = Color.Green;
            Color alaca = Color.LightPink;
            Color orange = Color.Brown;
            Color blue = Color.Blue;
            Color white = Color.White;

            for (int i = 0; i < 10000;)
            {
                using (Graphics G = Graphics.FromImage(pictureBox1.Image))
                {
                    G.FillRectangle(new SolidBrush(Color.Red), new Rectangle(Convert.ToInt32(i), Convert.ToInt32(i), 14, 14));
                }
                i += 100;
            }
            for (int i = 0; i < 10000;)
            {
                using (Graphics G = Graphics.FromImage(pictureBox2.Image))
                {
                    G.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(Convert.ToInt32(i), Convert.ToInt32(i), 14, 14));
                }
                i += 100;
            }
            for (int i = 0; i < 10000;)
            {
                using (Graphics G = Graphics.FromImage(pictureBox3.Image))
                {
                    G.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Convert.ToInt32(i), Convert.ToInt32(i), 14, 14));
                }
                i += 100;
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X + 60;
            int y = e.Y + 20;
            this.Text = $"X: {x} Y: {y}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile(dlg.FileName);
            }
        }
    }
}

