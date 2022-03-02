using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Data
{
    public class Login
    {

        public static string VerificarLoginUsuario(string username, string password)
        {
            ConexionDB.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Usuarios where @username = username and @password = password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = ConexionDB.DataReader(cmd);
            if (dr.Read())
            {
                return username;
            }
            return null;
        }

    }
}

