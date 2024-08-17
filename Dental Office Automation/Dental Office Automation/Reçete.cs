using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
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
namespace Dental_Office_Automation
{
    public partial class Reçete : Form
    {
        public Reçete()
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
            SqlCommand komut = new SqlCommand("select * from Randevu where Hasta='" + guna2ComboBox1.SelectedValue.ToString() + "'", baglanti);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sdaaa = new SqlDataAdapter(komut);
            sdaaa.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                guna2TextBox4.Text = dr["Tedavi"].ToString();
            }
            baglanti.Close();
        }
        private void fullÜcret()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tedavi where Ad='" + guna2TextBox4.Text + "'", baglanti);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sdaaa = new SqlDataAdapter(komut);
            sdaaa.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                guna2TextBox1.Text = dr["Ücret"].ToString();
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_MouseEnter(object sender, EventArgs e)
        {
            guna2Button2.FillColor = Color.FromArgb(97, 87, 86);
            guna2Button2.ForeColor = Color.White;
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            guna2Button2.FillColor = Color.White;
            guna2Button2.ForeColor = Color.Black;
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

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            fullÜcret();
            guna2TextBox4.FillColor = Color.FromArgb(97, 87, 86);
            guna2TextBox4.ForeColor = Color.White;
        }

        private void Reçete_Load(object sender, EventArgs e)
        {
            fullhasta();
            kayıt();
            bilgileritemizle();
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fulltedavi();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();

        }
        void kayıt()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Recete";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        void arama()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from Recete where HastaAdı like '%" + Arama.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        void bilgileritemizle()
        {
            guna2ComboBox1.SelectedItem = "";
            guna2TextBox4.Text = "";
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Recete values ('" + guna2ComboBox1.SelectedValue.ToString() + "','" + guna2TextBox4.Text + "'," + guna2TextBox1.Text + ",'" + guna2TextBox2.Text + "'," + guna2TextBox3.Text + ")";
            Hastalar hass = new Hastalar();
            try
            {
                hass.hastaekleme(query);
                MessageBox.Show("Reçete eklendi.");
                kayıt();
                bilgileritemizle();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int key = 0;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2ComboBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            if (guna2TextBox4.Text.ToString() == "")
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
                MessageBox.Show("Silinecek reçete kaydını seçiniz.");

            }
            else
            {
                try
                {
                    string query = "delete from Recete where Id=" + key + "";
                    hs.hastasilmeislemi(query);
                    MessageBox.Show("Recete kaydı silindi.");
                    kayıt();
                    bilgileritemizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Arama_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        Bitmap bitmap;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int height = guna2DataGridView1.Height;
            guna2DataGridView1.Height = guna2DataGridView1.RowCount * guna2DataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(guna2DataGridView1.Width, guna2DataGridView1.Height);
            guna2DataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 10, guna2DataGridView1.Width, guna2DataGridView1.Height));
            guna2DataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
