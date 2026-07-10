namespace c2_SP_Tasks.Task1
{
    public partial class _3_text : Form
    {
        public _3_text()
        {
            InitializeComponent();
        }

        Font font;

        private void Form5_Load(object sender, EventArgs e)
        {
            font = new Font("soyuz grotesk", 36, FontStyle.Bold);
            button1.Text = "Рисовать";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Text = String.Format("{0}", textBox1.Text);
            Brush Brush = new SolidBrush(Color.LimeGreen);
            Graphics G = pictureBox1.CreateGraphics();
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            G.DrawString(Text, font, Brush, 150, 50);
        }
    }
}
