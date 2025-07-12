using System;
using System.Collections.Generic;

class Program
{
    class Torre
    {
        public Stack<int> Discos = new Stack<int>();
        public string Nombre;

        public Torre(string nombre)
        {
            Nombre = nombre;
        }

        public void MoverDesde(Torre origen)
        {
            int disco = origen.Discos.Pop();
            Discos.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {origen.Nombre} a {Nombre}");
        }
    }

    static void Resolver(int n, Torre origen, Torre destino, Torre auxiliar)
    {
        if (n == 1)
        {
            destino.MoverDesde(origen);
        }
        else
        {
            Resolver(n - 1, origen, auxiliar, destino);
            destino.MoverDesde(origen);
            Resolver(n - 1, auxiliar, destino, origen);
        }
    }

    static void Main()
    {
        Console.WriteLine("Torres de Hanoi");
        Console.Write("¿Cuántos discos deseas mover? ");
        int n = int.Parse(Console.ReadLine());

        Torre torreA = new Torre("A");
        Torre torreB = new Torre("B");
        Torre torreC = new Torre("C");

        for (int i = n; i >= 1; i--)
        {
            torreA.Discos.Push(i);
        }

        Console.WriteLine("Movimientos necesarios:");
        Resolver(n, torreA, torreC, torreB);

        Console.WriteLine("Proceso finalizado. Presiona una tecla para salir.");
        Console.ReadKey();
    }
}

