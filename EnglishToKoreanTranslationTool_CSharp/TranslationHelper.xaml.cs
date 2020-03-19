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

namespace EnglishToKoreanTranslationTool_CSharp
{
    /// <summary>
    /// Interaction logic for TranslationManager.xaml
    /// </summary>
    public partial class TranslationHelper : Window
    {
        // TODO: 모르는 단어를 찾아봤을 때는 단어장에 저장해서 다음에 똑같은 단어가 나온다면 도움을 줄 수 있게 하면 좋겠다.

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
            
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
            EngLyricsLoadButton.IsEnabled = false;
            LeftDock.Children.Remove((UIElement)FindName("EngLyricsTextBox"));
            System.Windows.Controls.ListView listView = new System.Windows.Controls.ListView();
            listView.Name = "EngLyricsListView";
            listView.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0x4C, 0xFF, 0xFF, 0xFF));
            listView.Foreground = new SolidColorBrush(Colors.Black);
            listView.FontFamily = new FontFamily("/EnglishToKoreanTranslationTool_CSharp;component/Fonts/#Cafe24 Shiningstar");
            listView.FontSize = 18;
            LeftDock.Children.Add(listView);
        }

        // 번역할 데이터 힌트 추기
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == null) return;
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                string toFindData = button.Content.ToString();
            }
            catch
            {

            }
        }

        // 리스트뷰에 값 추가하기
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // 진행중이던 가사 번역본 불러오기
        private void KorLyricsLoadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // 지금까지 진행한 가사 번역본 저장하기
        private void KorLyricsSaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
