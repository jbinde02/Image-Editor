using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Image_Editor
{
    public partial class ColorMatixForm : Form
    {
        public ColorMatrix colorMatrix = new ColorMatrix();
        private Dictionary<string,ColorMatrix> presets = new Dictionary<string,ColorMatrix>();
        private TextBox[,] textBoxMatrix;


        public string TheValue
        {
            get { return "Hello"; }
        }

        public ColorMatixForm()
        {
            InitializeComponent();
            textBoxMatrix = new TextBox[5, 5] { {matrix00,matrix01,matrix02,matrix03,matrix04},
                                                {matrix10,matrix11,matrix12,matrix13,matrix14 },
                                                {matrix20,matrix21,matrix22,matrix23,matrix24 },
                                                {matrix30,matrix31,matrix32,matrix33,matrix34 },
                                                {matrix40,matrix41,matrix42,matrix43,matrix44 }};

            //Presets added to dictionary
            presets.Add("Grayscale", new ColorMatrix(new float[][] {new float[] {0.333f, 0.333f, 0.333f,  0, 0},    // red scaling factor
                                                                    new float[] { 0.333f, 0.333f, 0.333f,  0, 0},   // green scaling factor
                                                                    new float[] { 0.333f, 0.333f, 0.333f,  0, 0},   // blue scaling factor
                                                                    new float[] {0,  0,  0,  1, 0},                 // alpha scaling factor
                                                                    new float[] {0, 0, 0, 0, 1}
            }));

            presets.Add("Invert", new ColorMatrix(new float[][] {new float[] {-1, 0, 0,  0, 0},    // red scaling factor
                                                                 new float[] { 0, -1, 0,  0, 0},   // green scaling factor
                                                                 new float[] { 0, 0, -1,  0, 0},   // blue scaling factor
                                                                 new float[] {0,  0,  0,  1, 0},   // alpha scaling factor
                                                                 new float[] {1, 1, 1, 0, 1}
            }));
        }



        private void submitButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<5; i++)
            {
                for(int j = 0; j<5; j++)
                {
                    try
                    {
                        colorMatrix[i, j] = float.Parse(textBoxMatrix[i, j].Text);
                    }
                    catch
                    {
                        colorMatrix[i, j] = 0;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void identityButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(i == j)
                    {
                        textBoxMatrix[i, j].Text = "1";
                    }
                    else
                    {
                        textBoxMatrix[i, j].Text = "0";
                    }
                }
            }
        }

        private void presetsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            presets.TryGetValue(presetsListBox.SelectedItem.ToString(), out colorMatrix);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    textBoxMatrix[i, j].Text = colorMatrix[i, j].ToString();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This matrix represents a transformation on a vector that makes up the data for each pixel in the image. The identiy matrix will do nothing to the image. " +
                "Changing only the values on the diagonal will scale the colors. Some combinations can perform rotations, translations, shears, and much more. " +
                "You can also select a preset. Enter 'float' values in each cell. ", "Help");
        }
    }
}
