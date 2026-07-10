using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task1
{
    public partial class _3_imagebg : Form
    {
        public _3_imagebg()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Доска объявлений";
            label1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }
}
}
