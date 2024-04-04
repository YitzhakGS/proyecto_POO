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
        public int CantidadProductos { get; set; }
        protected string Proveedor { get; set; }

        public CPedidoAlmacen(string idOrden, string tipo, int cantidad, string proveedor) 
        { 
            this.IdOrden = idOrden;
            this.TipoProductos = tipo;
            this.CantidadProductos = cantidad;
            this.Proveedor = proveedor;
        }

    }
}
