﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Categoria
    {
        public int ID { get; set; }
        public bool Estado { get; set; }

        public string Descripcion { get; set; }

        public int Nombre_Categoria{ get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaIngreso { get; set; }
    }
}
