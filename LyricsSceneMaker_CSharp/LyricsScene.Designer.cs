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
            this.lyricsTextBox1 = new System.Windows.Forms.Label();
            this.lyricsTextBox2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ahdelronPictureBox = new System.Windows.Forms.PictureBox();
            this.blurPictureBox = new System.Windows.Forms.PictureBox();
            this.titlebar = new System.Windows.Forms.Label();
            this.scenePictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ahdelronPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptorTextBox
            // 
            this.descriptorTextBox.BackColor = System.Drawing.Color.Transparent;
            this.descriptorTextBox.Font = new System.Drawing.Font("BM DoHyeon", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.descriptorTextBox.ForeColor = System.Drawing.Color.White;
            this.descriptorTextBox.Location = new System.Drawing.Point(0, 68);
            this.descriptorTextBox.Name = "descriptorTextBox";
            this.descriptorTextBox.Size = new System.Drawing.Size(1277, 49);
            this.descriptorTextBox.TabIndex = 0;
            this.descriptorTextBox.Text = "Welcome our application.";
            this.descriptorTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lyricsTextBox1
            // 
            this.lyricsTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.lyricsTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lyricsTextBox1.Font = new System.Drawing.Font("Gmarket Sans TTF Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox1.ForeColor = System.Drawing.Color.White;
            this.lyricsTextBox1.Location = new System.Drawing.Point(0, 243);
            this.lyricsTextBox1.Name = "lyricsTextBox1";
            this.lyricsTextBox1.Size = new System.Drawing.Size(1277, 36);
            this.lyricsTextBox1.TabIndex = 2;
            this.lyricsTextBox1.Text = "lyrics loading ...";
            this.lyricsTextBox1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lyricsTextBox2
            // 
            this.lyricsTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.lyricsTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lyricsTextBox2.Font = new System.Drawing.Font("Gmarket Sans TTF Bold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.lyricsTextBox2.Location = new System.Drawing.Point(0, 427);
            this.lyricsTextBox2.Name = "lyricsTextBox2";
            this.lyricsTextBox2.Size = new System.Drawing.Size(1280, 27);
            this.lyricsTextBox2.TabIndex = 3;
            this.lyricsTextBox2.Text = "lyrics loading ...";
            this.lyricsTextBox2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.ahdelronPictureBox);
            this.panel2.Controls.Add(this.lyricsTextBox2);
            this.panel2.Controls.Add(this.lyricsTextBox1);
            this.panel2.Controls.Add(this.descriptorTextBox);
            this.panel2.Controls.Add(this.blurPictureBox);
            this.panel2.Controls.Add(this.titlebar);
            this.panel2.Controls.Add(this.scenePictureBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 720);
            this.panel2.TabIndex = 6;
            // 
            // ahdelronPictureBox
            // 
            this.ahdelronPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ahdelronPictureBox.Image = global::LyricsSceneMaker_CSharp.Properties.Resources.ahdelron___while;
            this.ahdelronPictureBox.Location = new System.Drawing.Point(1052, 661);
            this.ahdelronPictureBox.Name = "ahdelronPictureBox";
            this.ahdelronPictureBox.Size = new System.Drawing.Size(225, 56);
            this.ahdelronPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ahdelronPictureBox.TabIndex = 6;
            this.ahdelronPictureBox.TabStop = false;
            // 
            // blurPictureBox
            // 
            this.blurPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.blurPictureBox.Image = global::LyricsSceneMaker_CSharp.Properties.Resources.blur_simple_black;
            this.blurPictureBox.Location = new System.Drawing.Point(0, 0);
            this.blurPictureBox.Name = "blurPictureBox";
            this.blurPictureBox.Size = new System.Drawing.Size(1280, 720);
            this.blurPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.blurPictureBox.TabIndex = 7;
            this.blurPictureBox.TabStop = false;
            this.blurPictureBox.Click += new System.EventHandler(this.blurPictureBox_Click);
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
            // scenePictureBox
            // 
            this.scenePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePictureBox.Location = new System.Drawing.Point(0, 0);
            this.scenePictureBox.Name = "scenePictureBox";
            this.scenePictureBox.Size = new System.Drawing.Size(1280, 720);
            this.scenePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.scenePictureBox.TabIndex = 3;
            this.scenePictureBox.TabStop = false;
            // 
            // LyricsScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LyricsScene";
            this.Text = "LyricsScene";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ahdelronPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label descriptorTextBox;
        private System.Windows.Forms.Label lyricsTextBox1;
        private System.Windows.Forms.Label lyricsTextBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titlebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox scenePictureBox;
        private System.Windows.Forms.PictureBox ahdelronPictureBox;
        private System.Windows.Forms.PictureBox blurPictureBox;
    }
}