using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace c2_SP_Tasks.Task2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainLayout = new TableLayoutPanel();
            panelControls = new FlowLayoutPanel();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            bStartPause = new Button();
            bReset = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            tObjectSpeed = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            circleControlsLayout = new TableLayoutPanel();
            cbCircleBrush = new ComboBox();
            label7 = new Label();
            tCirclePulseSpeed = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            tCircleSmallR = new TextBox();
            tCircleBigR = new TextBox();
            panel2 = new Panel();
            label8 = new Label();
            hexagonControlsLayout = new TableLayoutPanel();
            label9 = new Label();
            tHexagonAngleSpeed = new TextBox();
            label10 = new Label();
            label12 = new Label();
            tHexagonR = new TextBox();
            cbHexagonBrush = new ComboBox();
            panel3 = new Panel();
            label11 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            nZoom = new NumericUpDown();
            label20 = new Label();
            nCenterX = new NumericUpDown();
            label17 = new Label();
            numericUpDown1 = new NumericUpDown();
            label19 = new Label();
            label18 = new Label();
            nCenterY = new NumericUpDown();
            nSteps = new NumericUpDown();
            label16 = new Label();
            nXMax = new NumericUpDown();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            cbCurveBrush = new ComboBox();
            nXMin = new NumericUpDown();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            colorDialog1 = new ColorDialog();
            menuStrip1 = new MenuStrip();
            кистиToolStripMenuItem = new ToolStripMenuItem();
            создатьКистьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mainLayout.SuspendLayout();
            panelControls.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            circleControlsLayout.SuspendLayout();
            hexagonControlsLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nZoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nCenterX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nCenterY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nSteps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nXMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nXMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 340F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(panelControls, 0, 0);
            mainLayout.Controls.Add(pictureBox1, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 24);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.Size = new Size(1129, 684);
            mainLayout.TabIndex = 0;
            // 
            // panelControls
            // 
            panelControls.AutoScroll = true;
            panelControls.Controls.Add(label1);
            panelControls.Controls.Add(flowLayoutPanel1);
            panelControls.Controls.Add(flowLayoutPanel2);
            panelControls.Controls.Add(panel1);
            panelControls.Controls.Add(label3);
            panelControls.Controls.Add(circleControlsLayout);
            panelControls.Controls.Add(panel2);
            panelControls.Controls.Add(label8);
            panelControls.Controls.Add(hexagonControlsLayout);
            panelControls.Controls.Add(panel3);
            panelControls.Controls.Add(label11);
            panelControls.Controls.Add(tableLayoutPanel1);
            panelControls.Dock = DockStyle.Fill;
            panelControls.FlowDirection = FlowDirection.TopDown;
            panelControls.Location = new Point(3, 3);
            panelControls.Name = "panelControls";
            panelControls.Padding = new Padding(15);
            panelControls.Size = new Size(334, 678);
            panelControls.TabIndex = 0;
            panelControls.Paint += panelControls_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 15);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 0;
            label1.Text = "Настройки симуляции";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(bStartPause);
            flowLayoutPanel1.Controls.Add(bReset);
            flowLayoutPanel1.Location = new Point(18, 33);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(300, 45);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // bStartPause
            // 
            bStartPause.Location = new Point(3, 3);
            bStartPause.Name = "bStartPause";
            bStartPause.Size = new Size(135, 36);
            bStartPause.TabIndex = 0;
            bStartPause.Text = "ПАУЗА";
            bStartPause.UseVisualStyleBackColor = true;
            bStartPause.Click += bStartPause_Click;
            // 
            // bReset
            // 
            bReset.Location = new Point(144, 3);
            bReset.Name = "bReset";
            bReset.Size = new Size(135, 36);
            bReset.TabIndex = 1;
            bReset.Text = "СБРОС";
            bReset.UseVisualStyleBackColor = true;
            bReset.Click += bReset_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(tObjectSpeed);
            flowLayoutPanel2.Location = new Point(18, 84);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(300, 30);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(173, 29);
            label2.TabIndex = 2;
            label2.Text = "Скорость движения объектов:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tObjectSpeed
            // 
            tObjectSpeed.Location = new Point(182, 3);
            tObjectSpeed.Name = "tObjectSpeed";
            tObjectSpeed.Size = new Size(115, 23);
            tObjectSpeed.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(18, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 1);
            panel1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 124);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 6;
            label3.Text = "Объект №1: Круг";
            // 
            // circleControlsLayout
            // 
            circleControlsLayout.ColumnCount = 2;
            circleControlsLayout.ColumnStyles.Add(new ColumnStyle());
            circleControlsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            circleControlsLayout.Controls.Add(cbCircleBrush, 1, 3);
            circleControlsLayout.Controls.Add(label7, 0, 3);
            circleControlsLayout.Controls.Add(tCirclePulseSpeed, 1, 2);
            circleControlsLayout.Controls.Add(label6, 0, 2);
            circleControlsLayout.Controls.Add(label4, 0, 0);
            circleControlsLayout.Controls.Add(label5, 0, 1);
            circleControlsLayout.Controls.Add(tCircleSmallR, 1, 0);
            circleControlsLayout.Controls.Add(tCircleBigR, 1, 1);
            circleControlsLayout.Location = new Point(18, 142);
            circleControlsLayout.Name = "circleControlsLayout";
            circleControlsLayout.RowCount = 4;
            circleControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            circleControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            circleControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            circleControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            circleControlsLayout.Size = new Size(300, 120);
            circleControlsLayout.TabIndex = 7;
            // 
            // cbCircleBrush
            // 
            cbCircleBrush.Dock = DockStyle.Fill;
            cbCircleBrush.FormattingEnabled = true;
            cbCircleBrush.Location = new Point(130, 93);
            cbCircleBrush.Name = "cbCircleBrush";
            cbCircleBrush.Size = new Size(167, 23);
            cbCircleBrush.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 90);
            label7.Name = "label7";
            label7.Size = new Size(121, 30);
            label7.TabIndex = 6;
            label7.Text = "Кисть контура:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tCirclePulseSpeed
            // 
            tCirclePulseSpeed.Dock = DockStyle.Fill;
            tCirclePulseSpeed.Location = new Point(130, 63);
            tCirclePulseSpeed.Name = "tCirclePulseSpeed";
            tCirclePulseSpeed.Size = new Size(167, 23);
            tCirclePulseSpeed.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 60);
            label6.Name = "label6";
            label6.Size = new Size(121, 30);
            label6.TabIndex = 4;
            label6.Text = "Скорость пульсации";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 30);
            label4.TabIndex = 0;
            label4.Text = "Мин. радиус (r)";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 30);
            label5.Name = "label5";
            label5.Size = new Size(121, 30);
            label5.TabIndex = 1;
            label5.Text = "Макс. радиус (R)";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tCircleSmallR
            // 
            tCircleSmallR.Dock = DockStyle.Fill;
            tCircleSmallR.Location = new Point(130, 3);
            tCircleSmallR.Name = "tCircleSmallR";
            tCircleSmallR.Size = new Size(167, 23);
            tCircleSmallR.TabIndex = 2;
            // 
            // tCircleBigR
            // 
            tCircleBigR.Dock = DockStyle.Fill;
            tCircleBigR.Location = new Point(130, 33);
            tCircleBigR.Name = "tCircleBigR";
            tCircleBigR.Size = new Size(167, 23);
            tCircleBigR.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(18, 268);
            panel2.Name = "panel2";
            panel2.Size = new Size(290, 1);
            panel2.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 272);
            label8.Name = "label8";
            label8.Size = new Size(161, 15);
            label8.TabIndex = 10;
            label8.Text = "Объект №2: Шестиугольник";
            // 
            // hexagonControlsLayout
            // 
            hexagonControlsLayout.AutoSize = true;
            hexagonControlsLayout.ColumnCount = 2;
            hexagonControlsLayout.ColumnStyles.Add(new ColumnStyle());
            hexagonControlsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            hexagonControlsLayout.Controls.Add(label9, 0, 2);
            hexagonControlsLayout.Controls.Add(tHexagonAngleSpeed, 1, 1);
            hexagonControlsLayout.Controls.Add(label10, 0, 1);
            hexagonControlsLayout.Controls.Add(label12, 0, 0);
            hexagonControlsLayout.Controls.Add(tHexagonR, 1, 0);
            hexagonControlsLayout.Controls.Add(cbHexagonBrush, 1, 2);
            hexagonControlsLayout.Location = new Point(18, 290);
            hexagonControlsLayout.Name = "hexagonControlsLayout";
            hexagonControlsLayout.RowCount = 3;
            hexagonControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            hexagonControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            hexagonControlsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            hexagonControlsLayout.Size = new Size(300, 90);
            hexagonControlsLayout.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 60);
            label9.Name = "label9";
            label9.Size = new Size(179, 30);
            label9.TabIndex = 6;
            label9.Text = "Кисть контура:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tHexagonAngleSpeed
            // 
            tHexagonAngleSpeed.Dock = DockStyle.Fill;
            tHexagonAngleSpeed.Location = new Point(188, 33);
            tHexagonAngleSpeed.Name = "tHexagonAngleSpeed";
            tHexagonAngleSpeed.Size = new Size(109, 23);
            tHexagonAngleSpeed.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 30);
            label10.Name = "label10";
            label10.Size = new Size(179, 30);
            label10.TabIndex = 4;
            label10.Text = "Скорость вращения";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(3, 0);
            label12.Name = "label12";
            label12.Size = new Size(179, 30);
            label12.TabIndex = 1;
            label12.Text = "Радиус описанной окружности";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tHexagonR
            // 
            tHexagonR.Dock = DockStyle.Fill;
            tHexagonR.Location = new Point(188, 3);
            tHexagonR.Name = "tHexagonR";
            tHexagonR.Size = new Size(109, 23);
            tHexagonR.TabIndex = 3;
            // 
            // cbHexagonBrush
            // 
            cbHexagonBrush.Dock = DockStyle.Fill;
            cbHexagonBrush.FormattingEnabled = true;
            cbHexagonBrush.Location = new Point(188, 63);
            cbHexagonBrush.Name = "cbHexagonBrush";
            cbHexagonBrush.Size = new Size(109, 23);
            cbHexagonBrush.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Location = new Point(18, 386);
            panel3.Name = "panel3";
            panel3.Size = new Size(290, 1);
            panel3.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 390);
            label11.Name = "label11";
            label11.Size = new Size(71, 15);
            label11.TabIndex = 14;
            label11.Text = "Траектория";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(nZoom, 1, 6);
            tableLayoutPanel1.Controls.Add(label20, 0, 6);
            tableLayoutPanel1.Controls.Add(nCenterX, 1, 5);
            tableLayoutPanel1.Controls.Add(label17, 0, 5);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 1, 3);
            tableLayoutPanel1.Controls.Add(label19, 0, 3);
            tableLayoutPanel1.Controls.Add(label18, 0, 4);
            tableLayoutPanel1.Controls.Add(nCenterY, 1, 4);
            tableLayoutPanel1.Controls.Add(nSteps, 1, 2);
            tableLayoutPanel1.Controls.Add(label16, 0, 2);
            tableLayoutPanel1.Controls.Add(nXMax, 1, 1);
            tableLayoutPanel1.Controls.Add(label15, 0, 1);
            tableLayoutPanel1.Controls.Add(label14, 0, 0);
            tableLayoutPanel1.Controls.Add(label13, 0, 7);
            tableLayoutPanel1.Controls.Add(cbCurveBrush, 1, 7);
            tableLayoutPanel1.Controls.Add(nXMin, 1, 0);
            tableLayoutPanel1.Location = new Point(18, 408);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(300, 240);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // nZoom
            // 
            nZoom.Location = new Point(107, 183);
            nZoom.Name = "nZoom";
            nZoom.Size = new Size(120, 23);
            nZoom.TabIndex = 25;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Dock = DockStyle.Fill;
            label20.Location = new Point(3, 180);
            label20.Name = "label20";
            label20.Size = new Size(98, 30);
            label20.TabIndex = 24;
            label20.Text = "Масштаб:";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nCenterX
            // 
            nCenterX.DecimalPlaces = 1;
            nCenterX.Location = new Point(107, 153);
            nCenterX.Name = "nCenterX";
            nCenterX.Size = new Size(120, 23);
            nCenterX.TabIndex = 23;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Dock = DockStyle.Fill;
            label17.Location = new Point(3, 150);
            label17.Name = "label17";
            label17.Size = new Size(98, 30);
            label17.TabIndex = 22;
            label17.Text = "Центр X:";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 3;
            numericUpDown1.Location = new Point(107, 93);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 21;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Dock = DockStyle.Fill;
            label19.Location = new Point(3, 90);
            label19.Name = "label19";
            label19.Size = new Size(98, 30);
            label19.TabIndex = 20;
            label19.Text = "Длина шага:";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Dock = DockStyle.Fill;
            label18.Location = new Point(3, 120);
            label18.Name = "label18";
            label18.Size = new Size(98, 30);
            label18.TabIndex = 18;
            label18.Text = "Центр Y:";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nCenterY
            // 
            nCenterY.DecimalPlaces = 1;
            nCenterY.Location = new Point(107, 123);
            nCenterY.Name = "nCenterY";
            nCenterY.Size = new Size(120, 23);
            nCenterY.TabIndex = 17;
            // 
            // nSteps
            // 
            nSteps.Location = new Point(107, 63);
            nSteps.Name = "nSteps";
            nSteps.Size = new Size(120, 23);
            nSteps.TabIndex = 13;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Dock = DockStyle.Fill;
            label16.Location = new Point(3, 60);
            label16.Name = "label16";
            label16.Size = new Size(98, 30);
            label16.TabIndex = 12;
            label16.Text = "Шаги простчёта:";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nXMax
            // 
            nXMax.DecimalPlaces = 1;
            nXMax.Location = new Point(107, 33);
            nXMax.Name = "nXMax";
            nXMax.Size = new Size(120, 23);
            nXMax.TabIndex = 11;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Dock = DockStyle.Fill;
            label15.Location = new Point(3, 30);
            label15.Name = "label15";
            label15.Size = new Size(98, 30);
            label15.TabIndex = 10;
            label15.Text = "xMax:";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(3, 0);
            label14.Name = "label14";
            label14.Size = new Size(98, 30);
            label14.TabIndex = 8;
            label14.Text = "xMin:";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Location = new Point(3, 210);
            label13.Name = "label13";
            label13.Size = new Size(98, 30);
            label13.TabIndex = 6;
            label13.Text = "Кисть контура:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbCurveBrush
            // 
            cbCurveBrush.Dock = DockStyle.Fill;
            cbCurveBrush.FormattingEnabled = true;
            cbCurveBrush.Location = new Point(107, 213);
            cbCurveBrush.Name = "cbCurveBrush";
            cbCurveBrush.Size = new Size(190, 23);
            cbCurveBrush.TabIndex = 7;
            // 
            // nXMin
            // 
            nXMin.DecimalPlaces = 1;
            nXMin.Location = new Point(107, 3);
            nXMin.Name = "nXMin";
            nXMin.Size = new Size(120, 23);
            nXMin.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(343, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(783, 678);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 16;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { кистиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1129, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // кистиToolStripMenuItem
            // 
            кистиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьКистьToolStripMenuItem, toolStripSeparator1 });
            кистиToolStripMenuItem.Name = "кистиToolStripMenuItem";
            кистиToolStripMenuItem.Size = new Size(51, 20);
            кистиToolStripMenuItem.Text = "Кисти";
            // 
            // создатьКистьToolStripMenuItem
            // 
            создатьКистьToolStripMenuItem.Name = "создатьКистьToolStripMenuItem";
            создатьКистьToolStripMenuItem.Size = new Size(159, 22);
            создатьКистьToolStripMenuItem.Text = "Создать кисть...";
            создатьКистьToolStripMenuItem.Click += создатьКистьToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(156, 6);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1129, 708);
            Controls.Add(mainLayout);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1000, 700);
            Name = "MainForm";
            Text = "Form1";
            mainLayout.ResumeLayout(false);
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            circleControlsLayout.ResumeLayout(false);
            circleControlsLayout.PerformLayout();
            hexagonControlsLayout.ResumeLayout(false);
            hexagonControlsLayout.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nZoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nCenterX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nCenterY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nSteps).EndInit();
            ((System.ComponentModel.ISupportInitialize)nXMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nXMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private FlowLayoutPanel panelControls;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button bStartPause;
        private Button bReset;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private TableLayoutPanel circleControlsLayout;
        private Label label4;
        private Label label5;
        private TextBox tCircleSmallR;
        private TextBox tCircleBigR;
        private Label label6;
        private TextBox tCirclePulseSpeed;
        private Panel panel2;
        private Label label8;
        private TableLayoutPanel hexagonControlsLayout;
        private TextBox tHexagonAngleSpeed;
        private Label label10;
        private Label label12;
        private TextBox tHexagonR;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private ColorDialog colorDialog1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox tObjectSpeed;
        private Label label7;
        private Label label9;
        private ComboBox cbCircleBrush;
        private ComboBox cbHexagonBrush;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem кистиToolStripMenuItem;
        private ToolStripMenuItem создатьКистьToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel3;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label13;
        private ComboBox cbCurveBrush;
        private Label label16;
        private NumericUpDown nXMax;
        private Label label15;
        private Label label14;
        private NumericUpDown nXMin;
        private NumericUpDown nCenterY;
        private NumericUpDown nSteps;
        private Label label19;
        private Label label18;
        private NumericUpDown nZoom;
        private Label label20;
        private NumericUpDown nCenterX;
        private Label label17;
        private NumericUpDown numericUpDown1;
    }
}