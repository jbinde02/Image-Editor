﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public Color PaintColor; 

        public Form1()
        {
            InitializeComponent();
            Slider s = new Slider();
            s.Show();
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
                updateDatabase();
            }
        }

        private void openRecentForm_Load(object sender, EventArgs e)
        {
            openRecentToolStripMenuItem.DropDownItems.Clear();
            ToolStripItem[] recents = new ToolStripMenuItem[5];
            try
            {
                String constr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Jabbe\\OneDrive\\Documents\\School Work\\CIS 302\\Image Editor\\Image Editor\\ImageEditorDatabase.mdf;Integrated Security=True";
                var connection = new SqlConnection(constr);

                var cmd = new SqlCommand();
                cmd.CommandText = @"SELECT TOP " + recents.Length + " * FROM Images ORDER BY [Date Opened] DESC;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ToolStripMenuItem tsmi = new ToolStripMenuItem();
                        tsmi.Size = new System.Drawing.Size(180, 22);
                        tsmi.Text = reader.GetString(reader.GetOrdinal("Path"));
                        tsmi.Click += openRecent_Click;
                        recents[index] = tsmi;
                        index++;
                    }
                }
                cmd.Dispose();
                connection.Close();
                reader.Close();
                openRecentToolStripMenuItem.DropDownItems.AddRange(recents);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void openRecent_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            img = new Bitmap(tsmi.Text);
            path = tsmi.Text;
            resizePictureBox();
            pictureBox1.Image = img;
            updateDatabase();
        }

        private void updateDatabase()
        {
            try
            {
                String constr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Jabbe\\OneDrive\\Documents\\School Work\\CIS 302\\Image Editor\\Image Editor\\ImageEditorDatabase.mdf;Integrated Security=True";
                var connection = new SqlConnection(constr);

                var cmd = new SqlCommand();
                cmd.CommandText = @"IF EXISTS(SELECT * FROM Images WHERE Path = @Path)
                                    UPDATE Images SET [Date Opened] = @Date, [Horizontal Resolution] = @HorizontalResolution, [Verticle Resolution] = @VerticleResolution, Width = @Width, Height = @Height, [File Size (MB)] = @FileSize, [Pixel Format] = @PixelFormat WHERE Path = @Path
                                    ELSE
                                    INSERT INTO Images VALUES (@Path, @Date, @HorizontalResolution, @VerticleResolution, @Width, @Height, @FileSize, @PixelFormat);";
                cmd.Parameters.AddWithValue("@Path", path);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@HorizontalResolution", img.HorizontalResolution);
                cmd.Parameters.AddWithValue("@VerticleResolution", img.VerticalResolution);
                cmd.Parameters.AddWithValue("@Width", img.Width);
                cmd.Parameters.AddWithValue("@Height", img.Height);
                cmd.Parameters.AddWithValue("@FileSize", new System.IO.FileInfo(path).Length);
                cmd.Parameters.AddWithValue("@PixelFormat",img.PixelFormat.ToString());

                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                openRecentForm_Load(null, null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            updateDatabase();
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
                updateDatabase();
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

        private void colorMatrixEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorMatixForm colorMatrixForm = new ColorMatixForm();
            var colorMatrix = new System.Drawing.Imaging.ColorMatrix();

            if(colorMatrixForm.ShowDialog() == DialogResult.OK)
            {
                colorMatrix = colorMatrixForm.colorMatrix;
            }

            var imageAtrtributes = new System.Drawing.Imaging.ImageAttributes();
            imageAtrtributes.SetColorMatrix(colorMatrix);

            var graphics = Graphics.FromImage(img);
            graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtrtributes);
            graphics.Dispose();
            refresh();
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
