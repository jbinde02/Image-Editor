﻿using System;
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
        private Bitmap originalImg = new Bitmap(1,1);
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
                    originalImg = new Bitmap(openFileDialog1.FileName);
                    img = new Bitmap(openFileDialog1.FileName);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Invalid File Type\n" + exception.Message);
                    return;
                }
                originalImg.Dispose();
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
                    //If file exist, delete and then resave
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
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
            originalImg = null;
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
        //Tools menubar end

        //View menubar start
        private void defaultWindowSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = defaultWindowSize;
        }

        private void fitToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = img.Size;
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
