using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Image_Editor
{
    public partial class Slider : Form
    {
        int thickness = 1;
        public Slider()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(100, 0, 0);
            trackBar1.Value = 100;
        }

        public void updateBackColor() {
            this.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);

            
        }
        public Color get_Color() {
            return this.BackColor;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            updateBackColor();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            updateBackColor();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            updateBackColor();
        }

        private void Slider_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public int getThickness() {
            return this.thickness;
        
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar4.Value.ToString();
            this.thickness = trackBar4.Value;

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            updateBackColor();
        }
    }
}
