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
        public string NOMBRE_COMPLETO { get; set; }

        public string CORREO { get; set; }

        public int TELEFONO { get; set; }
        public string ESTADO { get; set; }
        public DateTime? FECHA_CREACION { get; set; }

    }
}
