using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        // this.dragmove 로 쉽게 창 드래그 기능을 구현할 수 있음
        private void Titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
