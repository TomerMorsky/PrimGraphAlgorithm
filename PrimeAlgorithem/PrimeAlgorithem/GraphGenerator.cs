using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class GraphGenerator
    {
        public UndirectedGraph UndirectedGraph;

        public GraphGenerator()
        {
            UndirectedGraph = new UndirectedGraph();
        }

        public UndirectedGraph generateUndirectedGraph(int numberOfVerties, int maxEdgeWeight)
        {
            var random = new Random();

            UndirectedGraph.AddVertex(new Vertex(0));

            // Create all verties of the graph
            for (int currentVertexIndex = 1; currentVertexIndex < numberOfVerties; currentVertexIndex++)
            {
                var newVertex = new Vertex(currentVertexIndex);
                UndirectedGraph.AddVertex(newVertex);

                var ramdomTargetIndex = random.Next(0, currentVertexIndex); // The target can't be the new vertex
                var randomWeight = random.Next(0, maxEdgeWeight);

                UndirectedGraph.AddEdge(currentVertexIndex, ramdomTargetIndex, randomWeight);
            }

            return UndirectedGraph;
        }
           
    }
}
