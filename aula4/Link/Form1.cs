using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Link
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Process.Start("www.roblox.com/pt");
        }
    }
}
