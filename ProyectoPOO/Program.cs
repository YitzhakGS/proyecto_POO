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
            //CEmpleado objEmpleado = new CEmpleado();
            Menu();


            Console.ReadKey();
        }

        private static void Menu()
        {
            //CEmpleado empleado = new CEmpleado();
            string resp;
            do
            {
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

        public static void MenuUsuario()
        {
            CUsuario usuario = new CUsuario();
            string resp;
            string[,] validado;
            do
            {
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
                        //if (validado[0,0] == "true")
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

        public static void MenuReservaciones(CUsuario Usuario)
        {
            CReservacion Reservacion = new CReservacion();
            string resp;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t*MENU DE RESERVACIONES\n");
                Console.WriteLine("\t-->REALIZAR RESERVACIÓN.......(1)");
                Console.WriteLine("\t-->CONSULTAR RESERVACIÓN......(2)");
                Console.WriteLine("\t-->REGRESAR...................(3)");
                Console.WriteLine("\t-->SALIR......................(4)\n\n");

                Console.Write("Seleccione una opción: ");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Usuario.RealizarReservacion(Usuario);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("\nIngrese el Id de su reservación: ");
                        int IdR = Convert.ToInt32(Console.ReadLine());
                        Reservacion.MostrarReservacion(Usuario, IdR);
                        break;
                    case 3:
                        MenuUsuario();
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

        public static void MenuEmpleado()
        {
            //obj de Admin
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

        public static void MenuAlmacen()
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

        public void MenuInventario()
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


        public static void MenuAdmin()
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

        }
}
