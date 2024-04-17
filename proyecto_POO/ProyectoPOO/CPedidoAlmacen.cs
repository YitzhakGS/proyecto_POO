
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class CPedidoAlmacen
    {
        public string IdOrden { get; set; }
        public string TipoProductos { get; set; }
        public string CantidadProductos { get; set; }
        public string Proveedor { get; set; }
        public decimal Precio { get; set; }
        public DateTime DateTime { get; set; }

    }
}
