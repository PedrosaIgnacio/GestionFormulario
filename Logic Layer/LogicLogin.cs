using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer
{
    public class LogicLogin
    {
        public static string VerificarUsuario(string username, string password)
        {
            return Data.Login.VerificarLoginUsuario(username,password);
        }
    }
}
