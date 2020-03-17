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
using System.Windows.Threading;

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

        // 특수효과 키 추가하려면 이 변수를 수정하면 됨. // 필요 없을듯
        //private Keys[] noteTrigger = { Keys.Enter, Keys.Space };
        //private Keys[] effectTrigger = { Keys.A };

        // 타이머 활성화
        public LyricsControlXaml()
        {
            InitializeComponent();
            LyricsSceneXaml scene = new LyricsSceneXaml();
            scene.Show();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            for(int i = 0; i < 2; i++)
            {
                BackgroundColorSelector.Items.Add(i.ToString());
            }

            foreach (SolidColorBrush color in LyricsSceneXaml.descriptor_colors)
            {
                DescriptorColorSelector.Items.Add(color.ToString());
            }

            foreach (SolidColorBrush color in LyricsSceneXaml.lyrics_colors)
            {
                LyricsColorSelector.Items.Add(color.ToString());
            }

            for (int i = 0; i < LyricsSceneXaml.ahdelron_pictures.Length; i++)
            {
                WatermarkColorSelector.Items.Add(i.ToString());
            }
        }

        // 시간 맞춰서 데이터 Scene으로 전송
        private void timer_Tick(object sender, EventArgs e)
        {
            int size = NotesListBox.Items.Count;

            if (size == 0 || size - 1 < notesNowSelectedIndex || audioFile == null || outputDevice == null)
            {
                // nothing to do 
            }
            else
            {
                // 노트 신호 보내기
                if (long.Parse(((string)NotesListBox.Items[notesNowSelectedIndex]).Split(',')[0]) <= audioFile.Position)
                {
                    toscene(int.Parse(((string)NotesListBox.Items[notesNowSelectedIndex]).Split(',')[1]), song.Lyrics[notesNowSelectedIndex],
                        (song.Lyrics.Length > notesNowSelectedIndex + 1) ? song.Lyrics[notesNowSelectedIndex + 1] : null);

                    // 현재 지점 Note 정보 알려주기
                    NoteInformation.Content = (string)NotesListBox.Items[notesNowSelectedIndex];

                    // 다음 가사 기다리기 시작
                    notesNowSelectedIndex++;
                }
            }

            if (EffectsListBox.Items.Count - 1 < formEffectNowSelectedIndex)
            {
                // nothing to do 
            }
            else
            {
                // 폼 이펙트 신호 보내기
                string[] datas = ((string)EffectsListBox.Items[formEffectNowSelectedIndex]).Split(',');
                if (long.Parse(datas[0]) <= audioFile.Position)
                {
                    int opcode = int.Parse(datas[1]);

                    if (opcode == (int)Keys.C)
                    {
                        toscene(opcode, datas[2], null);
                    }
                    else
                    {
                        toscene(opcode, null, null);
                    }

                    // 현재 지점 폼 이펙트 정보 알려주기
                    EffectInformation.Content = (string)EffectsListBox.Items[formEffectNowSelectedIndex];

                    // 다음 폼 이펙트 기다리기 시작
                    formEffectNowSelectedIndex++;
                }
            }
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
            EffectsListBox.IsEnabled = true;
            EffectsLoadButton.IsEnabled = true;
            EffectsSaveButton.IsEnabled = true;
            NoteMake1.IsEnabled = true;
            EffectMake1.IsEnabled = true;
            OpenCutMaker.IsEnabled = true;

            // Song 개체 생성
            song = new Song(SongNameTextBox.Text, ArtistTextBox.Text, SelectFile.Content.ToString(), lines_lyrics);
            notesNowSelectedIndex = 0;
            formEffectNowSelectedIndex = 0;

            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, ArtistTextBox.Text, SongNameTextBox.Text);

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

        // 텍스트 애니메이션 추가 이벤트
        private void NoteMake1_Click(object sender, RoutedEventArgs e)
        {
            Boolean isValid = true;
            //Boolean isValid = false;
            //foreach (Keys key in noteTrigger)
            //{
            //    if (e.Key.Equals(key))
            //    {
            //        isValid = true;
            //        break;
            //    }
            //}
            if (isValid)
            {
                int size = NotesListBox.Items.Count;
                if (song.Lyrics.Length <= size) return;

                int insertIndex = 0;
                long nowTime = audioFile.Position;
                //string insertString = nowTime + "," + (int)e.Key; // opcode
                string insertString = nowTime + "," + (int)Keys.Enter;

                if (size == 0)
                {
                    NotesListBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (string item in NotesListBox.Items)
                    {
                        if (long.Parse(item.Split(',')[0]) > nowTime)
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

        // 폼 효과 추가 이벤트
        private void EffectMake1_Click(object sender, RoutedEventArgs e)
        {
            Boolean isValid = true;
            //Boolean isValid = false;
            //foreach (Keys key in noteTrigger)
            //{
            //    if (e.Key.Equals(key))
            //    {
            //        isValid = true;
            //        break;
            //    }
            //}
            if (isValid)
            {
                int size = EffectsListBox.Items.Count;

                int insertIndex = 0;
                long nowTime = audioFile.Position;
                //string insertString = nowTime + "," + (int)e.Key; // opcode
                string insertString = nowTime + "," + (int)Keys.A;

                if (size == 0)
                {
                    EffectsListBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (string item in EffectsListBox.Items)
                    {
                        if (long.Parse(item.Split(',')[0]) > nowTime)
                        {
                            EffectsListBox.Items.Insert(insertIndex, insertString);
                            isInserted = true;
                            break;
                        }
                        insertIndex++;
                    }
                    if (!isInserted) EffectsListBox.Items.Insert(size, insertString);
                }
                formEffectNowSelectedIndex = insertIndex;
            }
        }

        // 폼 이펙트 시점 변경 및 타임스탬프 제거
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

            // wpf 컨트롤 예외 처리
            if (selectedIndex == -1) return;

            string selectedString = (string)NotesListBox.SelectedItem;

            DialogResult dr = System.Windows.Forms.MessageBox.Show("선택한 지점부터 재생하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                notesNowSelectedIndex = selectedIndex;
                long nowTime = long.Parse(selectedString.Split(',')[0]);
                formEffectNowSelectedIndex = getFormEffectNowIndex(nowTime);
                audioFile.Position = nowTime;
            }
            else
            {
                dr = System.Windows.Forms.MessageBox.Show("더블 클릭한 노트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    NotesListBox.Items.RemoveAt(selectedIndex);
                    if(notesNowSelectedIndex > 0) notesNowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        // 폼 이펙트 시점 변경 및 타임스탬프 제거
        private void EffectsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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

            int selectedIndex = EffectsListBox.SelectedIndex;

            // wpf 컨트롤 예외 처리
            if (selectedIndex == -1) return;

            string selectedString = (string)EffectsListBox.SelectedItem;

            DialogResult dr = System.Windows.Forms.MessageBox.Show("선택한 지점부터 재생하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                formEffectNowSelectedIndex = selectedIndex;
                long nowTime = long.Parse(selectedString.Split(',')[0]);
                notesNowSelectedIndex = getNoteNowIndex(nowTime);
                audioFile.Position = nowTime;
            }
            else
            {
                dr = System.Windows.Forms.MessageBox.Show("더블 클릭한 노트를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    EffectsListBox.Items.RemoveAt(selectedIndex);
                    if (formEffectNowSelectedIndex > 0) formEffectNowSelectedIndex--;
                }
            }
            outputDevice.Play();
        }

        // 선택한 nowTime을 통해 노트 싱크 목적지를 찾아야 함
        private int getNoteNowIndex(long nowTime)
        {
            int index = 0;
            foreach (string note in NotesListBox.Items)
            {
                long notesTime = long.Parse(note.Split(',')[0]);
                if (notesTime > nowTime)
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
            foreach (string effect in EffectsListBox.Items)
            {
                long notesTime = long.Parse(effect.Split(',')[0]);
                if (notesTime > nowTime)
                {
                    return (index != 0) ? --index : 0;
                }
                index++;
            }
            return index;
        }

        // 가사 불러오기
        private void LyricsLoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "가사 데이터 파일 (*.lyrics)|*.lyrics";
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
            sfd.Filter = "가사 데이터 파일 (*.lyrics)|*.lyrics";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "lyrics";
            sfd.FileName = ArtistTextBox.Text + "-" + SongNameTextBox.Text.Replace("|", " ");
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
            foreach (string item in NotesListBox.Items)
            {
                string line_data = item + "|";
                sb.Append(line_data);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "노트 데이터 파일 (*.notes)|*.notes";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "notes";
            sfd.FileName = ArtistTextBox.Text + "-" + SongNameTextBox.Text.Replace("|", " ");
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

        // 폼 이펙트 저장하기 버튼
        private void EffectsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in EffectsListBox.Items)
            {
                string line_data = item + "|";
                sb.Append(line_data);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "폼 이펙트 데이터 파일 (*.effects)|*.effects";
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "effects";
            sfd.FileName = ArtistTextBox.Text + "-" + SongNameTextBox.Text.Replace("|", " ");
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

        // 폼 이펙트 불러오기 버튼
        private void EffectsLoadButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dr;
            if (EffectsListBox.Items.Count != 0)
            {
                dr = System.Windows.Forms.MessageBox.Show("정말로 진행하시던 것을 삭제하고\r\n새로운 폼 이펙트 정보를 덮어씌우시겠습니까?", "Question",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != System.Windows.Forms.DialogResult.OK) return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "폼 이펙트 데이터 파일 (*.effects)|*.effects";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                    System.Windows.Forms.MessageBox.Show("비어있는 폼 이펙트 데이터 파일을 불러올 수 없습니다.", "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 데이터 파싱
                //replay_Click(this, e);
                EffectsListBox.Items.Clear();
                string[] effect_datas = sb.ToString().Split('|');

                foreach (string effect_line in effect_datas)
                {
                    // 마지막 공백 제거
                    if (!effect_line.Equals(""))
                        EffectsListBox.Items.Add(effect_line);
                }
            }
        }

        // NAudio 라이브러리를 통한 mp3 파일 재생 함수
        private void Replay_Click(object sender, RoutedEventArgs e)
        {
            // Scene 폼에 곡 이름, 아티스트 정보를 넘겨준다.
            toscene(0, ArtistTextBox.Text, SongNameTextBox.Text);

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }


        /// <summary>
        /// 컷 전환을 위한 기능 개발
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OpenCutMaker_Click(object sender, RoutedEventArgs e)
        {
            if(OpenCutMaker.Content.Equals("+"))
            {
                FirstGridColumn.Width = new GridLength(0, GridUnitType.Star);
                ThirdGridColumn.Width = new GridLength(1, GridUnitType.Star);
                
                BackgroundColorSelector.IsEnabled = true;
                ImagesListBox.IsEnabled = true;
                ImageAddButton.IsEnabled = true;
                //ImageListLoadButton.IsEnabled = true;
                //ImageListSaveButton.IsEnabled = true;
                DescriptorColorSelector.IsEnabled = true;
                LyricsColorSelector.IsEnabled = true;
                WatermarkColorSelector.IsEnabled = true;
                InitialImageAddButton.IsEnabled = true;
                ImageChangeTimeAddButton.IsEnabled = true;
                ImageAddButton.IsEnabled = true;
                OpenCutMaker.Content = "-";
            }
            else if(OpenCutMaker.Content.Equals("-"))
            {
                FirstGridColumn.Width = new GridLength(1, GridUnitType.Star);
                ThirdGridColumn.Width = new GridLength(0, GridUnitType.Star);

                BackgroundColorSelector.IsEnabled = false;
                ImagesListBox.IsEnabled = false;
                ImageAddButton.IsEnabled = false;
                //ImageListLoadButton.IsEnabled = false;
                //ImageListSaveButton.IsEnabled = false;
                DescriptorColorSelector.IsEnabled = false;
                LyricsColorSelector.IsEnabled = false;
                WatermarkColorSelector.IsEnabled = false;
                InitialImageAddButton.IsEnabled = false;
                ImageChangeTimeAddButton.IsEnabled = false;
                ImageAddButton.IsEnabled = false;
                OpenCutMaker.Content = "+";
            }
            
        }

        // 이미지 삭제
        private void ImagesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DialogResult dr = System.Windows.Forms.MessageBox.Show("더블 클릭한 이미지를 삭제하시겠습니까?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                image_paths.RemoveAt(ImagesListBox.SelectedIndex);
                int index = ImagesListBox.SelectedIndex;
                ImagesListBox.Items.RemoveAt(index);
            }
        }

        // 이미지 불러오기
        public static List<string> image_paths = new List<string>();
        private void ImageAddButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "사진 파일 (*.jpg;*.jpeg;*.png;*.jfif;*.gif;)|*.jpg;*.jpeg;*.png;*.jfif;*.gif;";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image_paths.AddRange(ofd.FileNames);
                foreach(string data in ofd.FileNames)
                    ImagesListBox.Items.Add(data);
            }
        }

        // 첫 화면 레이아웃 추가하기
        private void InitialImageAddButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean isValid = true;
            //Boolean isValid = false;
            //foreach (Keys key in noteTrigger)
            //{
            //    if (e.Key.Equals(key))
            //    {
            //        isValid = true;
            //        break;
            //    }
            //}
            if (isValid)
            {
                int size = EffectsListBox.Items.Count;

                int insertIndex = 0;
                //long nowTime = audioFile.Position;
                long nowTime = 0;
                //string insertString = nowTime + "," + (int)e.Key; // opcode
                string insertString = nowTime + "," + (int)Keys.C + "," + ImagesListBox.SelectedIndex
                    + "!" + BackgroundColorSelector.SelectedIndex + "!" + DescriptorColorSelector.SelectedIndex
                    + "!" + LyricsColorSelector.SelectedIndex + "!" + WatermarkColorSelector.SelectedIndex;

                if (size == 0)
                {
                    EffectsListBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (string item in EffectsListBox.Items)
                    {
                        if (long.Parse(item.Split(',')[0]) > nowTime)
                        {
                            EffectsListBox.Items.Insert(insertIndex, insertString);
                            isInserted = true;
                            break;
                        }
                        insertIndex++;
                    }
                    if (!isInserted) EffectsListBox.Items.Insert(size, insertString);
                }
                //if (formEffectNowSelectedIndex != 0) formEffectNowSelectedIndex++;
            }
        }

        // 화면 전환 타이밍 추가하기
        private void ImageChangeTimeAddButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean isValid = true;
            //Boolean isValid = false;
            //foreach (Keys key in noteTrigger)
            //{
            //    if (e.Key.Equals(key))
            //    {
            //        isValid = true;
            //        break;
            //    }
            //}
            if (isValid)
            {
                int size = EffectsListBox.Items.Count;

                int insertIndex = 0;
                long nowTime = audioFile.Position;
                //string insertString = nowTime + "," + (int)e.Key; // opcode
                string insertString = nowTime + "," + (int)Keys.C + "," + ImagesListBox.SelectedIndex
                    + "!" + BackgroundColorSelector.SelectedIndex + "!" + DescriptorColorSelector.SelectedIndex
                    + "!" + LyricsColorSelector.SelectedIndex + "!" + WatermarkColorSelector.SelectedIndex;

                if (size == 0)
                {
                    EffectsListBox.Items.Insert(insertIndex, insertString);
                }
                else
                {
                    // Big-O : O(logn)
                    // later ~ 이분탐색 구현
                    Boolean isInserted = false;
                    foreach (string item in EffectsListBox.Items)
                    {
                        if (long.Parse(item.Split(',')[0]) > nowTime)
                        {
                            EffectsListBox.Items.Insert(insertIndex, insertString);
                            isInserted = true;
                            break;
                        }
                        insertIndex++;
                    }
                    if (!isInserted) EffectsListBox.Items.Insert(size, insertString);
                }
                formEffectNowSelectedIndex = insertIndex;
            }
        }

        /// <summary>
        /// 미리보기 레이아웃 색깔 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ImagesListBox.SelectedIndex == -1) return;
            string selectedText = ImagesListBox.SelectedItem.ToString();
            PreviewImage.Source = new BitmapImage(new Uri(selectedText, UriKind.Absolute));
        }

        private void BackgroundColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rectangle1.Fill = LyricsSceneXaml.descriptor_colors[BackgroundColorSelector.SelectedIndex];
        }

        private void DescriptorColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Descriptor.Foreground = LyricsSceneXaml.descriptor_colors[DescriptorColorSelector.SelectedIndex];
        }

        private void LyricsColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lyrics1.Foreground = LyricsSceneXaml.lyrics_colors[LyricsColorSelector.SelectedIndex];
            Lyrics2.Foreground = LyricsSceneXaml.lyrics_colors[LyricsColorSelector.SelectedIndex];
            Lyrics1.Background = LyricsSceneXaml.lyrics_border_colors[LyricsColorSelector.SelectedIndex];
            Lyrics2.Background = LyricsSceneXaml.lyrics_border_colors[LyricsColorSelector.SelectedIndex];
        }

        private void WatermarkColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WatermarkImage.Source = LyricsSceneXaml.ahdelron_pictures[WatermarkColorSelector.SelectedIndex];
        }
    }
}
