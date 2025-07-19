using System;
using System.Collections.Generic;

class Persona {
    public string Nombre { get; set; }
    public int NumeroTicket { get; set; }
    public Persona(string nombre, int numero) {
        Nombre = nombre;
        NumeroTicket = numero;
    }
    public override string ToString() => $"Ticket {NumeroTicket} - {Nombre}";
}

class Cola {
    private Queue<Persona> cola = new Queue<Persona>();
    public void Encolar(Persona p) => cola.Enqueue(p);
    public Persona Desencolar() => cola.Count > 0 ? cola.Dequeue() : null;
    public int Count => cola.Count;
}

class Program {
    static void Main() {
        Cola cola = new Cola();
        int asientos = 5;
        string[] nombres = { "Cristhian", "Jackeline", "Jared", "Ashley", "Fabiola" };
        int ticket = 1;

        Console.WriteLine("Simulación de ingreso a la atracción:\n");
        for (int i = 0; i < asientos; i++) {
            Console.WriteLine($"Registrando: {nombres[i]} (Asiento disponible: {asientos - i})");
            cola.Encolar(new Persona(nombres[i], ticket++));
        }

        Console.WriteLine("\nOrden de ingreso:");
        while (cola.Count > 0) {
            Persona p = cola.Desencolar();
            Console.WriteLine($"{p} ha ingresado.");
        }
    }
}

