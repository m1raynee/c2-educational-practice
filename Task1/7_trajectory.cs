using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task1
{
    public partial class _7_trajectory : Form
    {
        double initT = 0;
        double lastT = 6.3;
        double step = 0.05;
        double angle;

        int cX = 200;
        int cY = 200;
        int R2 = 120;
        int k;
        int R1;

        List<Point> trajectoryPoints = new List<Point>();

        int currentX1, currentY1; // центр окружности
        int currentX, currentY;   // точка окружности


        public _7_trajectory()
        {
            InitializeComponent();

            k = (int)numericUpDown1.Value;
            R1 = R2 / k;
            angle = initT;

            timer1.Interval = 40;
            timer1.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (angle <= lastT)
            {
                k = (int)numericUpDown1.Value;

                double x = R1 * (k - 1) * (Math.Cos(angle) + Math.Cos((k - 1) * angle) / (k - 1));
                double y = R1 * (k - 1) * (Math.Sin(angle) - Math.Sin((k - 1) * angle) / (k - 1));

                currentX = (int)x;
                currentY = (int)y;

                trajectoryPoints.Add(new Point(cX + currentX, cY + (int)y));

                currentX1 = (int)((R2 - R1) * Math.Cos(angle));
                currentY1 = (int)((R2 - R1) * Math.Sin(angle));

                angle += step;

                pictureBox1.Invalidate();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawEllipse(Pens.Blue, cX - R2, cY - R2, R2 * 2, R2 * 2);

            if (trajectoryPoints.Count > 1)
            {
                g.DrawLines(Pens.Red, trajectoryPoints.ToArray());
            }

            int circle1X = cX + currentX1;
            int circle1Y = cY + currentY1;
            g.DrawEllipse(Pens.Black, circle1X - R1, circle1Y - R1, R1 * 2, R1 * 2);

            g.DrawLine(Pens.Green, circle1X, circle1Y, cX + currentX, cY + currentY);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            angle = initT;
            k = (int)numericUpDown1.Value;
            R1 = R2 / k;
            trajectoryPoints.Clear();
            pictureBox1.Invalidate();
            timer1.Start();
        }

    }
}
