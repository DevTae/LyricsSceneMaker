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
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptorTextBox
            // 
            this.descriptorTextBox.AutoSize = true;
            this.descriptorTextBox.Font = new System.Drawing.Font("BM DoHyeon", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.descriptorTextBox.Location = new System.Drawing.Point(144, 351);
            this.descriptorTextBox.Name = "descriptorTextBox";
            this.descriptorTextBox.Size = new System.Drawing.Size(120, 23);
            this.descriptorTextBox.TabIndex = 0;
            this.descriptorTextBox.Text = "descriptor";
            // 
            // albumPictureBox
            // 
            this.albumPictureBox.Location = new System.Drawing.Point(96, 125);
            this.albumPictureBox.Name = "albumPictureBox";
            this.albumPictureBox.Size = new System.Drawing.Size(218, 213);
            this.albumPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.albumPictureBox.TabIndex = 1;
            this.albumPictureBox.TabStop = false;
            this.albumPictureBox.Click += new System.EventHandler(this.albumPictureBox_Click);
            // 
            // lyricsTextBox1
            // 
            this.lyricsTextBox1.Font = new System.Drawing.Font("Gmarket Sans TTF Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox1.Location = new System.Drawing.Point(414, 125);
            this.lyricsTextBox1.Name = "lyricsTextBox1";
            this.lyricsTextBox1.Size = new System.Drawing.Size(333, 106);
            this.lyricsTextBox1.TabIndex = 2;
            this.lyricsTextBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lyricsTextBox2
            // 
            this.lyricsTextBox2.Font = new System.Drawing.Font("Gmarket Sans TTF Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lyricsTextBox2.Location = new System.Drawing.Point(424, 266);
            this.lyricsTextBox2.Name = "lyricsTextBox2";
            this.lyricsTextBox2.Size = new System.Drawing.Size(323, 108);
            this.lyricsTextBox2.TabIndex = 3;
            this.lyricsTextBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.titlebar);
            this.panel1.Controls.Add(this.lyricsTextBox2);
            this.panel1.Controls.Add(this.lyricsTextBox1);
            this.panel1.Controls.Add(this.descriptorTextBox);
            this.panel1.Controls.Add(this.albumPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 472);
            this.panel1.TabIndex = 4;
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.Linen;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(812, 68);
            this.titlebar.TabIndex = 5;
            this.titlebar.Text = "titlebar";
            this.titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.titlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
            this.titlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseUp);
            // 
            // LyricsScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 472);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LyricsScene";
            this.Text = "LyricsScene";
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label descriptorTextBox;
        private System.Windows.Forms.PictureBox albumPictureBox;
        private System.Windows.Forms.Label lyricsTextBox1;
        private System.Windows.Forms.Label lyricsTextBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titlebar;
    }
}