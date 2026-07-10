using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task2
{
    public partial class BrushDialog : Form
    {
        public Color ChosenColor { get; private set; } = Color.Black;
        public float ChosenWidth { get; private set; } = 5;
        public DashStyle ChosenDashStyle { get; private set; } = DashStyle.Solid;
        public float[] ChosenCustomPattern { get; private set; } = null;

        public BrushDialog()
        {
            InitializeComponent();

            // Привязываем кнопку "Сохранить" к закрытию с результатом OK
            bSave.DialogResult = DialogResult.OK;

            // Начальные настройки элементов интерфейса
            cType.SelectedIndex = 0;
            tPattern.Enabled = false;

            // подписка на события
            cType.SelectedIndexChanged += UpdatePreview;
            tPattern.TextChanged += UpdatePreview;
            nWidth.ValueChanged += UpdatePreview;

            bColor.Click += bColor_Click;
            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.SizeChanged += (s, e) => pictureBox1.Invalidate();
        }

        private void bColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = bColor.BackColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    bColor.BackColor = cd.Color;
                    ChosenColor = cd.Color;
                    pictureBox1.Invalidate(); // Заставляем превью перерисоваться
                }
            }
        }

        private void UpdatePreview(object sender, EventArgs e)
        {
            tPattern.Enabled = (cType.SelectedIndex == 4);

            ChosenWidth = (float)nWidth.Value;

            switch (cType.SelectedIndex)
            {
                case 0: ChosenDashStyle = DashStyle.Solid; break;
                case 1: ChosenDashStyle = DashStyle.Dash; break;
                case 2: ChosenDashStyle = DashStyle.Dot; break;
                case 3: ChosenDashStyle = DashStyle.DashDot; break;
                case 4: ChosenDashStyle = DashStyle.Custom; break;
            }

            if (ChosenDashStyle == DashStyle.Custom)
            {
                ChosenCustomPattern = ParsePattern(tPattern.Text);
            }
            else
            {
                ChosenCustomPattern = null;
            }
            pictureBox1.Invalidate();
        }

        private float[] ParsePattern(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;

            try
            {
                var numbers = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(n => float.Parse(n))
                                  .Where(n => n > 0)
                                  .ToArray();

                return numbers.Length > 0 ? numbers : null;
            }
            catch
            {
                return null;
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int diameter = (int)(Math.Min(pictureBox1.Width, pictureBox1.Height) * 0.6);

            int x = (pictureBox1.Width - diameter) / 2;
            int y = (pictureBox1.Height - diameter) / 2;

            using (Pen pen = new Pen(ChosenColor, ChosenWidth))
            {
                pen.DashStyle = ChosenDashStyle;

                if (ChosenDashStyle == DashStyle.Custom && ChosenCustomPattern != null)
                {
                    pen.DashPattern = ChosenCustomPattern;
                }

                g.DrawEllipse(pen, x, y, diameter, diameter);
            }
        }
    }
}