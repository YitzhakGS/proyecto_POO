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

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función permite registrar nuevos usuarios pidiendole sus datos personales y almacenandolos en una base de datos
        /// para que posteriormente pudan iniciar sesion y realizar tramites con su cuenta; se le asigna un Id de usuario comprobando
        /// que sea consecutivo y no exista otro usuario con su mismo Id y la contraseña que el usuario ingrese se almacenará en otra base de datos
        /// para mayor seguridad.
        /// </summary>
        public void RegistrarUsuario()
        {
            try
            {
                Console.Clear();
                CUsuario nuevoUsuario = new CUsuario();

                Console.WriteLine("\t\t\t\t*REGISTRAR NUEVO USUARIO*");
                Console.WriteLine("\nIntroduce los siguientes datos: \nNOTA: Separar las palabras con un guión bajo (_)");
                Console.Write("\nNombre(s): ");
                nuevoUsuario.Nombres = Console.ReadLine();
                Console.Write("\nApellidos: ");
                nuevoUsuario.Apellidos = Console.ReadLine();
                Console.Write("\nEdad: ");
                nuevoUsuario.Edad = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSexo: ");
                nuevoUsuario.Sexo = Console.ReadLine();
                do
                {
                    Console.Write("\nTelefono: ");
                    nuevoUsuario.Telefono = Console.ReadLine();
                    if (nuevoUsuario.Telefono.Length != 10)
                    {
                        Console.WriteLine("*Telefono invalido, por favor ingresa 10 digitos");
                    }
                } while (nuevoUsuario.Telefono.Length != 10);
                Console.Write("\nDireccion: ");
                nuevoUsuario.Direccion = Console.ReadLine();
                Console.Write("\nContraseña: ");
                nuevoUsuario.Contraseña = Console.ReadLine();

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

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función revisa la base de datos y verifica que el id de usuario y contraseña correspondan entre si y de ser asi
        /// permite el ingreso a el apartado de reservaciones.
        /// </summary>
        /// <returns>Una vez que se validen los datos, se retornará el objeto usuario que contendran sus datos para inciar sesion en su cuenta</returns>
        public CUsuario ValidarUsuario()
        {
            int Id;
            string Contra;
            CUsuario Usuario = new CUsuario();

            
            try
            {
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
                if(Usuario.IdUsuario!=Id)
                {
                    Console.WriteLine("\n\t\t\t\t***USUARIO Y/O CONTRASEÑA INCORRECTA***\n\t\t\t\t*VERIFICA TUS DATOS*");
                }

                return Usuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Usuario;
            }

        }

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función solicita los datos para crear una reservación y manda a llamar la función RegistrarReservacion para 
        /// guardar el registro en la base de datos.
        /// </summary>
        /// <param name="Usuario">Para asociar la reservación con un usuario se solicita como parámetro el objeto usuario.</param>
        public void RealizarReservacion(CUsuario Usuario)
        {

            try
            {
                Console.Clear();
                CReservacion Reservacion = new CReservacion();

                Console.WriteLine("\t\t\t\t*BIENVENIDO AL APARTADO DE RESERVACIONES*\n");
                Console.WriteLine("\n-->Ingresa los siguientes datos para confirmar tu reservacion {0}:", Usuario.Nombres);
                Console.Write("\n\n1-Ingresa el dia y la hora de la reservación con el siguiente formato DD/MM/AA 00:00:00 : ");
                Reservacion.FechaReservacion = Convert.ToDateTime(Console.ReadLine());
                Console.Write("\n\n2-Selecciona el número de mesa que deseas reservar: ");
                Reservacion.MesaReservada = Convert.ToInt32(Console.ReadLine());

                Reservacion.RegistrarReservacion(Reservacion, Usuario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función da de baja una cuenta de un usuario, es decir, elimina el registro de un usuario tanto en la base de datos de los
        /// usuarios com en la base de datos que almacena las contraseñas de los usuarios.
        /// </summary>
        /// <param name="IdUSuario">Para identificar en la base de datos el registro que contiene los datos de un usuario se solicita el id del usuario que tiene actualmente su sesion iniciada</param>
        public void EliminarUsuario(int IdUSuario)
        {

            // Lista para almacenar todas las líneas del archivo, excepto la línea a eliminar
            List<string> lineasArchivo = new List<string>();

            using (StreamReader sr = new StreamReader("..\\..\\BDUsuarios.txt"))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] palabras = linea.Split();

                    // Si la línea no contiene el ID del producto a eliminar, agrégala a la lista
                    if (Convert.ToString(IdUsuario) != palabras[0])
                    {
                        lineasArchivo.Add(linea);
                    }
                }
            }

            // Reescribir el archivo con todas las líneas excepto la línea a eliminar
            using (StreamWriter sw = new StreamWriter("..\\..\\BDUsuarios.txt"))
            {
                foreach (string linea in lineasArchivo)
                {
                    sw.WriteLine(linea);
                }
            }

            List<string> lineasArchivoP = new List<string>();

            using (StreamReader srP = new StreamReader("..\\..\\BDUser_Pass.txt"))
            {
                string lineaP;
                while ((lineaP = srP.ReadLine()) != null)
                {
                    string[] palabrasP = lineaP.Split();

                    // Si la línea no contiene el ID del producto a eliminar, agrégala a la lista
                    if (Convert.ToString(IdUsuario) != palabrasP[0])
                    {
                        lineasArchivoP.Add(lineaP);
                    }
                }
            }

            using (StreamWriter swP = new StreamWriter("..\\..\\BDUser_Pass.txt"))
            {
                foreach (string lineaP in lineasArchivoP)
                {
                    swP.WriteLine(lineaP);
                }
            }

            Console.WriteLine("Usuario eliminado con exito");
            Console.ReadKey();
        }

    }
}
