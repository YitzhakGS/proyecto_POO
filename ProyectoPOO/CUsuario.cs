using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class CUsuario:CPersona
    {
        public int IdUsuario { get; set; }
        private string Contraseña { get; set; }


        CUsuario[] DBUsuarios; //Se crea un arreglo
        int contador = 0;

        //Metodos

        public CUsuario() //El constructor sirve para incializar para crear conexion a una base de datos entre otras cosas, cuando se usa new para crear una instancia en main se manda a llamar un constructor aunque no sea especificado
        {
            DBUsuarios = new CUsuario[5];
        }

        public void RegistrarUsuario()
        {
            try
            {
                Console.Clear();
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
                Console.Write("\nDireccion: ");
                nuevoUsuario.Direccion = Console.ReadLine();
                nuevoUsuario.IdUsuario = contador+1;
                Console.Write("\nContraseña: ");
                nuevoUsuario.Contraseña = Console.ReadLine();
                
                contador++;
                DBUsuarios[contador - 1] = nuevoUsuario;

                Console.WriteLine("\n\t\t\t*USUARIO REGISTRADO CON EXITO*\n*Tu ID para iniciar sesion es: {0}\n",nuevoUsuario.IdUsuario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public bool ValidarUsuario()
        {
            int Id;
            string Contra;
            bool Validado = false;

            Console.Clear();
            Console.WriteLine("\t\t\t\t*INGRESA TUS DATOS*");
            Console.Write("\n\n-->Ingresa tu ID de usuario: ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n-->Ingresa tu contraseña: ");
            Contra = Console.ReadLine();

            for (int i = 0; i < contador; i++)
            {
                if (DBUsuarios[i].IdUsuario == Id)
                {
                    if (DBUsuarios[i].Contraseña == Contra)
                    {
                        Console.WriteLine("\n\t\t\t\t*DATOS CORRECTOS, INICIANDO SESIÓN...*");
                        Validado = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t\t\t***ID Y/O CONTRASEÑA INCORRECTOS***\n\t\t\t\t*VERIFICA TUS DATOS*");
                    }
                }
                else
                {
                    Console.WriteLine("\n\t\t\t\t***ID Y/O CONTRASEÑA INCORRECTOS***\n\t\t\t\t*VERIFICA TUS DATOS*");
                }

            }

            return Validado;
        }


    }
}
