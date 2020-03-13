namespace EnglishToKoreanTranslationTool_CSharp
{
    partial class Main
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
            this.englishLyricsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadEnglishLyrics = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loadKoreanLyrics = new System.Windows.Forms.Button();
            this.saveEnglishLyrics = new System.Windows.Forms.Button();
            this.startTraslation = new System.Windows.Forms.Button();
            this.englishLyrics = new System.Windows.Forms.TextBox();
            this.koreanLyrics = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveKoreanLyrics = new System.Windows.Forms.Button();
            this.mergeLyrics = new System.Windows.Forms.Button();
            this.getNextSentence = new System.Windows.Forms.Button();
            this.koreanLyricsListbox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // englishLyricsTextBox
            // 
            this.englishLyricsTextBox.Location = new System.Drawing.Point(65, 12);
            this.englishLyricsTextBox.Multiline = true;
            this.englishLyricsTextBox.Name = "englishLyricsTextBox";
            this.englishLyricsTextBox.Size = new System.Drawing.Size(297, 409);
            this.englishLyricsTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "영어 :";
            // 
            // loadEnglishLyrics
            // 
            this.loadEnglishLyrics.Location = new System.Drawing.Point(12, 371);
            this.loadEnglishLyrics.Name = "loadEnglishLyrics";
            this.loadEnglishLyrics.Size = new System.Drawing.Size(48, 22);
            this.loadEnglishLyrics.TabIndex = 2;
            this.loadEnglishLyrics.Text = "load";
            this.loadEnglishLyrics.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "번역 진행 중 파일 :";
            // 
            // loadKoreanLyrics
            // 
            this.loadKoreanLyrics.Location = new System.Drawing.Point(517, 402);
            this.loadKoreanLyrics.Name = "loadKoreanLyrics";
            this.loadKoreanLyrics.Size = new System.Drawing.Size(208, 22);
            this.loadKoreanLyrics.TabIndex = 4;
            this.loadKoreanLyrics.Text = "select file";
            this.loadKoreanLyrics.UseVisualStyleBackColor = true;
            // 
            // saveEnglishLyrics
            // 
            this.saveEnglishLyrics.Location = new System.Drawing.Point(11, 399);
            this.saveEnglishLyrics.Name = "saveEnglishLyrics";
            this.saveEnglishLyrics.Size = new System.Drawing.Size(48, 22);
            this.saveEnglishLyrics.TabIndex = 5;
            this.saveEnglishLyrics.Text = "save";
            this.saveEnglishLyrics.UseVisualStyleBackColor = true;
            // 
            // startTraslation
            // 
            this.startTraslation.Location = new System.Drawing.Point(12, 438);
            this.startTraslation.Name = "startTraslation";
            this.startTraslation.Size = new System.Drawing.Size(349, 22);
            this.startTraslation.TabIndex = 6;
            this.startTraslation.Text = "start translation !";
            this.startTraslation.UseVisualStyleBackColor = true;
            // 
            // englishLyrics
            // 
            this.englishLyrics.Location = new System.Drawing.Point(803, 15);
            this.englishLyrics.Multiline = true;
            this.englishLyrics.Name = "englishLyrics";
            this.englishLyrics.Size = new System.Drawing.Size(367, 58);
            this.englishLyrics.TabIndex = 8;
            // 
            // koreanLyrics
            // 
            this.koreanLyrics.Location = new System.Drawing.Point(803, 94);
            this.koreanLyrics.Multiline = true;
            this.koreanLyrics.Name = "koreanLyrics";
            this.koreanLyrics.Size = new System.Drawing.Size(367, 53);
            this.koreanLyrics.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(973, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "↓";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(750, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "영어 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(750, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "한글 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "한글 :";
            // 
            // saveKoreanLyrics
            // 
            this.saveKoreanLyrics.Location = new System.Drawing.Point(378, 438);
            this.saveKoreanLyrics.Name = "saveKoreanLyrics";
            this.saveKoreanLyrics.Size = new System.Drawing.Size(349, 22);
            this.saveKoreanLyrics.TabIndex = 14;
            this.saveKoreanLyrics.Text = "임시저장";
            this.saveKoreanLyrics.UseVisualStyleBackColor = true;
            // 
            // mergeLyrics
            // 
            this.mergeLyrics.Location = new System.Drawing.Point(803, 438);
            this.mergeLyrics.Name = "mergeLyrics";
            this.mergeLyrics.Size = new System.Drawing.Size(367, 22);
            this.mergeLyrics.TabIndex = 15;
            this.mergeLyrics.Text = "한영 가사 병합";
            this.mergeLyrics.UseVisualStyleBackColor = true;
            // 
            // getNextSentence
            // 
            this.getNextSentence.Location = new System.Drawing.Point(803, 163);
            this.getNextSentence.Name = "getNextSentence";
            this.getNextSentence.Size = new System.Drawing.Size(367, 34);
            this.getNextSentence.TabIndex = 16;
            this.getNextSentence.Text = "다음 문장 가져와줄래?";
            this.getNextSentence.UseVisualStyleBackColor = true;
            // 
            // koreanLyricsListbox
            // 
            this.koreanLyricsListbox.FormattingEnabled = true;
            this.koreanLyricsListbox.ItemHeight = 15;
            this.koreanLyricsListbox.Location = new System.Drawing.Point(428, 15);
            this.koreanLyricsListbox.Name = "koreanLyricsListbox";
            this.koreanLyricsListbox.Size = new System.Drawing.Size(297, 379);
            this.koreanLyricsListbox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(856, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "이곳에 번역에 도움되는 자료 나열해";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 472);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.koreanLyricsListbox);
            this.Controls.Add(this.getNextSentence);
            this.Controls.Add(this.mergeLyrics);
            this.Controls.Add(this.saveKoreanLyrics);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.koreanLyrics);
            this.Controls.Add(this.englishLyrics);
            this.Controls.Add(this.startTraslation);
            this.Controls.Add(this.saveEnglishLyrics);
            this.Controls.Add(this.loadKoreanLyrics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadEnglishLyrics);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.englishLyricsTextBox);
            this.Name = "Main";
            this.Text = "EnglishToKoreanTranslationTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox englishLyricsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadEnglishLyrics;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadKoreanLyrics;
        private System.Windows.Forms.Button saveEnglishLyrics;
        private System.Windows.Forms.Button startTraslation;
        private System.Windows.Forms.TextBox englishLyrics;
        private System.Windows.Forms.TextBox koreanLyrics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveKoreanLyrics;
        private System.Windows.Forms.Button mergeLyrics;
        private System.Windows.Forms.Button getNextSentence;
        private System.Windows.Forms.ListBox koreanLyricsListbox;
        private System.Windows.Forms.Label label7;
    }
}