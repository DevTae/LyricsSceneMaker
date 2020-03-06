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

        void receive_data(int opcode, string data1, string data2)
        {
            if(opcode == 0)
            {
                // descriptor 정보 받아오기
                descriptorTextBox.Text = data1;
            }
            else
            {
                lyricsTextBox1.Text = data1;
                lyricsTextBox2.Text = data2;
            }
            // 옵코드에 따라 움직이는 애니메이션 다르게 만들 것임. 
        }

        private void LyricsScene_Load(object sender, EventArgs e)
        {
            LyricsControl newControl = new LyricsControl();
            newControl.Show();
        }
    }
}
