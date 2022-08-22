using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.ETL.Entities
{
    public class ProveedoresObj
    {
        public int idProveedor { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public int idEstado { get; set; }
        public string desEstado { get; set; }


    }
}
