using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Guna.UI2.WinForms;
namespace Dental_Office_Automation
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        private void fullhasta()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ad from Hastalar", baglanti);
            SqlDataReader read;
            read = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Ad", typeof(string));
            dt.Load(read);
            guna2ComboBox1.ValueMember = "Ad";
            guna2ComboBox1.DataSource = dt;
            baglanti.Close();
        }
        private void fulltedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ad from Tedavi", baglanti);
            SqlDataReader read;
            read = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Ad", typeof(string));
            dt.Load(read);
            guna2ComboBox3.ValueMember = "Ad";
            guna2ComboBox3.DataSource = dt;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox2.FillColor = Color.FromArgb(97, 87, 86);
            guna2ComboBox2.ForeColor = Color.White;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker1.FillColor = Color.FromArgb(97, 87, 86);
            guna2DateTimePicker1.ForeColor = Color.White;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox1.FillColor = Color.FromArgb(97, 87, 86);
            guna2ComboBox1.ForeColor = Color.White;
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox3.FillColor = Color.FromArgb(97, 87, 86);
            guna2ComboBox3.ForeColor = Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(97, 87, 86);
        }

        void bilgileritemizle()
        {
            guna2ComboBox1.SelectedValue = "";
            guna2ComboBox3.SelectedValue = "";
            guna2DateTimePicker1.Text = "";
            guna2ComboBox2.SelectedValue = "";
        }
        private void Randevu_Load(object sender, EventArgs e)
        {
            fullhasta();
            fulltedavi();
            kayıt();
            bilgileritemizle();
        }
        void kayıt()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Randevu";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Randevu values('" + guna2ComboBox1.SelectedValue.ToString() + "','" + guna2ComboBox3.SelectedValue.ToString() + "','" + guna2DateTimePicker1.Text + "','" + guna2ComboBox2.Text + "')";

            Hastalar hass = new Hastalar();
            try
            {
                hass.hastaekleme(query);
                MessageBox.Show("Randevu eklendi.");
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
                MessageBox.Show("Güncellenecek randevu kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "update Randevu set Hasta='" + guna2ComboBox1.SelectedValue.ToString() + "',Tedavi='" + guna2ComboBox3.SelectedValue.ToString() + "',RandevuTarihi'" + guna2DateTimePicker1.Text + "', Saat='" + guna2ComboBox2.Text + "' where Id=" + key + ";";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Randevu kaydı güncellendi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2ComboBox1.SelectedValue = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2ComboBox3.SelectedValue = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2DateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2ComboBox2.SelectedValue = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (guna2ComboBox1.SelectedIndex == 1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek randevu kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "delete from Randevu where Id=" + key + "";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Randevu kaydı silindi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }
        void arama()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Randevu where Hasta like '%" + Arama.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        private void Arama_TextChanged(object sender, EventArgs e)
        {
            arama();
        }
    }
}
