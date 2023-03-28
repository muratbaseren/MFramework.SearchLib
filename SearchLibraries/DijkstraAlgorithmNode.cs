namespace MFramework.SearchLib
{
    public class DijkstraAlgorithmNode
    {
        public string Name { get; set; }
        public List<DijkstraAlgorithmEdge> Edges { get; set; }
        public int Distance { get; set; }
        public bool Visited { get; set; }

        public DijkstraAlgorithmNode(string name)
        {
            Name = name;
            Edges = new List<DijkstraAlgorithmEdge>();
            Distance = int.MaxValue;
            Visited = false;
        }

        public void AddEdge(DijkstraAlgorithmNode destination, int weight)
        {

            DijkstraAlgorithmEdge edge = new DijkstraAlgorithmEdge(destination, weight);
            edge.FromNode = this;
            edge.ToNode = destination;
            Edges.Add(edge);
        }
    }
}