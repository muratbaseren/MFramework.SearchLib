using MFramework.SearchLib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LinearSearch();
            //BinarySearch();
            //InterpolationSearch();
            //ExponentialSearch();
            //JumpSearch();
            //FibonacciSearch();
            //TernarySearch();
            //DepthFirstSearch();
            //BreadthFirstSearch();
        }

        private static void BreadthFirstSearch()
        {
            // Örnek bir graf tanımlıyoruz
            BFSGraph graph = new BFSGraph(6);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);

            Console.WriteLine("BFS ile grafı dolaşma: ");

            // Grafı BFS ile dolaşıyoruz
            graph.BFS(0);
        }

        private static void DepthFirstSearch()
        {
            DFSGraph graph = new DFSGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            Console.WriteLine("DFS traversal starting from vertex 2:");
            graph.DFS(2);
            // Çıktı: 2 0 1 3

        }

        private static void TernarySearch()
        {
            int[] array = { 2, 3, 5, 7, 9, 11 };
            int element = 7;
            int index = SearchAlgorithms.TernarySearch(array, 0, array.Length - 1, element);
            Console.WriteLine(index); // Çıktı: 3
        }

        private static void FibonacciSearch()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int searchNumber = 30;

            int result = SearchAlgorithms.FibonacciSearch(numbers, searchNumber);

            if (result == -1)
            {
                Console.WriteLine("Eleman dizide bulunamadı");
            }
            else
            {
                Console.WriteLine("Eleman dizinin {0}. indeksinde bulundu", result);
            }
        }

        private static void JumpSearch()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int searchNumber = 30;

            int result = SearchAlgorithms.JumpSearch(numbers, searchNumber);

            if (result == -1)
            {
                Console.WriteLine("Eleman dizide bulunamadı");
            }
            else
            {
                Console.WriteLine("Eleman dizinin {0}. indeksinde bulundu", result);
            }
        }

        private static void ExponentialSearch()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int searchNumber = 30;

            int result = SearchAlgorithms.ExponentialSearch(numbers, searchNumber);

            if (result == -1)
            {
                Console.WriteLine("Eleman dizide bulunamadı");
            }
            else
            {
                Console.WriteLine("Eleman dizinin {0}. indeksinde bulundu", result);
            }
        }

        private static void InterpolationSearch()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int searchNumber = 30;

            int result = SearchAlgorithms.InterpolationSearch(numbers, searchNumber);

            if (result == -1)
            {
                Console.WriteLine("Eleman dizide bulunamadı");
            }
            else
            {
                Console.WriteLine("Eleman dizinin {0}. indeksinde bulundu", result);
            }
        }

        private static void BinarySearch()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int searchNumber = 30;

            int result = SearchAlgorithms.BinarySearch(numbers, searchNumber);

            if (result == -1)
            {
                Console.WriteLine("Eleman dizide bulunamadı");
            }
            else
            {
                Console.WriteLine("Eleman dizinin {0}. indeksinde bulundu", result);
            }
        }

        private static void LinearSearch()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int searchNumber = 30;

            int result = SearchAlgorithms.LinearSearch(numbers, searchNumber);

            if (result == -1)
            {
                Console.WriteLine("Eleman dizide bulunamadı");
            }
            else
            {
                Console.WriteLine("Eleman dizinin {0}. indeksinde bulundu", result);
            }
        }

        
    }
}