namespace c2_SP_Tasks.Task1
{
    partial class _6_hover
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Sweet Mavka Script", 71.99999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(583, 193);
            label1.TabIndex = 0;
            label1.Text = "Не трогать";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseHover += label1_MouseHover;
            // 
            // _6_hover
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 193);
            Controls.Add(label1);
            Name = "_6_hover";
            Text = "_6_hover";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}