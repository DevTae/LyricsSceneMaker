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
        private int width;
        private int height;
        private int top;
        private int left;
        
        public LyricsScene()
        {
            InitializeComponent();
            titlebar.Parent = scenePictureBox;
            descriptorTextBox.Parent = scenePictureBox;
            lyricsTextBox1.Parent = scenePictureBox;
            lyricsTextBox2.Parent = scenePictureBox;
            width = albumPictureBox.Width;
            height = albumPictureBox.Height;
            top = albumPictureBox.Top;
            left = albumPictureBox.Left;
            LyricsControl.toscene += new toScene(receive_data);
        }
        
        // delegate 함수 피호출 함수
        void receive_data(int opcode, string data1, string data2)
        {
            if(opcode == 0)
            {
                // descriptor 정보 받아오기
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
            else if(opcode == (int)Keys.S)
            {
                formEffectFunction2();
            }
            // 옵코드에 따라 움직이는 애니메이션 다르게 만들 것임. 
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
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    albumPictureBox.Left += 1;
                    albumPictureBox.Top += 1;
                    albumPictureBox.Width -= 2;
                    albumPictureBox.Height -= 2;
                    Thread.Sleep(1);
                }
                for (int i = 0; i < 2; i++)
                {
                    albumPictureBox.Left -= 1;
                    albumPictureBox.Top -= 1;
                    albumPictureBox.Width += 2;
                    albumPictureBox.Height += 2;
                    Thread.Sleep(1);
                }
                albumPictureBox.Width = width;
                albumPictureBox.Height = height;
                albumPictureBox.Top = top;
                albumPictureBox.Left = left;
            }); thread.Start();
        }

        private void formEffectFunction2()
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    this.Top -= 1;
                    Thread.Sleep(10);
                }
                for (int i = 0; i < 5; i++)
                {
                    this.Top += 1;
                    Thread.Sleep(10);
                }
            }); thread.Start();
        }


        // 앨범 이미지 변경 버튼
        private void albumPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "사진 파일 (*.jpeg; *.jpg; *.png; *.gif;)|*.jpeg;*.jpg;*.png;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                albumPictureBox.Image = Image.FromFile(ofd.FileName);
            }
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
    }
}
