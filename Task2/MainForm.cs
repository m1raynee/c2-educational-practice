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
    public partial class MainForm : Form
    {
        TrajectoryPath trajectory = new TrajectoryPath();

        PointF viewCenter = new PointF(-0.5f, 0.5f);
        float zoom = 140.0f;

        float globalTime = 0.0f;
        double circleT = 0;
        double hexagonT = 200;

        List<CustomBrushData> customBrushes = new List<CustomBrushData>();
        CustomBrushData defaultCircleBrush;
        CustomBrushData defaultHexagonBrush;
        CustomBrushData defaultCurveBrush;

        private Point mouseDragStart;
        private PointF viewCenterDragStart;
        private bool isDragging = false;



        public MainForm()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(pictureBox1, true, null);

            tObjectSpeed.Text = "1";
            tCircleSmallR.Text = "15";
            tCircleBigR.Text = "40";
            tCirclePulseSpeed.Text = "2.0";
            tHexagonR.Text = "35";
            tHexagonAngleSpeed.Text = "1.5";

            defaultCircleBrush = new CustomBrushData
            {
                Name = "Круг (по умолчанию)",
                Color = Color.FromArgb(255, 46, 147),
                Width = 2.5f,
                DashStyle = DashStyle.Solid
            };
            defaultHexagonBrush = new CustomBrushData
            {
                Name = "Шестиугольник (по умолчанию)",
                Color = Color.FromArgb(40, 215, 170),
                Width = 2.5f,
                DashStyle = DashStyle.Solid
            };
            defaultCurveBrush = new CustomBrushData
            {
                Name = "Траектория (по умолчанию)",
                Color = Color.FromArgb(215, 40, 100),
                Width = 2f,
                DashStyle = DashStyle.Solid
            };

            customBrushes.Add(defaultCircleBrush);
            customBrushes.Add(defaultHexagonBrush);
            customBrushes.Add(defaultCurveBrush);

            UpdateBrushComboBoxes();
            RebuildBrushMenu();

            ConfigureInputControls();

            cbCircleBrush.SelectedIndexChanged += (s, e) => pictureBox1.Invalidate();
            cbHexagonBrush.SelectedIndexChanged += (s, e) => pictureBox1.Invalidate();
            cbCurveBrush.SelectedIndexChanged += (s, e) => pictureBox1.Invalidate();

            BindControlsEvents();
            GenerateTrajectory();
        }


        private void ConfigureInputControls()
        {
            nXMin.Minimum = -100;
            nXMin.Maximum = 100;
            nXMin.DecimalPlaces = 2;
            nXMin.Increment = 0.5m;
            nXMin.Value = -3.5m;

            nXMax.Minimum = -100;
            nXMax.Maximum = 100;
            nXMax.DecimalPlaces = 2;
            nXMax.Increment = 0.5m;
            nXMax.Value = 2.5m;

            nSteps.Minimum = 10;
            nSteps.Maximum = 100000;
            nSteps.Increment = 100m;
            nSteps.Value = 4000m;

            numericUpDown1.Minimum = 0.001m;
            numericUpDown1.Maximum = 2.0m;
            numericUpDown1.DecimalPlaces = 3;
            numericUpDown1.Increment = 0.005m;
            numericUpDown1.Value = 0.010m;

            nCenterX.Minimum = -1000;
            nCenterX.Maximum = 1000;
            nCenterX.DecimalPlaces = 3;
            nCenterX.Increment = 0.1m;
            nCenterX.Value = -0.5m;

            nCenterY.Minimum = -1000;
            nCenterY.Maximum = 1000;
            nCenterY.DecimalPlaces = 3;
            nCenterY.Increment = 0.1m;
            nCenterY.Value = 0.5m;

            nZoom.Minimum = 5;
            nZoom.Maximum = 50000;
            nZoom.Increment = 10m;
            nZoom.Value = 140m;
        }

        private void BindControlsEvents()
        {
            nXMin.ValueChanged += (s, e) => GenerateTrajectory();
            nXMax.ValueChanged += (s, e) => GenerateTrajectory();
            nSteps.ValueChanged += (s, e) => GenerateTrajectory();
            numericUpDown1.ValueChanged += (s, e) => GenerateTrajectory();

            nCenterX.ValueChanged += (s, e) => UpdateViewParameters();
            nCenterY.ValueChanged += (s, e) => UpdateViewParameters();
            nZoom.ValueChanged += (s, e) => UpdateViewParameters();

            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            pictureBox1.Click += (s, e) => pictureBox1.Focus();
        }

        private void GenerateTrajectory()
        {
            double xMin = (double)nXMin.Value;
            double xMax = (double)nXMax.Value;
            int rawSteps = (int)nSteps.Value;
            double spacing = (double)numericUpDown1.Value;

            trajectory.Generate(xMin, xMax, rawSteps, spacing);
            pictureBox1.Invalidate();
        }

        private void UpdateViewParameters()
        {
            viewCenter = new PointF((float)nCenterX.Value, (float)nCenterY.Value);
            zoom = (float)nZoom.Value;
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDragStart = e.Location;
                viewCenterDragStart = viewCenter;
                isDragging = true;
                pictureBox1.Cursor = Cursors.NoMove2D;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                float dx = e.Location.X - mouseDragStart.X;
                float dy = e.Location.Y - mouseDragStart.Y;

                float mathDx = dx / zoom;
                float mathDy = dy / zoom;

                float newCenterX = viewCenterDragStart.X - mathDx;
                float newCenterY = viewCenterDragStart.Y + mathDy;

                nCenterX.Value = Math.Max(nCenterX.Minimum, Math.Min(nCenterX.Maximum, (decimal)newCenterX));
                nCenterY.Value = Math.Max(nCenterY.Minimum, Math.Min(nCenterY.Maximum, (decimal)newCenterY));
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                pictureBox1.Cursor = Cursors.Default;
            }
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            float zoomFactor = 1.15f;
            float currentZoom = (float)nZoom.Value;

            if (e.Delta > 0)
            {
                currentZoom = Math.Min((float)nZoom.Maximum, currentZoom * zoomFactor);
            }
            else
            {
                currentZoom = Math.Max((float)nZoom.Minimum, currentZoom / zoomFactor);
            }

            nZoom.Value = (decimal)currentZoom;
        }



        private void UpdateBrushComboBoxes()
        {
            var selectedCircle = cbCircleBrush.SelectedItem as CustomBrushData;
            var selectedHexagon = cbHexagonBrush.SelectedItem as CustomBrushData;
            var selectedCurve = cbCurveBrush.SelectedItem as CustomBrushData;


            cbCircleBrush.Items.Clear();
            cbHexagonBrush.Items.Clear();
            cbCurveBrush.Items.Clear();


            foreach (var brush in customBrushes)
            {
                cbCircleBrush.Items.Add(brush);
                cbHexagonBrush.Items.Add(brush);
                cbCurveBrush.Items.Add(brush);
            }

            if (selectedCircle != null && cbCircleBrush.Items.Contains(selectedCircle))
                cbCircleBrush.SelectedItem = selectedCircle;
            else if (cbCircleBrush.Items.Count > 0)
                cbCircleBrush.SelectedItem = defaultCircleBrush;

            if (selectedHexagon != null && cbHexagonBrush.Items.Contains(selectedHexagon))
                cbHexagonBrush.SelectedItem = selectedHexagon;
            else if (cbHexagonBrush.Items.Count > 0)
                cbHexagonBrush.SelectedItem = defaultHexagonBrush;

            if (selectedCurve != null && cbCurveBrush.Items.Contains(selectedCurve))
                cbCurveBrush.SelectedItem = selectedCurve;
            else if (cbCurveBrush.Items.Count > 0)
                cbCurveBrush.SelectedItem = defaultCurveBrush;
        }

        private void RebuildBrushMenu()
        {
            while (кистиToolStripMenuItem.DropDownItems.Count > 2)
            {
                кистиToolStripMenuItem.DropDownItems.RemoveAt(2);
            }

            foreach (var brush in customBrushes)
            {
                var item = new ToolStripMenuItem(brush.ToString());
                item.Tag = brush;
                item.Click += BrushMenuItem_Click;
                кистиToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void BrushMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is CustomBrushData brush)
            {
                MessageBox.Show(
                    $"Свойства кисти:\n\n" +
                    $"Название: {brush.Name}\n" +
                    $"Цвет: {brush.Color.Name} (R:{brush.Color.R}, G:{brush.Color.G}, B:{brush.Color.B})\n" +
                    $"Ширина: {brush.Width}px\n" +
                    $"Стиль: {brush.DashStyle}",
                    "Информация о кисти",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private float GetFloatFromTextBox(TextBox textBox, float defaultValue)
        {
            if (float.TryParse(textBox.Text, out float value))
            {
                return value;
            }
            else
            {
                textBox.Text = defaultValue.ToString();
                return defaultValue;
            }
        }

        #region Колбеки событий

        private void bStartPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                bStartPause.Text = "СТАРТ";
            }
            else
            {
                timer1.Start();
                bStartPause.Text = "ПАУЗА";
            }
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            circleT = 0;
            hexagonT = 200;
            pictureBox1.Invalidate();
        }

        private void создатьКистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BrushDialog dialog = new BrushDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string brushName = $"Кисть #{customBrushes.Count + 1}";
                    var newBrush = new CustomBrushData
                    {
                        Name = brushName,
                        Color = dialog.ChosenColor,
                        Width = dialog.ChosenWidth,
                        DashStyle = dialog.ChosenDashStyle,
                        CustomPattern = dialog.ChosenCustomPattern
                    };

                    customBrushes.Add(newBrush);

                    UpdateBrushComboBoxes();
                    RebuildBrushMenu();
                }
            }
        }

        #endregion

        private PointF MathToScreen(PointF mathPt)
        {
            float x = (pictureBox1.Width / 2f) + (mathPt.X - viewCenter.X) * zoom;
            float y = (pictureBox1.Height / 2f) - (mathPt.Y - viewCenter.Y) * zoom;
            return new PointF(x, y);
        }

        private PointF ScreenToMath(PointF screenPt)
        {
            float x = (screenPt.X - pictureBox1.Width / 2f) / zoom + viewCenter.X;
            float y = (pictureBox1.Height / 2f - screenPt.Y) / zoom + viewCenter.Y;
            return new PointF(x, y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (trajectory.EquidistantPoints.Count == 0) return;

            globalTime += 0.025f;

            double speedFactor = GetFloatFromTextBox(tObjectSpeed, 2.5f);

            circleT += speedFactor;
            hexagonT += speedFactor;

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(255, 255, 255));

            // 1. отрисовка осей и координатной сетки
            DrawAxesAndGrid(g);

            // 2. отрисовка траектории x^3 + y^3 = 1
            DrawCurve(g);

            if (trajectory.EquidistantPoints.Count == 0) return;

            // 3. расчет и отрисовка круг
            DrawCircleObject(g);

            // 4. расчет и отрисовка шестиугольник
            DrawHexagonObject(g);
        }

        private void DrawAxesAndGrid(Graphics g)
        {
            float gridStep = 1.0f;

            using (Pen gridPen = new Pen(Color.FromArgb(50, 50, 50), 1f))
            using (Pen axisPen = new Pen(Color.FromArgb(0, 0, 0), 1.5f))
            using (Font font = new Font("Segoe UI", 8.5f))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(20, 20, 20)))
            {
                PointF minMath = ScreenToMath(new PointF(0, pictureBox1.Height));
                PointF maxMath = ScreenToMath(new PointF(pictureBox1.Width, 0));

                float startX = (float)(Math.Floor(minMath.X / gridStep) * gridStep);
                float endX = (float)(Math.Ceiling(maxMath.X / gridStep) * gridStep);
                float startY = (float)(Math.Floor(minMath.Y / gridStep) * gridStep);
                float endY = (float)(Math.Ceiling(maxMath.Y / gridStep) * gridStep);

                // вертикальная разметка
                for (float x = startX; x <= endX; x += gridStep)
                {
                    PointF pStart = MathToScreen(new PointF(x, minMath.Y));
                    PointF pEnd = MathToScreen(new PointF(x, maxMath.Y));
                    g.DrawLine(gridPen, pStart, pEnd);

                    PointF pZeroY = MathToScreen(new PointF(x, 0));
                    g.DrawString(x.ToString("0.0"), font, textBrush, pZeroY.X + 2, Math.Min(pictureBox1.Height - 18, Math.Max(5, pZeroY.Y + 2)));
                }

                // горизонтальная разметка
                for (float y = startY; y <= endY; y += gridStep)
                {
                    PointF pStart = MathToScreen(new PointF(minMath.X, y));
                    PointF pEnd = MathToScreen(new PointF(maxMath.X, y));
                    g.DrawLine(gridPen, pStart, pEnd);

                    PointF pZeroX = MathToScreen(new PointF(0, y));
                    g.DrawString(y.ToString("0.0"), font, textBrush, Math.Min(pictureBox1.Width - 30, Math.Max(5, pZeroX.X + 5)), pZeroX.Y - 14);
                }

                // ох и оу
                PointF origin = MathToScreen(new PointF(0, 0));
                g.DrawLine(axisPen, 0, origin.Y, pictureBox1.Width, origin.Y);
                g.DrawLine(axisPen, origin.X, 0, origin.X, pictureBox1.Height);
            }
        }

        private void DrawCurve(Graphics g)
        {
            if (trajectory.EquidistantPoints.Count < 2) return;


            CustomBrushData activeBrush = cbCurveBrush.SelectedItem as CustomBrushData ?? defaultCurveBrush;
            using (Pen curvePen = activeBrush.CreatePen())
            {
                List<PointF> screenPoints = new List<PointF>();
                foreach (var pt in trajectory.EquidistantPoints)
                {
                    screenPoints.Add(MathToScreen(pt));
                }
                g.DrawLines(curvePen, screenPoints.ToArray());
            }
        }

        private void DrawCircleObject(Graphics g)
        {
            int count = trajectory.EquidistantPoints.Count;
            int index = ((int)circleT % count + count) % count;
            PointF mathPos = trajectory.EquidistantPoints[index];
            PointF screenPos = MathToScreen(mathPos);

            float rMin = GetFloatFromTextBox(tCircleSmallR, 10f);
            float rMax = GetFloatFromTextBox(tCircleBigR, 40f);
            float pSpeed = GetFloatFromTextBox(tCirclePulseSpeed, 1f);

            if (rMax < rMin) rMax = rMin + 5;

            float currentRadius = rMin + (rMax - rMin) * 0.5f * (1.0f + (float)Math.Sin(globalTime * pSpeed));

            CustomBrushData activeBrush = cbCircleBrush.SelectedItem as CustomBrushData ?? defaultCircleBrush;

            using (Pen circlePen = activeBrush.CreatePen())
            {
                g.DrawEllipse(circlePen, screenPos.X - currentRadius, screenPos.Y - currentRadius, currentRadius * 2, currentRadius * 2);
            }

            using (Brush brush = new SolidBrush(activeBrush.Color))
            {
                g.FillEllipse(brush, screenPos.X - 3, screenPos.Y - 3, 6, 6);
            }
        }

        private void DrawHexagonObject(Graphics g)
        {
            int count = trajectory.EquidistantPoints.Count;
            int index = ((int)hexagonT % count + count) % count;
            PointF mathPos = trajectory.EquidistantPoints[index];
            PointF touchPoint = MathToScreen(mathPos);

            float hexR = GetFloatFromTextBox(tHexagonR, 30f);
            float rotSpeed = GetFloatFromTextBox(tHexagonAngleSpeed, 1f);

            float angle = globalTime * rotSpeed;

            PointF[] vertices = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                float a = angle + i * (float)Math.PI / 3f;
                vertices[i] = new PointF(hexR * (float)Math.Cos(a), hexR * (float)Math.Sin(a));
            }

            float dx = touchPoint.X - vertices[0].X;
            float dy = touchPoint.Y - vertices[0].Y;

            for (int i = 0; i < 6; i++)
            {
                vertices[i].X += dx;
                vertices[i].Y += dy;
            }

            CustomBrushData activeBrush = cbHexagonBrush.SelectedItem as CustomBrushData ?? defaultHexagonBrush;

            using (Pen hexPen = activeBrush.CreatePen())
            {
                g.DrawPolygon(hexPen, vertices);
            }

            using (Brush touchBrush = new SolidBrush(activeBrush.Color))
            {
                g.FillEllipse(touchBrush, touchPoint.X - 4, touchPoint.Y - 4, 8, 8);
            }
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class CustomBrushData
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public float Width { get; set; }
        public DashStyle DashStyle { get; set; }
        public float[] CustomPattern { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Color.Name}, {Width}px, {DashStyle})";
        }

        public Pen CreatePen()
        {
            Pen pen = new Pen(Color, Width);
            pen.DashStyle = DashStyle;
            if (DashStyle == DashStyle.Custom && CustomPattern != null)
            {
                pen.DashPattern = CustomPattern;
            }
            return pen;
        }
    }


    public class TrajectoryPath
    {
        public List<PointF> RawPoints { get; private set; } = new List<PointF>();
        public List<PointF> EquidistantPoints { get; private set; } = new List<PointF>();
        public double TotalLength { get; private set; }

        public void Generate(double xMin, double xMax, int rawSteps, double spacing)
        {
            RawPoints.Clear();
            EquidistantPoints.Clear();

            // 1. базовые точки y = (1 - x^3)^(1/3)
            for (int i = 0; i <= rawSteps; i++)
            {
                double t = (double)i / rawSteps;
                double x = xMin + t * (xMax - xMin);
                double y = CubeRoot(1.0 - x * x * x);
                RawPoints.Add(new PointF((float)x, (float)y));
            }

            if (RawPoints.Count < 2) return;

            // 2. интегральный расчет длинны дуги
            double accumLength = 0;
            List<double> distances = new List<double> { 0 };
            for (int i = 1; i < RawPoints.Count; i++)
            {
                double dx = RawPoints[i].X - RawPoints[i - 1].X;
                double dy = RawPoints[i].Y - RawPoints[i - 1].Y;
                double dist = Math.Sqrt(dx * dx + dy * dy);
                accumLength += dist;
                distances.Add(accumLength);
            }
            TotalLength = accumLength;

            // 3. расстановка точек анимации по равным интервалам
            double currentDist = 0;
            int rawIdx = 0;
            while (currentDist <= TotalLength)
            {
                while (rawIdx < distances.Count - 1 && distances[rawIdx + 1] < currentDist)
                {
                    rawIdx++;
                }
                if (rawIdx >= distances.Count - 1)
                {
                    EquidistantPoints.Add(RawPoints[RawPoints.Count - 1]);
                    break;
                }
                double t = (currentDist - distances[rawIdx]) / (distances[rawIdx + 1] - distances[rawIdx]);
                float x = (float)(RawPoints[rawIdx].X + t * (RawPoints[rawIdx + 1].X - RawPoints[rawIdx].X));
                float y = (float)(RawPoints[rawIdx].Y + t * (RawPoints[rawIdx + 1].Y - RawPoints[rawIdx].Y));
                EquidistantPoints.Add(new PointF(x, y));
                currentDist += spacing;
            }
        }

        private double CubeRoot(double val)
        {
            return val >= 0 ? Math.Pow(val, 1.0 / 3.0) : -Math.Pow(-val, 1.0 / 3.0);
        }
    }
}