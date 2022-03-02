using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Register
    {
        public static bool RegistrarUsuario(string username, string password)
        {
            ConexionDB.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuarios (username, password, tipo) VALUES (@username, @password, 1)";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            int rowAff = ConexionDB.ExecuteQuery(cmd);
            if (rowAff >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
