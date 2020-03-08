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
            this.LyricsTextBox = new System.Windows.Forms.TextBox();
            this.initializeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nextSentence = new System.Windows.Forms.Label();
            this.previousSentence = new System.Windows.Forms.Label();
            this.nowSentence = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.noteInformationLabel = new System.Windows.Forms.Label();
            this.selectFile = new System.Windows.Forms.Button();
            this.replay = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "노래 제목 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "아티스트 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "음악 파일 선택 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(10, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
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
            // LyricsTextBox
            // 
            this.LyricsTextBox.Location = new System.Drawing.Point(65, 102);
            this.LyricsTextBox.Multiline = true;
            this.LyricsTextBox.Name = "LyricsTextBox";
            this.LyricsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LyricsTextBox.Size = new System.Drawing.Size(297, 395);
            this.LyricsTextBox.TabIndex = 3;
            // 
            // initializeButton
            // 
            this.initializeButton.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label7.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(392, 163);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(468, 334);
            this.listBox.TabIndex = 17;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(389, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Notes:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(399, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "←, → : 싱크 이동, ↑, ↓ : 이동, SPACE : 선택한 지점 재생\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(391, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Note Information:";
            // 
            // noteInformationLabel
            // 
            this.noteInformationLabel.AutoSize = true;
            this.noteInformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.noteInformationLabel.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.noteInformationLabel.Location = new System.Drawing.Point(532, 105);
            this.noteInformationLabel.Name = "noteInformationLabel";
            this.noteInformationLabel.Size = new System.Drawing.Size(29, 15);
            this.noteInformationLabel.TabIndex = 21;
            this.noteInformationLabel.Text = "null";
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(136, 73);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(226, 23);
            this.selectFile.TabIndex = 22;
            this.selectFile.Text = "select file";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // replay
            // 
            this.replay.Location = new System.Drawing.Point(451, 137);
            this.replay.Name = "replay";
            this.replay.Size = new System.Drawing.Size(75, 23);
            this.replay.TabIndex = 23;
            this.replay.Text = "replay";
            this.replay.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(535, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LyricsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 546);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.replay);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.noteInformationLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.nextSentence);
            this.Controls.Add(this.previousSentence);
            this.Controls.Add(this.nowSentence);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.LyricsTextBox);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.songNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LyricsControl";
            this.Text = "LyricsControl";
            this.Load += new System.EventHandler(this.LyricsControl_Load);
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
        private System.Windows.Forms.TextBox LyricsTextBox;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nextSentence;
        private System.Windows.Forms.Label previousSentence;
        private System.Windows.Forms.Label nowSentence;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label noteInformationLabel;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Button replay;
        private System.Windows.Forms.Button button2;
    }
}