﻿using LyricsSceneMaker_CSharp.model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//TODO:리스트뷰 Delimeter(,) 뒤에 효과 번호 주기, 리스트뷰 하나 추가(폼 효과만을 위한)

namespace LyricsSceneMaker_CSharp
{
    public delegate void toScene(int opcode, string data1, string data2);

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

            // 윈도우 특성상 생기는 \r 지워줌
            LyricsTextBox.Text = LyricsTextBox.Text.Replace("\n\n", "\n");

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
            this.Width = 706;
            this.Height = 593;
            
            // Song 개체 생성
            song = new Song(songNameTextBox.Text, artistTextBox.Text, selectFile.Text, lines_lyrics);
            nowSelectedIndex = 0;

            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, artistTextBox.Text + " - " + songNameTextBox.Text,
                (song.Lyrics.Length > 0) ? song.Lyrics[0] : null);

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
        
        private void LyricsControl_Load(object sender, EventArgs e)
        {
            LyricsScene scene = new LyricsScene();
            scene.Show();
        }
        
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                int size = listBox.Items.Count;
                if (song.Lyrics.Length <= size) return;

                int insertIndex = 0;
                long nowTime = audioFile.Position;
                string insertString = nowTime + "," + (int)e.KeyCode; // opcode

                if (size == 0)
                {
                    listBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (object item in listBox.Items)
                    {
                        if (long.Parse(listBox.GetItemText(item).Split(',')[0]) > nowTime)
                        {
                            listBox.Items.Insert(insertIndex, insertString);
                            isInserted = true;
                            break;
                        }
                        insertIndex++;
                    }
                    if (!isInserted) listBox.Items.Insert(size, insertString);
                }
                nowSelectedIndex = insertIndex;
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
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
            outputDevice.Pause();
            int selectedIndex = listBox.SelectedIndex;
            DialogResult dr = MessageBox.Show("선택한 지점부터 재생하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                nowSelectedIndex = selectedIndex;
                audioFile.Position = long.Parse(listBox.GetItemText(listBox.Items[nowSelectedIndex]).Split(',')[0]);
            }
            else
            {
                dr = MessageBox.Show("더블 클릭한 노트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    listBox.Items.RemoveAt(selectedIndex);
                    nowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int size = listBox.Items.Count;

            if (size == 0 || size - 1 < nowSelectedIndex || audioFile == null || outputDevice == null) return;

            if(long.Parse(listBox.GetItemText(listBox.Items[nowSelectedIndex]).Split(',')[0]) <= audioFile.Position)
            {
                
                nowSentence.Text = song.Lyrics[nowSelectedIndex];
                if (song.Lyrics.Length > nowSelectedIndex + 1) nextSentence.Text = song.Lyrics[nowSelectedIndex + 1];
                else nextSentence.Text = "null";
                listBox.SelectedIndex = nowSelectedIndex;
                toscene(int.Parse(listBox.GetItemText(listBox.Items[nowSelectedIndex]).Split(',')[1]), song.Lyrics[nowSelectedIndex],
                    (song.Lyrics.Length > ++nowSelectedIndex) ? song.Lyrics[nowSelectedIndex] : null);
            }
        }

        private void replay_Click(object sender, EventArgs e)
        {
            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, artistTextBox.Text + " - " + songNameTextBox.Text, 
                (song.Lyrics.Length > 0) ? song.Lyrics[0] : null);

            nowSelectedIndex = 0;
            
            // 노래 재생
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

            // audio file rewind
            audioFile.Position = 0;

            outputDevice.Play();
        }

        

        private void continueButton_Click(object sender, EventArgs e)
        {
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

        private void pause_Click(object sender, EventArgs e)
        {
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
            outputDevice.Pause();
        }

        // loadButton 클립보드 작동 안함
        private void loadButton_Click(object sender, EventArgs e)
        {
            string clipboard_data = Clipboard.GetText();
            if (!clipboard_data.Contains("|")) return;
            clipboard_data.Replace("||", "|");

            DialogResult dr;
            if (listBox.Items.Count != 0)
            {
                dr = MessageBox.Show("정말로 진행하시던 것을 삭제하고 새로운 노트 정보를 덮어씌우시겠습니까?", "Question",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    replay_Click(this, e);
                    listBox.Items.Clear();
                    string[] note_datas = clipboard_data.Split('|');
                    foreach(string note_line in note_datas)
                    {
                        if (!note_line.Equals(""))
                            listBox.Items.Add(note_line);
                    }
                }
            }
                
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(object item in listBox.Items)
            {
                string line_data = listBox.GetItemText(item) + "|";
                sb.Append(line_data);
            }
            Clipboard.SetText(sb.ToString());
            MessageBox.Show("클립보드에 노트 데이터를 복사했습니다.\r\n" +
                "Ctrl+V를 통해 원하는 곳에 저장하세요!", "Must Do It", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
