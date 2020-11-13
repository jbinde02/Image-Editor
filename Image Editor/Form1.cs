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

        Image img;
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Size = img.Size;
                if(pictureBox1.Size.Width > this.Size.Width || pictureBox1.Size.Height > this.Size.Height)
                {
                    this.Size = pictureBox1.Size;
                }
                pictureBox1.Image = img;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
