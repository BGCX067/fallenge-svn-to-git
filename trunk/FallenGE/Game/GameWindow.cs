using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FallenGE.Win32;

namespace FallenGE.Game
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        public GameWindow(string title, int width, int height, int bitdepth, bool fullscreen)
        {
            InitializeComponent();

            SetTitle(title);
            SetSize(width, height);

            if (fullscreen)
            {
                Core.Fullscreen(this.ClientSize.Width, this.ClientSize.Height, bitdepth);
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left = 0;
                this.Top = 0;
            }

            Show();
        }

        public void SetSize(int width, int height)
        {
            this.ClientSize = new Size(width, height);
        }

        public void Display()
        {
            base.Show();
        }

        public void SetTitle(string title)
        {
            Text = title;
        }

        public IntPtr GetHandle()
        {
            return this.Handle;
        }

        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Quit();
        }
    }
}
