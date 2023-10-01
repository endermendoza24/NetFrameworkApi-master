using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Categoria
    {
        public int ID_CATEGORIA{ get; set; }
        public string ESTADO { get; set; }

        public string DESCRIPCION { get; set; }

        public string NOMBRE_CATEGORIA { get; set; }

        public string NOMBRE { get; set; }

        public DateTime? FECHAINGRESO { get; set; }
    }
}
