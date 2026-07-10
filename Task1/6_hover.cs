namespace c2_SP_Tasks.Task1
{
    public partial class _6_hover : Form
    {
        public _6_hover()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "ERROR!!!";
            label1.ForeColor = Color.Red;
            MessageBox.Show("Написано же\nНЕ трогать!", "Fatal ERROR!",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
