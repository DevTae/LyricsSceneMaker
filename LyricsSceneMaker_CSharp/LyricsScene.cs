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
    public partial class LyricsScene : Form
    {
        
        public LyricsScene()
        {
            InitializeComponent();

            // 라벨 투명하게 만들기 위해서
            titlebar.Parent = blurPictureBox;
            descriptorTextBox.Parent = blurPictureBox;
            lyricsTextBox1.Parent = blurPictureBox;
            lyricsTextBox2.Parent = blurPictureBox;
            ahdelronPictureBox.Parent = blurPictureBox;

            blurPictureBox.Parent = scenePictureBox;

            
            

            //this.ClientSize = new Size(1280, 720);
            // clientSize는 왼쪽과 위의 공백부분을 조절할 수 있는 설정으로 보임.

            LyricsControl.toscene += new toScene(receive_data);
        }
        
        // delegate 함수 피호출 함수
        void receive_data(int opcode, string data1, string data2)
        {
            if(opcode == -1) // 팝송
            {
                lyricsTextBox2.Font = new Font("Gmarket Sans TTF Bold", 18);
                lyricsTextBox2.ForeColor = Color.DimGray;
            }
            else if(opcode == 0) // K-POP
            {
                // descriptor 정보 받아오기
                // 맨 처음 화면
                descriptorTextBox.Text = data1;
                lyricsTextBox1.Text = data1;
                lyricsTextBox2.Text = data2;
            }
            else if(opcode == (int)Keys.Enter || opcode == (int)Keys.Space)
            {
                effectFunction1(data1, data2);
            }
            else if(opcode == (int)Keys.A)
            {
                formEffectFunction1();
            }
        }

        /// <summary>
        /// 텍스트 효과 및 폼 효과 적용 함수
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        private void effectFunction1(string data1, string data2)
        {
            lyricsTextBox1.Text = data1;
            lyricsTextBox2.Text = data2;
        }

        private void formEffectFunction1()
        {
            // mp4 혹은 gif 눈내리거나 비내리거나 사탕내리거나 천둥치거나 등등 자연효과가 제일 어울릴듯 해보임.
        }

        /// <summary>
        /// 창 끌기 구현 부분
        /// </summary>
        Point point;
        Boolean isMouseDown = false;

        private void titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            point = new Point(e.X, e.Y);
        }

        private void titlebar_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void titlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDown)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private Bitmap[] ahdelron_pictures = new Bitmap[] { global::LyricsSceneMaker_CSharp.Properties.Resources.아무래도_하얀색,
                                                            global::LyricsSceneMaker_CSharp.Properties.Resources.아무레도_검은색
        };

        //private int ahdelron_picture_index = 0;
        //private void ahdelronPictureBox_Click(object sender, EventArgs e)
        //{
        //    if(ahdelron_picture_index >= ahdelron_pictures.Length - 1)
        //    {
        //        ahdelron_picture_index = 0;
        //        ahdelronPictureBox.Image = ahdelron_pictures[ahdelron_picture_index];
        //    }
        //    else
        //    {
        //        ahdelronPictureBox.Image = ahdelron_pictures[++ahdelron_picture_index];
        //    }
        //}

        private Bitmap[] blur_pictures = new Bitmap[] { global::LyricsSceneMaker_CSharp.Properties.Resources.blur_simple_black,
                                                        global::LyricsSceneMaker_CSharp.Properties.Resources.blur_simple_white
        };

        // 화면 테마 모드
        private int blur_picture_index = 0;

        private Color[] descriptor_colors = new Color[] { Color.White,
                                                          Color.Black
        };

        private Color[] lyrics1_colors = new Color[] { Color.White,
                                                       Color.Black
        };

        private Color[] lyrics2_colors = new Color[] { Color.Gray,
                                                       Color.Gray
        };

        private void blurPictureBox_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("백그라운드 이미지 변경 : 예(Yes)\r\n블러 이미지 변경 : 아니요(No)\r\n해당 없음 : 취소(Cancel)", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel) return;

            if (dr == DialogResult.Yes) // 백그라운드 이미지 변경
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    scenePictureBox.Image = Image.FromFile(ofd.FileNames[0]);
                }
            }
            else if (dr == DialogResult.No) // 블러 이미지 변경
            {
                if (blur_picture_index >= blur_pictures.Length - 1)
                {
                    blur_picture_index = 0;
                    blurPictureBox.Image = blur_pictures[blur_picture_index];
                }
                else
                {
                    blurPictureBox.Image = blur_pictures[++blur_picture_index];
                }
                descriptorTextBox.ForeColor = descriptor_colors[blur_picture_index];
                lyricsTextBox1.ForeColor = lyrics1_colors[blur_picture_index];
                lyricsTextBox2.ForeColor = lyrics2_colors[blur_picture_index];
                ahdelronPictureBox.Image = ahdelron_pictures[blur_picture_index];
            }
        }
    }
}
