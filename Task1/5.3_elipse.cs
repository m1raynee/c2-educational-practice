using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task1
{
    public partial class Form9 : Form
    {
        int[] m_p = new int[4];
        bool index = false;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.Text = "Рисование эллипса";
            label1.Text = "Введите данные";
            button1.Text = "Рисовать";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_p[0] = Convert.ToInt32(textBox1.Text);
            m_p[1] = Convert.ToInt32(textBox2.Text);
            m_p[2] = Convert.ToInt32(textBox3.Text);
            m_p[3] = Convert.ToInt32(textBox4.Text);
            index = true;
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (index)
            {
                Pen ElipsePen = new Pen(Color.Black);
                e.Graphics.DrawEllipse(ElipsePen, m_p[0], m_p[1], m_p[2], m_p[3]);
            }
        }
    }
}