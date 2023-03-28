namespace MFramework.SearchLib
{
    public class GreedyBestFirstSearchNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GreedyBestFirstSearchEdge> AdjacentEdges { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public GreedyBestFirstSearchNode(int id, string name, double x, double y)
        {
            Id = id;
            Name = name;
            AdjacentEdges = new List<GreedyBestFirstSearchEdge>();
            X = x;
            Y = y;
        }
    }
}