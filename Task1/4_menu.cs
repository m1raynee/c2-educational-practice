using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace c2_SP_Tasks.Task1
{
    public partial class _4_menu : Form
    {
        public _4_menu()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Text = "Текстовый редактор";
            openFileDialog1.FileName = @"D:\ВУЗ\Text2.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var MyReader = new StreamReader(openFileDialog1.FileName))
                {
                    textBox1.Text = MyReader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ситуация)
            {
                MessageBox.Show(ситуация.Message + "\nФайл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ситуация)
            {
                MessageBox.Show(ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save();
            }
        }

        private void Save()
        {
            try
            {
                using (var MyWriter = new StreamWriter(saveFileDialog1.FileName, false))
                {
                    MyWriter.Write(textBox1.Text);
                }
                textBox1.Modified = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!textBox1.Modified) return;

            var MeBox = MessageBox.Show("Текст был изменён. \nСохранить изменения?", "Текстовый редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (MeBox == DialogResult.No) return;
            if (MeBox == DialogResult.Cancel) e.Cancel = true;
            if (MeBox == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
