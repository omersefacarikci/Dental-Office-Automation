using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Office_Automation
{
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }
        void kayıt()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Tedavi";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        void arama()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Tedavi where Ad like '%" + Arama.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        void bilgileritemizle()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.FillColor = Color.FromArgb(97, 87, 86);
            guna2TextBox1.ForeColor = Color.White;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.FillColor = Color.FromArgb(97, 87, 86);
            guna2TextBox2.ForeColor = Color.White;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox3.FillColor = Color.FromArgb(97, 87, 86);
            guna2TextBox3.ForeColor = Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Tedavi values ('" + guna2TextBox1.Text + "','" + guna2TextBox2.Text + "','" + guna2TextBox3.Text + "')";
            Hastalar hass = new Hastalar();
            try
            {
                hass.hastaekleme(query);
                MessageBox.Show("Hasta tedavi eklendi.");
                kayıt();
                bilgileritemizle();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek tedavi kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "update Tedavi set Ad='" + guna2TextBox1.Text + "',Ücret='" + guna2TextBox2.Text + "',Acıklama'" + guna2TextBox3.Text + "' where Id=" + key + ";";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Tedavi kaydı güncellendi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek tedavi kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "delete from Tedavi where Id=" + key + "";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Tedavi kaydı silindi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Tedavi_Load(object sender, EventArgs e)
        {
            kayıt();
            bilgileritemizle();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (guna2TextBox1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }

        private void Arama_TextChanged(object sender, EventArgs e)
        {
            arama();
        }
    }
}
