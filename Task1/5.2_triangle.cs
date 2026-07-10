using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task1
{
    public partial class Form8 : Form
    {
        int[] m_p = new int[6];
        bool index = false;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label1.Text = "Введите координаты";
            button1.Text = "Рисовать";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_p[0] = Convert.ToInt32(textBox1.Text);
            m_p[1] = Convert.ToInt32(textBox2.Text);
            m_p[2] = Convert.ToInt32(textBox3.Text);
            m_p[3] = Convert.ToInt32(textBox4.Text);
            m_p[4] = Convert.ToInt32(textBox5.Text);
            m_p[5] = Convert.ToInt32(textBox6.Text);
            index = true;
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (index)
            {
                Graphics g = e.Graphics;
                g.DrawLine(Pens.Black, m_p[0], m_p[1], m_p[2], m_p[3]);
                g.DrawLine(Pens.Red, m_p[2], m_p[3], m_p[4], m_p[5]);
                g.DrawLine(Pens.White, m_p[4], m_p[5], m_p[0], m_p[1]);
            }
        }
    }
}