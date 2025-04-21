using dfs;

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        Console.WriteLine("Введите пары рёбер через пробел. Пустая строка — завершить:");

        //Input of edges
        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) break;

            var parts = line.Split();
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int a) ||
                !int.TryParse(parts[1], out int b))
            {
                Console.WriteLine("Неверный формат. Введите две цифры через пробел.");
                continue;
            }

            graph.AddEdge(a, b);
        }

        //Input of vertices
        Console.Write("Введите стартовую вершину: ");
        if (!int.TryParse(Console.ReadLine(), out int start))
        {
            Console.WriteLine("Неверный ввод.");
            return;
        }

        Console.Write("Введите конечную вершину: ");
        if (!int.TryParse(Console.ReadLine(), out int target))
        {
            Console.WriteLine("Неверный ввод.");
            return;
        }

        //Path length calculation
        var pathLength = graph.DFSFindPathLength(start, target);

        if (pathLength != null)
        {
            Console.WriteLine($"Длина пути от {start} до {target}: {pathLength}");
        }
        else
        {
            Console.WriteLine($"Путь от {start} до {target} не найден.");
        }
    }
}