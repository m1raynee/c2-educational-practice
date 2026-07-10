namespace c2_SP_Tasks.Task1
{
    public partial class Form7 : Form
    {
        int[] m_p = new int[4];
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Text = "Рисуем Линию";
            button1.Text = "Рисовать";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_p[0] = Convert.ToInt32(textBox1.Text);
            m_p[1] = Convert.ToInt32(textBox2.Text);
            m_p[2] = Convert.ToInt32(textBox3.Text);
            m_p[3] = Convert.ToInt32(textBox4.Text);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Green, m_p[0], m_p[1], m_p[2], m_p[3]);
        }
    }
}
