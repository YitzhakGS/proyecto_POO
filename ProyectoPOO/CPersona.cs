using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class CPersona
    {
        public string Nombres { get; set; } //get y set para poder manipular los valores de la base de datos
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

}
