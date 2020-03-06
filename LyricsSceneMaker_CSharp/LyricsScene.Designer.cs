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
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptorTextBox
            // 
            this.descriptorTextBox.AutoSize = true;
            this.descriptorTextBox.Location = new System.Drawing.Point(131, 318);
            this.descriptorTextBox.Name = "descriptorTextBox";
            this.descriptorTextBox.Size = new System.Drawing.Size(71, 15);
            this.descriptorTextBox.TabIndex = 0;
            this.descriptorTextBox.Text = "descriptor";
            // 
            // albumPictureBox
            // 
            this.albumPictureBox.Location = new System.Drawing.Point(58, 86);
            this.albumPictureBox.Name = "albumPictureBox";
            this.albumPictureBox.Size = new System.Drawing.Size(218, 213);
            this.albumPictureBox.TabIndex = 1;
            this.albumPictureBox.TabStop = false;
            // 
            // lyricsTextBox1
            // 
            this.lyricsTextBox1.Font = new System.Drawing.Font("배달의민족 도현", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox1.Location = new System.Drawing.Point(433, 189);
            this.lyricsTextBox1.Name = "lyricsTextBox1";
            this.lyricsTextBox1.Size = new System.Drawing.Size(249, 58);
            this.lyricsTextBox1.TabIndex = 2;
            this.lyricsTextBox1.Text = "label1";
            this.lyricsTextBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lyricsTextBox2
            // 
            this.lyricsTextBox2.Font = new System.Drawing.Font("배달의민족 도현", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lyricsTextBox2.Location = new System.Drawing.Point(434, 284);
            this.lyricsTextBox2.Name = "lyricsTextBox2";
            this.lyricsTextBox2.Size = new System.Drawing.Size(248, 49);
            this.lyricsTextBox2.TabIndex = 3;
            this.lyricsTextBox2.Text = "label1";
            this.lyricsTextBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LyricsScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 472);
            this.Controls.Add(this.lyricsTextBox2);
            this.Controls.Add(this.lyricsTextBox1);
            this.Controls.Add(this.albumPictureBox);
            this.Controls.Add(this.descriptorTextBox);
            this.Name = "LyricsScene";
            this.Text = "LyricsScene";
            this.Load += new System.EventHandler(this.LyricsScene_Load);
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptorTextBox;
        private System.Windows.Forms.PictureBox albumPictureBox;
        private System.Windows.Forms.Label lyricsTextBox1;
        private System.Windows.Forms.Label lyricsTextBox2;
    }
}