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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.songNameTextBox = new System.Windows.Forms.TextBox();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.youtubeURLTextBox = new System.Windows.Forms.TextBox();
            this.LyricsTextBox = new System.Windows.Forms.TextBox();
            this.initializeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nextSentence = new System.Windows.Forms.Label();
            this.previousSentence = new System.Windows.Forms.Label();
            this.nowSentence = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "노래 제목 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "아티스트 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "유튜브 URL : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "가사 : ";
            // 
            // songNameTextBox
            // 
            this.songNameTextBox.Location = new System.Drawing.Point(97, 41);
            this.songNameTextBox.Name = "songNameTextBox";
            this.songNameTextBox.Size = new System.Drawing.Size(265, 25);
            this.songNameTextBox.TabIndex = 1;
            // 
            // artistTextBox
            // 
            this.artistTextBox.Location = new System.Drawing.Point(92, 11);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(269, 25);
            this.artistTextBox.TabIndex = 0;
            // 
            // youtubeURLTextBox
            // 
            this.youtubeURLTextBox.Location = new System.Drawing.Point(111, 71);
            this.youtubeURLTextBox.Name = "youtubeURLTextBox";
            this.youtubeURLTextBox.Size = new System.Drawing.Size(251, 25);
            this.youtubeURLTextBox.TabIndex = 2;
            // 
            // LyricsTextBox
            // 
            this.LyricsTextBox.Location = new System.Drawing.Point(70, 102);
            this.LyricsTextBox.Multiline = true;
            this.LyricsTextBox.Name = "LyricsTextBox";
            this.LyricsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LyricsTextBox.Size = new System.Drawing.Size(292, 395);
            this.LyricsTextBox.TabIndex = 3;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(391, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Now :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(391, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Previous :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(391, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Next :";
            // 
            // nextSentence
            // 
            this.nextSentence.AutoSize = true;
            this.nextSentence.BackColor = System.Drawing.Color.Transparent;
            this.nextSentence.Location = new System.Drawing.Point(444, 76);
            this.nextSentence.Name = "nextSentence";
            this.nextSentence.Size = new System.Drawing.Size(29, 15);
            this.nextSentence.TabIndex = 16;
            this.nextSentence.Text = "null";
            // 
            // previousSentence
            // 
            this.previousSentence.AutoSize = true;
            this.previousSentence.BackColor = System.Drawing.Color.Transparent;
            this.previousSentence.Location = new System.Drawing.Point(472, 16);
            this.previousSentence.Name = "previousSentence";
            this.previousSentence.Size = new System.Drawing.Size(29, 15);
            this.previousSentence.TabIndex = 15;
            this.previousSentence.Text = "null";
            // 
            // nowSentence
            // 
            this.nowSentence.AutoSize = true;
            this.nowSentence.BackColor = System.Drawing.Color.Transparent;
            this.nowSentence.Location = new System.Drawing.Point(442, 45);
            this.nowSentence.Name = "nowSentence";
            this.nowSentence.Size = new System.Drawing.Size(29, 15);
            this.nowSentence.TabIndex = 14;
            this.nowSentence.Text = "null";
            // 
            // LyricsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 544);
            this.Controls.Add(this.nextSentence);
            this.Controls.Add(this.previousSentence);
            this.Controls.Add(this.nowSentence);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.LyricsTextBox);
            this.Controls.Add(this.youtubeURLTextBox);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.songNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LyricsControl";
            this.Text = "LyricsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox songNameTextBox;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.TextBox youtubeURLTextBox;
        private System.Windows.Forms.TextBox LyricsTextBox;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nextSentence;
        private System.Windows.Forms.Label previousSentence;
        private System.Windows.Forms.Label nowSentence;
    }
}