namespace LyricsSceneMaker_CSharp
{
    partial class LyricsScene
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
            this.descriptorTextBox = new System.Windows.Forms.Label();
            this.albumPictureBox = new System.Windows.Forms.PictureBox();
            this.lyricsTextBox1 = new System.Windows.Forms.Label();
            this.lyricsTextBox2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titlebar = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scenePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptorTextBox
            // 
            this.descriptorTextBox.BackColor = System.Drawing.Color.Transparent;
            this.descriptorTextBox.Font = new System.Drawing.Font("BM DoHyeon", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.descriptorTextBox.Location = new System.Drawing.Point(71, 519);
            this.descriptorTextBox.Name = "descriptorTextBox";
            this.descriptorTextBox.Size = new System.Drawing.Size(445, 49);
            this.descriptorTextBox.TabIndex = 0;
            this.descriptorTextBox.Text = "descriptor";
            this.descriptorTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // albumPictureBox
            // 
            this.albumPictureBox.BackColor = System.Drawing.Color.Black;
            this.albumPictureBox.Location = new System.Drawing.Point(73, 157);
            this.albumPictureBox.Name = "albumPictureBox";
            this.albumPictureBox.Size = new System.Drawing.Size(441, 359);
            this.albumPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.albumPictureBox.TabIndex = 1;
            this.albumPictureBox.TabStop = false;
            this.albumPictureBox.Click += new System.EventHandler(this.albumPictureBox_Click);
            // 
            // lyricsTextBox1
            // 
            this.lyricsTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.lyricsTextBox1.Font = new System.Drawing.Font("Gmarket Sans TTF Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox1.Location = new System.Drawing.Point(739, 219);
            this.lyricsTextBox1.Name = "lyricsTextBox1";
            this.lyricsTextBox1.Size = new System.Drawing.Size(470, 149);
            this.lyricsTextBox1.TabIndex = 2;
            this.lyricsTextBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lyricsTextBox2
            // 
            this.lyricsTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.lyricsTextBox2.Font = new System.Drawing.Font("Gmarket Sans TTF Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lyricsTextBox2.Location = new System.Drawing.Point(741, 420);
            this.lyricsTextBox2.Name = "lyricsTextBox2";
            this.lyricsTextBox2.Size = new System.Drawing.Size(468, 129);
            this.lyricsTextBox2.TabIndex = 3;
            this.lyricsTextBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 4;
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.Transparent;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(1280, 68);
            this.titlebar.TabIndex = 5;
            this.titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.titlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
            this.titlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lyricsTextBox2);
            this.panel2.Controls.Add(this.titlebar);
            this.panel2.Controls.Add(this.lyricsTextBox1);
            this.panel2.Controls.Add(this.albumPictureBox);
            this.panel2.Controls.Add(this.descriptorTextBox);
            this.panel2.Controls.Add(this.scenePictureBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 720);
            this.panel2.TabIndex = 6;
            // 
            // scenePictureBox
            // 
            this.scenePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePictureBox.Image = global::LyricsSceneMaker_CSharp.Properties.Resources.scene1;
            this.scenePictureBox.Location = new System.Drawing.Point(0, 0);
            this.scenePictureBox.Name = "scenePictureBox";
            this.scenePictureBox.Size = new System.Drawing.Size(1280, 720);
            this.scenePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.scenePictureBox.TabIndex = 3;
            this.scenePictureBox.TabStop = false;
            // 
            // LyricsScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LyricsScene";
            this.Text = "LyricsScene";
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label descriptorTextBox;
        private System.Windows.Forms.PictureBox albumPictureBox;
        private System.Windows.Forms.Label lyricsTextBox1;
        private System.Windows.Forms.Label lyricsTextBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titlebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox scenePictureBox;
    }
}