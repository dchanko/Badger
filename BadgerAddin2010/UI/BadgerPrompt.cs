using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BadgerAddin2010.UI
{
    public partial class BadgerPrompt : Form
    {
        Action<int> mHandler;

        public BadgerPrompt(Action<int> pHandler)
        {
            mHandler = pHandler;
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            mHandler.Invoke(int.Parse(btn.Tag.ToString()));
            this.Close();
        }
    }
}
