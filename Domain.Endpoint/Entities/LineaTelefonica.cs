using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Linea_Telefonica
    {
        public int ID_LINEA_TELEFONICA { get; set; }
        public int CLARO { get; set; }

        public int TIGO { get; set; }

        public int CONVENCIONAL { get; set; }

        public int ID_PROVEEDOR { get; set; }

        
    }
}
