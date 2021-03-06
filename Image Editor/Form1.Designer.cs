﻿namespace Image_Editor
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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDropperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(901, 484);
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
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
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
            this.aboutToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.filterToolStripMenuItem,
            this.stampToolStripMenuItem,
            this.paintToolStripMenuItem,
            this.toolStripSeparator1,
            this.cropToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.undoToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.colorMatrixEditorToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // stampToolStripMenuItem
            // 
            this.stampToolStripMenuItem.Name = "stampToolStripMenuItem";
            this.stampToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stampToolStripMenuItem.Text = "Stamp";
            this.stampToolStripMenuItem.Click += new System.EventHandler(this.stampToolStripMenuItem_Click);
            // 
            // paintToolStripMenuItem
            // 
            this.paintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorDropperToolStripMenuItem});
            this.paintToolStripMenuItem.Name = "paintToolStripMenuItem";
            this.paintToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.paintToolStripMenuItem.Text = "Paint";
            this.paintToolStripMenuItem.Click += new System.EventHandler(this.paintToolStripMenuItem_Click);
            // 
            // colorDropperToolStripMenuItem
            // 
            this.colorDropperToolStripMenuItem.Name = "colorDropperToolStripMenuItem";
            this.colorDropperToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.colorDropperToolStripMenuItem.Text = "Color Dropper";
            this.colorDropperToolStripMenuItem.Click += new System.EventHandler(this.colorDropperToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // cropToolStripMenuItem
            // 
            this.cropToolStripMenuItem.Name = "cropToolStripMenuItem";
            this.cropToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cropToolStripMenuItem.Text = "Crop";
            this.cropToolStripMenuItem.Click += new System.EventHandler(this.cropToolStripMenuItem_Click);
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
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 521);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Image Editor";
            this.Load += new System.EventHandler(this.openRecentForm_Load);
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorDropperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stampToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

