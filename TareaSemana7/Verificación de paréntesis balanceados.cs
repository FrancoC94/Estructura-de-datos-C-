using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Verificación de paréntesis, llaves y corchetes balanceados");
        Console.Write("Escribe una expresión matemática: ");
        string expresion = Console.ReadLine();

        if (EstaBalanceado(expresion))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula NO balanceada.");
        }

        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }

    static bool EstaBalanceado(string texto)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in texto)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0)
                    return false;

                char abierto = pila.Pop();

                if ((c == ')' && abierto != '(') ||
                    (c == ']' && abierto != '[') ||
                    (c == '}' && abierto != '{'))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0;
    }
}
