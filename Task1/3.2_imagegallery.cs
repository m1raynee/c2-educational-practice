using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task1
{
    public partial class _3_imagegallery : Form
    {
        public _3_imagegallery()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Галерея мемов";
            label1.Text = "";
            comboBox1.Text = "Выберите мем";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        pictureBox1.Image = Image.FromFile("C:\\Users\\peche\\Downloads\\meme1.jpg");
                        label1.Text = "терафлю"; break;
                    case 1:
                        pictureBox1.Image = Image.FromFile("C:\\Users\\peche\\Downloads\\meme2.jpg");
                        label1.Text = "бро чат гбт"; break;
                    case 2:
                        pictureBox1.Image = Image.FromFile("C:\\Users\\peche\\Downloads\\meme3.jpg")
                    ; label1.Text = "стоицизм"; break;
                    case 3:
                        pictureBox1.Image = Image.FromFile("C:\\Users\\peche\\Downloads\\meme4.jpg");
                        label1.Text = "господь сохрани"; break;
                }
            }
        }
    }
}