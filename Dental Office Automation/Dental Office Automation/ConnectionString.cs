using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace Dental_Office_Automation
{
    class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ömer Sefa\Documents\DentalDB.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True";
            return baglanti;
        }

    }
}
