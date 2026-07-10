namespace c2_SP_Tasks.Task1
{
    public partial class _1_simple : Form
    {
        public _1_simple()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }
    }
}

