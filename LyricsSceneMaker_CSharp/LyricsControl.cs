using LyricsSceneMaker_CSharp.model;
using NAudio.Wave;
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

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Song song;
        private int nowSelectedIndex = 0;

        public LyricsControl()
        {
            InitializeComponent();
            this.Width = 393;
            this.Height = 593;
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "음악 파일 (*.mp3)|*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectFile.Text = ofd.FileName;
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
            toscene(0, artistTextBox.Text + " - " + songNameTextBox.Text);

            // 가사 입력된 것을 string[] 배열에 저장해준다.
            string[] lines_lyrics = LyricsTextBox.Text.Split('\n');

            // 모드 변환 (곡 정보 입력 창 -> 가사 싱크 맞추는 폼)
            //Thread newThread = new Thread(() =>
            //{
            //    Control.ControlCollection controls = this.Controls;

            //    foreach (Control control in controls)
            //    {
            //        control.Left -= 380;
            //    }
            //}); newThread.Start();
            //this.Width += 100;
            //this.Height += 100;
            artistTextBox.Enabled = false;
            songNameTextBox.Enabled = false;
            selectFile.Enabled = false;
            LyricsTextBox.ReadOnly = true;
            initializeButton.Enabled = false;
            this.Width = 900;
            this.Height = 593;

            // Song 개체 생성
            song = new Song(songNameTextBox.Text, artistTextBox.Text, selectFile.Text, lines_lyrics);

            // 첫 가사 전송 시켜 놓기
            toscene(1, lines_lyrics[nowSelectedIndex++]);

            // 노래 재생하기
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(selectFile.Text);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LyricsControl_Load(object sender, EventArgs e)
        {
            LyricsScene scene = new LyricsScene();
            scene.Show();
        }

        int i = 0;
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toscene(1, "데이터 갑니다잉 " + i++);
                listBox.Items.Add(audioFile.Position);
            }
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //if(audioFile.Position > )
        }

        private void replay_Click(object sender, EventArgs e)
        {
            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, artistTextBox.Text + " - " + songNameTextBox.Text);

            // 첫 가사 전송 시켜 놓기
            nowSelectedIndex = 0;
            toscene(1, song.Lyrics[nowSelectedIndex++]);
            
            // audio file rewind
            audioFile.Position = 0;
        }


        //noteInformationLabel = remained = 53 / done = 32
    }
}
