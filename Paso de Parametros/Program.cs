using System;
using System.Collections.Generic;
using System.Linq;

namespace Productos
{
    public struct Producto
    {
        public string Nombre, Inventario;
        public int Cantidad;
        public double Precio;

        public Producto(string nombre, string inventario, int cantidad, double precio)
        {
            Nombre = nombre;
            Inventario = inventario;
            Cantidad = cantidad;
            Precio = precio;
        }
    }

    public class Productos
    {
        private static List<Producto> productos = new List<Producto>();

        public static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("╔═══════ Productos ═══════╗");
                Console.WriteLine("║                         ║");
                Console.WriteLine("║  1. Nuevo Producto      ║");
                Console.WriteLine("║  2. Leer Productos      ║");
                Console.WriteLine("║  3. Actualizar Producto ║");
                Console.WriteLine("║  4. Eliminar Producto   ║");
                Console.WriteLine("║  5. Total de Inventario ║");
                Console.WriteLine("║  6. Salir               ║");
                Console.WriteLine("║                         ║");
                Console.WriteLine("╚═════════════════════════╝");
                Console.Write("\nSeleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: AgregarProducto(); break;
                    case 2: LeerProductos(); break;
                    case 3: ActualizarProducto(); break;
                    case 4: EliminarProducto(); break;
                    case 5: TotalInventario(); break;
                    case 6: break;
                    default: Console.Clear(); break;
                }
            } while (opcion != 6);
        }

        public static void AgregarProducto()
        {
            Console.Write("Ingrese el nombre del Producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el Inventario al que pertenece el producto: ");
            string inventario = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto en inventario: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio unitario del producto: ");
            double precio = double.Parse(Console.ReadLine());

            Producto producto = new Producto(nombre, inventario, cantidad, precio);
            productos.Add(producto);

            Console.WriteLine("Producto agregado exitosamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void LeerProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos para mostrar.");
            }
            else
            {
                Console.WriteLine("\nProductos");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"Nombre: {producto.Nombre}");
                    Console.WriteLine($"Inventario: {producto.Inventario}");
                    Console.WriteLine($"Cantidad: {producto.Cantidad}");
                    Console.WriteLine($"Precio unitario: {producto.Precio}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EliminarProducto()
        {
            Console.Write("Ingrese el Nombre del Producto a eliminar: ");
            string search = Console.ReadLine();
            var producto = productos.FirstOrDefault(p => p.Nombre.ToLower() == search.ToLower());

            if (producto.Nombre != null)
            {
                productos.Remove(producto);
                Console.WriteLine("El Producto fue eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("El Producto no se ha encontrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ActualizarProducto()
        {
            Console.Write("Ingrese el nombre del Producto: ");
            string search = Console.ReadLine();
            var index = productos.FindIndex(p => p.Nombre.ToLower() == search.ToLower());

            if (index != -1)
            {
                Producto producto = productos[index];

                Console.Write("Ingrese el nuevo Inventario: ");
                producto.Inventario = Console.ReadLine();
                Console.Write("Ingrese la nueva cantidad: ");
                producto.Cantidad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el nuevo precio: ");
                producto.Precio = double.Parse(Console.ReadLine());

                productos[index] = producto;

                Console.WriteLine("El producto fue actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se ha encontrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void TotalInventario()
        {
            Console.Write("Ingrese el nombre del Inventario: ");
            string search = Console.ReadLine();
            var productosInventario = productos.Where(p => p.Inventario.ToLower() == search.ToLower()).ToList();

            if (productosInventario.Count > 0)
            {
                double total = productosInventario.Sum(p => p.Precio * p.Cantidad);
                Console.WriteLine($"El total de los productos en el Inventario {search} es: ${total}");
            }
            else
            {
                Console.WriteLine("El inventario no se ha encontrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
