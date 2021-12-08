using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            var graph = graphGenerator.generateUndirectedGraph(10, 20);
            graph.PrintGraph();

            Console.WriteLine("Hello World!");
        }
    }
}
