using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Editor
{
    public partial class Form1 : Form
    {
        private Bitmap img = new Bitmap(1,1);
        private string path;
        private Point point1, point2; //Mouse locations janky solution
        private Size defaultWindowSize = new Size(940, 560);

        public Form1()
        {
            InitializeComponent();
        }

        //File menubar start
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = new Bitmap(openFileDialog1.FileName);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Invalid File Type\n" + exception.Message);
                    return;
                }
                path = openFileDialog1.FileName;
                resizePictureBox();
                pictureBox1.Image = img;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imgToSave = new Bitmap(img);
            img.Dispose();
            try
            {
                //Since file exist, delete and then resave
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                imgToSave.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            img = new Bitmap(imgToSave);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.FileName = System.IO.Path.GetFileName(path);
            Bitmap imgToSave = new Bitmap(img);
            img.Dispose();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imgToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    path = saveFileDialog1.FileName;
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                img = new Bitmap(imgToSave);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img = null;
            path = null;
            pictureBox1.Image = img;
            this.Size = defaultWindowSize;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //File menubar end

        //Tools menubar start
        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = this.Text + " - (Crop)";
            pictureBox1.MouseDown += new MouseEventHandler(Crop);
        }

        private void Crop(object sender, MouseEventArgs e)
        {
            if (!point1.IsEmpty)
            {
                point2 = e.Location;
                if (point1.X > point2.X || point1.Y > point2.Y)
                {
                    Point temp = point1;
                    point1 = point2;
                    point2 = temp;
                }
                Rectangle rectangle = new Rectangle(point1, new Size(Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y)));
                img = img.Clone(rectangle, img.PixelFormat);
                refresh();
                pictureBox1.MouseDown -= Crop;
                point1 = new Point(0, 0);
                point2 = new Point(0, 0);
                this.Text = "Image Editor";
            }
            else
            {
                point1 = e.Location;
            }
        }

        private void filterScalarToolStripTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            { 
            float red, green, blue, alpha;
            float.TryParse(redScalartoolStripTextBox.Text, out red);
            float.TryParse(greenScalartoolStripTextBox.Text, out green);
            float.TryParse(blueScalartoolStripTextBox.Text, out blue);
            float.TryParse(alphaScalartoolStripTextBox.Text, out alpha);

            float[][] colorMatrixElements = {
                new float[] {red,  0,  0,  0, 0},        // red scaling factor
                new float[] {0,  green,  0,  0, 0},        // green scaling factor
                new float[] {0,  0,  blue,  0, 0},        // blue scaling factor
                new float[] {0,  0,  0,  alpha, 0},        // alpha scaling factor
                new float[] {0, 0, 0, 0, 1}};
            var colorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);

            var imageAtrtributes = new System.Drawing.Imaging.ImageAttributes();
            imageAtrtributes.SetColorMatrix(colorMatrix);

            var graphics = Graphics.FromImage(img);
            graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtrtributes);
            graphics.Dispose();
            refresh();
            }
        }

        private void filterPresetToolStripComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ToolStripComboBox item = (ToolStripComboBox)sender;

                if (item.SelectedItem.Equals("Grayscale")) //Grayscale preset
                {
                    float[][] colorMatrixElements = {
                        new float[] {0.333f, 0.333f, 0.333f,  0, 0},        // red scaling factor
                        new float[] { 0.333f, 0.333f, 0.333f,  0, 0},        // green scaling factor
                        new float[] { 0.333f, 0.333f, 0.333f,  0, 0},        // blue scaling factor
                        new float[] {0,  0,  0,  1, 0},        // alpha scaling factor
                        new float[] {0, 0, 0, 0, 1}};
                    var colorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);

                    var imageAtrtributes = new System.Drawing.Imaging.ImageAttributes();
                    imageAtrtributes.SetColorMatrix(colorMatrix);

                    var graphics = Graphics.FromImage(img);
                    graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtrtributes);
                    graphics.Dispose();
                    refresh();
                }

                if (item.SelectedItem.Equals("Invert")) //Invert preset
                {
                    float[][] colorMatrixElements = {
                        new float[] {-1, 0, 0,  0, 0},        // red scaling factor
                        new float[] { 0, -1, 0,  0, 0},        // green scaling factor
                        new float[] { 0, 0, -1,  0, 0},        // blue scaling factor
                        new float[] {0,  0,  0,  1, 0},        // alpha scaling factor
                        new float[] {1, 1, 1, 0, 1}};
                    var colorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);

                    var imageAtrtributes = new System.Drawing.Imaging.ImageAttributes();
                    imageAtrtributes.SetColorMatrix(colorMatrix);

                    var graphics = Graphics.FromImage(img);
                    graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtrtributes);
                    graphics.Dispose();
                    refresh();
                }
            }
        }

        private void resizeToolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(double.TryParse(resizeToolStripTextBox1.Text, out double ratio))
                {
                    ratio = ratio / 100;
                    img = new Bitmap(img, new Size((int)(img.Width * ratio), (int)(img.Height * ratio)));
                    refresh();
                    resizeToolStripTextBox1.Text = "";
                }
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(item.Text == "90° Clockwise")
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (item.Text == "90° Counter Clockwise")
            {
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (item.Text == "Flip X")
            {
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else if (item.Text == "Flip Y")
            {
                img.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            refresh();
        }
        //Tools menubar end

        //View menubar start
        private void defaultWindowSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = defaultWindowSize;
        }

        private void fitToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(img.Width + 100, img.Height + 100);
        }
        //View menubar end

        private void resizePictureBox()
        {
            pictureBox1.Size = img.Size;
            if (pictureBox1.Size.Width > this.Size.Width || pictureBox1.Size.Height > this.Size.Height)
            {
                this.Size = pictureBox1.Size;
            }
        }

        private void refreshImage()
        {
            pictureBox1.Image = img;
        }

        //Call this whenever changes are made to the image
        private void refresh()
        {
            resizePictureBox();
            refreshImage();
        }
    }
}
