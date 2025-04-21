namespace dfs
{
    class Graph
    {
        private Dictionary<int, List<int>> adjacencyList = new();

        public void AddEdge(int a, int b)
        {
            if (!adjacencyList.ContainsKey(a)) adjacencyList[a] = new List<int>();
            if (!adjacencyList.ContainsKey(b)) adjacencyList[b] = new List<int>();

            adjacencyList[a].Add(b);
            adjacencyList[b].Add(a); // неориентированный граф
        }

        public List<int> DFS(int start)
        {
            var visited = new HashSet<int>();
            var result = new List<int>();
            DFSRecursive(start, visited, result);
            return result;
        }

        private void DFSRecursive(int current, HashSet<int> visited, List<int> result)
        {
            if (visited.Contains(current)) return;

            visited.Add(current);
            result.Add(current);

            if (!adjacencyList.ContainsKey(current)) return;

            foreach (var neighbor in adjacencyList[current])
            {
                DFSRecursive(neighbor, visited, result);
            }
        }
    }
}
