using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class TablaUsuario
    {
        public int ID { get; set; }
        public string Nombre_Completo { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public bool Estado { get; set; }

        public DateTime? Fecha_Creacion { get; set; }

    }
}
