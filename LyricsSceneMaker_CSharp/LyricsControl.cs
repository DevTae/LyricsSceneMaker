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
    public delegate void toScene(int opcode, string data, string data2);

    public partial class LyricsControl : Form
    {
        public static event toScene toscene;

        private Song song;

        public LyricsControl()
        {
            InitializeComponent();
            this.Width = 393;
            this.Height = 591;
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "음악 파일 (*.mp3)|*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectFile.Text = ofd.FileName;
                selectFile.Enabled = false;
            }
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            // 정보 미기입 시 진행 불가능
            if (songNameTextBox.Text.Equals("") || artistTextBox.Text.Equals("")
                || selectFile.Text.Equals("select file") || LyricsTextBox.Text.Equals(""))
            {
                MessageBox.Show("곡에 대한 정보가 부족합니다.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, artistTextBox.Text + " - " + songNameTextBox.Text, null);

            // 가사 입력된 것을 string[] 배열에 저장해준다.
            string[] lines_lyrics = LyricsTextBox.Text.Split('\n');

            // 음악 다운로드 쓰레드로 완료된 것 알려주기

            // 모드 변환 (곡 정보 입력 창 -> 가사 싱크 맞추는 폼)
            Thread newThread = new Thread(() =>
            {
                Control.ControlCollection controls = this.Controls;

                foreach (Control control in controls)
                {
                    control.Left -= 380;
                }
            }); newThread.Start();
            this.Width += 100;
            this.Height += 100;
        }

        private void LyricsControl_Load(object sender, EventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        //noteInformationLabel = remained = 53 / done = 32
    }
}
