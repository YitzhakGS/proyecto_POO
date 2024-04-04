using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO
{
    internal class CEmpAlmacen:CEmpleado
    {
        CEmpAlmacen[] RegistroPedidos;
        int Cont;
        public decimal dinero = 10000;
        

        public CEmpAlmacen() 
        {
            RegistroPedidos = new CEmpAlmacen[5];
        }

        public void RealizarPedido()
        {
            Console.Clear();
            try
            {
                
                Console.WriteLine("\t\tLista de Proveedores\n");
                Console.WriteLine("ID Proveedor  | Tipo de Producto  | Nombre del Proveedor  | Precio  | Cantidad");
                TextReader BDProveedores = new StreamReader("..\\..\\BDProveedores.txt");
                Console.WriteLine(BDProveedores.ReadToEnd());
                BDProveedores.Close();
                Console.WriteLine("\n\t\tSeleccione el ID que corresponde al producto: ");
                string op = Console.ReadLine();

                using (StreamReader streamReader = new StreamReader("..\\..\\BDProveedores.txt"))
                {
                    TextReader DATAProveedores = streamReader;
                    string line = DATAProveedores.ReadLine();
                    while (line != null)
                    {
                        string[] palabras = line.Split();

                        for (int i = 0; i < palabras.Length; i++)
                        {
                            if (op == palabras[0])
                            {
                                Console.WriteLine($"\t\tSELECCIONO: {palabras[1]}\n");
                                string DATA = string.Join(" ", palabras);
                                Console.WriteLine("ID Proveedor  | Tipo de Producto  | Nombre del Proveedor  | Precio  | Cantidad");
                                Console.WriteLine(DATA);
                                break;
                            }
                        }

                        line = DATAProveedores.ReadLine();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //CPedidoAlmacen pedido = new CPedidoAlmacen();

        }

        public void Inventario()
        {

        }

        public void Informes()
        {

        }


    }

    

}
