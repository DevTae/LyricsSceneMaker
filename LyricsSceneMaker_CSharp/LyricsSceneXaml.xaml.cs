using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LyricsSceneMaker_CSharp
{
    /// <summary>
    /// Interaction logic for LyricsSceneXaml.xaml
    /// </summary>
    public partial class LyricsSceneXaml : Window
    {
        public LyricsSceneXaml()
        {
            InitializeComponent();
            LyricsControlXaml.toscene += new toScene(receive_data);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        // 타이머 이벤트 (CD회전)
        private void timer_Tick(object sender, EventArgs e)
        {
            rotationDegree.Angle += 1;
        }

        // delegate 함수 피호출 함수
        void receive_data(int opcode, string data1, string data2)
        {
            
            if (opcode == 0)
            {
                // descriptor 정보 받아오기
                // 맨 처음 화면
                DescriptorLabel.Visibility = Visibility.Hidden;
                LyricsLabel1.Visibility = Visibility.Hidden;
                LyricsLabel2.Visibility = Visibility.Hidden;
                FirstLastText.Visibility = Visibility.Visible;
                if(data2.Contains("|"))
                {
                    FirstLastText.Text = data1 + " - " + data2.Split('|')[0];
                }
                else
                {
                    FirstLastText.Text = data1 + " - " + data2;
                }
                data2 = data2.Replace("|", "\r\n");
                DescriptorLabel.Text = data1 + " - " + data2;
            }
            else if (opcode == (int)Keys.Enter || opcode == (int)Keys.Space)
            {
                effectFunction1(data1, data2);
            }
            else if (opcode == (int)Keys.A)
            {
                formEffectFunction1();
            }
            else if(opcode == (int)Keys.C)
            {
                transformImage(data1);
            }
        }

        /// <summary>
        /// 텍스트 효과 및 폼 효과 적용 함수
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        private void effectFunction1(string data1, string data2)
        {
            if (data1 != null) data1 = data1.Replace("\r", "");
            if (data2 != null) data2 = data2.Replace("\r", "");
            if (FirstLastText.Visibility == Visibility.Visible)
            {
                FirstLastText.Visibility = Visibility.Hidden;
                DescriptorLabel.Visibility = Visibility.Visible;
                LyricsLabel1.Visibility = Visibility.Visible;
                LyricsLabel2.Visibility = Visibility.Visible;
            }
            else if (EffectText.Visibility == Visibility.Visible)
            {
                EffectText.Visibility = Visibility.Hidden;
                LyricsLabel1.Visibility = Visibility.Visible;
                LyricsLabel2.Visibility = Visibility.Visible;
            }

            if (data1 == null)
            {
                LyricsLabel1.Text = "";
            }
            else
            {
                LyricsLabel1.Text = data1;
            }

            if(data2 == null)
            {
                LyricsLabel2.Visibility = Visibility.Hidden;
                //LyricsLabel2.Text = "";
            }
            else
            {
                LyricsLabel2.Visibility = Visibility.Visible;
                LyricsLabel2.Text = data2;
            }
        }

        // 간주 화면 출력
        private void formEffectFunction1()
        {
            LyricsLabel1.Visibility = Visibility.Hidden;
            LyricsLabel2.Visibility = Visibility.Hidden;
            EffectText.Visibility = Visibility.Visible;
        }

        // 컷 전환 함수
        double blur_memo_data;
        private void transformImage(string data)
        {
            string[] datas = data.Split('!');
            int index, i = 1, p = 0;
            int data_length = datas.Length;

            if (data_length >= i++)
                if (int.TryParse(datas[p++], out index))
                {
                    ScenePictureBox.Source = new BitmapImage(new Uri(LyricsControlXaml.image_paths[index], UriKind.Absolute));
                }


            if (data_length >= i++)
                if (int.TryParse(datas[p++], out index))
                {
                    Rectangle1.Fill = descriptor_colors[index];
                }

            if (data_length >= i++)

                if (int.TryParse(datas[p++], out index))
                {
                    descriptor_index = index;
                    DescriptorLabel.Foreground = descriptor_colors[index];
                }

            if (data_length >= i++)
                if (int.TryParse(datas[p++], out index))
                {
                    lyricsLabel_index = index;
                    LyricsLabel1.Foreground = lyrics_colors[index];
                    LyricsLabel2.Foreground = lyrics_colors[index];
                    FirstLastText.Foreground = lyrics_colors[index];
                    EffectText.Foreground = lyrics_colors[index];
                    LyricsLabel1.Background = lyrics_border_colors[index];
                    LyricsLabel2.Background = lyrics_border_colors[index];
                    FirstLastText.Background = lyrics_border_colors[index];
                    EffectText.Background = lyrics_border_colors[index];
                }

            if (data_length >= i++)
                if (int.TryParse(datas[p++], out index))
                {
                    ahdelron_index = index;
                    AhdelronPictureBox.Source = ahdelron_pictures[index];
                }

            if (data_length >= i++)
            {
                if (datas[p].Contains("b"))
                {
                    var animation = new DoubleAnimation
                    {
                        From = blur_memo_data,
                        To = double.Parse(datas[p++].Replace("b", "")),
                        Duration = TimeSpan.FromMilliseconds(300),
                        AutoReverse = true
                    };
                    ScenePictureBox.Effect = new BlurEffect();
                    ScenePictureBox.Effect.BeginAnimation(BlurEffect.RadiusProperty, animation);
                }
                else
                {
                    var animation = new DoubleAnimation
                    {
                        From = blur_memo_data,
                        To = double.Parse(datas[p++]),
                        Duration = TimeSpan.FromMilliseconds(1000),
                        AutoReverse = false
                    };
                    blur_memo_data = (double)animation.To;
                    ScenePictureBox.Effect = new BlurEffect();
                    ScenePictureBox.Effect.BeginAnimation(BlurEffect.RadiusProperty, animation);
                }
            }

        }

        // this.dragmove 로 쉽게 창 드래그 기능을 구현할 수 있음
        private void Titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // 화면 테마 모드
        public static BitmapImage[] ahdelron_pictures = new BitmapImage[] {
            new BitmapImage(new Uri(@"images\아무레도_검은색.png", UriKind.RelativeOrAbsolute)),
            new BitmapImage(new Uri(@"images\아무래도_하얀색.png", UriKind.RelativeOrAbsolute))
        };

        public static SolidColorBrush[] descriptor_colors = new SolidColorBrush[] {
            new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0, 0, 0)), // 검은색
            new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF)) // 하얀색
        };

        public static SolidColorBrush[] lyrics_colors = new SolidColorBrush[] {
            new SolidColorBrush(Colors.White), // 하얀색
            new SolidColorBrush(Colors.Black) // 검은색
        };

        public static SolidColorBrush[] lyrics_border_colors = new SolidColorBrush[] {
            new SolidColorBrush(System.Windows.Media.Color.FromArgb(0x60, 0, 0, 0)), // 검은색
            new SolidColorBrush(System.Windows.Media.Color.FromArgb(0x60, 0xFF, 0xFF, 0xFF)) // 하얀색
        };

        //private SolidColorBrush getSolidColorBrush(byte a, byte r, byte g, byte b)
        //{
        //    return new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, r, g, b));
        //}

        // 백그라운드 이미지 설정
        private void ScenePictureBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult dr = System.Windows.Forms.MessageBox.Show("백그라운드 이미지 변경 : 예(Yes)\r\n가우시안 블러 레디우스 변경(+10) : 아니요(No)\r\n해당 없음 : 취소(Cancel)", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Cancel) return;

            if (dr == System.Windows.Forms.DialogResult.Yes) // 백그라운드 이미지 변경
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        ScenePictureBox.Source = new BitmapImage(new Uri(ofd.FileNames[0]));
                        dr = System.Windows.Forms.MessageBox.Show("- 백그라운드 색깔 변경 -\r\n검은색(Black) : 예(Yes)\r\n하얀색(White) : 아니요(No)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            Rectangle1.Fill = new SolidColorBrush(Colors.Black);
                        }
                        else if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            Rectangle1.Fill = new SolidColorBrush(Colors.White);
                        }
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("로딩 실패!", "Fatal Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (dr == System.Windows.Forms.DialogResult.No)
            {
                double radius = blurEffect.Radius;
                radius += 10;
                if (radius <= 100)
                {
                    blurEffect.Radius = radius;
                }
                else
                {
                    blurEffect.Radius = 0;
                }
            }
        }

        // 워터마크 이미지 설정
        private int ahdelron_index = 0;
        private void AhdelronPictureBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ahdelron_index >= ahdelron_pictures.Length - 1)
            {
                ahdelron_index = 0;
            }
            else
            {
                ++ahdelron_index;
            }
            AhdelronPictureBox.Source = ahdelron_pictures[ahdelron_index];
        }

        // 가사 색깔 설정
        private int lyricsLabel_index = 0;
        private void LyricsLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lyricsLabel_index >= lyrics_colors.Length - 1)
            {
                lyricsLabel_index = 0;
            }
            else
            {
                ++lyricsLabel_index;
            }
            LyricsLabel1.Foreground = lyrics_colors[lyricsLabel_index];
            LyricsLabel2.Foreground = lyrics_colors[lyricsLabel_index];
            FirstLastText.Foreground = lyrics_colors[lyricsLabel_index];
            EffectText.Foreground = lyrics_colors[lyricsLabel_index];
            LyricsLabel1.Background = lyrics_border_colors[lyricsLabel_index];
            LyricsLabel2.Background = lyrics_border_colors[lyricsLabel_index];
            FirstLastText.Background = lyrics_border_colors[lyricsLabel_index];
            EffectText.Background = lyrics_border_colors[lyricsLabel_index];
        }

        // 곡 이름 색깔 설정
        private int descriptor_index = 0;
        private void DescriptorLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (descriptor_index >= descriptor_colors.Length - 1)
            {
                descriptor_index = 0;
            }
            else
            {
                ++descriptor_index;
            }
            DescriptorLabel.Foreground = descriptor_colors[descriptor_index];
        }
    }
}
