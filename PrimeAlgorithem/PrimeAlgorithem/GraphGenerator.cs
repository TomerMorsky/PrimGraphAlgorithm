using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class GraphGenerator
    {
        public GraphGenerator() {   }

        public UndirectedGraph generateUndirectedGraphWithCircles(
            int numberOfVerties,
            int numberOfEdges,
            int maxEdgeWeight)
        {
            var undirectedGraph = CreateConnectedGraphWithoutCircles(numberOfVerties, maxEdgeWeight);

            var currentNumberOfEdges = numberOfVerties - 1;
            undirectedGraph = AddRandomEdgesToGraph(undirectedGraph, numberOfEdges - currentNumberOfEdges);

            return undirectedGraph;
        }

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

        private static UndirectedGraph AddRandomEdgesToGraph(UndirectedGraph undirectedGraph, int numberOfEdges)
        {
            // Add additional edges
            
            for (int i = 0; i < numberOfEdges; i++)
            {

            }
        }
           
    }
}
