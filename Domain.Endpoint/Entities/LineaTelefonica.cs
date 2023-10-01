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
        public string claro { get; set; }

        public string tigo { get; set; }

        public string convencional { get; set; }

        public int ID_PROVEEDOR { get; set; }

        
    }
}
