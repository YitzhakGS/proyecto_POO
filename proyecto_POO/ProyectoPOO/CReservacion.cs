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

        public CReservacion() //El constructor sirve para incializar para crear conexion a una base de datos entre otras cosas, cuando se usa new para crear una instancia en main se manda a llamar un constructor aunque no sea especificado
        {
            DBReservaciones = new CReservacion[10];
        }


        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función permite crear nuevas reservaciones en la base de datos "BDReservaciones", almacenando los datos pertinentes
        /// y asociandolo con el usuario que esta haciendo la reservación.
        /// </summary>
        /// <param name="Reservacion">Se recibe como parametro el objeto reservacion que contiene los datos ingresados de la reservacion</param>
        /// <param name="Usuario">Se recibe como parametro el objeto usuario que contiene todos los datos del usuario que inicio sesion</param>
        /// <returns>Se retorna el Id de la Reservación realizada con exito para que el usuario pueda identificarla</returns>
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


        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función sirve para mostrar los detalles de una reservación que se encuentre registrada en la base de datos buscandola en
        /// base a un Id de reservación, para poder mostrar una reservación se debe verificar que el id ingresado exista y que este
        /// asociado al id de usuarios que inicio sesión.
        /// </summary>
        /// <param name="Usuario">Se recibe como paramtero el objeto usuario para mostrar los datos asociados al usuario que tiene iniciada sesión</param>
        /// <param name="IdReservacion">Se le solicita al usuario un Id de reservación para identificarla</param>
        public void MostrarReservacion(CUsuario Usuario, int IdReservacion)
        {
            try
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
                    if (Reservacion.IdReservacion != IdReservacion)
                    {
                        Console.WriteLine("\t\t\t*ID DE RESERVA INEXISTENTE\n\t\t\tVERIFICA TUS DATOS*");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función sirve para cancelar las reservas de los clientes, en otras palabras, 
        /// eliminar el registro de reservación de la base de datos
        /// </summary>
        /// <param name="Usuario">Se recibe como parametro el objeto usuario para verificar los datos de la reservación antes de eliminar el registro</param>
        /// <param name="IdReservacion">El id de reservación sera para verificar que existe la reservacion y se identifique para ser eliminada</param>
        public void CancelarReservacion(CUsuario Usuario, int IdReservacion)
        {
            try
            {
                Console.Clear();
                CReservacion Reservacion = new CReservacion();
                string confirm="";

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

                                Console.WriteLine("\t\t\t\t\n\n");
                                Console.WriteLine("-->Reservacion a nombre de: {0} {1}", Usuario.Nombres, Usuario.Apellidos);
                                Console.WriteLine("\n-Domicilio: {0}", Usuario.Direccion);
                                Console.WriteLine("\n-Telefono: {0}", Usuario.Telefono);
                                Console.WriteLine("\n-Id de reservación: {0}", Reservacion.IdReservacion);
                                Console.WriteLine("\n-Fecha y hora de reservación: {0} {1}", palabras[6], palabras[7]);
                                Console.WriteLine("\n-Mesa reservada No.{0}", Reservacion.MesaReservada);
                                Console.WriteLine("\n\n*¿ESTAS SEGURO DE ELIMINAR LA RESERVACIÓN? (S/N)\n*Esta acción es irreversible");
                                confirm = Console.ReadLine();
                                break;
                            }

                        }
                        line = DATAReserva.ReadLine();
                    }
                    if (Reservacion.IdReservacion != IdReservacion)
                    {
                        Console.WriteLine("\t\t\t*ID DE RESERVA INEXISTENTE\n\t\t\tVERIFICA TUS DATOS*");
                    }
                }
                if (confirm == "S" || confirm == "s")
                {
                    // Lista para almacenar todas las líneas del archivo, excepto la línea a eliminar
                    List<string> lineasArchivo = new List<string>();

                    using (StreamReader sr = new StreamReader("..\\..\\BDReservaciones.txt"))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] palabrasR = linea.Split();

                            // Si la línea no contiene el ID del producto a eliminar, agrégala a la lista
                            if (Convert.ToString(Reservacion.IdReservacion) != palabrasR[3])
                            {
                                lineasArchivo.Add(linea);
                            }
                        }
                    }

                    // Reescribir el archivo con todas las líneas excepto la línea a eliminar
                    using (StreamWriter sw = new StreamWriter("..\\..\\BDReservaciones.txt"))
                    {
                        foreach (string linea in lineasArchivo)
                        {
                            sw.WriteLine(linea);
                        }
                    }

                    Console.WriteLine("\n\n\n***RESERVACIÓN CANCELADA***");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
