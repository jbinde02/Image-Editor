using System;
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
        private Point point1, point2;
        private Size defaultWindowSize = new Size(940, 560);
        private Pen paintPen = new Pen(Color.FromArgb(100, 100, 100));
        private ColorSliderForm paintSlider = new ColorSliderForm();
        private String databasePath = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|ImageEditorDatabase.mdf; Initial Catalog=Test; Integrated Security=True";
        private DatabaseManager dbManager = new DatabaseManager();
        private Bitmap stampedImg;
        private List<Bitmap> pastImages = new List<Bitmap>();

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
                updateDatabase();
                refreshSave();
            }           
        }

        private void openRecentForm_Load(object sender, EventArgs e)
        {
            openRecentToolStripMenuItem.DropDownItems.Clear();
            ToolStripItem[] recents = new ToolStripMenuItem[5];
            int index = 0;
            using (var connection = new SqlConnection(databasePath))
            {
                using (SqlDataReader reader = dbManager.selectRecentRows(connection, 5))
                {
                    if (reader != null)
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
                }
            }
            try
            {
                openRecentToolStripMenuItem.DropDownItems.AddRange(recents); //Throws an exception if recents contains null. Ignore it
            }
            catch{}
        }

        private void openRecent_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            img = new Bitmap(tsmi.Text);
            path = tsmi.Text;
            refreshSave();
            updateDatabase();
        }

        private void updateDatabase()
        {
            try
            {
                using (var connection = new SqlConnection(databasePath))
                {
                    dbManager.insertUpdateDatabase(connection, path, img);
                    openRecentForm_Load(null, null);
                }
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
            using(var connection = new SqlConnection(databasePath))
            {
                using (SqlDataReader reader = dbManager.selectRow(connection, path))
                {
                    if(reader != null)
                    {
                        while (reader.Read())
                        {
                            aboutForm.pathLabel.Text = reader["Path"].ToString();
                            aboutForm.dateLabel.Text = reader["Date Opened"].ToString();
                            aboutForm.horizontalResolutionLabel.Text = reader["Horizontal Resolution"].ToString() + " pixels per inch";
                            aboutForm.verticleResolutionLabel.Text = reader["Verticle Resolution"].ToString() + " pixels per inch";
                            aboutForm.widthLabel.Text = reader["Width"].ToString() + " pixels";
                            aboutForm.heightLabel.Text = reader["Height"].ToString() + " pixels";
                            aboutForm.fileSizeLabel.Text = reader["File Size (MB)"].ToString() + "MB";
                            aboutForm.pixelFormatLabel.Text = reader["Pixel Format"].ToString();
                        }
                    }
                }
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
        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteHandlers();
            this.Text = this.Text + " - (Paint)";
            pictureBox1.MouseDown += new MouseEventHandler(paint_down);
            pictureBox1.MouseMove += new MouseEventHandler(paint_move);
            pictureBox1.MouseUp += new MouseEventHandler(paint_up);
            paintSlider.Show();
        }

        private void paint_down(object sender, MouseEventArgs e) {
            this.point1 = e.Location;
            paintPen.Color = paintSlider.get_Color();
            paintPen.Width = paintSlider.getThickness();
        }

        private void paint_move(object sender, MouseEventArgs e) {
            int radius = paintSlider.getThickness() / 2;
            if (!point1.IsEmpty)
            {
                using (var graphics = Graphics.FromImage(img))
                {
                    graphics.DrawLine(paintPen, point1.X, point1.Y, e.Location.X, e.Location.Y);
                    graphics.FillEllipse(paintPen.Brush, e.Location.X - radius, e.Location.Y - radius,
                                         radius + radius, radius + radius);
                }
                refresh();
                point1 = e.Location;
            }
        }

        private void paint_up(object sender, MouseEventArgs e) {
            point1 = new Point(0,0);
            refreshSave();
        }

        private void colorDropperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteHandlers();
            this.Text = this.Text + " - (Color Dropper)";
            pictureBox1.MouseDown += new MouseEventHandler(colorDropper);
        }

        private void colorDropper(object sender, MouseEventArgs e)
        {
            paintSlider.updateBackColor(img.GetPixel(e.X, e.Y));
        }

        private void stampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteHandlers();
            this.Text = this.Text + " - (Stamp) Click twice in picture";
            pictureBox1.MouseDown += new MouseEventHandler(Stamp);
        }

        private void Stamp(object sender, MouseEventArgs e)
        {
            if (!point1.IsEmpty)
            {
                if (!point2.IsEmpty)
                {
                    using(var graphics = Graphics.FromImage(img))
                    {
                        graphics.DrawImage(stampedImg, e.Location);
                        refreshSave();
                    }
                    return;
                }
                point2 = e.Location;
                if (point1.X > point2.X || point1.Y > point2.Y)
                {
                    Point temp = point1;
                    point1 = point2;
                    point2 = temp;
                }
                Rectangle rectangle = new Rectangle(point1, new Size(Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y)));
                stampedImg = img.Clone(rectangle, img.PixelFormat);

                //Creates a new form with that shows the stamped image. When this new form is closed, the stamp tool will be disabled
                Form stampForm = new Form();
                stampForm.Text = "Stamped Image - Close this to stop stamping";
                PictureBox stampPictureBox = new PictureBox();
                stampPictureBox.Image = stampedImg;
                stampPictureBox.Size = stampedImg.Size;
                stampForm.Size = new Size(stampPictureBox.Size.Width + 75, stampPictureBox.Size.Height + 75);
                stampForm.Controls.Add(stampPictureBox);
                stampForm.FormClosing += new FormClosingEventHandler(stampForm_Closing);
                stampForm.Show();
            }
            else
            {
                point1 = e.Location;
            }
        }

        private void stampForm_Closing(Object sender, FormClosingEventArgs e)
        {
            deleteHandlers();
            stampedImg = null;
            point1 = new Point(0, 0);
            point2 = new Point(0, 0);
        }

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteHandlers();
            this.Text = this.Text + " - (Crop) Click twice in picture";
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
                deleteHandlers();
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

            using (var graphics = Graphics.FromImage(img))
            {
                graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtrtributes);
            }
            refreshSave();
        }

        private void resizeToolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(double.TryParse(resizeToolStripTextBox1.Text, out double ratio))
                {
                    ratio = ratio / 100;
                    img = new Bitmap(img, new Size((int)(img.Width * ratio), (int)(img.Height * ratio)));
                    refreshSave();
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
            refreshSave();
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
                this.Size = new Size(img.Width + 100, img.Height + 100);
            }
        }

        private void refreshImage()
        {
            pictureBox1.Image = img;
        }
        
        private void deleteHandlers()
        {
            pictureBox1.MouseDown -= paint_down;
            pictureBox1.MouseMove -= paint_move;
            pictureBox1.MouseUp -= paint_up;
            pictureBox1.MouseDown -= colorDropper;
            pictureBox1.MouseDown -= Crop;
            pictureBox1.MouseDown -= Stamp;
            this.Text = "Image Editor";
        }

        //Call this whenever changes are made to the image
        private void refresh()
        {
            resizePictureBox();
            refreshImage();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (pastImages.Count >= 2)
            {               
                img = pastImages[pastImages.Count-2];
                pastImages.RemoveAt(pastImages.Count - 1);
                refresh();
            }           
        }
        
        //Call this to refresh the screen and save the image to the pastImages list
        private void refreshSave() {
            refresh();           
            if (pastImages.Count < 15) {
                pastImages.Add(new Bitmap(img));
            }
            else {
                pastImages.RemoveAt(0);
                pastImages.Add(new Bitmap(img));
            }
        }
    }
}
