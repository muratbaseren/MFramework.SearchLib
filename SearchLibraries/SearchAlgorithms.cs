namespace MFramework.SearchLib
{
    public partial class SearchAlgorithms
    {
        /// <summary>
        /// Linear Search (Doğrusal Arama); Tabanı sıralanmamış bir dizide belirli bir elemanı aramak için kullanılan en basit search (arama) algoritması olan Linear Search (Doğrusal Arama) algoritması C# programlama dilinde aşağıdaki gibi bir metot şeklinde uygulanabilir.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int LinearSearch(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i; // Elemanın dizideki konumunu döndürür
                }
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        /// <summary>
        /// Binary Search (İkili Arama); Sıralanmış bir dizide belirli bir elemanı aramak için kullanılan Binary Search (İkili Arama) algoritması, Linear Search algoritmasından daha hızlı çalışır. Bu algoritma, bir dizi içerisinde aranan elemanı bulmak için, dizinin ortasından başlayarak elemanları karşılaştırarak aramayı gerçekleştirir. Eğer aranan eleman ortadaki elemana eşit değilse, arama yönü sağa veya sola kaydırılır ve tekrar orta eleman bulunarak işlem tekrarlanır. Bu işlem, aranan eleman bulunana kadar tekrar eder.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] array, int element)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == element)
                {
                    return mid; // Elemanın dizideki konumunu döndürür
                }
                else if (array[mid] < element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        /// <summary>
        /// Interpolation Search (İnterpolasyon Araması); Tabanlı arama algoritmalarından bir diğeri olan Interpolation Search algoritması, sıralı bir dizide aranan elemanı bulmak için Linear Search ve Binary Search algoritmalarına göre daha hızlı çalışabilir. Bu algoritma, Binary Search algoritması gibi bir sıralı dizi içerisinde arama yapar, ancak arama yaparken aranan elemanın muhtemel konumunu da hesaplayarak arama yapar.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int InterpolationSearch(int[] array, int element)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right && element >= array[left] && element <= array[right])
            {
                int pos = left + ((element - array[left]) * (right - left)) / (array[right] - array[left]);
                if (array[pos] == element)
                {
                    return pos;
                }
                else if (array[pos] < element)
                {
                    left = pos + 1;
                }
                else
                {
                    right = pos - 1;
                }
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        /// <summary>
        /// Exponential Search (Üstel Arama); Exponential Search, Binary Search benzeri bir arama algoritmasıdır ve sıralı bir dizide aranan elemanı bulmak için kullanılır. Fakat Binary Search'ten farklı olarak Exponential Search önce aralığı ikiye katlar, daha sonra binary search yöntemini kullanır.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int ExponentialSearch(int[] array, int element)
        {
            int size = array.Length;
            if (array[0] == element) // Dizinin ilk elemanı aranan eleman mı?
            {
                return 0;
            }
            int i = 1;
            while (i < size && array[i] <= element) // Aranan elemanın olası konumunu hesapla
            {
                i = i * 2;
            }
            return BinarySearch(array, i / 2, Math.Min(i, size - 1), element); // Binary Search yöntemini kullanarak arama yap
        }

        /// <summary>
        /// Jump Search (Atlama Araması); Jump Search algoritması, bir sıralı dizide aranan elemanı bulmak için bir adım boyu belirleyerek dizinin elemanlarını o adım boyutunda atlayarak arama yapar. Bu algoritma, sıralı dizilerde Binary Search algoritmasından daha hızlı çalışabilir.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int JumpSearch(int[] array, int element)
        {
            int n = array.Length;
            int step = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;
            while (array[Math.Min(step, n) - 1] < element)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                {
                    return -1;
                }
            }
            while (array[prev] < element)
            {
                prev++;
                if (prev == Math.Min(step, n))
                {
                    return -1;
                }
            }
            if (array[prev] == element)
            {
                return prev;
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        /// <summary>
        /// Fibonacci Search (Fibonacci Araması); Fibonacci Search algoritması, bir sıralı dizide aranan elemanı bulmak için Fibonacci dizisini kullanır. Bu algoritma, Binary Search algoritmasından daha yavaş ancak bazı durumlarda daha hızlı çalışabilir.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int FibonacciSearch(int[] array, int element)
        {
            int n = array.Length;
            int fib2 = 0;
            int fib1 = 1;
            int fib = fib1 + fib2;
            while (fib < n)
            {
                fib2 = fib1;
                fib1 = fib;
                fib = fib1 + fib2;
            }
            int offset = -1;
            while (fib > 1)
            {
                int i = Math.Min(offset + fib2, n - 1);
                if (array[i] < element)
                {
                    fib = fib1;
                    fib1 = fib2;
                    fib2 = fib - fib1;
                    offset = i;
                }
                else if (array[i] > element)
                {
                    fib = fib2;
                    fib1 = fib1 - fib2;
                    fib2 = fib - fib1;
                }
                else
                {
                    return i;
                }
            }
            if (fib1 == 1 && array[offset + 1] == element)
            {
                return offset + 1;
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        /// <summary>
        /// Ternary Search (Üçlü Arama); Ternary Search algoritması, sıralı bir dizide aranan elemanı bulmak için kullanılan bir algoritmadır. Bu algoritma, Binary Search algoritmasından daha yavaş ancak bazı durumlarda daha hızlı çalışabilir. İlk olarak dizinin orta elemanı seçilir ve aranan eleman bu elemana eşitse indeks döndürülür. Eğer aranan eleman orta elemandan küçükse, sol kısmı aramak için algoritma tekrarlanır. Eğer aranan eleman orta elemandan büyükse, sağ kısmı aramak için algoritma tekrarlanır.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int TernarySearch(int[] array, int left, int right, int element)
        {
            if (right >= left)
            {
                int mid1 = left + (right - left) / 3;
                int mid2 = right - (right - left) / 3;
                if (array[mid1] == element)
                {
                    return mid1;
                }
                else if (array[mid2] == element)
                {
                    return mid2;
                }
                else if (element < array[mid1])
                {
                    return TernarySearch(array, left, mid1 - 1, element);
                }
                else if (element > array[mid2])
                {
                    return TernarySearch(array, mid2 + 1, right, element);
                }
                else
                {
                    return TernarySearch(array, mid1 + 1, mid2 - 1, element);
                }
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        /// <summary>
        /// A* Search (A yıldız Araması); Tabii, A* (A star) algoritması, iki farklı fonksiyonu kullanarak en kısa yolu bulmak için bir graf üzerinde çalışır. Öncelikle, gerçek maliyeti temsil eden g(n) fonksiyonunu kullanarak bir düğümün uzaklığını ölçer. İkincisi, tahmini maliyeti temsil eden h(n) fonksiyonunu kullanarak bir düğümün hedefe olan uzaklığını ölçer.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static List<AStarSearchNode> AStarSearch(AStarSearchNode start, AStarSearchNode goal)
        {
            // A* algoritması için bir öncülü liste ve bir sonuç listesi oluşturun
            List<AStarSearchNode> openList = new List<AStarSearchNode>();
            List<AStarSearchNode> closedList = new List<AStarSearchNode>();

            // Başlangıç düğümünü açık listeye ekleyin ve g(n) maliyetini 0 olarak ayarlayın
            start.GScore = 0;
            openList.Add(start);

            // A* algoritması ana döngüsü
            while (openList.Count > 0)
            {
                // Açık listeyi düşük f(n) değerine göre sıralayın
                openList.Sort((x, y) => x.FScore.CompareTo(y.FScore));

                // En düşük f(n) değerine sahip düğümü alın
                AStarSearchNode current = openList[0];

                // Eğer hedef düğüme ulaşılmışsa, sonuç listesini döndürün
                if (current == goal)
                {
                    List<AStarSearchNode> path = new List<AStarSearchNode>();
                    while (current != null)
                    {
                        path.Add(current);
                        current = current.Parent;
                    }
                    path.Reverse();
                    return path;
                }

                // Mevcut düğümü açık listesinden kaldırın ve kapalı listeye ekleyin
                openList.Remove(current);
                closedList.Add(current);

                // Mevcut düğümün komşularını alın
                List<AStarSearchNode> neighbors = current.Neighbors;

                foreach (AStarSearchNode neighbor in neighbors)
                {
                    // Komşu kapalı listede ise atla
                    if (closedList.Contains(neighbor))
                        continue;

                    // Komşunun g(n) değerini hesaplayın
                    double cost = current.GScore + current.GetCost(neighbor);

                    // Eğer komşu açık listede değilse, açık listeye ekle
                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
                    // Eğer komşu zaten açık listedeyse, daha iyi bir yoldan geldiyse g(n) değerini güncelle
                    else if (cost >= neighbor.GScore)
                        continue;

                    // Yeni yolu seçtiğimiz için düğümün ebeveynini güncelle
                    neighbor.Parent = current;
                    neighbor.GScore = cost;
                    neighbor.Heuristic = neighbor.GetHeuristic(goal);
                    neighbor.FScore = neighbor.GScore + neighbor.Heuristic;
                }
            }

            // Hedefe ulaşılamadı
            return null;
        }

        /// <summary>
        /// Dijkstra's Algorithm (Dijkstra Algoritması); Dijkstra algoritması, tek kaynaklı kısa yol probleminin çözümü için kullanılan bir graf algoritmasıdır. Algoritma, başlangıç düğümünden diğer tüm düğümlere en kısa yolu bulur. Algoritma, başlangıç düğümünden diğer düğümlere giden en kısa yolu bulmak için her düğümü ziyaret eder. Ziyaret edilen düğümün komşularını gezerek, komşularına varmak için başlangıç düğümünden o noktaya kadar olan toplam maliyetini hesaplar ve daha önce hesaplanmış olan maliyetlerle karşılaştırır. Eğer yeni hesaplanan maliyet, daha önceki maliyetten daha düşükse, komşu düğümün maliyeti güncellenir. Algoritma, tüm düğümler ziyaret edildiğinde sonuçlarını döndürür ve her düğümün başlangıç düğümünden olan en kısa yolu içeren bir sözlük (dictionary) döndürür.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Dictionary<DijkstraAlgorithmNode, int> DijkstraAlgorithm(DijkstraAlgorithmGraph graph, DijkstraAlgorithmNode source)
        {
            // Başlangıç düğümünün önceden ayarlanması
            var distance = new Dictionary<DijkstraAlgorithmNode, int>();
            var visited = new Dictionary<DijkstraAlgorithmNode, bool>();
            var previous = new Dictionary<DijkstraAlgorithmNode, DijkstraAlgorithmNode>();

            foreach (var vertex in graph.Nodes)
            {
                distance[vertex] = int.MaxValue;
                visited[vertex] = false;
                previous[vertex] = null;
            }

            distance[source] = 0;

            // En kısa yolların hesaplanması
            while (visited.Count < graph.Nodes.Count)
            {
                // En yakın düğümün seçimi
                DijkstraAlgorithmNode current = null;
                var shortestDistance = int.MaxValue;

                foreach (DijkstraAlgorithmNode vertex in graph.Nodes)
                {
                    if (!visited[vertex] && distance[vertex] < shortestDistance)
                    {
                        current = vertex;
                        shortestDistance = distance[vertex];
                    }
                }

                // Seçilen düğümün ziyareti
                visited[current] = true;

                // Komşu düğümler için minimum mesafenin hesaplanması
                foreach (DijkstraAlgorithmNode neighbor in graph.GetNeighbors(current))
                {
                    var tentativeDistance = distance[current] + graph.GetWeight(current, neighbor);

                    if (tentativeDistance < distance[neighbor])
                    {
                        distance[neighbor] = tentativeDistance;
                        previous[neighbor] = current;
                    }
                }
            }

            return distance;
        }

        /// <summary>
        /// Greedy Best First Search (Açgözlü En İyi-Öncelikli Arama); Greedy Best First Search, bir graf arama algoritmasıdır. A* aramasına benzer bir şekilde, bir düğümü hedef düğüme götüren en az maliyetli yolu bulmaya çalışır. Ancak, A* aramasından farklı olarak, Greedy Best First Search, her adımda sadece hedefe en yakın düğüme gider. Bu nedenle, diğer düğümleri tamamen ihmal edebilir ve yanlış yollara yönlendirebilir. İşleyiş olarak, algoritma bir başlangıç düğümünden başlar ve hedefe ulaşana kadar en yakın düğüme ilerler. Daha sonra, en yakın düğümden hedefe olan mesafe hesaplanır ve bir sonraki adımda hedefe en yakın olan düğüme ilerlenir. Bu işlem, hedef düğüme ulaşılana kadar devam eder.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static List<GreedyBestFirstSearchNode> GreedyBestFirstSearch(GreedyBestFirstSearchNode start, GreedyBestFirstSearchNode goal)
        {
            List<GreedyBestFirstSearchNode> path = new List<GreedyBestFirstSearchNode>();
            SortedList<double, GreedyBestFirstSearchNode> frontier = new SortedList<double, GreedyBestFirstSearchNode>();
            Dictionary<GreedyBestFirstSearchNode, GreedyBestFirstSearchNode> cameFrom = new Dictionary<GreedyBestFirstSearchNode, GreedyBestFirstSearchNode>();
            Dictionary<GreedyBestFirstSearchNode, double> costSoFar = new Dictionary<GreedyBestFirstSearchNode, double>();

            frontier.Add(0, start);
            cameFrom[start] = null;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                GreedyBestFirstSearchNode current = frontier.Values.First();
                frontier.RemoveAt(0);

                if (current == goal)
                {
                    break;
                }

                foreach (GreedyBestFirstSearchEdge edge in current.AdjacentEdges)
                {
                    GreedyBestFirstSearchNode neighbor = edge.ToNode;
                    double priority = Heuristic(neighbor, goal);
                    if (!costSoFar.ContainsKey(neighbor))
                    {
                        costSoFar[neighbor] = edge.Weight;
                        frontier.Add(priority, neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            GreedyBestFirstSearchNode node = goal;
            while (node != start)
            {
                path.Add(node);
                node = cameFrom[node];
            }

            path.Add(start);
            path.Reverse();
            return path;
        }

        /// <summary>
        /// Hill Climbing (Tepe Tırmanma); Hill Climbing Search, verilen bir problemin çözümünü arayan bir arama algoritmasıdır. Bu algoritma, her adımda mevcut çözümden daha iyi bir çözüm arar ve en iyi sonucu veren yolu takip eder. Başlangıçta, bir çözüm adayı belirlenir ve bu çözüm adayı üzerinde bir dizi iyileştirme yapılır. Ardından, en iyi sonucu veren çözüm adayı seçilir ve bu çözüm adayı üzerinde iyileştirme yapılır. Bu işlem, sonuç elde edilene kadar veya elde edilebilecek en iyi sonuca ulaşılıncaya kadar devam eder. Hill Climbing Search algoritması, daha büyük problemlerde kullanılan ve daha karmaşık algoritmalara temel oluşturan birçok optimizasyon algoritmasının temelini oluşturur. Ancak bu algoritmanın, global optimumu garanti etmediği ve yerel optimuma takılıp kaldığı durumlar olabileceği unutulmamalıdır.
        /// </summary>
        /// <param name="initialNode"></param>
        /// <param name="goalTest"></param>
        /// <param name="heuristic"></param>
        /// <param name="expand"></param>
        /// <returns></returns>
        public static List<HillClimbingSearchNode<string>> HillClimbingSearch(HillClimbingSearchNode<string> initialNode, Func<HillClimbingSearchNode<string>, bool> goalTest, Func<HillClimbingSearchNode<string>, int> heuristic, Func<HillClimbingSearchNode<string>, List<HillClimbingSearchNode<string>>> expand)
        {
            var currentNode = initialNode;
            var visitedNodes = new List<HillClimbingSearchNode<string>> { currentNode };

            while (!goalTest(currentNode))
            {
                var childNodes = expand(currentNode);
                if (childNodes.Count == 0) return null;

                HillClimbingSearchNode<string> nextNode = null;
                var maxH = int.MinValue;

                foreach (var node in childNodes)
                {
                    if (!visitedNodes.Contains(node))
                    {
                        visitedNodes.Add(node);
                        var h = heuristic(node);
                        if (h > maxH)
                        {
                            maxH = h;
                            nextNode = node;
                        }
                    }
                }

                if (maxH <= heuristic(currentNode))
                {
                    return null;
                }

                currentNode = nextNode;
            }

            return visitedNodes;
        }

        /// <summary>
        /// Exponential Search (Üstel Arama) için gerekli genişletilmiş parametreli Binary Search metodu.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private static int BinarySearch(int[] array, int left, int right, int element)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == element)
                {
                    return mid;
                }
                else if (array[mid] < element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1; // Eleman dizide yoksa -1 döndürür
        }

        private static double Heuristic(GreedyBestFirstSearchNode a, GreedyBestFirstSearchNode b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

    }
}