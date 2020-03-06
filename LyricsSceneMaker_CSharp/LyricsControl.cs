using LyricsSceneMaker_CSharp.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LyricsSceneMaker_CSharp
{
    public delegate void toScene(int opcode, string data);

    public partial class LyricsControl : Form
    {
        public static event toScene toscene;

        public LyricsControl()
        {
            InitializeComponent();
        }
        
        // 가사 검색 이벤트
        private void searchSongTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Thread thread = new Thread(() => 
                    webBrowser.Navigate("https://search.naver.com/search.naver?sm=tab_hty.top&where=nexearch&query=" + searchSongTextBox.Text + " 가사")
                );
                thread.Start();

                // searchSongTextBox 텍스트를 바탕으로 자료 검색 시도
            }
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            //Song newSong = new Song();
            string[] lines_lyrics = LyricsTextBox.Text.Split('\n');
            Thread thread = new Thread(() =>
            {
                int i = 0;
                foreach (string line in lines_lyrics)
                {
                    textBox1.Text += "[" + i++ + "] " + line + "\n";
                    //Thread.Sleep(50);
                }
            });
            thread.Start();
        }
    }
}
