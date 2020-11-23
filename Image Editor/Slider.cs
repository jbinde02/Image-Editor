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
        
        public Slider()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(0, 0, 0);
        }

        public void updateBackColor() {
            this.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            
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
    }
}
