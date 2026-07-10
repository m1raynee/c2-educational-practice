using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Text = "Закрашивание фигур";
            label1.Text = "Выберите фигуру";
            comboBox1.Text = "Фигуры";

            string[] фигуры = { "Прямоугольник", "Эллипс", "Окружность" };
            comboBox1.Items.AddRange(фигуры);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics графика = pictureBox1.CreateGraphics();

            using (Brush заливка = new SolidBrush(Color.Orange))
            {
                графика.Clear(SystemColors.Control);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        графика.FillRectangle(заливка, 60, 60, 120, 180);
                        break;
                    case 1:
                        графика.FillEllipse(заливка, 60, 60, 120, 180);
                        break;
                    case 2:
                        графика.FillEllipse(заливка, 60, 60, 120, 120);
                        break;
                }
            }
        }
    }
}