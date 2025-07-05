using System;

namespace ListaEnlazadaUnica
{
    // Nodo de la lista
    class Nodo
    {
        public int Valor;
        public Nodo Siguiente;

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    // Lista enlazada simple
    class ListaEnlazada
    {
        private Nodo cabeza;

        // Insertar al inicio (modo stack/pila)
        public void InsertarInicio(int valor)
        {
            Nodo nuevo = new Nodo(valor);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // Mostrar todos los elementos
        public void Mostrar()
        {
            Nodo actual = cabeza;
            Console.WriteLine("Lista enlazada:");
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // Contar nodos con valores pares
        public int ContarPares()
        {
            int contador = 0;
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Valor % 2 == 0)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }

            return contador;
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            Console.WriteLine("Insertando valores al inicio...");
            lista.InsertarInicio(15);
            lista.InsertarInicio(28);
            lista.InsertarInicio(9);
            lista.InsertarInicio(42);
            lista.InsertarInicio(33);

            lista.Mostrar();

            Console.WriteLine("\nEjercicio 2: Contar nodos con números pares...");
            int totalPares = lista.ContarPares();
            Console.WriteLine($"Cantidad de nodos con valores pares: {totalPares}");
        }
    }
}
