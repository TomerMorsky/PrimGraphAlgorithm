using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = GraphGenerator.GenerateUndirectedGraphWithCircles(10, 20, 7);
            graph.PrintGraph();

            MinHeap<int> heap = new MinHeap<int>();

            Console.WriteLine("Hello World!");
        }
    }
}
