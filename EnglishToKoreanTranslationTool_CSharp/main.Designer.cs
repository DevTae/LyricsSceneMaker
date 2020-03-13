namespace EnglishToKoreanTranslationTool_CSharp
{
    partial class main
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadLyricsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.getTranlatedLyricsButton = new System.Windows.Forms.Button();
            this.saveLyricsButton = new System.Windows.Forms.Button();
            this.initializeButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 380);
            this.textBox1.TabIndex = 0;
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
            // loadLyricsButton
            // 
            this.loadLyricsButton.Location = new System.Drawing.Point(12, 342);
            this.loadLyricsButton.Name = "loadLyricsButton";
            this.loadLyricsButton.Size = new System.Drawing.Size(48, 22);
            this.loadLyricsButton.TabIndex = 2;
            this.loadLyricsButton.Text = "load";
            this.loadLyricsButton.UseVisualStyleBackColor = true;
            this.loadLyricsButton.Click += new System.EventHandler(this.loadLyricsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "번역 진행 중 파일 :";
            // 
            // getTranlatedLyricsButton
            // 
            this.getTranlatedLyricsButton.Location = new System.Drawing.Point(153, 402);
            this.getTranlatedLyricsButton.Name = "getTranlatedLyricsButton";
            this.getTranlatedLyricsButton.Size = new System.Drawing.Size(208, 22);
            this.getTranlatedLyricsButton.TabIndex = 4;
            this.getTranlatedLyricsButton.Text = "select file";
            this.getTranlatedLyricsButton.UseVisualStyleBackColor = true;
            this.getTranlatedLyricsButton.Click += new System.EventHandler(this.getTranlatedLyricsButton_Click);
            // 
            // saveLyricsButton
            // 
            this.saveLyricsButton.Location = new System.Drawing.Point(12, 370);
            this.saveLyricsButton.Name = "saveLyricsButton";
            this.saveLyricsButton.Size = new System.Drawing.Size(48, 22);
            this.saveLyricsButton.TabIndex = 5;
            this.saveLyricsButton.Text = "save";
            this.saveLyricsButton.UseVisualStyleBackColor = true;
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(12, 438);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(349, 22);
            this.initializeButton.TabIndex = 6;
            this.initializeButton.Text = "Initialize !";
            this.initializeButton.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(784, 44);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(367, 25);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(784, 121);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(367, 25);
            this.textBox4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(954, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "↓";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(731, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "영어 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(731, 131);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 22);
            this.button1.TabIndex = 14;
            this.button1.Text = "중도저장";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(349, 22);
            this.button2.TabIndex = 15;
            this.button2.Text = "병합";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(784, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(349, 22);
            this.button3.TabIndex = 16;
            this.button3.Text = "다음 문장 가져와";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(428, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(297, 379);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 472);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.saveLyricsButton);
            this.Controls.Add(this.getTranlatedLyricsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadLyricsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "main";
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadLyricsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getTranlatedLyricsButton;
        private System.Windows.Forms.Button saveLyricsButton;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
    }
}