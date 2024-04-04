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
                        usuario.ValidarUsuario();
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
                        //
                        break;
                    case 3:
                        //
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
