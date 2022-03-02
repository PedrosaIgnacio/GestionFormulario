using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
namespace Logic_Layer
{
    public class LogicFormulario
    {
        public static int? InsertFormulario(string name)
        {
            return Data.DataFormulario.InsertFormulario(name);
        }
        public static bool InsertarDetallesEnFormulario(List<DetalleFormulario>lst, int id)
        {
            return Data.DataFormulario.InsertDetallesEnFormulario(lst, id);
        }
        public static List<Formulario> ListaFormularios()
        {
            return Data.DataFormulario.ListaFormularios();
        }
        public static List<DetalleFormulario> DetallesDeUnFormulario(int id)
        {
            return Data.DataFormulario.DetallesDeUnFormulario(id);
        }
        public static List<Formulario> Top5Formularios()
        {
            return Data.DataFormulario.Top5Formularios();
        }
    }
}
