namespace MFramework.SearchLib
{
    public class AStarSearchNode
    {
        public int X { get; set; } // Düğümün x koordinatı
        public int Y { get; set; } // Düğümün y koordinatı
        public List<AStarSearchNode> Neighbors { get; set; } // Düğüme bağlı komşu düğümler
        public double GScore { get; set; } // Başlangıç düğümünden bu düğüme kadar olan gerçek maliyet
        public double FScore { get; set; } // GScore + bu düğümden hedef düğüme olan tahmini maliyet
        public double Heuristic { get; set; } // GScore + bu düğümden hedef düğüme olan tahmini maliyet
        public AStarSearchNode Parent { get; set; }

        // Node sınıfının yapıcı metodu
        public AStarSearchNode(int x, int y)
        {
            X = x;
            Y = y;
            Neighbors = new List<AStarSearchNode>();
            GScore = double.MaxValue;
            FScore = double.MaxValue;
        }

        public double GetHeuristic(AStarSearchNode targetNode)
        {
            // Manhattan mesafesi kullanarak hedef düğüme olan tahmini maliyeti hesapla
            double dx = Math.Abs(X - targetNode.X);
            double dy = Math.Abs(Y - targetNode.Y);
            double heuristic = dx + dy;
            return heuristic;
        }

        public double GetCost(AStarSearchNode neighborNode)
        {
            // İki düğüm arasındaki gerçek maliyeti hesapla
            double dx = Math.Abs(X - neighborNode.X);
            double dy = Math.Abs(Y - neighborNode.Y);
            double cost = Math.Sqrt(dx * dx + dy * dy); // Öklid mesafesi
            return cost;
        }
    }
}