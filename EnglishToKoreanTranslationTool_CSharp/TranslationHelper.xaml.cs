using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnglishToKoreanTranslationTool_CSharp
{
    /// <summary>
    /// Interaction logic for TranslationManager.xaml
    /// </summary>
    public partial class TranslationHelper : Window
    {
        // TODO: 모르는 단어를 찾아봤을 때는 단어장에 저장해서 다음에 똑같은 단어가 나온다면 도움을 줄 수 있게 하면 좋겠다.

        List<Lyric> lyrics = new List<Lyric>();
        System.Windows.Controls.ListView EngLyricsListView;
        private int nowSelected = -1;

        public TranslationHelper()
        {
            InitializeComponent();
        }

        // 창 드래그 함수
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // 영어 자막 불러오기 버튼
        private void EngLyricsLoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "가사 데이터 파일 (*.lyrics)|*.lyrics";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader bs = new StreamReader(fs);
                EngLyricsTextBox.Text = bs.ReadToEnd();
                bs.Close();
                fs.Close();
            }
        }

        // 불러온 영어 자막을 바탕으로 초기 세팅하기 // 가정 : 이미 가공된 lyrics 파일이어야 함.
        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EngLyricsTextBox.Text.Equals("")) return;

            EngLyricsLoadButton.IsEnabled = false;
            InitializeButton.IsEnabled = false;
            RejectButton.IsEnabled = true;
            AfterTextBox.IsEnabled = true;
            SubmitButton.IsEnabled = true;
            KorLyricsLoadButton.IsEnabled = true;
            KorLyricsSaveButton.IsEnabled = true;

            // 가사 정보 인지하기
            string[] lyrics_data = EngLyricsTextBox.Text.Split('\n');
            for(int i = 0; i < lyrics_data.Length; i++)
            {
                lyrics_data[i] = lyrics_data[i].Replace("\r", "");
            }

            for (int i = 0; i < lyrics_data.Length; i++)
            {
                lyrics.Add(new Lyric() { index = i + 1, isSuccess = false, engLyric = lyrics_data[i], korLyric = string.Empty });
            }

            // 리스트뷰 컨트롤 설정하기
            LeftDock.Children.Remove((UIElement)FindName("EngLyricsTextBox"));
            EngLyricsListView = new System.Windows.Controls.ListView();
            EngLyricsListView.Name = "EngLyricsListView";
            EngLyricsListView.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0x4C, 0xFF, 0xFF, 0xFF));
            EngLyricsListView.Foreground = new SolidColorBrush(Colors.Black);
            EngLyricsListView.FontSize = 12;
            EngLyricsListView.SelectionChanged += EngLyricsListView_SelectionChanged;

            GridView engGridView = new GridView();
            GridView korGridView = new GridView();
            GridViewColumn col;

            col = new GridViewColumn();
            col.Header = "n";
            col.Width = 30;
            col.DisplayMemberBinding = new System.Windows.Data.Binding("index");
            engGridView.Columns.Add(col);

            col = new GridViewColumn();
            col.Header = "n";
            col.Width = 30;
            col.DisplayMemberBinding = new System.Windows.Data.Binding("index");
            korGridView.Columns.Add(col);

            col = new GridViewColumn();
            col.Header = "상태";
            col.Width = 50;
            col.DisplayMemberBinding = new System.Windows.Data.Binding("isSuccess");
            engGridView.Columns.Add(col);

            col = new GridViewColumn();
            col.Header = "상태";
            col.Width = 50;
            col.DisplayMemberBinding = new System.Windows.Data.Binding("isSuccess");
            korGridView.Columns.Add(col);

            col = new GridViewColumn();
            col.Header = "Eng Lyric";
            col.Width = 200;
            col.DisplayMemberBinding = new System.Windows.Data.Binding("engLyric");
            engGridView.Columns.Add(col);

            col = new GridViewColumn();
            col.Header = "Kor Lyric";
            col.Width = 200;
            col.DisplayMemberBinding = new System.Windows.Data.Binding("korLyric");
            korGridView.Columns.Add(col);

            EngLyricsListView.View = engGridView;
            KorLyricsListView.View = korGridView;

            // 리스트뷰 컨트롤 추가하기
            LeftDock.Children.Add(EngLyricsListView);

            // 리스트뷰 List<Lyric> 정보와 연결
            EngLyricsListView.ItemsSource = lyrics;
            KorLyricsListView.ItemsSource = lyrics;
            EngLyricsListView.SelectedIndex = 0;
        }

        // 선택한 데이터 가져오기
        private void EngLyricsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KorLyricsListView.SelectedIndex = EngLyricsListView.SelectedIndex;
            nowSelected = EngLyricsListView.SelectedIndex;
            BeforeTextBlock.Text = lyrics[EngLyricsListView.SelectedIndex].engLyric;
            AfterTextBox.Text = lyrics[EngLyricsListView.SelectedIndex].korLyric;
            SetHintObjects();
        }

        // 선택한 데이터 가져오기
        private void KorLyricsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EngLyricsListView.SelectedIndex = KorLyricsListView.SelectedIndex;
            nowSelected = KorLyricsListView.SelectedIndex;
            BeforeTextBlock.Text = lyrics[KorLyricsListView.SelectedIndex].engLyric;
            AfterTextBox.Text = lyrics[KorLyricsListView.SelectedIndex].korLyric;
            SetHintObjects();
        }

        // 번역할 데이터 힌트 주기
        private void SetHintObjects()
        {
            // 올라와져 있는 버튼 삭제
            wrapPanel.Children.RemoveRange(0, wrapPanel.Children.Count);

            // 새로운 버튼 등록
            string[] hints = BeforeTextBlock.Text.Split(' ');
            
            foreach (string hint in hints)
            {
                System.Windows.Controls.Button button = new System.Windows.Controls.Button();
                button.Content = hint;
                button.Click += Button_Click;
                button.Background = new SolidColorBrush(Colors.Transparent);
                wrapPanel.Children.Add(button);
            }

            // 파파고 TextBlock 이름 처리
            PapagoSaid.Text = "파파고 said \"" + BeforeTextBlock.Text + "\" equals ~.";
        }

        // 파파고 번역본 가져오기
        private void PapagoSaid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "https://papago.naver.com/?sk=en&tk=ko&hn=0&st=" + BeforeTextBlock.Text.Replace(" ", "%20"));
        }

        // 힌트 바탕으로 검색창 띄어줌
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 검색어 유도 : ~ 슬랭, ~ 회화, ~ meaning
            try
            {
                if (sender == null) return;
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                string toFindData = button.Content.ToString();
                System.Diagnostics.Process.Start("Chrome.exe", "https://www.google.com/search?q=" + toFindData + "%20뜻");
            } catch { }
        }

        // 리스트뷰에 값 추가하기 (실패한 상태로)
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            Lyric lyric = lyrics.ElementAt(nowSelected);
            lyric.isSuccess = false;
            lyric.korLyric = AfterTextBox.Text;
            EngLyricsListView.Items.Refresh();
            KorLyricsListView.Items.Refresh();

            // 다음 가사로 옮기기
            if (nowSelected + 1 < lyrics.Count)
            {
                nowSelected++;
                EngLyricsListView.SelectedIndex = nowSelected;
                EngLyricsListView.SelectedIndex = nowSelected;
            }
        }

        // 리스트뷰에 값 추가하기
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Lyric lyric = lyrics.ElementAt(nowSelected);
            lyric.isSuccess = true;
            lyric.korLyric = AfterTextBox.Text;
            EngLyricsListView.Items.Refresh();
            KorLyricsListView.Items.Refresh();

            // 다음 가사로 옮기기
            if (nowSelected + 1 < lyrics.Count)
            {
                nowSelected++;
                EngLyricsListView.SelectedIndex = nowSelected;
                EngLyricsListView.SelectedIndex = nowSelected;
            }
        }

        // 진행중이던 가사 번역본 불러오기
        private void KorLyricsLoadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // 지금까지 진행한 가사 번역본 저장하기
        private void KorLyricsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            // false 이면 가사 앞에 false| 붙이고 공백이면 | 붙이기 저 두개없으면 true로 판단 // 바꾸면 notify해줘야함
            StringBuilder sb = new StringBuilder();
            foreach(Lyric lyric in lyrics)
            {
                string korLyric = lyric.korLyric;
                if (lyric.isSuccess)
                {
                    sb.Append(korLyric + "\n");
                }
                else
                {
                    sb.Append("[false data]" + korLyric + "\n");
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "노래 가사 데이터 파일 (*.lyrics)|*.lyrics";
            sfd.DefaultExt = "lyrics";
            
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream os = new FileStream(sfd.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(os);
                    sw.Write(sb.ToString());
                    sw.Close();
                    os.Close();
                    System.Windows.Forms.MessageBox.Show("저장 성공!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("저장 실패!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
