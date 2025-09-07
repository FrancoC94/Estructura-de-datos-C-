using System;
using System.Collections.Generic;

class ProgramaTorneo
{
    static Dictionary<string, HashSet<string>> equipos = new Dictionary<string, HashSet<string>>();

    static void AgregarEquipo(string nombreEquipo)
    {
        if (!equipos.ContainsKey(nombreEquipo))
        {
            equipos[nombreEquipo] = new HashSet<string>();
            Console.WriteLine($"Equipo {nombreEquipo} agregado correctamente.");
        }
        else
        {
            Console.WriteLine($"El equipo {nombreEquipo} ya existe.");
        }
    }

    static void AgregarJugador(string nombreEquipo, string jugador)
    {
        if (equipos.ContainsKey(nombreEquipo))
        {
            if (equipos[nombreEquipo].Add(jugador))
            {
                Console.WriteLine($"Jugador {jugador} agregado al equipo {nombreEquipo}.");
            }
            else
            {
                Console.WriteLine($"El jugador {jugador} ya pertenece al equipo {nombreEquipo}.");
            }
        }
        else
        {
            Console.WriteLine($"El equipo {nombreEquipo} no está registrado.");
        }
    }

    static void MostrarEquipos()
    {
        foreach (var equipo in equipos)
        {
            Console.WriteLine($"Equipo: {equipo.Key}, Jugadores: {string.Join(", ", equipo.Value)}");
        }
    }

    static void Main(string[] args)
    {
        AgregarEquipo("Independiente");
        AgregarJugador("Independiente", "Juan");
        AgregarJugador("Independiente", "Pedro");
        AgregarEquipo("Barcelona");
        AgregarJugador("Barcelona", "Carlos");
        AgregarJugador("Barcelona", "Juan"); // prueba de duplicación
        MostrarEquipos();
    }
}
