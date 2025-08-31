using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TraductorAmigable
{
    static void Main()
    {
        // Diccionario inicial inglés → español
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"Time", "tiempo"},
            {"Person", "persona"},
            {"Year", "año"},
            {"Way", "camino"},
            {"Day", "día"},
            {"Thing", "cosa"},
            {"Man", "hombre"},
            {"World", "mundo"},
            {"Life", "vida"},
            {"Hand", "mano"},
            {"Part", "parte"},
            {"Child", "niño"},
            {"Eye", "ojo"},
            {"Woman", "mujer"},
            {"Place", "lugar"},
            {"Work", "trabajo"},
            {"Week", "semana"},
            {"Case", "caso"},
            {"Point", "punto"},
            {"Government", "gobierno"},
            {"Company", "empresa"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\n========== BIENVENIDO AL TRADUCTOR ==========");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabra al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;
                case 2:
                    AgregarPalabra(diccionario);
                    break;
                case 0:
                    Console.WriteLine("Gracias por usar el traductor. Hasta pronto.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intenta de nuevo.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nEscribe la frase que deseas traducir: ");
        string frase = Console.ReadLine();

        // Dividir por palabras conservando la puntuación
        string resultado = Regex.Replace(frase, @"\b\w+\b", match =>
        {
            string palabra = match.Value;
            string traduccion;
            if (diccionario.TryGetValue(palabra, out traduccion))
            {
                // Mantener mayúscula inicial si estaba en la palabra original
                if (char.IsUpper(palabra[0]))
                {
                    traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);
                }
                return traduccion;
            }
            else
            {
                return palabra;
            }
        });

        Console.WriteLine("\nTraducción parcial:");
        Console.WriteLine(resultado);
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngresa la palabra en inglés: ");
        string ingles = Console.ReadLine().Trim();

        if (string.IsNullOrWhiteSpace(ingles))
        {
            Console.WriteLine("No ingresaste ninguna palabra. Intenta de nuevo.");
            return;
        }

        Console.Write("Ingresa su traducción al español: ");
        string espanol = Console.ReadLine().Trim();

        if (string.IsNullOrWhiteSpace(espanol))
        {
            Console.WriteLine("No ingresaste ninguna traducción. Intenta de nuevo.");
            return;
        }

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine($"La palabra '{ingles}' ha sido agregada al diccionario con éxito.");
        }
        else
        {
            Console.WriteLine($"La palabra '{ingles}' ya existe en el diccionario.");
        }
    }
}
