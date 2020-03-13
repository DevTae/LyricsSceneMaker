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
            titlebar.Parent = scenePictureBox;
            descriptorTextBox.Parent = scenePictureBox;
            lyricsTextBox1.Parent = scenePictureBox;
            lyricsTextBox2.Parent = scenePictureBox;

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

        }
        
        // 가사 줄바꿈 위치 선정
        private string addNewLineFunction(string text)
        {
            byte[] b = Encoding.Default.GetBytes(text);
            if (b.Length <= 24) return text;

            int count_byte = 0;
            int index = 0;
            while(count_byte <= 24)
            {
                count_byte += Encoding.Default.GetByteCount(text.Substring(index++, 1));
            }
            return text;
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

        private void lyricsTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
