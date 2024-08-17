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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(97, 87, 86);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox1.FillColor = Color.FromArgb(97, 87, 86);
            guna2ComboBox1.ForeColor = Color.White;
        }
        void kayıt()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Hastalar";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        void bilgileritemizle()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2DateTimePicker1.Text = "";
            guna2ComboBox1.SelectedItem = "";
            guna2TextBox4.Text = "";
            guna2TextBox3.Text = "";
        }
        private void Hasta_Load(object sender, EventArgs e)
        {
            kayıt();
            bilgileritemizle();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker1.FillColor = Color.FromArgb(97, 87, 86);
            guna2DateTimePicker1.ForeColor = Color.White;
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

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.FillColor = Color.FromArgb(97, 87, 86);
            guna2TextBox4.ForeColor = Color.White;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Hastalar values ('" + guna2TextBox1.Text + "','" + guna2TextBox2.Text + "','" + guna2TextBox4.Text + "','" + guna2DateTimePicker1.Text + "','" + guna2ComboBox1.SelectedItem.ToString() + "','" + guna2TextBox3.Text + "')";
            Hastalar hass = new Hastalar();
            try
            {
                hass.hastaekleme(query);
                MessageBox.Show("Hasta kaydı eklendi.");
                kayıt();
                bilgileritemizle();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2DateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            guna2ComboBox1.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();


            if (guna2TextBox1.Text == "")
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
                MessageBox.Show("Silinecek hasta kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "delete from Hastalar where Id=" + key + "";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Hasta kaydı silindi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek hasta kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "update Hastalar set Ad='" + guna2TextBox1.Text + "',Telefon='" + guna2TextBox2.Text + "',Adres'" + guna2TextBox4.Text + "',DoğumTarihi='" + guna2DateTimePicker1.Text + "',Cinsiyet='" + guna2ComboBox1.SelectedItem.ToString() + "',Alerji='" + guna2TextBox3.Text + "' where Id=" + key + ";";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Hasta kaydı güncellendi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }
        void arama()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Hastalar where Ad like '%" + Arama.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        private void Arama_TextChanged(object sender, EventArgs e)
        {
            arama();
        }
    }
}
