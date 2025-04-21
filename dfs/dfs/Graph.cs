namespace dfs
{
    class Graph
    {
        private Dictionary<int, List<int>> adjacencyList = new();

        public void AddEdge(int a, int b)
        {
            if (!adjacencyList.ContainsKey(a)) adjacencyList[a] = new List<int>();
            if (!adjacencyList.ContainsKey(b)) adjacencyList[b] = new List<int>();

            //Добавление вершин в граф
            adjacencyList[a].Add(b);
            adjacencyList[b].Add(a);
        }

        public int? DFSFindPathLength(int start, int target)
        {
            var visited = new HashSet<int>();
            return DFSRecursive(start, target, visited, 0);
        }

        private int? DFSRecursive(int current, int target, HashSet<int> visited, int depth)
        {
            if (current == target) return depth;

            visited.Add(current);

            if (!adjacencyList.ContainsKey(current)) return null;

            //Вычисление длины пути
            foreach (var neighbor in adjacencyList[current])
            {
                if (!visited.Contains(neighbor))
                {
                    var result = DFSRecursive(neighbor, target, visited, depth + 1);
                    if (result != null) return result;
                }
            }

            return null;
        }
    }
}
