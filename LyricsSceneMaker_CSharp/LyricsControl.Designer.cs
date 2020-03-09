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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.songNameTextBox = new System.Windows.Forms.TextBox();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.LyricsTextBox = new System.Windows.Forms.TextBox();
            this.initializeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nextSentence = new System.Windows.Forms.Label();
            this.nowSentence = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.selectFile = new System.Windows.Forms.Button();
            this.replay = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pause = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.notesLoadButton = new System.Windows.Forms.Button();
            this.notesSaveButton = new System.Windows.Forms.Button();
            this.lyricsLoadButton = new System.Windows.Forms.Button();
            this.lyricsSaveButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.noteInformation = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.effectButton1 = new System.Windows.Forms.Button();
            this.effectButton2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.effectListBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.effectsSaveButton = new System.Windows.Forms.Button();
            this.effectsLoadButton = new System.Windows.Forms.Button();
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
            this.label5.Location = new System.Drawing.Point(399, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Now :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(399, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Next :";
            // 
            // nextSentence
            // 
            this.nextSentence.AutoSize = true;
            this.nextSentence.BackColor = System.Drawing.Color.Transparent;
            this.nextSentence.Location = new System.Drawing.Point(452, 38);
            this.nextSentence.Name = "nextSentence";
            this.nextSentence.Size = new System.Drawing.Size(29, 15);
            this.nextSentence.TabIndex = 16;
            this.nextSentence.Text = "null";
            // 
            // nowSentence
            // 
            this.nowSentence.AutoSize = true;
            this.nowSentence.BackColor = System.Drawing.Color.Transparent;
            this.nowSentence.Location = new System.Drawing.Point(451, 12);
            this.nowSentence.Name = "nowSentence";
            this.nowSentence.Size = new System.Drawing.Size(29, 15);
            this.nowSentence.TabIndex = 14;
            this.nowSentence.Text = "null";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(399, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Notes:";
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
            this.replay.Location = new System.Drawing.Point(589, 87);
            this.replay.Name = "replay";
            this.replay.Size = new System.Drawing.Size(43, 28);
            this.replay.TabIndex = 23;
            this.replay.Text = "◀";
            this.replay.UseVisualStyleBackColor = true;
            this.replay.Click += new System.EventHandler(this.replay_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(638, 87);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(43, 28);
            this.pause.TabIndex = 24;
            this.pause.Text = "〓";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(687, 87);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(43, 28);
            this.continueButton.TabIndex = 25;
            this.continueButton.Text = "▶";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // notesLoadButton
            // 
            this.notesLoadButton.Location = new System.Drawing.Point(583, 296);
            this.notesLoadButton.Name = "notesLoadButton";
            this.notesLoadButton.Size = new System.Drawing.Size(164, 31);
            this.notesLoadButton.TabIndex = 26;
            this.notesLoadButton.Text = "불러오기";
            this.notesLoadButton.UseVisualStyleBackColor = true;
            this.notesLoadButton.Click += new System.EventHandler(this.notesLoadButton_Click);
            // 
            // notesSaveButton
            // 
            this.notesSaveButton.Location = new System.Drawing.Point(402, 296);
            this.notesSaveButton.Name = "notesSaveButton";
            this.notesSaveButton.Size = new System.Drawing.Size(170, 31);
            this.notesSaveButton.TabIndex = 27;
            this.notesSaveButton.Text = "저장";
            this.notesSaveButton.UseVisualStyleBackColor = true;
            this.notesSaveButton.Click += new System.EventHandler(this.notesSaveButton_Click);
            // 
            // lyricsLoadButton
            // 
            this.lyricsLoadButton.Location = new System.Drawing.Point(13, 445);
            this.lyricsLoadButton.Name = "lyricsLoadButton";
            this.lyricsLoadButton.Size = new System.Drawing.Size(48, 23);
            this.lyricsLoadButton.TabIndex = 28;
            this.lyricsLoadButton.Text = "load";
            this.lyricsLoadButton.UseVisualStyleBackColor = true;
            this.lyricsLoadButton.Click += new System.EventHandler(this.lyricsLoadButton_Click);
            // 
            // lyricsSaveButton
            // 
            this.lyricsSaveButton.Enabled = false;
            this.lyricsSaveButton.Location = new System.Drawing.Point(11, 474);
            this.lyricsSaveButton.Name = "lyricsSaveButton";
            this.lyricsSaveButton.Size = new System.Drawing.Size(50, 23);
            this.lyricsSaveButton.TabIndex = 29;
            this.lyricsSaveButton.Text = "save";
            this.lyricsSaveButton.UseVisualStyleBackColor = true;
            this.lyricsSaveButton.Click += new System.EventHandler(this.lyricsSaveButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(402, 121);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(247, 169);
            this.listBox.TabIndex = 30;
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(399, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Note :";
            // 
            // noteInformation
            // 
            this.noteInformation.AutoSize = true;
            this.noteInformation.Location = new System.Drawing.Point(453, 65);
            this.noteInformation.Name = "noteInformation";
            this.noteInformation.Size = new System.Drawing.Size(29, 15);
            this.noteInformation.TabIndex = 32;
            this.noteInformation.Text = "null";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(459, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "(스크롤 금지!)";
            // 
            // effectButton1
            // 
            this.effectButton1.Location = new System.Drawing.Point(663, 126);
            this.effectButton1.Name = "effectButton1";
            this.effectButton1.Size = new System.Drawing.Size(84, 28);
            this.effectButton1.TabIndex = 34;
            this.effectButton1.Text = "기본 효과";
            this.effectButton1.UseVisualStyleBackColor = true;
            this.effectButton1.Click += new System.EventHandler(this.effectButton1_Click);
            // 
            // effectButton2
            // 
            this.effectButton2.Location = new System.Drawing.Point(663, 160);
            this.effectButton2.Name = "effectButton2";
            this.effectButton2.Size = new System.Drawing.Size(84, 57);
            this.effectButton2.TabIndex = 35;
            this.effectButton2.Text = "기본 효과(space)";
            this.effectButton2.UseVisualStyleBackColor = true;
            this.effectButton2.Click += new System.EventHandler(this.effectButton2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(512, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 15);
            this.label10.TabIndex = 38;
            this.label10.Text = "(스크롤 금지!)";
            // 
            // effectListBox
            // 
            this.effectListBox.FormattingEnabled = true;
            this.effectListBox.ItemHeight = 15;
            this.effectListBox.Location = new System.Drawing.Point(402, 367);
            this.effectListBox.Name = "effectListBox";
            this.effectListBox.Size = new System.Drawing.Size(247, 124);
            this.effectListBox.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(399, 346);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 15);
            this.label11.TabIndex = 36;
            this.label11.Text = "Form Effects:";
            // 
            // effectsSaveButton
            // 
            this.effectsSaveButton.Location = new System.Drawing.Point(402, 503);
            this.effectsSaveButton.Name = "effectsSaveButton";
            this.effectsSaveButton.Size = new System.Drawing.Size(170, 31);
            this.effectsSaveButton.TabIndex = 40;
            this.effectsSaveButton.Text = "저장";
            this.effectsSaveButton.UseVisualStyleBackColor = true;
            this.effectsSaveButton.Click += new System.EventHandler(this.effectsSaveButton_Click);
            // 
            // effectsLoadButton
            // 
            this.effectsLoadButton.Location = new System.Drawing.Point(583, 503);
            this.effectsLoadButton.Name = "effectsLoadButton";
            this.effectsLoadButton.Size = new System.Drawing.Size(164, 31);
            this.effectsLoadButton.TabIndex = 39;
            this.effectsLoadButton.Text = "불러오기";
            this.effectsLoadButton.UseVisualStyleBackColor = true;
            this.effectsLoadButton.Click += new System.EventHandler(this.effectsLoadButton_Click);
            // 
            // LyricsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 546);
            this.Controls.Add(this.effectsSaveButton);
            this.Controls.Add(this.effectsLoadButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.effectListBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.effectButton2);
            this.Controls.Add(this.effectButton1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.noteInformation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.lyricsSaveButton);
            this.Controls.Add(this.lyricsLoadButton);
            this.Controls.Add(this.notesSaveButton);
            this.Controls.Add(this.notesLoadButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.replay);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nextSentence);
            this.Controls.Add(this.nowSentence);
            this.Controls.Add(this.label7);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nextSentence;
        private System.Windows.Forms.Label nowSentence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Button replay;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button notesLoadButton;
        private System.Windows.Forms.Button notesSaveButton;
        private System.Windows.Forms.Button lyricsLoadButton;
        private System.Windows.Forms.Button lyricsSaveButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label noteInformation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button effectButton1;
        private System.Windows.Forms.Button effectButton2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox effectListBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button effectsSaveButton;
        private System.Windows.Forms.Button effectsLoadButton;
    }
}