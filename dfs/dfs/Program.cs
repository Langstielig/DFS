using dfs;

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        Console.WriteLine("Введите пары рёбер через пробел, пустая строка — завершить:");

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

        Console.Write("Введите стартовую вершину: ");
        if (!int.TryParse(Console.ReadLine(), out int startNode))
        {
            Console.WriteLine("Неверный ввод стартовой вершины.");
            return;
        }

        List<int> dfsPath = graph.DFS(startNode);

        Console.WriteLine("Путь обхода в глубину:");
        Console.WriteLine(string.Join(", ", dfsPath));
    }
}