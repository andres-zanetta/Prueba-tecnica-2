using System;

class Programa
{
    static void Main()
    {
        char[,] sala = new char[5, 8];
        int[,] precios = {
            { 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500 },
            { 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500 },
            { 1200, 1200, 1200, 1200, 1200, 1200, 1200, 1200 },
            { 1200, 1200, 1200, 1200, 1200, 1200, 1200, 1200 },
            { 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000 }
        };

        int totalRecaudado = 0;
        int entradasVendidas = 0;

        // Inicializamos la sala como libre
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 8; j++)
                sala[i, j] = 'L';

        while (true)
        {
            Console.Clear();
            MostrarMapa(sala);
            Console.WriteLine("\nIngrese fila (1-5) o 0 para salir:");
            if (!int.TryParse(Console.ReadLine(), out int fila) || fila < 0 || fila > 5)
            {
                Console.WriteLine("⚠ Entrada inválida. Presione una tecla para continuar.");
                Console.ReadKey();
                continue;
            }

            if (fila == 0) break;

            Console.WriteLine("Ingrese número de asiento (1-8):");
            if (!int.TryParse(Console.ReadLine(), out int asiento) || asiento < 1 || asiento > 8)
            {
                Console.WriteLine("⚠ Asiento inválido. Presione una tecla para continuar.");
                Console.ReadKey();
                continue;
            }

            int f = fila - 1;
            int a = asiento - 1;

            if (sala[f, a] == 'X')
            {
                Console.WriteLine("❌ Ese asiento ya está ocupado. Intente con otro.");
                Console.ReadKey();
                continue;
            }

            int precio = precios[f, a];
            Console.WriteLine($"💲 El precio del asiento es: ${precio}");
            Console.WriteLine("¿Desea confirmar la reserva? (s/n):");
            string confirmacion = Console.ReadLine().ToLower();

            if (confirmacion == "s")
            {
                sala[f, a] = 'X';
                totalRecaudado += precio;
                entradasVendidas++;
                Console.WriteLine("✅ Reserva confirmada.");
            }
            else
            {
                Console.WriteLine("Reserva cancelada.");
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        Console.Clear();
        MostrarMapa(sala);
        Console.WriteLine($"\n🎟 Entradas vendidas: {entradasVendidas}");
        Console.WriteLine($"💰 Total recaudado: ${totalRecaudado}");
    }

    static void MostrarMapa(char[,] sala)
    {
        Console.WriteLine("MAPA DE LA SALA (L: Libre, X: Ocupado)\n");
        Console.Write("     ");
        for (int j = 0; j < sala.GetLength(1); j++)
        {
            Console.Write($"A{j + 1} ");
        }
        Console.WriteLine();

        for (int i = 0; i < sala.GetLength(0); i++)
        {
            Console.Write($"F{i + 1} | ");
            for (int j = 0; j < sala.GetLength(1); j++)
            {
                Console.Write($" {sala[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
