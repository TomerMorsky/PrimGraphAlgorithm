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

           
            heap.Add(100);
            heap.Add(40);
            heap.Add(101);
            heap.Add(4);

            heap.Pop();
            heap.Pop();
            heap.Pop();

            Console.WriteLine("Hello World!");
        }
    }
}
