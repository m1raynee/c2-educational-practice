namespace c2_SP_Tasks.Task1
{
    public partial class _2_simple : Form
    {
        public _2_simple()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Форма приветствия";
            label1.Text = "Name: ";
            label2.Text = "Напишите ваше имя.";
            button1.Text = "Ввод";

            toolTip1.SetToolTip(textBox1, "Введите\nваше имя");
            toolTip1.IsBalloon = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здравствуй " + textBox1.Text + "!", "Приветствие");
        }
    }
}

