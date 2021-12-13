using System;

namespace PrimeAlgorithem
{
    internal class Program
    {
        private const int VERTICES_COUNT = 5;
        public const int EDGES_COUNT = 6;
        public const int MAX_EDGE_WEIGHT = 7; // Minimun is 0 by default

        static void Main(string[] args)
        {
            Console.WriteLine("Format explain: (to - destenation vertex id, w = weight of edge to destenation vertex)");
            var graph = GraphGenerator.GenerateUndirectedGraphWithCircles(VERTICES_COUNT, EDGES_COUNT, MAX_EDGE_WEIGHT);
            graph.PrintGraph();

            var newEdge = AddRandomEdge(graph, 2);
            graph.PrintGraph();
            //MSTUtills.AddEdgeToMstTree(graph, )

            MSTUtills.AddEdgeToMstTree(graph, newEdge);
            graph.PrintGraph();

            // Excercise 1
            /*var mstTree = Prime.GetMstPrim(graph, graph.Vertices[0]);
            mstTree.PrintGraph();*/


            // Excercise 2
        }

        private static Edge AddRandomEdge(UndirectedGraph graph, int maxEdgeWeight)
        {
            const int MIN_EDGE_WEIGHT = 1;
            var rnd = new Random();
            var numberOfVerties = graph.Vertices.Count;

            int fromVertexIndex = rnd.Next(numberOfVerties);
            int toVertexIndex = rnd.Next(numberOfVerties);

            while (fromVertexIndex == toVertexIndex || graph.HasEdge(fromVertexIndex, toVertexIndex))
            {
                fromVertexIndex = rnd.Next(numberOfVerties);
                toVertexIndex = rnd.Next(numberOfVerties);
            }

            int randomWeight = rnd.Next(MIN_EDGE_WEIGHT, maxEdgeWeight);

            return graph.AddEdge(fromVertexIndex, toVertexIndex, randomWeight);
        }
    }
}
