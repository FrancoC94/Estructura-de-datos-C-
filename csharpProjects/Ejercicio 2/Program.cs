using System;

class Vehiculo
{
    public string Placa, Marca, Modelo;
    public int Año;
    public double Precio;
    public Vehiculo Siguiente;

    public Vehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        Placa = placa; Marca = marca; Modelo = modelo; Año = año; Precio = precio; Siguiente = null;
    }
}

class Estacionamiento
{
    Vehiculo cabeza;

    public void Agregar(Vehiculo v)
    {
        if (cabeza == null) cabeza = v;
        else
        {
            var actual = cabeza;
            while (actual.Siguiente != null) actual = actual.Siguiente;
            actual.Siguiente = v;
        }
        Console.WriteLine($"Agregado {v.Placa}");
    }

    public Vehiculo Buscar(string placa)
    {
        var actual = cabeza;
        while (actual != null)
        {
            if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                return actual;
            actual = actual.Siguiente;
        }
        return null;
    }

    public void VerPorAño(int año)
    {
        var actual = cabeza;
        bool encontrado = false;
        while (actual != null)
        {
            if (actual.Año == año)
            {
                Console.WriteLine($"{actual.Placa} {actual.Marca} {actual.Modelo} ${actual.Precio}");
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
        if (!encontrado) Console.WriteLine("No hay vehículos de ese año.");
    }

    public void VerTodos()
    {
        var actual = cabeza;
        if (actual == null) Console.WriteLine("No hay vehículos.");
        while (actual != null)
        {
            Console.WriteLine($"{actual.Placa} {actual.Marca} {actual.Modelo} {actual.Año} ${actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    public bool Eliminar(string placa)
    {
        Vehiculo actual = cabeza, previo = null;
        while (actual != null)
        {
            if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                if (previo == null) cabeza = actual.Siguiente;
                else previo.Siguiente = actual.Siguiente;
                Console.WriteLine($"Eliminado {placa}");
                return true;
            }
            previo = actual;
            actual = actual.Siguiente;
        }
        Console.WriteLine("No encontrado");
        return false;
    }
}

class Program
{
    static void Main()
    {
        var parqueadero = new Estacionamiento();
        while (true)
        {
            Console.WriteLine("\n1-Agregar 2-Buscar 3-Ver por año 4-Ver todos 5-Eliminar 6-Salir");
            string op = Console.ReadLine();
            if (op == "6") break;

            switch (op)
            {
                case "1":
                    Console.Write("Placa: "); string p = Console.ReadLine();
                    Console.Write("Marca: "); string m = Console.ReadLine();
                    Console.Write("Modelo: "); string mo = Console.ReadLine();
                    Console.Write("Año: "); int a = int.Parse(Console.ReadLine());
                    Console.Write("Precio: "); double pr = double.Parse(Console.ReadLine());
                    parqueadero.Agregar(new Vehiculo(p, m, mo, a, pr));
                    break;

                case "2":
                    Console.Write("Placa a buscar: ");
                    var v = parqueadero.Buscar(Console.ReadLine());
                    if (v != null) Console.WriteLine($"{v.Placa} {v.Marca} {v.Modelo} {v.Año} ${v.Precio}");
                    else Console.WriteLine("No encontrado");
                    break;

                case "3":
                    Console.Write("Año: ");
                    parqueadero.VerPorAño(int.Parse(Console.ReadLine()));
                    break;

                case "4":
                    parqueadero.VerTodos();
                    break;

                case "5":
                    Console.Write("Placa a eliminar: ");
                    parqueadero.Eliminar(Console.ReadLine());
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
        Console.WriteLine("Adiós!");
    }
}