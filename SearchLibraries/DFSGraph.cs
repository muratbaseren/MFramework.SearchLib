namespace MFramework.SearchLib
{
    public class DFSGraph
    {
        private int _numberOfNodes;
        private List<int>[] _adjacencyList;

        public DFSGraph(int numberOfNodes)
        {
            _numberOfNodes = numberOfNodes;
            _adjacencyList = new List<int>[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int node1, int node2)
        {
            _adjacencyList[node1].Add(node2);
            _adjacencyList[node2].Add(node1);
        }

        /// <summary>
        /// Depth-First Search (DFS - Derinlik-Öncelikli Arama); Depth-First Search (DFS) algoritması, bir grafın veya ağacın tüm düğümlerini ziyaret etmek için kullanılan bir algoritmadır. Algoritma, bir düğümün tüm alt düğümlerini keşfetmek için mümkün olduğunca derinlere iner ve keşfedilmemiş alt düğüm yoksa geri döner. DFS, bir düğümü ziyaret ettiğinde, o düğümün alt düğümlerini bir yığın (stack) veri yapısı üzerinde saklayarak ilerler.
        /// </summary>
        /// <param name="startNode"></param>
        public void DFS(int startNode)
        {
            bool[] visited = new bool[_numberOfNodes];
            Stack<int> stack = new Stack<int>();
            visited[startNode] = true;
            stack.Push(startNode);

            while (stack.Count != 0)
            {
                startNode = stack.Pop();
                Console.Write(startNode + " ");

                foreach (int adjNode in _adjacencyList[startNode])
                {
                    if (!visited[adjNode])
                    {
                        visited[adjNode] = true;
                        stack.Push(adjNode);
                    }
                }
            }
        }
    }
}