namespace LyricsSceneMaker_CSharp
{
    partial class LyricsControl
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
            this.searchSongTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.songNameTextBox = new System.Windows.Forms.TextBox();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.youtubeLinkTextBox = new System.Windows.Forms.TextBox();
            this.LyricsTextBox = new System.Windows.Forms.TextBox();
            this.initializeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchSongTextBox
            // 
            this.searchSongTextBox.Enabled = false;
            this.searchSongTextBox.Location = new System.Drawing.Point(528, 37);
            this.searchSongTextBox.Name = "searchSongTextBox";
            this.searchSongTextBox.Size = new System.Drawing.Size(303, 25);
            this.searchSongTextBox.TabIndex = 1;
            this.searchSongTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchSongTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "노래 제목 : ";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(488, 77);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(386, 411);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "아티스트 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "유튜브 링크 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "가사 : ";
            // 
            // songNameTextBox
            // 
            this.songNameTextBox.Location = new System.Drawing.Point(97, 11);
            this.songNameTextBox.Name = "songNameTextBox";
            this.songNameTextBox.Size = new System.Drawing.Size(265, 25);
            this.songNameTextBox.TabIndex = 0;
            // 
            // artistTextBox
            // 
            this.artistTextBox.Location = new System.Drawing.Point(93, 41);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(269, 25);
            this.artistTextBox.TabIndex = 7;
            // 
            // youtubeLinkTextBox
            // 
            this.youtubeLinkTextBox.Location = new System.Drawing.Point(111, 71);
            this.youtubeLinkTextBox.Name = "youtubeLinkTextBox";
            this.youtubeLinkTextBox.Size = new System.Drawing.Size(251, 25);
            this.youtubeLinkTextBox.TabIndex = 8;
            // 
            // LyricsTextBox
            // 
            this.LyricsTextBox.Location = new System.Drawing.Point(70, 102);
            this.LyricsTextBox.Multiline = true;
            this.LyricsTextBox.Name = "LyricsTextBox";
            this.LyricsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LyricsTextBox.Size = new System.Drawing.Size(292, 395);
            this.LyricsTextBox.TabIndex = 9;
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(12, 503);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(350, 32);
            this.initializeButton.TabIndex = 10;
            this.initializeButton.Text = "Initialize !";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(378, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(292, 395);
            this.textBox1.TabIndex = 11;
            // 
            // LyricsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 544);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.LyricsTextBox);
            this.Controls.Add(this.youtubeLinkTextBox);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.songNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.searchSongTextBox);
            this.Controls.Add(this.label1);
            this.Name = "LyricsControl";
            this.Text = "LyricsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchSongTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox songNameTextBox;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.TextBox youtubeLinkTextBox;
        private System.Windows.Forms.TextBox LyricsTextBox;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}