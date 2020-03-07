using NAudio.Wave;
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
    public partial class MusicPlayerTest : Form
    {
        public MusicPlayerTest()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        
        private void InitializeComponent2()
        {
            var flowPanel = new FlowLayoutPanel();
            flowPanel.FlowDirection = FlowDirection.LeftToRight;
            flowPanel.Margin = new Padding(10);

            var buttonPlay = new Button();
            buttonPlay.Text = "Play";
            buttonPlay.Click += OnButtonPlayClick;
            flowPanel.Controls.Add(buttonPlay);

            var buttonStop = new Button();
            buttonStop.Text = "Stop";
            buttonStop.Click += OnButtonStopClick;
            flowPanel.Controls.Add(buttonStop);

            this.Controls.Add(flowPanel);

            this.FormClosing += OnButtonStopClick;
        }

        private void OnButtonPlayClick(object sender, EventArgs args)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(@"C:\Users\fmkms\Desktop\[랩갓 귀환] 에미넴 X 주스 월드 (Eminem X Juice WRLD) - Godzilla [가사해석번역자막].mp3");
                outputDevice.Init(audioFile);
                
            }
            //audioFile.Position = 15160000;
            outputDevice.Play();

        }

        private void OnButtonStopClick(object sender, EventArgs args)
        {
            outputDevice?.Stop();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(outputDevice.GetPosition().ToString());
            outputDevice.Pause();
        }
    }
}
