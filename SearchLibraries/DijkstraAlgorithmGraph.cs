namespace MFramework.SearchLib
{
    public class DijkstraAlgorithmGraph
    {
        public List<DijkstraAlgorithmNode> Nodes { get; set; }

        public DijkstraAlgorithmGraph()
        {
            Nodes = new List<DijkstraAlgorithmNode>();
        }

        public void AddNode(DijkstraAlgorithmNode node)
        {
            Nodes.Add(node);
        }

        public List<DijkstraAlgorithmNode> GetNeighbors(DijkstraAlgorithmNode node)
        {
            List<DijkstraAlgorithmNode> neighbors = new List<DijkstraAlgorithmNode>();

            foreach (DijkstraAlgorithmEdge edge in node.Edges)
            {
                if (edge.FromNode == node)
                {
                    neighbors.Add(edge.ToNode);
                }
            }

            return neighbors;
        }

        public int GetWeight(DijkstraAlgorithmNode node1, DijkstraAlgorithmNode node2)
        {
            foreach (DijkstraAlgorithmEdge edge in node1.Edges)
            {
                if (edge.FromNode == node1 && edge.ToNode == node2)
                {
                    return edge.Weight;
                }
            }

            return int.MaxValue;
        }
    }
}