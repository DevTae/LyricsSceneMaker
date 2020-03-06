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
            MessageBox.Show(data);
        }

        private void LyricsScene_Load(object sender, EventArgs e)
        {
            LyricsControl newControl = new LyricsControl();
            newControl.Show();
        }
    }
}
