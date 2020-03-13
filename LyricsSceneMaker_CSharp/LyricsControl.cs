using LyricsSceneMaker_CSharp.model;
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

namespace LyricsSceneMaker_CSharp
{
    public delegate void toScene(int opcode, string data1, string data2);

    public partial class LyricsControl : Form
    {
        public static event toScene toscene;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Song song;
        private int notesNowSelectedIndex = 0;
        private int formEffectNowSelectedIndex = 0;

        // 특수효과 키 추가하려면 이 변수를 수정하면 됨.
        private Keys[] noteTrigger = { Keys.Enter, Keys.Space };
        private Keys[] effectTrigger = { Keys.A };

        public LyricsControl()
        {
            InitializeComponent();
            this.Width = 393;
            this.Height = 593;
            foreach(Keys key in noteTrigger)
            {
                noteTriggerInformation.Text += "\r\n" + key.ToString();
            }
            foreach (Keys key in effectTrigger)
            {
                effectTriggerInformation.Text += "\r\n" + key.ToString();
            }
        }

        // 음악파일 불러오기
        private void selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "음악 파일 (*.mp3)|*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectFile.Text = ofd.FileName;
            }
        }

        // Initialize! 버튼 이벤트
        private void initializeButton_Click(object sender, EventArgs e)
        {
            // 정보 미기입 시 진행 불가능
            if (songNameTextBox.Text.Equals("") || artistTextBox.Text.Equals("")
                || selectFile.Text.Equals("select file") || LyricsTextBox.Text.Equals(""))
            {
                MessageBox.Show("곡에 대한 정보가 부족합니다.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 공백 줄바꿈 \r\n 지워줌
            while(LyricsTextBox.Text.Contains("\r\n\r\n"))
                LyricsTextBox.Text = LyricsTextBox.Text.Replace("\r\n\r\n", "\r\n");

            // 마지막줄의 줄바꿈 지워줌 (필수)
            int length = LyricsTextBox.Text.Length;
            if (LyricsTextBox.Text.Substring(length - 2, 2).Equals("\r\n"))
                LyricsTextBox.Text = LyricsTextBox.Text.Substring(0, length - 2);
                
            // 가사 입력된 것을 string[] 배열에 저장해준다.
            string[] lines_lyrics = LyricsTextBox.Text.Split('\n');

            // 모드 변환 (곡 정보 입력 창 -> 가사 싱크 맞추는 폼)
            Control.ControlCollection controls = this.Controls;

            foreach (Control control in controls)
            {
                control.Left -= 380;
            }

            artistTextBox.Enabled = false;
            songNameTextBox.Enabled = false;
            selectFile.Enabled = false;
            LyricsTextBox.ReadOnly = true;
            initializeButton.Enabled = false;
            lyricsLoadButton.Enabled = false;
            lyricsSaveButton.Enabled = true;
            
            // Song 개체 생성
            song = new Song(songNameTextBox.Text, artistTextBox.Text, selectFile.Text, lines_lyrics);
            notesNowSelectedIndex = 0;
            formEffectNowSelectedIndex = 0;

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
        
        // LyricsScene 폼 호출
        private void LyricsControl_Load(object sender, EventArgs e)
        {
            LyricsScene scene = new LyricsScene();
            scene.Show();
        }

        // 텍스트 애니메이션 추가 이벤트
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            Boolean isValid = false;
            foreach(Keys key in noteTrigger)
            {
                if(e.KeyCode == key)
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid)
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
                notesNowSelectedIndex = insertIndex;
            }
        }

        // 노트 시점 변경 및 타임스탬프 제거
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
                notesNowSelectedIndex = selectedIndex;
                long nowTime = long.Parse(listBox.GetItemText(listBox.Items[notesNowSelectedIndex]).Split(',')[0]);
                formEffectNowSelectedIndex = getFormEffectNowIndex(nowTime);
                audioFile.Position = nowTime;
            }
            else
            {
                dr = MessageBox.Show("더블 클릭한 노트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    listBox.Items.RemoveAt(selectedIndex);
                    notesNowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        // 폼 효과 추가 이벤트
        private void effectListBox_KeyDown(object sender, KeyEventArgs e)
        {
            Boolean isValid = false;
            foreach(Keys key in effectTrigger)
            {
                if(e.KeyCode == key)
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid)
            {
                int size = effectListBox.Items.Count;

                int insertIndex = 0;
                long nowTime = audioFile.Position;
                string insertString = nowTime + "," + (int)e.KeyCode; // opcode

                if (size == 0)
                {
                    effectListBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (object item in effectListBox.Items)
                    {
                        if (long.Parse(effectListBox.GetItemText(item).Split(',')[0]) > nowTime)
                        {
                            effectListBox.Items.Insert(insertIndex, insertString);
                            isInserted = true;
                            break;
                        }
                        insertIndex++;
                    }
                    if (!isInserted) effectListBox.Items.Insert(size, insertString);
                }
                formEffectNowSelectedIndex = insertIndex;
            }
        }

        // 폼 이펙트 시점 변경 및 타임스탬프 제거
        private void effectListBox_DoubleClick(object sender, EventArgs e)
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
            int selectedIndex = effectListBox.SelectedIndex;
            DialogResult dr = MessageBox.Show("선택한 지점부터 재생하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                formEffectNowSelectedIndex = selectedIndex;
                long nowTime = long.Parse(effectListBox.GetItemText(effectListBox.Items[formEffectNowSelectedIndex]).Split(',')[0]);
                notesNowSelectedIndex = getNoteNowIndex(nowTime);
                audioFile.Position = nowTime;
            }
            else
            {
                dr = MessageBox.Show("더블 클릭한 폼 이펙트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    effectListBox.Items.RemoveAt(selectedIndex);
                    formEffectNowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        // 선택한 nowTime을 통해 노트 싱크 목적지를 찾아야 함
        private int getNoteNowIndex(long nowTime)
        {
            int index = 0;
            foreach(object note in listBox.Items)
            {
                long notesTime = long.Parse(listBox.GetItemText(note).Split(',')[0]);
                if(notesTime > nowTime)
                {
                    return (index != 0) ? --index : 0;
                }
                index++;
            }
            return index;
        }

        // 선택한 nowTime을 통해 폼 효과 싱크 목적지를 찾아야 함
        private int getFormEffectNowIndex(long nowTime)
        {
            int index = 0;
            foreach (object note in effectListBox.Items)
            {
                long notesTime = long.Parse(effectListBox.GetItemText(note).Split(',')[0]);
                if (notesTime > nowTime)
                {
                    return (index != 0) ? --index : 0;
                }
                index++;
            }
            return index;
        }

        // 리스트박스 두개 감시하면서 시간에 맞게 알맞은 값을 LyricsScene으로 보내줌
        private void timer_Tick(object sender, EventArgs e)
        {
            int size = listBox.Items.Count;

            if (size == 0 || size - 1 < notesNowSelectedIndex || audioFile == null || outputDevice == null){}else
            // 노트 신호 보내기
            if (long.Parse(listBox.GetItemText(listBox.Items[notesNowSelectedIndex]).Split(',')[0]) <= audioFile.Position)
            {
                toscene(int.Parse(listBox.GetItemText(listBox.Items[notesNowSelectedIndex]).Split(',')[1]), song.Lyrics[notesNowSelectedIndex],
                    (song.Lyrics.Length > notesNowSelectedIndex + 1) ? song.Lyrics[notesNowSelectedIndex + 1] : null);

                nowSentence.Text = song.Lyrics[notesNowSelectedIndex];
                if (song.Lyrics.Length > notesNowSelectedIndex + 1) nextSentence.Text = song.Lyrics[notesNowSelectedIndex + 1];
                else nextSentence.Text = "null";

                // 현재 지점 Note 정보 알려주기
                noteInformation.Text = listBox.GetItemText(listBox.Items[notesNowSelectedIndex]);

                // 다음 가사 기다리기 시작
                notesNowSelectedIndex++;
            }


            if (effectListBox.Items.Count - 1 < formEffectNowSelectedIndex){}else
            // 폼 이펙트 신호 보내기
            if (long.Parse(effectListBox.GetItemText(effectListBox.Items[formEffectNowSelectedIndex]).Split(',')[0]) <= audioFile.Position)
            {
                toscene(int.Parse(effectListBox.GetItemText(effectListBox.Items[formEffectNowSelectedIndex]).Split(',')[1]), null, null);

                // 현재 지점 폼 이펙트 정보 알려주기
                /////
                effectInformation.Text = effectListBox.GetItemText(effectListBox.Items[formEffectNowSelectedIndex]);

                // 다음 폼 이펙트 기다리기 시작
                formEffectNowSelectedIndex++;
            }
        }

        // NAudio 라이브러리를 통한 mp3 파일 재생 함수
        private void replay_Click(object sender, EventArgs e)
        {
            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, artistTextBox.Text + " - " + songNameTextBox.Text, 
                (song.Lyrics.Length > 0) ? song.Lyrics[0] : null);

            notesNowSelectedIndex = 0;
            formEffectNowSelectedIndex = 0;
            
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

        // 가사 불러오기
        private void lyricsLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "가사 데이터 파일 (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = File.OpenText(ofd.FileNames[0]);

                // 노트 데이터 읽어오기
                if (sr.Peek() > 0)
                {
                    sb.Append(sr.ReadToEnd());
                }

                // 객체 닫기
                sr.Close();

                // Text 속성 변경
                LyricsTextBox.Text = sb.ToString();
            }
        }

        // 가사 저장하기
        private void lyricsSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "가사 데이터 파일 (*.txt)|*.txt";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "notes";
            sfd.FileName = artistTextBox.Text + "-" + songNameTextBox.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = (FileStream)sfd.OpenFile();
                    sw = new StreamWriter(fs);
                    sw.Write(LyricsTextBox.Text);
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("저장 성공!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException e1)
                {
                    if (fs != null) fs.Close();
                    if (sw != null) fs.Close();
                    MessageBox.Show("저장 실패!", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Write("{0}", e1.StackTrace);
                }
            }
        }

        // 가사 노트 불러오기 버튼
        private void notesLoadButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (listBox.Items.Count != 0)
            {
                dr = MessageBox.Show("정말로 진행하시던 것을 삭제하고\r\n새로운 노트 정보를 덮어씌우시겠습니까?", "Question",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK) return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "노트 데이터 파일 (*.notes)|*.notes";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = File.OpenText(ofd.FileNames[0]);

                // 노트 데이터 읽어오기
                if (sr.Peek() > 0)
                {
                    sb.Append(sr.ReadToEnd());
                }

                // 객체 닫기
                sr.Close();

                // 데이터 유무 예외처리
                if (!sb.ToString().Contains("|"))
                {
                    MessageBox.Show("비어있는 노트 데이터 파일을 불러올 수 없습니다.", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 데이터 파싱
                //replay_Click(this, e);
                listBox.Items.Clear();
                string[] note_datas = sb.ToString().Split('|');

                foreach (string note_line in note_datas)
                {
                    // 마지막 공백 제거
                    if (!note_line.Equals(""))
                        listBox.Items.Add(note_line);
                }
            }
        }

        // 가사 노트 저장하기 버튼
        private void notesSaveButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(object item in listBox.Items)
            {
                string line_data = listBox.GetItemText(item) + "|";
                sb.Append(line_data);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "노트 데이터 파일 (*.notes)|*.notes";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "notes";
            sfd.FileName = artistTextBox.Text + "-" + songNameTextBox.Text;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = (FileStream)sfd.OpenFile();
                    sw = new StreamWriter(fs);
                    sw.Write(sb.ToString());
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("저장 성공!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException e1)
                {
                    if (fs != null) fs.Close();
                    if (sw != null) fs.Close();
                    MessageBox.Show("저장 실패!", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Write("{0}", e1.StackTrace);
                }
            }
        }

        // 폼 이펙트 불러오기 버튼
        private void effectsLoadButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (effectListBox.Items.Count != 0)
            {
                dr = MessageBox.Show("정말로 진행하시던 것을 삭제하고\r\n새로운 폼 이펙트 정보를 덮어씌우시겠습니까?", "Question",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK) return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "폼 이펙트 데이터 파일 (*.effects)|*.effects";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = File.OpenText(ofd.FileNames[0]);

                // 폼 이펙트 데이터 읽어오기
                if (sr.Peek() > 0)
                {
                    sb.Append(sr.ReadToEnd());
                }

                // 객체 닫기
                sr.Close();

                // 데이터 유무 예외처리
                if (!sb.ToString().Contains("|"))
                {
                    MessageBox.Show("비어있는 폼 이펙트 데이터 파일을 불러올 수 없습니다.", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 데이터 파싱
                //replay_Click(this, e);
                effectListBox.Items.Clear();
                string[] effect_datas = sb.ToString().Split('|');

                foreach (string effect_line in effect_datas)
                {
                    // 마지막 공백 제거
                    if (!effect_line.Equals(""))
                        effectListBox.Items.Add(effect_line);
                }
            }
        }

        // 폼 이펙트 저장하기 버튼
        private void effectsSaveButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object item in effectListBox.Items)
            {
                string line_data = effectListBox.GetItemText(item) + "|";
                sb.Append(line_data);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "폼 이펙트 데이터 파일 (*.effects)|*.effects";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "effects";
            sfd.FileName = artistTextBox.Text + "-" + songNameTextBox.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = (FileStream)sfd.OpenFile();
                    sw = new StreamWriter(fs);
                    sw.Write(sb.ToString());
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("저장 성공!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException e1)
                {
                    if (fs != null) fs.Close();
                    if (sw != null) fs.Close();
                    MessageBox.Show("저장 실패!", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Write("{0}", e1.StackTrace);
                }
            }
        }
 
        ////// 텍스트 효과 변경 함수 
        ////private void effect_change_function(Keys number)
        ////{
        ////    int selectedIndex = listBox.SelectedIndex;
        ////    if (selectedIndex == -1) return;

        ////    DialogResult dr;
        ////    dr = MessageBox.Show("선택된 노트를 이 효과로 바꾸시겠습니까?", "Question",
        ////        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        ////    if (dr == DialogResult.OK)
        ////    {
        ////        object note = listBox.Items[selectedIndex];
        ////        string noteTimeData = listBox.GetItemText(note).Split(',')[0];
        ////        listBox.Items.Remove(note);
        ////        listBox.Items.Insert(selectedIndex, noteTimeData + "," + (int)number);
        ////    }
        ////}

        /////// <summary>
        /////// 아래부분은 텍스트 효과와 폼 효과 호출하는 버튼 이벤트 모음
        /////// </summary>
        /////// <param name="sender"></param>
        /////// <param name="e"></param>
        ////private void effectButton1_Click(object sender, EventArgs e)
        ////{
        ////    effect_change_function(Keys.Enter);
        ////}

        ////private void effectButton2_Click(object sender, EventArgs e)
        ////{
        ////    effect_change_function(Keys.Space);
        ////}
    }
}
