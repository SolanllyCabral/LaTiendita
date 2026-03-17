namespace LaTiendita
{
    public class Productos
    {
        static List<string> nombres = new List<string>();
        static List<double> precios = new List<double>();
        static List<int> stock = new List<int>();

        public static void RegistrarProducto()
        {
            Console.Write("\nIngrese el nombre del producto: ");
            string nombre = Console.ReadLine()!.ToUpper();

            double precio;
            Console.Write("\nIngrese el precio del producto: ");
            while (!double.TryParse(Console.ReadLine(), out precio))
            {
                Console.Write("Precio inválido. Intente de nuevo: ");
            }

            int cantidad;
            Console.Write("\nIngrese la cantidad en stock: ");
            while (!int.TryParse(Console.ReadLine(), out cantidad))
            {
                Console.Write("Cantidad inválida. Intente de nuevo: ");
            }

            nombres.Add(nombre);
            precios.Add(precio);
            stock.Add(cantidad);

            Console.WriteLine("\nProducto registrado exitosamente.");
        }

        public static void ListarProductos()
        {
            Console.WriteLine("\n========================================================================");
            Console.WriteLine("            LISTA DE PRODUCTOS            ");
            Console.WriteLine("========================================================================");
            Console.WriteLine($"{"NO.",-10} {"Producto",-15} {"Precio",-15} {"Stock",-15} {"Estado Stock"}");
            Console.WriteLine("------------------------------------------------------------------------");

            for (int i = 0; i < nombres.Count; i++)
            {
                string alerta = stock[i] < 5 ? "BAJO" : "";

                Console.WriteLine($"{i + 1,-10} {nombres[i],-15} RD$ {precios[i],-15} {stock[i],-15} {alerta}");
            }

            Console.WriteLine("========================================================================");
        }

        public static void ActualizarStock()
        {
            int indice;
            while (true)
            {
                ListarProductos();

                Console.Write("\nEscriba el número del producto que desea actualizar: ");
                while(!int.TryParse(Console.ReadLine(), out indice))
                {
                    Console.Write("Número inválido. Intente de nuevo: ");
                }
                indice -= 1;

                if (indice < 0 || indice >= nombres.Count)
                {
                    Console.WriteLine("Producto no válido.");
                    continue;
                }

                break;
            }

            int nuevaCantidad;
            Console.Write("\nNueva cantidad: ");
            while(!int.TryParse(Console.ReadLine(), out nuevaCantidad))
            {
                Console.Write("Cantidad inválida. Intente de nuevo: ");
            }

            stock[indice] = nuevaCantidad;

            Console.WriteLine($"\nProducto {nombres[indice]} actualizado.");
            Console.WriteLine($"El nuevo stock es de {nuevaCantidad}.");

        }

        public static void EliminarProducto()
        {
            int indice;
            while (true)
            {
                ListarProductos();

                Console.Write("\nIngrese el número del producto a eliminar: ");
                while (!int.TryParse(Console.ReadLine(), out indice))
                {
                    Console.Write("Número inválido. Intente de nuevo: ");
                }

                indice -= 1;

                if (indice < 0 || indice >= nombres.Count)
                {
                    Console.WriteLine("Producto no válido.");
                    continue;
                }

                break;
            }
            string productoEliminado = nombres[indice];

            nombres.RemoveAt(indice);
            precios.RemoveAt(indice);
            stock.RemoveAt(indice);

            Console.WriteLine($"Producto {productoEliminado} eliminado.");

        }

        public static void GenerarFacura()
        {
            List<string> productosFactura = new List<string>();
            List<int> cantidadesFactura = new List<int>();
            List<double> preciosFactura = new List<double>();

            double total = 0;
            string comprarDeNuevo = "S";
            string salir = "Salir";

            while(comprarDeNuevo == "S")
            {
                int indice;
                while (true)
                {
                    ListarProductos();

                    Console.Write("\nEscriba el número del producto a seleccionar: ");
                    while(!int.TryParse(Console.ReadLine(), out indice))
                    {
                        Console.Write("Número inválido. Intente de nuevo: ");
                    }
                    indice -= 1;

                    if (indice < 0 || indice >= nombres.Count)
                    {
                        Console.WriteLine("Producto no válido.");
                        continue;
                    }

                    break;
                }

                int cantidad;
                Console.Write("\nCantidad: ");
                while (!int.TryParse(Console.ReadLine(), out cantidad))
                {
                    Console.Write("Cantidad inválida. Intente de nuevo: ");
                }

                if (cantidad > stock[indice])
                {
                    Console.WriteLine("Stock insuficiente. Por favor intente de nuevo.");

                    Console.WriteLine("¿Desea comprar otro producto? S/N: ");
                    salir = Console.ReadLine()!.ToUpper();
                    
                    if ( salir == "N")
                    {
                        break;
                    }

                    continue;
                }

                double subtotal = precios[indice] * cantidad;

                total += subtotal;

                productosFactura.Add(nombres[indice]);
                cantidadesFactura.Add(cantidad);
                preciosFactura.Add(precios[indice]);

                stock[indice] -= cantidad;

                Console.WriteLine("Producto agregado.");

                Console.Write("¿Desea comprar otro producto? S/N: ");
                comprarDeNuevo = Console.ReadLine()!.ToUpper();

            }
            MostrarFactura(productosFactura, cantidadesFactura, preciosFactura);
        }

        static void MostrarFactura(List<string> productos, List<int> cantidades, List<double> precios)
        {
            double total = 0;

            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("             LA TIENDITA");
            Console.WriteLine("=======================================================");
            Console.WriteLine($"{"Producto",-15} {"Cantidad",-15} {"Precio",-15} {"Subtotal",-15}");
            Console.WriteLine("-------------------------------------------------------");

            for (int i = 0; i < productos.Count; i++)
            {
                double subtotal = cantidades[i] * precios[i];
                total += subtotal;

                Console.WriteLine($"{productos[i],-15} {cantidades[i],-15} RD$ {precios[i],-15:F2} RD$ {subtotal,-15:F2}");
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"{"TOTAL:",-35} RD$ {total:F2}");
            Console.WriteLine("=======================================================");

            Console.WriteLine("\n¡Gracias por su compra!");
            Console.ReadKey();
        }

        public static void Salir()
        {
            Console.WriteLine("\nGracias por usar La Tiendita. ¡Hasta luego!");
            Environment.Exit(0);
        }
    }
}
