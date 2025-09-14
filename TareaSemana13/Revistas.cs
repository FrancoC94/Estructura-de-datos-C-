using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Lista que almacena los títulos de las revistas
        static List<string> catalogo = new List<string>
        {
            "National Geographic",
            "Time",
            "Scientific American",
            "Forbes",
            "The Economist",
            "Nature",
            "Wired",
            "Sports Illustrated",
            "People",
            "Harvard Business Review"
        };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Catálogo de Revistas ===");
                Console.WriteLine("1. Buscar revista");
                Console.WriteLine("2. Salir");
                Console.Write("Selecciona una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Debes ingresar un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        BuscarRevista();
                        break;
                    case 2:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 2);
        }

        // Método para pedir un título y buscarlo recursivamente
        static void BuscarRevista()
        {
            Console.Write("\nIngresa el título de la revista que deseas buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = BuscarRecursivo(catalogo, titulo, 0);

            if (encontrado)
                Console.WriteLine("Resultado: Encontrado");
            else
                Console.WriteLine("Resultado: No encontrado");
        }

        // Función recursiva que busca el título en la lista
        static bool BuscarRecursivo(List<string> lista, string titulo, int indice)
        {
            if (indice >= lista.Count)
                return false;

            if (lista[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;

            return BuscarRecursivo(lista, titulo, indice + 1);
        }
    }
}
