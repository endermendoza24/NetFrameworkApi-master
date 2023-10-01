using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class TablaUsuario
    {
        public int ID_USUARIO{ get; set; }
        public string Nombre_Completo { get; set; }

        public string Correo { get; set; }

        public int Telefono { get; set; }

        public string Estado { get; set; }

        public DateTime? Fecha_Creacion { get; set; }

    }
}
