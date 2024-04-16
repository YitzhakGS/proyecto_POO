using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();


            Console.ReadKey();
        }

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Esta función actúa como el menu principal y que permite ingresar a los distintos modulos en función de las necesidades del usuario o empleado
        /// </summary>
        private static void Menu()
        {
            try
            {
                string resp = "";
                do
                {
                    if (resp == "n" || resp == "N")
                    {
                        Environment.Exit(0);
                    }
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t*INICIO DE SESION*\n");
                    Console.WriteLine("\n\n--Iniciar sesión como... \n");
                    Console.WriteLine("\t\t\tUSUARIO..........(1)");
                    Console.WriteLine("\t\t\tEMPLEADO.........(2)");
                    Console.WriteLine("\t\t\tADMINISTRADOR....(3)");
                    Console.WriteLine("\t\t\tSALIR............(4)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            MenuUsuario();
                            break;
                        case 2:
                            MenuEmpleado();
                            break;
                        case 3:
                            MenuAdmin();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del sistema");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.WriteLine("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Menu();
            }
            

        }

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Al ingresar al apartado de usuarios se mostrará el menu en el que se podra registrar o iniciar sesión
        /// </summary>
        public static void MenuUsuario()
        {
            try
            {
                CUsuario usuario = new CUsuario();
                string resp="";
                
                do
                {
                    if (resp == "n" || resp == "N")
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t*RESERVACIONES*\n");
                    Console.WriteLine("\n\t\t\t-->INICIAR SESIÓN......(1)");
                    Console.WriteLine("\t\t\t-->REGISTRARSE.........(2)");
                    Console.WriteLine("\t\t\t-->REGRESAR............(3)");
                    Console.WriteLine("\t\t\t-->SALIR...............(4)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            usuario = usuario.ValidarUsuario();
                            Console.ReadKey();
                            if (usuario.IdUsuario != 0)
                            {
                                //MenuReservaciones(Convert.ToInt32(validado[0,1]));
                                MenuReservaciones(usuario);
                            }
                            break;
                        case 2:
                            usuario.RegistrarUsuario();
                            break;
                        case 3:
                            Menu();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del sistema");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.Write("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Autor: Luis Mario Maurio Jimenez
        /// Una vez que el usuario inicie sesión se le mostrará un menú en el que pueda realizar distintas acciones con su cuenta,
        /// entre ellas: realizar, consultar o cancelar una reservación y también la posibilidad de eliminar su cuenta.
        /// </summary>
        /// <param name="Usuario"></param>
        public static void MenuReservaciones(CUsuario Usuario)
        {
            try
            {


                CReservacion Reservacion = new CReservacion();
                string resp="";
                do
                {
                    if (resp == "n" || resp == "N")
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t*MENU DE RESERVACIONES\n");
                    Console.WriteLine("\t-->REALIZAR RESERVACIÓN.......(1)");
                    Console.WriteLine("\t-->CONSULTAR RESERVACIÓN......(2)");
                    Console.WriteLine("\t-->CANCELAR RESERVACION.......(3)");
                    Console.WriteLine("\t-->ELIMINAR CUENTA DE USUARIO.(4)");
                    Console.WriteLine("\t-->REGRESAR...................(5)");
                    Console.WriteLine("\t-->SALIR......................(6)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Usuario.RealizarReservacion(Usuario);
                            break;
                        case 2:
                            try
                            {
                                Console.Clear();
                                Console.Write("\nIngrese el Id de su reservación: ");
                                int IdRe = Convert.ToInt32(Console.ReadLine());
                                Reservacion.MostrarReservacion(Usuario, IdRe);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message);
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("\nIngrese el Id de su reservación: ");
                            int IdR = Convert.ToInt32(Console.ReadLine());
                            Reservacion.CancelarReservacion(Usuario,IdR);
                            break;
                        case 4:
                            string confirm;
                            Console.Clear();
                            Console.WriteLine("\n\t\t\t***ADVERTENCIA***");
                            Console.WriteLine("\n\n*¿Estas seguro de eliminar tu cuenta? (S/N)\n*Esta acción es irreversible");
                            confirm= Console.ReadLine();
                            if(confirm=="S" || confirm == "s")
                            {
                                Usuario.EliminarUsuario(Usuario.IdUsuario);
                                MenuUsuario();
                            }
                            else
                            {
                                Console.WriteLine("\nCONFIRMACIÓN INVALIDA");
                            }
                            break;
                        case 5:
                            MenuUsuario();
                            break;
                        case 6:
                            Console.WriteLine("Saliendo del sistema");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.WriteLine("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void MenuEmpleado()
        {
            try
            {
                string resp;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t*VALIDACIÓN DE CREDENCIALES\n");
                    Console.WriteLine("\t-->INICIAR SESIÓN......(1)");
                    Console.WriteLine("\t-->REGRESAR............(2)");
                    Console.WriteLine("\t-->SALIR...............(3)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            MenuAlmacen();
                            break;
                        case 2:
                            Menu();
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.WriteLine("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void MenuAlmacen()
        {
            try
            {
                CEmpAlmacen almacen = new CEmpAlmacen();
                string resp;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t*M E N U\n");
                    Console.WriteLine("\t-->PEDIDOS........................(1)");
                    Console.WriteLine("\t-->INVENTARIO.....................(2)");
                    Console.WriteLine("\t-->GENERAR INFORME................(3)");
                    Console.WriteLine("\t-->SALIR..........................(4)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            almacen.RealizarPedido();
                            break;
                        case 2:
                            almacen.MenuInventario();
                            break;
                        case 3:
                            almacen.Informes();
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.WriteLine("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public void MenuInventario()
        {
            try
            {
                CEmpAlmacen almacen = new CEmpAlmacen();
                string resp;
                do
                {
                    Console.WriteLine("\n\t\t*M E N U\n");
                    Console.WriteLine("\t-->Agregar Producto...............(1)");
                    Console.WriteLine("\t-->Eliminar Producto..............(2)");
                    Console.WriteLine("\t-->SALIR..........................(3)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            almacen.AgregarInventario();
                            break;
                        case 2:
                            almacen.EliminarInventario();
                            break;
                        case 3:
                            MenuAlmacen();
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.WriteLine("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void MenuAdmin()
        {
            try
            {
                string resp;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t*VALIDACIÓN DE CREDENCIALES\n");
                    Console.WriteLine("\t-->INICIAR SESIÓN......(1)");
                    Console.WriteLine("\t-->REGRESAR............(2)");
                    Console.WriteLine("\t-->SALIR...............(3)\n\n");

                    Console.Write("Seleccione una opción: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            //Admin.Registrar();
                            break;
                        case 2:
                            Menu();
                            break;
                        case 3:
                            Console.WriteLine("Saliendo del sistema");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                    Console.WriteLine("\nDesea continuar S(Si) / N(No): ");
                    resp = Console.ReadLine();
                } while (resp == "S" || resp == "s");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        }
}
