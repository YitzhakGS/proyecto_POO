using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoPOO
{
    internal class CReservacion
    {
        public int IdReservacion { get; set; }

        public DateTime FechaReservacion { get; set; }
        public int MesaReservada { get; set; }

        CReservacion[] DBReservaciones; //Se crea un arreglo
        int contador = 0;

        public CReservacion() //El constructor sirve para incializar para crear conexion a una base de datos entre otras cosas, cuando se usa new para crear una instancia en main se manda a llamar un constructor aunque no sea especificado
        {
            DBReservaciones = new CReservacion[10];
        }

        public int RegistrarReservacion(CReservacion Reservacion, CUsuario Usuario)
        {

            using (StreamReader streamReader = new StreamReader("..\\..\\BDReservaciones.txt"))
            {
                TextReader DATAReservaciones = streamReader;
                string line = DATAReservaciones.ReadLine();
                while (line != null)
                {
                    string[] palabras = line.Split();
                    Reservacion.IdReservacion = Convert.ToInt32(palabras[3]) + 1;
                    line = DATAReservaciones.ReadLine();
                }
            }


            StringBuilder contenidoArchivo = new StringBuilder();

            string IdU = Convert.ToString(Usuario.IdUsuario);
            contenidoArchivo.Append(IdU + "   ");
            string RId = Convert.ToString(Reservacion.IdReservacion);
            contenidoArchivo.Append(RId + "   ");
            contenidoArchivo.Append(Reservacion.FechaReservacion + "   ");
            contenidoArchivo.Append(Reservacion.MesaReservada);

            TextWriter BDReservacion = File.AppendText("..\\..\\BDReservaciones.txt");
            BDReservacion.WriteLine(contenidoArchivo);
            BDReservacion.Close();
            MostrarReservacion(Usuario, Reservacion.IdReservacion);
            return IdReservacion;
        }

        public void MostrarReservacion(CUsuario Usuario, int IdReservacion)
        {
            Console.Clear();
            CReservacion Reservacion = new CReservacion();


            using (StreamReader streamReader = new StreamReader("..\\..\\BDReservaciones.txt"))
            {
                TextReader DATAReserva = streamReader;
                string line = DATAReserva.ReadLine();
                while (line != null)
                {
                    string[] palabras = line.Split();
                    if (Convert.ToString(Usuario.IdUsuario) == palabras[0])
                    {
                        if (Convert.ToString(IdReservacion) == palabras[3])
                        {
                            Reservacion.IdReservacion = Convert.ToInt32(palabras[3]);
                            Reservacion.MesaReservada = Convert.ToInt32(palabras[12]);

                            Console.WriteLine("\t\t\t\t*DETALLES DE LA RESERVACIÓN***\n\n");
                            Console.WriteLine("-->Reservacion a nombre de: {0} {1}", Usuario.Nombres, Usuario.Apellidos);
                            Console.WriteLine("\n-Domicilio: {0}", Usuario.Direccion);
                            Console.WriteLine("\n-Telefono: {0}", Usuario.Telefono);
                            Console.WriteLine("\n-Id de reservación: {0}", Reservacion.IdReservacion);
                            Console.WriteLine("\n-Fecha y hora de reservación: {0} {1}", palabras[6], palabras[7]);
                            Console.WriteLine("\n-Mesa reservada No.{0}", Reservacion.MesaReservada);
                            break;
                        }

                    }
                    line = DATAReserva.ReadLine();
                }
            }

            

        }
    }
}
