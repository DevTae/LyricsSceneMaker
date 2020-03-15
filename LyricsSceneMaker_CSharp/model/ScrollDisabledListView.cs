using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LyricsSceneMaker_CSharp
{
    public partial class ScrollDisabledListView : ListBox
    {
        private bool mShowScroll;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!mShowScroll) cp.Style &= ~0x200000; // Turn off WS_VSCROLL
                return cp;
            }
        }

        [DefaultValue(false)]
        public bool ShowScrollbar
        {
            get { return mShowScroll; }
            set
            {
                if (value == mShowScroll) return;
                mShowScroll = value;
                if (this.Handle != IntPtr.Zero) RecreateHandle();
            }
        }

        public ScrollDisabledListView()
        {
            InitializeComponent();
        }
    }
}
