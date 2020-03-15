using LyricsSceneMaker_CSharp.model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
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
        private int formEffectNowSelectedIndex = 0;

        // 특수효과 키 추가하려면 이 변수를 수정하면 됨.
        private Keys[] noteTrigger = { Keys.Enter, Keys.Space };
        private Keys[] effectTrigger = { Keys.A };

        public LyricsControlXaml()
        {
            InitializeComponent();
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
            //ControlCollection controls = this.Controls;

            //foreach (Control control in controls)
            //{
            //    control.Left -= 380;
            //}

            ArtistTextBox.IsEnabled = false;
            SongNameTextBox.IsEnabled = false;
            SelectFile.IsEnabled = false;
            LyricsTextBox.IsReadOnly = true;
            InitializeButton.IsEnabled = false;
            LyricsLoadButton.IsEnabled = false;
            LyricsSaveButton.IsEnabled = true;

            // Song 개체 생성
            song = new Song(SongNameTextBox.Text, ArtistTextBox.Text, SelectFile.Content.ToString(), lines_lyrics);
            notesNowSelectedIndex = 0;
            formEffectNowSelectedIndex = 0;

            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, ArtistTextBox.Text + " - " + SongNameTextBox.Text,
                (song.Lyrics.Length > 0) ? song.Lyrics[0] : null);

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

        // LyricsSceneXaml 폼 호출
        // To be implemented

        // 텍스트 애니메이션 추가 이벤트
        private void NotesListBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Boolean isValid = false;
            foreach (Keys key in noteTrigger)
            {
                if (e.KeyCode == key)
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
                string insertString = nowTime + "," + (int)e.KeyCode; // opcode

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
            ListBoxItem selectedItem = (ListBoxItem)NotesListBox.SelectedItem;

            DialogResult dr = System.Windows.MessageBox.Show("선택한 지점부터 재생하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                notesNowSelectedIndex = selectedIndex;
                long nowTime = long.Parse(selectedItem.Content.ToString().Split(',')[0]);
                formEffectNowSelectedIndex = getFormEffectNowIndex(nowTime);
                audioFile.Position = nowTime;
            }
            else
            {
                dr = System.Windows.MessageBox.Show("더블 클릭한 노트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    NotesListBox.Items.RemoveAt(selectedIndex);
                    notesNowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        private void LyricsLoadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LyricsSaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        

        

        private void Replay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
