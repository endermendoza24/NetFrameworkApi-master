using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Bodega
    {
        [Key]
        public int ID { get; set; }
        public string NOMBRE_BODEGA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string  DIRECCION { get; set; }
    }
}
