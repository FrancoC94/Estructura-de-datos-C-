using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaniaVacunacionCovid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Total de ciudadanos simulados
            int totalCiudadanos = 500;
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= totalCiudadanos; i++)
                ciudadanos.Add($"Ciudadano {i}");

            // Generador aleatorio con semilla para que los resultados sean reproducibles
            Random random = new Random(20250821);

            // 75 vacunados con Pfizer
            HashSet<string> vacunadosPfizer = new HashSet<string>();
            while (vacunadosPfizer.Count < 75)
            {
                int id = random.Next(1, totalCiudadanos + 1);
                vacunadosPfizer.Add($"Ciudadano {id}");
            }

            // 75 vacunados con AstraZeneca
            HashSet<string> vacunadosAstra = new HashSet<string>();
            while (vacunadosAstra.Count < 75)
            {
                int id = random.Next(1, totalCiudadanos + 1);
                vacunadosAstra.Add($"Ciudadano {id}");
            }

            // Operaciones de conjuntos
            var noVacunados = ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstra)).ToList();
            var ambasDosis = vacunadosPfizer.Intersect(vacunadosAstra).ToList();
            var soloPfizer = vacunadosPfizer.Except(vacunadosAstra).ToList();
            var soloAstra = vacunadosAstra.Except(vacunadosPfizer).ToList();

            // Resultados
            Console.WriteLine("Campaña de Vacunación COVID-19 (Simulación)");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine($"Total de ciudadanos: {ciudadanos.Count}\n");

            Console.WriteLine($"1) No vacunados: {noVacunados.Count}");
            Console.WriteLine(string.Join(", ", noVacunados.Take(15)) + (noVacunados.Count > 15 ? "..." : ""));
            Console.WriteLine();

            Console.WriteLine($"2) Con ambas dosis: {ambasDosis.Count}");
            Console.WriteLine(string.Join(", ", ambasDosis));
            Console.WriteLine();

            Console.WriteLine($"3) Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine(string.Join(", ", soloPfizer.Take(15)) + (soloPfizer.Count > 15 ? "..." : ""));
            Console.WriteLine();

            Console.WriteLine($"4) Solo AstraZeneca: {soloAstra.Count}");
            Console.WriteLine(string.Join(", ", soloAstra.Take(15)) + (soloAstra.Count > 15 ? "..." : ""));
        }
    }
}

