using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RegistroFormulario
    {
        public int idFormulario { get; set; }
        public int idDetalleFormulario{ get; set; }
        public string valor { get; set; }
        public int idRegistroFormulario { get; set; }
        public int idFilaRegistro { get; set; }
    }
}
