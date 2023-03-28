namespace MFramework.SearchLib
{
    public class BFSGraph
    {
        private int _vertices;
        private List<int>[] _adjacencyList;

        public BFSGraph(int vertices)
        {
            _vertices = vertices;
            _adjacencyList = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int source, int destination)
        {
            _adjacencyList[source].Add(destination);
        }

        /// <summary>
        /// Breadth-First Search (BFS - Genişlik-Öncelikli Arama); Breadth-First Search (BFS), bir graf veya ağaç yapısındaki düğümleri keşfetmek için kullanılan bir arama algoritmasıdır. BFS, ağacın veya grafların her seviyesindeki düğümleri keşfeder ve daha sonra aşağıdaki seviyelere geçer. BFS, "genişliğe öncelik veren arama" olarak da adlandırılır.
        /// </summary>
        /// <param name="startVertex"></param>
        public void BFS(int startVertex)
        {
            bool[] visited = new bool[_vertices];
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count != 0)
            {
                int currentVertex = queue.Dequeue();
                Console.Write(currentVertex + " ");

                foreach (int adjacentVertex in _adjacencyList[currentVertex])
                {
                    if (!visited[adjacentVertex])
                    {
                        visited[adjacentVertex] = true;
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }
        }
    }
}