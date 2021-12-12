using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        private const int VERTICES_COUNT = 20;
        public const int EDGES_COUNT = 50;
        public const int MAX_EDGE_WEIGHT = 7; // Minimun is 0 by default

        static void Main(string[] args)
        {
            Console.WriteLine("Format explain: (to - destenation vertex id, w = weight of edge to destenation vertex)");
            var graph = GraphGenerator.GenerateUndirectedGraphWithCircles(VERTICES_COUNT, EDGES_COUNT, MAX_EDGE_WEIGHT);
            graph.PrintGraph();

            // Excercise 1
            var mstTree = Prime.GetMstPrim(graph, graph.Vertices[0]);
            mstTree.PrintGraph();


            // Excercise 2


        }
    }
}
