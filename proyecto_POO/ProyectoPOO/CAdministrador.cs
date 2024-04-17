using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoPOO
{
    /// <summary>
    /// Autor: Omar Reyes Morales 
    /// Clase que gestiona la administración de empleados en el sistema.
    /// Permite agregar, mostrar y eliminar empleados, así como operaciones relacionadas con archivos.
    /// </summary>
    public class Empleado
    {
 
        public string Nombre { get; set; }  
        public string Area { get; set; }    
        public string Puesto { get; set; }

        
        public Empleado(string nombre, string area, string puesto)
        {
            Nombre = nombre;  
            Area = area;      
            Puesto = puesto; 
        }
    }
    /// <summary>
    /// Constructor de la clase Administrador que inicializa el array de empleados con una capacidad especificada.
    /// </summary>
    /// <param name="capacidad">Capacidad máxima de empleados que puede gestionar el administrador.</param>
    public class Administrador
    {

        private Empleado[] empleados;  
        private int contador;          

        // Constructor de la clase Administrador que recibe la capacidad, el nombre y el área del primer empleado
        public Administrador(int capacidad, string nombreEmpleado, string areaEmpleado)
        {
            empleados = new Empleado[capacidad];  
            contador = 0;

            /// <summary>
            /// Método para agregar un nuevo empleado.
            /// </summary>
            /// <param name="nombre">Nombre del nuevo empleado.</param>
            /// <param name="area">Área del nuevo empleado.</param>
            AgregarEmpleado(nombreEmpleado, areaEmpleado);
        }

        public void AgregarEmpleado(string nombre, string area)
        {
            try
            {
                Empleado nuevoEmpleado = new Empleado(nombre, area, "Puesto por defecto");  
                empleados[contador] = nuevoEmpleado;  
                contador++;                           

                Console.WriteLine("\n\t\t\t*EMPLEADO REGISTRADO CON ÉXITO*\n");  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);  
            }
        }

        /// <summary>
        /// Método para mostrar la lista de empleados.
        /// </summary>
        public void MostrarEmpleados()
        {
            Console.WriteLine("Lista de empleados:");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"Nombre: {empleados[i].Nombre}, Área: {empleados[i].Area}, Puesto: {empleados[i].Puesto}");
            }
        }

        /// <summary>
        /// Método para mostrar la lista de empleados desde un archivo.
        /// </summary>
        public void ListaEmpleados()
        {
            try
            {
                Console.Clear(); 
                Console.WriteLine("\t\t*LISTA DE EMPLEADOS*\n");
                Console.WriteLine("ID    | AREA | NOMBRE");

                
                using (TextReader BDEmpleados = new StreamReader("..\\..\\BDEmpleados.txt"))
                {
                    Console.WriteLine(BDEmpleados.ReadToEnd());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);  // Muestra cualquier excepción ocurrida
            }
        }

        /// <summary>
        /// Método para agregar un empleado al archivo "BDEmpleados.txt".
        /// </summary>
        public void AgregarEmpleadoArchivo()
        {
            try
            {
                Console.WriteLine("\tIngresa el ID del empleado:");
                string IdEmpleado = Console.ReadLine().ToString();
                Console.WriteLine("\tIngresa el nombre del empleado:");
                string NombreEmpleado = Console.ReadLine().ToString();
                Console.WriteLine("\tIngresa el Area:");
                string AreaEmpleado = Console.ReadLine().ToString();
                string lineaConFormato = $"{IdEmpleado,-7} {NombreEmpleado} {AreaEmpleado}";

            
                using (TextWriter BDEmpleados = File.AppendText("..\\..\\BDEmpleados.txt"))
                {
                    BDEmpleados.WriteLine(lineaConFormato);
                }

                Console.WriteLine("\tEmpleado agregado con éxito.\n"); 
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        /// <summary>
        /// Método para eliminar un empleado del archivo "BDEmpleados.txt".
        /// </summary>
        public void EliminarEmpleado()
        {
            try
            {
                Console.WriteLine("Escribe el ID del empleado que deseas eliminar:");
                string id = Console.ReadLine();

                List<string> lineasArchivo = new List<string>();

               
                using (StreamReader sr = new StreamReader("..\\..\\BDEmpleados.txt"))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] palabras = linea.Split();
                        if (id != palabras[0])
                        {
                            lineasArchivo.Add(linea); 
                        }
                    }
                }

                
                using (StreamWriter sw = new StreamWriter("..\\..\\BDEmpleados.txt"))
                {
                    foreach (string linea in lineasArchivo)
                    {
                        sw.WriteLine(linea);
                    }
                }

                Console.WriteLine("Empleado eliminado.");  
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}