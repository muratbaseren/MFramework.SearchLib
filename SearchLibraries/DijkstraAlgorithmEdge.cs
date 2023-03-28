namespace MFramework.SearchLib
{
    public class DijkstraAlgorithmEdge
    {
        public DijkstraAlgorithmNode FromNode { get; set; }
        public DijkstraAlgorithmNode ToNode { get; set; }
        public DijkstraAlgorithmNode Destination { get; set; }
        public int Weight { get; set; }

        public DijkstraAlgorithmEdge(DijkstraAlgorithmNode destination, int weight)
        {
            Destination = destination;
            Weight = weight;
        }
    }
}