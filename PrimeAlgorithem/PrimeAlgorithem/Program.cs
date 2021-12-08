using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            graphGenerator.generateUndirectedGraph(10, 20);
            graphGenerator.UndirectedGraph.PrintGraph();

            Console.WriteLine("Hello World!");
        }
    }
}
