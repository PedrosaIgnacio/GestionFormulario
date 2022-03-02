using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   

    public class ConexionDB
    {
        private readonly static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        private static SqlConnection con;

        public static void OpenConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        public static void CloseConnection()
        {
            con.Close();
        }
        public static int ExecuteQuery(SqlCommand cmd)
        {
            cmd.Connection = con;
            int rowAff = cmd.ExecuteNonQuery();
            return rowAff;
        }
        public static SqlDataReader DataReader(SqlCommand cmd)
        {
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
