using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnglishToKoreanTranslationTool_CSharp
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void loadLyricsButton_Click(object sender, EventArgs e)
        {

        }

        private void getTranlatedLyricsButton_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //// 공백 줄바꿈 \r\n 지워줌
        //    while(LyricsTextBox.Text.Contains("\r\n\r\n"))
        //        LyricsTextBox.Text = LyricsTextBox.Text.Replace("\r\n\r\n", "\r\n");

        //    // 마지막줄의 줄바꿈 지워줌 (필수)
        //    int length = LyricsTextBox.Text.Length;
        //    if (LyricsTextBox.Text.Substring(length - 2, 2).Equals("\r\n"))
        //        LyricsTextBox.Text = LyricsTextBox.Text.Substring(0, length - 2);

        //    // 가사 입력된 것을 string[] 배열에 저장해준다.
        //    string[] lines_lyrics = LyricsTextBox.Text.Split('\n');
    }
}
