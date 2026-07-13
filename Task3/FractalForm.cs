using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task3
{
    public partial class FractalForm : Form
    {
        FractalNode _rootNode;
        TreeForm _treeForm;
        int _xStepCounter = 0;

        float _offsetX, _offsetY;

        public static readonly Color[] LevelColors = new Color[]
        {
            Color.FromArgb(231, 76, 60),
            Color.FromArgb(230, 126, 34),
            Color.FromArgb(46, 204, 113),
            Color.FromArgb(52, 152, 219),
            Color.FromArgb(155, 89, 182),
            Color.FromArgb(26, 188, 156),
            Color.FromArgb(241, 196, 15)
        };

        public FractalForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BuildAndRender();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            DrawFractal();
        }

        private void FractalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_treeForm != null && !_treeForm.IsDisposed)
            {
                _treeForm.Close();
            }
        }

        private void BuildAndRender()
        {
            try
            {
                int maxLevel = (int)numericUpDown1.Value;

                // Инициализация корневого элемента фрактала (центральный круг)
                _rootNode = new FractalNode
                {
                    FractalX = 0,
                    FractalY = 0,
                    Radius = 100f,
                    Level = 0
                };

                double scaleFactor = (double)numericUpDown3.Value;
                GenerateFractalTree(_rootNode, maxLevel, -1, scaleFactor);

                _xStepCounter = 0;
                CalculateInitialTreeCoords(_rootNode, 0);

                DrawFractal();

                if (_treeForm == null || _treeForm.IsDisposed)
                {
                    _treeForm = new TreeForm();
                }

                _treeForm.Show();
                _treeForm.UpdateTree(_rootNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка построения фрактала: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateFractalTree(FractalNode parent, int maxLevel, double incomingAngle, double scale)
        {
            if (parent.Level >= maxLevel) return;

            float childRadius = parent.Radius * (float)scale;
            float distance = parent.Radius + childRadius;

            if (parent.Level == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    double angleDeg = i * 60.0;
                    double angleRad = angleDeg * Math.PI / 180.0;

                    var child = new FractalNode
                    {
                        FractalX = parent.FractalX + distance * (float)Math.Cos(angleRad),
                        FractalY = parent.FractalY + distance * (float)Math.Sin(angleRad),
                        Radius = childRadius,
                        Level = parent.Level + 1
                    };
                    parent.Children.Add(child);
                    GenerateFractalTree(child, maxLevel, angleDeg, scale);
                }
            }
            else
            {
                for (int i = -2; i <= 2; i++)
                {
                    double angleDeg = (incomingAngle + i * 60.0) % 360.0;
                    if (angleDeg < 0) angleDeg += 360.0;
                    double angleRad = angleDeg * Math.PI / 180.0;

                    var child = new FractalNode
                    {
                        FractalX = parent.FractalX + distance * (float)Math.Cos(angleRad),
                        FractalY = parent.FractalY + distance * (float)Math.Sin(angleRad),
                        Radius = childRadius,
                        Level = parent.Level + 1
                    };
                    parent.Children.Add(child);
                    GenerateFractalTree(child, maxLevel, angleDeg, scale);
                }
            }
        }

        private void CalculateInitialTreeCoords(FractalNode node, int depth)
        {
            if (node == null) return;

            node.TreeY = depth * 100;

            if (node.Children.Count == 0)
            {
                node.TreeX = _xStepCounter * 50;
                _xStepCounter++;
            }
            else
            {
                foreach (var child in node.Children)
                {
                    CalculateInitialTreeCoords(child, depth + 1);
                }

                float sumX = 0;
                foreach (var child in node.Children)
                {
                    sumX += child.TreeX;
                }
                node.TreeX = sumX / node.Children.Count;
            }
        }

        private void DrawFractal()
        {
            if (_rootNode == null) return;

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            if (width <= 0 || height <= 0) return;

            // Использование фонового Bitmap для исключения мерцания
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(255, 255, 255));

                float scaleFactor = (float)numericUpDown2.Value / 100f;

                float centerX = width / 2f + _offsetX;
                float centerY = height / 2f + _offsetY;

                RenderFractalNode(g, _rootNode, centerX, centerY, scaleFactor);
            }

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }

        private void RenderFractalNode(Graphics g, FractalNode node, float cx, float cy, float scale)
        {
            if (node == null) return;

            float screenX = cx + node.FractalX * scale;
            float screenY = cy + node.FractalY * scale;
            float screenRadius = node.Radius * scale;

            Color color = LevelColors[node.Level % LevelColors.Length];

            using (Pen pen = new Pen(color, 1.5f))
            using (Brush brush = new SolidBrush(Color.FromArgb(40, color)))
            {
                float diameter = screenRadius * 2;
                g.FillEllipse(brush, screenX - screenRadius, screenY - screenRadius, diameter, diameter);
                g.DrawEllipse(pen, screenX - screenRadius, screenY - screenRadius, diameter, diameter);
            }

            foreach (var child in parentChildNode(node))
            {
                RenderFractalNode(g, child, cx, cy, scale);
            }
        }

        private List<FractalNode> parentChildNode(FractalNode node)
        {
            return node.Children;
        }

        bool _isDragging = false;
        Point _lastMousePos;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePos = e.Location;
                pictureBox1.Cursor = Cursors.NoMove2D; // Интуитивно понятный курсор переноса
            }
        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
                pictureBox1.Cursor = Cursors.Default;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _rootNode != null)
            {
                // Вычисляем дельту сдвига мыши
                float deltaX = e.X - _lastMousePos.X;
                float deltaY = e.Y - _lastMousePos.Y;

                _offsetX += deltaX;
                _offsetY += deltaY;

                _lastMousePos = e.Location;
                DrawFractal();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new TaskDialog().ShowDialog();
        }
    }


    public class FractalNode
    {
        public float FractalX { get; set; }
        public float FractalY { get; set; }
        public float Radius { get; set; }
        public int Level { get; set; }

        public float TreeX { get; set; }
        public float TreeY { get; set; }

        public List<FractalNode> Children { get; set; } = new List<FractalNode>();
    }
}