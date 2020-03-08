using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LyricsSceneMaker_CSharp
{
    public partial class LyricsScene : Form
    {

        public LyricsScene()
        {
            InitializeComponent();
            LyricsControl.toscene += new toScene(receive_data);
        }

        void receive_data(int opcode, string data)
        {
            if(opcode == 0)
            {
                // descriptor 정보 받아오기
                descriptorTextBox.Text = data;
                lyricsTextBox2.Text = "간주 중...";
            }
            else if(opcode == 1)
            {
                lyricsTextBox1.Text = lyricsTextBox2.Text;
                lyricsTextBox2.Text = data;
            }
            // 옵코드에 따라 움직이는 애니메이션 다르게 만들 것임. 
        }

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

        private void albumPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "사진 파일 (*.jpeg; *.jpg; *.png; *.gif;)|*.jpeg;*.jpg;*.png;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                albumPictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
