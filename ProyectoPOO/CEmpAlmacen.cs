using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class CEmpAlmacen:CEmpleado
    {
        List<CPedidoAlmacen> RegistroPedidos;

        public CEmpAlmacen() 
        {
            RegistroPedidos = new List<CPedidoAlmacen>();
        }
        /// <summary>
        /// Autor: guerrero jimenez jesse isaac
        /// esta funcion permite que el empelado acceda a la "base de datos" donde se guardan los proveedores, para posteriormente 
        /// selecionar uno mediante el id_proveedor, que es mediante leer el archivo txt, e ir recorriendolo por renlones y luego
        /// cada renglon se almacena en una cadena y se pasa a un arreglo donde se puede acceder a cada uno de los datos de forma separada,
        /// cuando se selecciona un producto se guarda este arreglo del cual se obtienen los datos para asignarlos a una instancia de la
        /// clase CPedidoAlmacen
        /// </summary>
        public void RealizarPedido()
        {
            try
            {
                string DATO = "";
                string resp = "";
                bool validar = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\tLista de Proveedores\n");
                    Console.WriteLine("ID Proveedor  | Tipo de Producto  | Nombre del Proveedor  | Precio  | Cantidad");
                    TextReader BDProveedores = new StreamReader("..\\..\\BDProveedores.txt");
                    Console.WriteLine(BDProveedores.ReadToEnd());
                    BDProveedores.Close();
                    Console.WriteLine("\n\tSeleccione el ID que corresponde al producto y si desea salir pusle (S)");
                    string op = Console.ReadLine();

                    if (op == "S" || op == "s")
                    {
                        break;
                    }
                    else
                    {   //lee el archivo por renglones y lo mete en una lista para diferenciar cada elemento
                        using (StreamReader streamReader = new StreamReader("..\\..\\BDProveedores.txt"))
                        {
                            TextReader DATAProveedores = streamReader;
                            string line = DATAProveedores.ReadLine();
                            while (line != null)
                            {
                                string[] palabras = line.Split();

                                if (op == palabras[0])
                                {
                                    validar = false;
                                    Console.Clear();
                                    Console.WriteLine($"\t\tSELECCIONO: {palabras[12]}\n");
                                    DATO = string.Join(" ", palabras);
                                    Console.WriteLine("ID Proveedor  | Tipo de Producto  | Nombre del Proveedor  | Precio  | Cantidad");
                                    Console.WriteLine(DATO);
                                    Console.WriteLine("\nCONFIRMAR EL PEDIDO S(Si) / N(No): ");
                                    break;
                                }
                                line = DATAProveedores.ReadLine();
                            }
                        }

                        if (validar == true)
                        {
                            Console.WriteLine("\n\tOPCION NO VALIDA\tINTENTE DE NUEVO...");
                            Console.ReadLine();
                            resp = "N";
                        }
                        else
                        {
                            resp = Console.ReadLine();
                        }
                    }
                    
                } while (resp == "N" || resp == "n");
                
                if (resp == "S" ||  resp == "s")
                {
                    CPedidoAlmacen pedido = new CPedidoAlmacen();
                    DateTime fechaHoraActual = DateTime.Now;
                    //la cadena que contiene los datos del pedido lo paso a un arreglo y elimino los espacios
                    string[] orden = DATO.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    pedido.IdOrden = orden[0];
                    pedido.TipoProductos = orden[1];
                    pedido.Proveedor = orden[2];
                    string precioString = orden[3].Replace("$","");
                    pedido.Precio = Convert.ToDecimal(precioString);
                    pedido.CantidadProductos = orden[4];
                    pedido.DateTime = fechaHoraActual;
                    RegistroPedidos.Add(pedido);
                    Console.WriteLine("\n\t\t\t*PEDIDO REGISTRADO CON EXITO*\n");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        /// <summary>
        /// Autor: guerrero jiemenez jesse isaac
        /// esta funcion muestra la "base de datos" o lista de el inventario en el almacen y le da al ususario
        /// opciones para eliminar, o anexar algun producto
        /// </summary>
        public void MenuInventario()
        {
            try
            {
                Program menu = new Program();
                Console.Clear();
                Console.WriteLine("\t\t*LISTA DE INVENTARIO*\n");
                Console.WriteLine("ID    | Tipo de Producto | Cantidad Disponible");
                TextReader BDProveedores = new StreamReader("..\\..\\BDInventario.txt");
                Console.WriteLine(BDProveedores.ReadToEnd());
                BDProveedores.Close();
                menu.MenuInventario();
            }
            catch (IOException ex) { Console.WriteLine(ex); }
        }


        /// <summary>
        /// Autor: guerrero jimenez jesse isaac
        /// esta funcion es para anexar algun rpoducto a la lista de invetario y agregarlo al achivo BDInventario
        /// </summary>
        public void AgregarInventario()
        {
            try
            {
                Console.WriteLine("\tIngresa un ID para el producto:");
                string IdProducto = Console.ReadLine().ToString();
                Console.WriteLine("\tIngresa el nombre del producto:");
                string TipoProducto = Console.ReadLine().ToString();
                Console.WriteLine("\tIngresa la cantidad:");
                string Cantidad = Console.ReadLine().ToString();
                string lineaConFormato = $"{IdProducto,-7} {TipoProducto,-18} {Cantidad}";
                TextWriter BDProveedores = File.AppendText("..\\..\\BDInventario.txt");
                BDProveedores.WriteLine(lineaConFormato);
                BDProveedores.Close();
                Console.WriteLine("\tProducto agregado al inventario con éxito.\n");
                Console.ReadLine();
                MenuInventario();
            }
            catch (IOException ex ){ Console.WriteLine(ex); }
        }


        /// <summary>
        /// Autor: guerrero jimenez jesse isaac
        /// esta funcion es para eliminar algun producto de la lista de inventari, dende lo busca por 
        /// id y elimina esa linea
        /// </summary>
        public void EliminarInventario()
        {
            try
            {
                Console.WriteLine("Escribe el ID del producto que desea eliminar:");
                string id = Console.ReadLine();

                // Lista para almacenar todas las líneas del archivo, excepto la línea a eliminar
                List<string> lineasArchivo = new List<string>();

                using (StreamReader sr = new StreamReader("..\\..\\BDInventario.txt"))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] palabras = linea.Split();

                        // Si la línea no contiene el ID del producto a eliminar, agrégala a la lista
                        if (id != palabras[0])
                        {
                            lineasArchivo.Add(linea);
                        }
                    }
                }

                // Reescribir el archivo con todas las líneas excepto la línea a eliminar
                using (StreamWriter sw = new StreamWriter("..\\..\\BDInventario.txt"))
                {
                    foreach (string linea in lineasArchivo)
                    {
                        sw.WriteLine(linea);
                    }
                }
                Console.WriteLine("Producto eliminado del inventario con éxito.");
                MenuInventario();
            }
            catch (IOException ex) { Console.WriteLine(ex); }
        }

        /// <summary>
        /// Autor: guerrero jimenez jesse isaac 
        /// en esta funcion utilizo StringBuilder para crear un contenedor de cadenas de texto en donde voy a anexar
        /// asi como darle fornato a la instancias de CPedidoAlmacen, para despues escribir estas cadenas en el archico
        /// BDInforme, guardando el archivo y mostrnadolo por pantalla, asi como el total del gasto que serian estos pedidos
        /// </summary>
        public void Informes()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\t\t*LISTA DE PEDIDO REALIZADOS*\n");

                StringBuilder contenidoArchivo = new StringBuilder();

                foreach (CPedidoAlmacen pedido in RegistroPedidos)
                {
                    contenidoArchivo.AppendLine($"\tID Orden: {pedido.IdOrden}");
                    contenidoArchivo.AppendLine($"\tTipo de Productos: {pedido.TipoProductos}");
                    contenidoArchivo.AppendLine($"\tProveedor: {pedido.Proveedor}");
                    contenidoArchivo.AppendLine($"\tPrecio: ${pedido.Precio}");
                    contenidoArchivo.AppendLine($"\tCantidad de Productos: {pedido.CantidadProductos}");
                    contenidoArchivo.AppendLine($"\tFecha y Hora: {pedido.DateTime}");
                    contenidoArchivo.AppendLine("\t--------------------------------------\n");
                }

                // Escribir el contenido en el archivo
                using (TextWriter archivo = new StreamWriter("..\\..\\BDInforme.txt"))
                {
                    archivo.Write(contenidoArchivo.ToString());
                }
                // mostrar el contenido en pantalla
                using (TextReader archivo = new StreamReader("..\\..\\BDInforme.txt"))
                {
                    Console.WriteLine(archivo.ReadToEnd());
                }
            }
            catch (IOException ex) { Console.WriteLine(ex); }

        }

    }
   

}
