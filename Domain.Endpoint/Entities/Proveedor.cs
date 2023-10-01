using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Proveedor
    {
        public int ID_PROVEEDOR { get; set; }
        public string CIUDAD_PROVEEDOR { get; set; }

        public string CORREO_ELECTRONICO { get; set; }

        public string NOMBRE_CONTACTO { get; set; }

        public int id_fac_compra { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public string Estado { get; set; }
    }
}
