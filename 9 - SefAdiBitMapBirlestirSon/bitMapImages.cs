using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace bitMapImage
{
    public partial class bitMapImages : Form
    {
        //private Bitmap imageLoad;
        private Bitmap imageResult; //Sonuç yani Toplam Resim(Üst üste binen resimlerin birleşimi)

        //Model Yüklendikten Sonra Sabit Kalacak, Hiç Değişmeyecek
        private Bitmap imageOutline; //Cam Resmi
        private Bitmap imageModelPoints; //Modelde Tanımlanan Tüm Noktalar (Beyaz)

        //Değişken(Hesaplanan)
        private Bitmap imageGreenPoints; //Ölçüm sonrası OK olan Noktalar
        private Bitmap imageRedPoints; //Ölçüm sonrası NOK olan Noktalar
        private Bitmap imageOrange; //Ölçüm sonrası %75 NOK olan Noktalar
        private Bitmap imageYellow; //Ölçüm sonrası %75 OK olan Noktalar

        private int cPNGWidth = 1000;
        private int cPNGHeight = 667;
        public bitMapImages()
        {
            InitializeComponent();
        }

        #region Bitmap İşlem Fonksiyonları
        private Bitmap MergeOverlayTwoImage(Bitmap source1, Bitmap source2)
        {
            //source1: your source images - assuming they're the same size
            var target = new Bitmap(source2.Width, source2.Height, PixelFormat.Format32bppArgb);
            source1 = ResizeImageProportional(source1, cPNGWidth, cPNGWidth);

            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver; // this is the default, but just to be clear
            graphics.DrawImage(source1, 0, 0);
            graphics.DrawImage(source2, 0, 0);

            //Bitmap target = target.Save("filename.png", ImageFormat.Png);
            return target;
        }
        private Bitmap ResizeImageProportional(Bitmap bitmap, int width, int height)
        {
            if (bitmap.Width == width || bitmap.Height == height) return bitmap;

            Bitmap destImage;
            Rectangle destRect;
            int destH, destW, destX, dextY;

            if (bitmap.Height > bitmap.Width)
            {
                destH = height;
                destW = bitmap.Width / bitmap.Height * height;
                destX = (width - destW) / 2;
                dextY = 0;
            }
            else if (bitmap.Height < bitmap.Width)
            {
                destH = bitmap.Height / bitmap.Width * width;
                destW = width;
                destX = 0;
                dextY = (height - destH) / 2;
            }
            else
            // if (bitmap.Width == bitmap.Height)
            {
                destH = height;
                destW = width;
                destX = 0;
                dextY = 0;
            }

            destRect = new Rectangle(destX, dextY, destW, destH);
            destImage = new Bitmap(width, height);

            destImage.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(bitmap, destRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        #endregion Bitmap İşlem Fonksiyonları


        private void createPointsFromList(ref Bitmap bitmap, List<Point> Points, Color pointColor)
        {
            pointColor = Color.Green;
            //Color yellow = Color.Yellow;
            //Color green = Color.Green;
            //Color alaca = Color.LightPink;
            //Color orange = Color.Brown;
            //Color blue = Color.Blue;
            //Color white = Color.White;
            /*
                        using (SolidBrush brush = new SolidBrush(white))
                        {
                            //var SelectedModel = _pointRepository.GetSelectedModelPoint(Program.selectedglassmodel.ModelId);
                            int w = pictureBox.Width, h = pictureBox.Height;

                            for (int i = 0; i < Program.selectedglassmodel.ModelPointCount; i++)
                            {
                                //var MeasValue = Program.selectedglassmodel.ModelMeasures[i].MeasureValue;
                                List<decimal> MeasValue = new List<decimal>() { -3.1m, -2.000m, -2.1m, -1.90m, -1.5m, -1.4m, 0.00m, 1.00m, 1.5000m, 1.6m, 2.0m, 2.1m, 3.0m, 100.0m };

                                var oranX = 1246 / SelectedModel[i].PositionX;
                                var oranX1 = 1128 / SelectedModel[i].PositionX;
                                var oranX2 = 1011 / SelectedModel[i].PositionX;
                                var oranX3 = 894 / SelectedModel[i].PositionX;
                                var oranY = 585 / SelectedModel[i].PositionY;
                                var oranY1 = 640 / SelectedModel[i].PositionY;
                                var oranY2 = 720 / SelectedModel[i].PositionY;
                                var oranY3 = 800 / SelectedModel[i].PositionY;

                                if (sfDataGrid.Enabled)
                                {
                                    e.Graphics.FillRectangle(brush, (Convert.ToInt32(w / oranX)), (Convert.ToInt32(h / oranY)), 10, 10);
                                }
                                else if (sfDataGrid1.Enabled)
                                {
                                    e.Graphics.FillRectangle(brush, (Convert.ToInt32(w / oranX1)), (Convert.ToInt32(h / oranY1) + 20), 10, 10);
                                }
                                else if (sfDataGrid2.Enabled)
                                {
                                    e.Graphics.FillRectangle(brush, (Convert.ToInt32(w / oranX2)), (Convert.ToInt32(h / oranY2) + 48), 10, 10);
                                }
                                else
                                {
                                    e.Graphics.FillRectangle(brush, (Convert.ToInt32(w / oranX3)), (Convert.ToInt32(h / oranY3) + 75), 10, 10);
                                }
                            }
                        }
            */
        }
        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            imageResult = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);
            imageOutline = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);
            imageModelPoints = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);
            imageGreenPoints = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);
            imageRedPoints = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);
            imageOrange = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);
            imageYellow = new Bitmap(cPNGWidth, cPNGHeight, PixelFormat.Format32bppArgb);

            imageOutline = new Bitmap(@"C:\Users\ibrahim.benli\Desktop\BOMBEÖLÇÜM\Recete Dosyalari\Image Files\ArPlTr.png", true);
            createPointsFromList(ref imageModelPoints, null, Color.Yellow); //İbrahim bu kısmı halledecek
            //imageModelPoints = new Bitmap(@"C:\Users\ibrahim.benli\Desktop\testBMP\png\testt.png", true);
            imageGreenPoints = new Bitmap(@"C:\Users\ibrahim.benli\Desktop\testBMP\png\testg.png", true);
            imageRedPoints = new Bitmap(@"C:\Users\ibrahim.benli\Desktop\testBMP\png\testr.png", true);


            imageResult = MergeOverlayTwoImage(imageResult, imageOutline);     //Cam Resmi(Background)
            imageResult = MergeOverlayTwoImage(imageResult, imageModelPoints); //Beyaz renk
            imageResult = MergeOverlayTwoImage(imageResult, imageGreenPoints); //Yeşil Renk
            imageResult = MergeOverlayTwoImage(imageResult, imageRedPoints);   //Kırmızı Renk

            pictureBox1.Width = cPNGWidth;
            pictureBox1.Height = cPNGHeight;
            pictureBox1.Image = imageResult;
            return;
            /*
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
            */
        }
    }
}
