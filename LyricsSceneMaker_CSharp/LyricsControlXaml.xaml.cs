using LyricsSceneMaker_CSharp.model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LyricsSceneMaker_CSharp
{
    public delegate void toScene(int opcode, string data1, string data2);

    public partial class LyricsControlXaml : Window
    {
        public static event toScene toscene;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Song song;
        private int notesNowSelectedIndex = 0;

        // 특수효과 키 추가하려면 이 변수를 수정하면 됨.
        private Keys[] noteTrigger = { Keys.Enter, Keys.Space };
        private Keys[] effectTrigger = { Keys.A };

        public LyricsControlXaml()
        {
            InitializeComponent();
            LyricsSceneXaml scene = new LyricsSceneXaml();
            scene.Show();
        }

        // 음악파일 불러오기
        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "음악 파일 (*.mp3)|*.mp3";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectFile.Content = ofd.FileName;
            }
        }

        // Initialize! 버튼 이벤트
        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            // 정보 미기입 시 진행 불가능
            if (SongNameTextBox.Text.Equals("") || ArtistTextBox.Text.Equals("")
                || SelectFile.Content.ToString().Equals("Select File") || LyricsTextBox.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("곡에 대한 정보가 부족합니다.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 공백 줄바꿈 \r\n 지워줌
            while (LyricsTextBox.Text.Contains("\r\n\r\n"))
                LyricsTextBox.Text = LyricsTextBox.Text.Replace("\r\n\r\n", "\r\n");

            // 마지막줄의 줄바꿈 지워줌 (필수)
            int length = LyricsTextBox.Text.Length;
            if (LyricsTextBox.Text.Substring(length - 2, 2).Equals("\r\n"))
                LyricsTextBox.Text = LyricsTextBox.Text.Substring(0, length - 2);

            // 가사 입력된 것을 string[] 배열에 저장해준다.
            string[] lines_lyrics = LyricsTextBox.Text.Split('\n');

            // 모드 변환 (곡 정보 입력 창 -> 가사 싱크 맞추는 폼)
            // 컨트롤 좌측 이동 및 크기 작아지게
            ArtistTextBox.IsEnabled = false;
            SongNameTextBox.IsEnabled = false;
            SelectFile.IsEnabled = false;
            LyricsTextBox.IsReadOnly = true;
            InitializeButton.IsEnabled = false;
            LyricsLoadButton.IsEnabled = false;
            LyricsSaveButton.IsEnabled = true;
            Pause.IsEnabled = true;
            Play.IsEnabled = true;
            Replay.IsEnabled = true;
            NotesListBox.IsEnabled = true;
            NotesLoadButton.IsEnabled = true;
            NotesSaveButton.IsEnabled = true;
            
            // Song 개체 생성
            song = new Song(SongNameTextBox.Text, ArtistTextBox.Text, SelectFile.Content.ToString(), lines_lyrics);
            notesNowSelectedIndex = 0;
            //formEffectNowSelectedIndex = 0;

            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            //toscene(0, ArtistTextBox.Text + " - " + SongNameTextBox.Text,
            //    (song.Lyrics.Length > 0) ? song.Lyrics[0] : null);

            // 노래 재생하기
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(SelectFile.Content.ToString());
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

        // 텍스트 애니메이션 추가 이벤트 // 버튼으로 바꿔야겠음 마우스로 치기
        private void NotesListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.Key.ToString());
            Boolean isValid = false;
            foreach (Keys key in noteTrigger)
            {
                if (e.Key.Equals(key))
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid)
            {
                int size = NotesListBox.Items.Count;
                if (song.Lyrics.Length <= size) return;

                int insertIndex = 0;
                long nowTime = audioFile.Position;
                string insertString = nowTime + "," + (int)e.Key; // opcode

                if (size == 0)
                {
                    NotesListBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (ListBoxItem item in NotesListBox.Items)
                    {
                        if (long.Parse(item.Content.ToString().Split(',')[0]) > nowTime)
                        {
                            NotesListBox.Items.Insert(insertIndex, insertString);
                            isInserted = true;
                            break;
                        }
                        insertIndex++;
                    }
                    if (!isInserted) NotesListBox.Items.Insert(size, insertString);
                }
                notesNowSelectedIndex = insertIndex;
            }
        }

        // 시점 변경 이벤트
        private void NotesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(SelectFile.Content.ToString());
                outputDevice.Init(audioFile);
            }
            outputDevice.Pause();

            int selectedIndex = NotesListBox.SelectedIndex;
            if(selectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("실어");
                return;
            }

            ListBoxItem selectedItem = (ListBoxItem)NotesListBox.SelectedItem;

            DialogResult dr = System.Windows.Forms.MessageBox.Show("선택한 지점부터 재생하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                notesNowSelectedIndex = selectedIndex;
                long nowTime = long.Parse(selectedItem.Content.ToString().Split(',')[0]);
                //formEffectNowSelectedIndex = getFormEffectNowIndex(nowTime);
                audioFile.Position = nowTime;
            }
            else
            {
                dr = System.Windows.Forms.MessageBox.Show("더블 클릭한 노트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    NotesListBox.Items.RemoveAt(selectedIndex);
                    notesNowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        // 가사 불러오기
        private void LyricsLoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "가사 데이터 파일 (*.txt)|*.txt";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
        private void LyricsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "가사 데이터 파일 (*.txt)|*.txt";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "notes";
            sfd.FileName = ArtistTextBox.Text + "-" + SongNameTextBox.Text;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                    System.Windows.Forms.MessageBox.Show("저장 성공!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException e1)
                {
                    if (fs != null) fs.Close();
                    if (sw != null) fs.Close();
                    System.Windows.Forms.MessageBox.Show("저장 실패!", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Write("{0}", e1.StackTrace);
                }
            }
        }

        // 가사 노트 저장하기 버튼
        private void NotesSaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListBoxItem item in NotesListBox.Items)
            {
                string line_data = item.Content.ToString() + "|";
                sb.Append(line_data);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "노트 데이터 파일 (*.notes)|*.notes";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "notes";
            sfd.FileName = ArtistTextBox.Text + "-" + SongNameTextBox.Text;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                    System.Windows.Forms.MessageBox.Show("저장 성공!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException e1)
                {
                    if (fs != null) fs.Close();
                    if (sw != null) fs.Close();
                    System.Windows.Forms.MessageBox.Show("저장 실패!", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Write("{0}", e1.StackTrace);
                }
            }
        }

        // 가사 노트 불러오기 버튼
        private void NotesLoadButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dr;
            if (NotesListBox.Items.Count != 0)
            {
                dr = System.Windows.Forms.MessageBox.Show("정말로 진행하시던 것을 삭제하고\r\n새로운 노트 정보를 덮어씌우시겠습니까?", "Question",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != System.Windows.Forms.DialogResult.OK) return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "노트 데이터 파일 (*.notes)|*.notes";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                    System.Windows.Forms.MessageBox.Show("비어있는 노트 데이터 파일을 불러올 수 없습니다.", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 데이터 파싱
                //replay_Click(this, e);
                NotesListBox.Items.Clear();
                string[] note_datas = sb.ToString().Split('|');

                foreach (string note_line in note_datas)
                {
                    // 마지막 공백 제거
                    if (!note_line.Equals(""))
                        NotesListBox.Items.Add(note_line);
                }
            }
        }

        // NAudio 라이브러리를 통한 mp3 파일 재생 함수
        private void Replay_Click(object sender, RoutedEventArgs e)
        {
            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, ArtistTextBox.Text + " - " + SongNameTextBox.Text,
                (song.Lyrics.Length > 0) ? song.Lyrics[0] : null);

            notesNowSelectedIndex = 0;
            //formEffectNowSelectedIndex = 0;

            // 노래 재생
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(SelectFile.Content.ToString());
                outputDevice.Init(audioFile);
            }

            // audio file rewind
            audioFile.Position = 0;

            outputDevice.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(SelectFile.Content.ToString());
                outputDevice.Init(audioFile);
            }
            outputDevice.Pause();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(SelectFile.Content.ToString());
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        // timer
    }
}
