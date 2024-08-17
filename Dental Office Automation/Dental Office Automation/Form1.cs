namespace Dental_Office_Automation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_MouseEnter(object sender, EventArgs e)
        {
            guna2GradientButton1.FillColor = Color.Black;
            guna2GradientButton1.FillColor2 = Color.Black;
            guna2GradientButton1.ForeColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2GradientButton1_MouseLeave(object sender, EventArgs e)
        {
            guna2GradientButton1.FillColor = Color.FromArgb(97, 87, 86);
            guna2GradientButton1.FillColor2 = Color.FromArgb(97, 87, 86);
            guna2GradientButton1.ForeColor = Color.Black;
        }

        private void guna2GradientButton2_MouseEnter(object sender, EventArgs e)
        {
            guna2GradientButton2.FillColor = Color.Black;
            guna2GradientButton2.FillColor2 = Color.Black;
            guna2GradientButton2.ForeColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2GradientButton2_MouseLeave(object sender, EventArgs e)
        {
            guna2GradientButton2.FillColor = Color.FromArgb(97, 87, 86);
            guna2GradientButton2.FillColor2 = Color.FromArgb(97, 87, 86);
            guna2GradientButton2.ForeColor = Color.Black;
        }

        private void guna2GradientButton3_MouseEnter(object sender, EventArgs e)
        {
            guna2GradientButton3.FillColor = Color.Black;
            guna2GradientButton3.FillColor2 = Color.Black;
            guna2GradientButton3.ForeColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2GradientButton3_MouseLeave(object sender, EventArgs e)
        {
            guna2GradientButton3.FillColor = Color.FromArgb(97, 87, 86);
            guna2GradientButton3.FillColor2 = Color.FromArgb(97, 87, 86);
            guna2GradientButton3.ForeColor = Color.Black;
        }

        private void guna2GradientButton4_MouseEnter(object sender, EventArgs e)
        {
            guna2GradientButton4.FillColor = Color.Black;
            guna2GradientButton4.FillColor2 = Color.Black;
            guna2GradientButton4.ForeColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2GradientButton4_MouseLeave(object sender, EventArgs e)
        {
            guna2GradientButton4.FillColor = Color.FromArgb(97, 87, 86);
            guna2GradientButton4.FillColor2 = Color.FromArgb(97, 87, 86);
            guna2GradientButton4.ForeColor = Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hasta frm = new Hasta();
            frm.ShowDialog();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Randevu frm = new Randevu();
            frm.ShowDialog();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Tedavi frm = new Tedavi();
            frm.ShowDialog();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Reçete frm = new Reçete();
            frm.ShowDialog();
        }
    }
}
