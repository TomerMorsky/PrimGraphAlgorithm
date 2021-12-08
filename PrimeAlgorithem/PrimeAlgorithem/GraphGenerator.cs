using System;

namespace PrimeAlgorithem
{
    public class GraphGenerator
    {
        #region Public methods

        public static UndirectedGraph GenerateUndirectedGraphWithCircles(
            int numberOfVerties,
            int numberOfEdges,
            int maxEdgeWeight)
        {
            var undirectedGraph = CreateConnectedGraphWithoutCircles(numberOfVerties, maxEdgeWeight);

            var numberOfEdgesToAdd = numberOfEdges - numberOfVerties - 1;

            for (int i = 0; i < numberOfEdgesToAdd; i++)
            {
                undirectedGraph = AddRandomEdge(undirectedGraph, maxEdgeWeight);
            }

            return undirectedGraph;
        }

        #endregion

        #region Private methods

        private static UndirectedGraph CreateConnectedGraphWithoutCircles(int numberOfVerties, int maxEdgeWeight)
        {
            var random = new Random();
            var undirectedGraph = new UndirectedGraph();

            undirectedGraph.AddVertex(new Vertex(0));

            // Create connected graph without circles. The number of edges will be numberOfVerties - 1 
            for (int currentVertexIndex = 1; currentVertexIndex < numberOfVerties; currentVertexIndex++)
            {
                var newVertex = new Vertex(currentVertexIndex);
                undirectedGraph.AddVertex(newVertex);

                var ramdomTargetIndex = random.Next(0, currentVertexIndex); // The target can't be the new vertex
                var randomWeight = random.Next(0, maxEdgeWeight);

                undirectedGraph.AddEdge(currentVertexIndex, ramdomTargetIndex, randomWeight);
            }

            return undirectedGraph;
        }

        private static UndirectedGraph AddRandomEdge(UndirectedGraph graph, int maxEdgeWeight)
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
            graph.AddEdge(fromVertexIndex, toVertexIndex, randomWeight);

            return graph;
        }

        #endregion
    }
}