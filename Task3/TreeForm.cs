using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace c2_SP_Tasks.Task3
{
    public partial class TreeForm : Form
    {
        private FractalNode _root;

        public TreeForm()
        {
            InitializeComponent();
        }

        public void UpdateTree(FractalNode newRoot)
        {
            _root = newRoot;
            DrawTree();
        }

        private void DrawTree()
        {
            if (_root == null) return;

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            if (width <= 0 || height <= 0) return;

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(255, 255, 255));

                float minX = float.MaxValue, maxX = float.MinValue;
                float minY = float.MaxValue, maxY = float.MinValue;
                FindTreeBounds(_root, ref minX, ref maxX, ref minY, ref maxY);

                float margin = 40f;
                float diffX = maxX - minX;
                float diffY = maxY - minY;

                float scaleX = diffX == 0 ? 1f : (width - 2 * margin) / diffX;
                float scaleY = diffY == 0 ? 1f : (height - 2 * margin) / diffY;

                RenderLevelScale(g, minY, scaleY, margin, width, GetMaxLevel(_root));

                RenderTreeEdges(g, _root, minX, minY, scaleX, scaleY, margin);

                RenderTreeNodes(g, _root, minX, minY, scaleX, scaleY, margin);
            }

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }

        private int GetMaxLevel(FractalNode node)
        {
            if (node == null) return 0;
            int max = node.Level;
            foreach (var child in node.Children)
            {
                max = Math.Max(max, GetMaxLevel(child));
            }
            return max;
        }

        private void RenderLevelScale(Graphics g, float minY, float scaleY, float width, float canvasWidth, int maxLevel)
        {
            for (int lvl = 0; lvl <= maxLevel; lvl++)
            {
                float rawY = lvl * 100;
                float screenY = width + (rawY - minY) * scaleY;

                Color levelColor = FractalForm.LevelColors[lvl % FractalForm.LevelColors.Length];

                using (Pen scalePen = new Pen(Color.FromArgb(45, levelColor), 1.2f))
                {
                    scalePen.DashStyle = DashStyle.Dash;
                    g.DrawLine(scalePen, 15f, screenY, canvasWidth - 15f, screenY);
                }

                string labelText = $"{lvl}";
                using (Font font = new Font("Segoe UI", 8.5f, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(180, levelColor)))
                using (Brush bgBrush = new SolidBrush(Color.FromArgb(180, Color.White)))
                {
                    SizeF textSize = g.MeasureString(labelText, font);

                    g.FillRectangle(bgBrush, 20f, screenY - textSize.Height / 2f, textSize.Width + 6f, textSize.Height);

                    g.DrawString(labelText, font, textBrush, 23f, screenY - textSize.Height / 2f + 1f);
                }
            }
        }

        private void FindTreeBounds(FractalNode node, ref float minX, ref float maxX, ref float minY, ref float maxY)
        {
            if (node == null) return;

            if (node.TreeX < minX) minX = node.TreeX;
            if (node.TreeX > maxX) maxX = node.TreeX;
            if (node.TreeY < minY) minY = node.TreeY;
            if (node.TreeY > maxY) maxY = node.TreeY;

            foreach (var child in node.Children)
            {
                FindTreeBounds(child, ref minX, ref maxX, ref minY, ref maxY);
            }
        }

        private void RenderTreeEdges(Graphics g, FractalNode node, float minX, float minY, float scaleX, float scaleY, float margin)
        {
            if (node == null) return;

            float parentX = margin + (node.TreeX - minX) * scaleX;
            float parentY = margin + (node.TreeY - minY) * scaleY;

            foreach (var child in node.Children)
            {
                float childX = margin + (child.TreeX - minX) * scaleX;
                float childY = margin + (child.TreeY - minY) * scaleY;

                Color edgeColor = FractalForm.LevelColors[child.Level % FractalForm.LevelColors.Length];

                using (Pen pen = new Pen(Color.FromArgb(160, edgeColor), 1.8f))
                {
                    g.DrawLine(pen, parentX, parentY, childX, childY);
                }

                RenderTreeEdges(g, child, minX, minY, scaleX, scaleY, margin);
            }
        }

        private void RenderTreeNodes(Graphics g, FractalNode node, float minX, float minY, float scaleX, float scaleY, float margin)
        {
            if (node == null) return;

            float screenX = margin + (node.TreeX - minX) * scaleX;
            float screenY = margin + (node.TreeY - minY) * scaleY;

            Color nodeColor = FractalForm.LevelColors[node.Level % FractalForm.LevelColors.Length];
            float nodeSize = 10f;

            using (Brush brush = new SolidBrush(nodeColor))
            using (Pen borderPen = new Pen(Color.White, 1.8f))
            {
                g.FillEllipse(brush, screenX - nodeSize / 2f, screenY - nodeSize / 2f, nodeSize, nodeSize);
                g.DrawEllipse(borderPen, screenX - nodeSize / 2f, screenY - nodeSize / 2f, nodeSize, nodeSize);
            }

            foreach (var child in node.Children)
            {
                RenderTreeNodes(g, child, minX, minY, scaleX, scaleY, margin);
            }
        }

        private void TreeForm_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            DrawTree();
        }
    }
}