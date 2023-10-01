using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Linea_Telefonica
    {
        public int ID { get; set; }
        public int claro { get; set; }

        public int tigo { get; set; }

        public int convencional { get; set; }

        public int ID_PROVEEDOR { get; set; }

        
    }
}
