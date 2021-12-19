using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Basit_Ajanda.Cls
{
    public class SQLConnectionClass
    {
        private static string SQLConnectionString = @"Server = SCC\SQLEXPRESS; Initial Catalog = BASIT_AJANDA_DB; Trusted_Connection = True;";
        private static SqlConnection con = new SqlConnection();
        private static SqlDataAdapter da = new SqlDataAdapter();
        private static SqlCommand com = new SqlCommand();
        public static SqlException exception = null;
        public static void Baglanti()
        {
            con = new SqlConnection(SQLConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // databasedeki veriler üzerinde işlem yapmak için bu fonksiyon kullanılıyor (insert, update, delete)
        public static object Command(string query) 
        {
            object obj = null;
            com.Connection = con; 
            com.CommandText = query; 

            try
            {
                obj = com.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.GetType().Name + " - " + ex.Message);
            }

            return obj;
        }

        // databaseden veri görüntülemek için bu fonksiyon kullanılıyor (select)
        public static DataTable Table(string query)
        {
            DataTable dt = new DataTable();
            com.Connection = con; 
            com.CommandText = query; 
            da.SelectCommand = com;
            
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.GetType().Name + " - " + ex.Message);
            }
            return dt;
        }
    }
}