namespace Image_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redScalartoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.greenScalartoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.blueScalartoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.alphaScalartoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.counterClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultWindowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1352, 745);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1386, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cropToolStripMenuItem,
            this.paintToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.rotateToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // cropToolStripMenuItem
            // 
            this.cropToolStripMenuItem.Name = "cropToolStripMenuItem";
            this.cropToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cropToolStripMenuItem.Text = "Crop";
            this.cropToolStripMenuItem.Click += new System.EventHandler(this.cropToolStripMenuItem_Click);
            // 
            // paintToolStripMenuItem
            // 
            this.paintToolStripMenuItem.Name = "paintToolStripMenuItem";
            this.paintToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.paintToolStripMenuItem.Text = "Paint";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redScalartoolStripTextBox,
            this.toolStripSeparator1,
            this.greenScalartoolStripTextBox,
            this.toolStripSeparator2,
            this.blueScalartoolStripTextBox,
            this.toolStripSeparator3,
            this.alphaScalartoolStripTextBox,
            this.toolStripComboBox1});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // redScalartoolStripTextBox
            // 
            this.redScalartoolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.redScalartoolStripTextBox.Name = "redScalartoolStripTextBox";
            this.redScalartoolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.redScalartoolStripTextBox.Text = "1";
            this.redScalartoolStripTextBox.ToolTipText = "Red Scaler | Enter a Float Value";
            this.redScalartoolStripTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterScalarToolStripTextBox_KeyUp);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // greenScalartoolStripTextBox
            // 
            this.greenScalartoolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.greenScalartoolStripTextBox.Name = "greenScalartoolStripTextBox";
            this.greenScalartoolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.greenScalartoolStripTextBox.Text = "1";
            this.greenScalartoolStripTextBox.ToolTipText = "Green Scaler | Enter a Float Value";
            this.greenScalartoolStripTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterScalarToolStripTextBox_KeyUp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // blueScalartoolStripTextBox
            // 
            this.blueScalartoolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.blueScalartoolStripTextBox.Name = "blueScalartoolStripTextBox";
            this.blueScalartoolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.blueScalartoolStripTextBox.Text = "1";
            this.blueScalartoolStripTextBox.ToolTipText = "Blue Scaler | Enter a Float Value";
            this.blueScalartoolStripTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterScalarToolStripTextBox_KeyUp);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // alphaScalartoolStripTextBox
            // 
            this.alphaScalartoolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.alphaScalartoolStripTextBox.Name = "alphaScalartoolStripTextBox";
            this.alphaScalartoolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.alphaScalartoolStripTextBox.Text = "1";
            this.alphaScalartoolStripTextBox.ToolTipText = "Alpha Scaler | Enter a Float Value";
            this.alphaScalartoolStripTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterScalarToolStripTextBox_KeyUp);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Grayscale",
            "Invert"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Text = "Presets";
            this.toolStripComboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterPresetToolStripComboBox_KeyUp);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripTextBox1});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resizeToolStripMenuItem.Text = "Resize by %";
            // 
            // resizeToolStripTextBox1
            // 
            this.resizeToolStripTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.resizeToolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.resizeToolStripTextBox1.Name = "resizeToolStripTextBox1";
            this.resizeToolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.resizeToolStripTextBox1.Text = "100";
            this.resizeToolStripTextBox1.ToolTipText = "Resize Factor | Enter a Double";
            this.resizeToolStripTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.resizeToolStripTextBox1_KeyUp);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.counterClockwiseToolStripMenuItem,
            this.flipToolStripMenuItem,
            this.flipYToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem3.Text = "90° Clockwise";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // counterClockwiseToolStripMenuItem
            // 
            this.counterClockwiseToolStripMenuItem.Name = "counterClockwiseToolStripMenuItem";
            this.counterClockwiseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.counterClockwiseToolStripMenuItem.Text = "90° Counter Clockwise";
            this.counterClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.flipToolStripMenuItem.Text = "Flip X";
            this.flipToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // flipYToolStripMenuItem
            // 
            this.flipYToolStripMenuItem.Name = "flipYToolStripMenuItem";
            this.flipYToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.flipYToolStripMenuItem.Text = "Flip Y";
            this.flipYToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultWindowSizeToolStripMenuItem,
            this.fitToImageToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 19);
            this.toolStripMenuItem1.Text = "View";
            // 
            // defaultWindowSizeToolStripMenuItem
            // 
            this.defaultWindowSizeToolStripMenuItem.Name = "defaultWindowSizeToolStripMenuItem";
            this.defaultWindowSizeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.defaultWindowSizeToolStripMenuItem.Text = "Default Window Size";
            this.defaultWindowSizeToolStripMenuItem.Click += new System.EventHandler(this.defaultWindowSizeToolStripMenuItem_Click);
            // 
            // fitToImageToolStripMenuItem
            // 
            this.fitToImageToolStripMenuItem.Name = "fitToImageToolStripMenuItem";
            this.fitToImageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.fitToImageToolStripMenuItem.Text = "Fit to Image";
            this.fitToImageToolStripMenuItem.Click += new System.EventHandler(this.fitToImageToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 802);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Image Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem defaultWindowSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox resizeToolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem fitToImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem counterClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipYToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox redScalartoolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox greenScalartoolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox blueScalartoolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox alphaScalartoolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}

