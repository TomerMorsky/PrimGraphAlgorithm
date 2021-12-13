using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class MSTUtills
    {
        public static UndirectedGraph AddEdgeToMstTree(UndirectedGraph graph, Edge newEdge)
        {
            //FindCircle.RunDFS(graph, newEdge.Source);
            var endCycleVertex = FindCircle.FindCycle(graph, newEdge.Source);

            var previousVertex = endCycleVertex;
            var currentVertex = previousVertex.DFS_pi;

            var maxWeightedEdge = graph.GetEdge(previousVertex, currentVertex);

            while (!currentVertex.Equals(newEdge.Source))
            {
                if (currentVertex.lowestWeightToVertex > maxWeightedEdge.Weight)
                   maxWeightedEdge = graph.GetEdge(currentVertex, currentVertex.DFS_pi);
                
                currentVertex = currentVertex.DFS_pi;
            }

            if (maxWeightedEdge.Weight <= newEdge.Weight)
            {
                Console.WriteLine("MST Not Changed");
            }
            else
            {
                Console.WriteLine("MST Changed");
                graph.DeleteEdge(maxWeightedEdge.Source, maxWeightedEdge.Destination);
            }
            
            return graph;
        }
    }
}
