using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer
{
    public class LogicRegister
    {
        public static bool RegistrarUsuario(string username, string password)
        {
            return Data.Register.RegistrarUsuario(username, password);
        }
    }
}
