using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaTiendita
{
    public class Menu
    {
        public static void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("\nBienvenido a La Tiendita");
                Console.WriteLine("Menú");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Mostrar productos");
                Console.WriteLine("3. Actualizar stock");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Generar factura");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                int opcion;

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("\nDebe colocar un número válido.");
                }

                switch (opcion) 
                {
                    case 1:
                        Productos.RegistrarProducto();
                        break;
                    case 2:
                        Productos.ListarProductos();
                        break;
                    case 3:
                        Productos.ActualizarStock();
                        break;
                    case 4:
                        Productos.EliminarProducto();
                        break;
                    case 5:
                        Productos.GenerarFacura();
                        break;
                    case 6:
                        Productos.Salir();
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida, por favor intente de nuevo.");
                        break;
                }
            }
        }
    }
}
