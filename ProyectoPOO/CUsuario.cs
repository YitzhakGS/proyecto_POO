using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class CUsuario:CPersona
    {
        List<CUsuario> RegistroUsuarios;
        public int IdUsuario { get; set; }
        private string Contraseña { get; set; }


        CUsuario[] DBUsuarios; //Se crea un arreglo
        int contador = 0;

        //Metodos

        public CUsuario() //El constructor sirve para incializar para crear conexion a una base de datos entre otras cosas, cuando se usa new para crear una instancia en main se manda a llamar un constructor aunque no sea especificado
        {
            DBUsuarios = new CUsuario[10];
            RegistroUsuarios = new List<CUsuario>();
        }

        public void RegistrarUsuario()
        {
            try
            {
                Console.Clear();
                string DATO = "";
                CUsuario nuevoUsuario = new CUsuario();

                Console.WriteLine("\t\t\t\t*REGISTRAR NUEVO USUARIO*");
                Console.WriteLine("\nIntroduce los siguientes datos: ");
                Console.Write("\nNombre(s): ");
                nuevoUsuario.Nombres = Console.ReadLine();
                Console.Write("\nApellidos: ");
                nuevoUsuario.Apellidos = Console.ReadLine();
                Console.Write("\nEdad: ");
                nuevoUsuario.Edad = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSexo: ");
                nuevoUsuario.Sexo = Console.ReadLine();
                Console.Write("\nTelefono: ");
                nuevoUsuario.Telefono = Console.ReadLine();
                Console.Write("\nDireccion: ");
                nuevoUsuario.Direccion = Console.ReadLine();
                Console.Write("\nContraseña: ");
                nuevoUsuario.Contraseña = Console.ReadLine();

                contador++; //Maybe no |
                // DBUsuarios[contador - 1] = nuevoUsuario;


                using (StreamReader streamReader = new StreamReader("..\\..\\BDUsuarios.txt"))
                {
                    TextReader DATAUsuarios = streamReader;
                    string line = DATAUsuarios.ReadLine();
                    while (line != null)
                    {
                        string[] palabras = line.Split();
                        nuevoUsuario.IdUsuario = Convert.ToInt32(palabras[0])+1;
                        line = DATAUsuarios.ReadLine();
                    }
                }
                


                        //la cadena que contiene los datos del pedido lo paso a un arreglo y elimino los espacios
                //string[] orden = DATO.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                RegistroUsuarios.Add(nuevoUsuario);

                StringBuilder contenidoArchivo = new StringBuilder();

                string UId = Convert.ToString(nuevoUsuario.IdUsuario);
                contenidoArchivo.Append(UId + "   ");
                contenidoArchivo.Append(nuevoUsuario.Nombres + "   ");
                contenidoArchivo.Append(nuevoUsuario.Apellidos + "   ");
                string UEdad = Convert.ToString(nuevoUsuario.Edad);
                contenidoArchivo.Append(UEdad + "   ");
                contenidoArchivo.Append(nuevoUsuario.Sexo + "   ");
                contenidoArchivo.Append(nuevoUsuario.Telefono + "   ");
                contenidoArchivo.Append(nuevoUsuario.Direccion);

                TextWriter BDUsuarios = File.AppendText("..\\..\\BDUsuarios.txt");
                BDUsuarios.WriteLine(contenidoArchivo);
                BDUsuarios.Close();


                /*using (TextReader archivo = new StreamReader("..\\..\\BDUsuarios.txt"))
                {
                    Console.WriteLine(archivo.ReadToEnd());
                }*/

                StringBuilder U_P = new StringBuilder();
                U_P.Append(nuevoUsuario.IdUsuario + "    "+nuevoUsuario.Contraseña);
                TextWriter BDContras = File.AppendText("..\\..\\BDUser_Pass.txt");
                BDContras.WriteLine(U_P);
                BDContras.Close();

                Console.WriteLine("\n\t\t\t*USUARIO REGISTRADO CON EXITO*\n*Tu ID para iniciar sesion es: {0}\n",nuevoUsuario.IdUsuario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public CUsuario ValidarUsuario()
        {
            int Id;
            string Contra;
            //string[,] Validado = new string[1,2];
            CUsuario Usuario = new CUsuario();
            bool validado = false;

            Console.Clear();
            Console.WriteLine("\t\t\t\t*INGRESA TUS DATOS*");
            Console.Write("\n\n-->Ingresa tu ID de usuario: ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n-->Ingresa tu contraseña: ");
            Contra = Console.ReadLine();

            using (StreamReader streamReader = new StreamReader("..\\..\\BDUser_Pass.txt"))
            {
                TextReader DATAContra = streamReader;
                string line = DATAContra.ReadLine();
                while (line != null)
                {
                    string[] palabras = line.Split();

                    if (Convert.ToString(Id) == palabras[0])
                    {
                        if (Contra == palabras[4])
                        {
                            using (StreamReader streamReaderU = new StreamReader("..\\..\\BDUsuarios.txt"))
                            {
                                TextReader DATAUsuario = streamReaderU;
                                string lineU = DATAUsuario.ReadLine();
                                while (lineU != null)
                                {
                                    string[] datosPalabras = lineU.Split();

                                    if (Convert.ToString(Id) == datosPalabras[0])
                                    {
                                        Console.WriteLine("\n\t\t\t\t*DATOS CORRECTOS, INICIANDO SESIÓN...*\n\t\t\t\tPRESIONA ENTER PARA CONTINUAR");
                                        Usuario.IdUsuario = Convert.ToInt32(datosPalabras[0]);
                                        Usuario.Nombres = datosPalabras[3];
                                        Usuario.Apellidos = datosPalabras[6];
                                        Usuario.Edad = Convert.ToInt32(datosPalabras[9]);
                                        Usuario.Sexo = datosPalabras[12];
                                        Usuario.Telefono = datosPalabras[15];
                                        Usuario.Direccion = datosPalabras[18];
                                        break;
                                    }
                                    lineU = DATAUsuario.ReadLine();
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\t\t\t\t***USUARIO Y/O CONTRASEÑA INCORRECTA***\n\t\t\t\t*VERIFICA TUS DATOS*");
                            break;
                        }
                    }
                        
                    line = DATAContra.ReadLine();
                }
            }

 
            return Usuario;
        }

        public void RealizarReservacion(CUsuario Usuario)
        {
            

            Console.Clear();
            CReservacion Reservacion = new CReservacion();
            
            Console.WriteLine("\t\t\t\t*BIENVENIDO AL APARTADO DE RESERVACIONES*\n");
            Console.WriteLine("\n-->Ingresa los siguientes datos para confirmar tu reservacion {0}:", Usuario.Nombres);
            Console.Write("\n\n1-Ingresa el dia y la hora de la reservación con el siguiente formato DD/MM/AA 00:00:00 : ");
            Reservacion.FechaReservacion = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\n\n2-Selecciona el número de mesa que deseas reservar: ");
            Reservacion.MesaReservada = Convert.ToInt32(Console.ReadLine());

            Reservacion.RegistrarReservacion(Reservacion,Usuario);
        }


    }
}
