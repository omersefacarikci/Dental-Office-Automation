using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Dental_Office_Automation
{
    class Tedaviler
    {
        
        
            public void hastaekleme(string query)
            {
                ConnectionString Baglantim = new ConnectionString();
                SqlConnection baglanti = Baglantim.GetCon();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                baglanti.Open();
                komut.CommandText = query;
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            public void hastasilmeislemi(string query)
            {
                ConnectionString Baglantim = new ConnectionString();
                SqlConnection baglanti = Baglantim.GetCon();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                baglanti.Open();
                komut.CommandText = query;
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            public void hastagüncellemeislemi(string query)
            {
                ConnectionString Baglantim = new ConnectionString();
                SqlConnection baglanti = Baglantim.GetCon();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                baglanti.Open();
                komut.CommandText = query;
                komut.ExecuteNonQuery();
                baglanti.Close();
            }

            public DataSet Showhasta(string query)
            {
                ConnectionString Baglantim = new ConnectionString();
                SqlConnection baglanti = Baglantim.GetCon();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;

            }
        
    }
}
