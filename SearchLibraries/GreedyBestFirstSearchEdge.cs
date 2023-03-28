namespace MFramework.SearchLib
{
    public class GreedyBestFirstSearchEdge
    {
        public GreedyBestFirstSearchNode FromNode { get; set; }
        public GreedyBestFirstSearchNode ToNode { get; set; }
        public double Weight { get; set; }

        public GreedyBestFirstSearchEdge(GreedyBestFirstSearchNode fromNode, GreedyBestFirstSearchNode toNode, double weight)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Weight = weight;
        }
    }
}