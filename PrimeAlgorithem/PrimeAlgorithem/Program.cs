using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        private const int VERTICES_COUNT = 5;
        private const int EDGES_COUNT = 6;
        private const int MAX_EDGE_WEIGHT = 7;
        private const int MIN_EDGE_WEIGHT = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Format explain: (to - destenation vertex id, w = weight of edge to destenation vertex)");
            var graph = GraphGenerator.GenerateUndirectedGraphWithCircles(VERTICES_COUNT, EDGES_COUNT, MIN_EDGE_WEIGHT, MAX_EDGE_WEIGHT);
            Console.WriteLine("Generated graph");
            graph.PrintGraph();

            // Excercise 1
            var mstTree = Prime.GetMstPrim(graph, graph.Vertices[0]);
            Console.WriteLine("MST graph - ex 1");
            mstTree.PrintGraph();

            // Excercise 2
            // No changing in mst
            var newEdge = mstTree.AddRandomEdge(mstTree, 10, 15);
            Console.WriteLine("The new edge: " + newEdge.Source.Id + " -> " + newEdge.Destination.Id + " weight: " + newEdge.Weight);

            MSTUtills.AddEdgeToMstTree(mstTree, newEdge);
            Console.WriteLine("MST Graph after taking care of the new edge");
            mstTree.PrintGraph();

            // Mst change
            newEdge = mstTree.AddRandomEdge(mstTree, 1, 2);
            Console.WriteLine("The new edge: " + newEdge.Source.Id + " -> " + newEdge.Destination.Id + " weight: " + newEdge.Weight);

            MSTUtills.AddEdgeToMstTree(mstTree, newEdge);
            Console.WriteLine("MST Graph after taking care of the new edge");
            mstTree.PrintGraph();
        }
    }
}