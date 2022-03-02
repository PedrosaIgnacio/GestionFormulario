using System;

namespace Entities
{
    [Serializable]
    public class DetalleFormulario
    {
        public int id { get; set; }
        public string name { get; set; }
        public string datatype { get; set; }
        public int idForm { get; set; }
    }
}
