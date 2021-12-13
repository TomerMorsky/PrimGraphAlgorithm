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
            var endCycleVertex = FindCircleUtill.Find(graph, newEdge.Source);
            var currentVertex = endCycleVertex.DFS_pi;

            var maxWeightedEdge = graph.GetEdge(endCycleVertex, currentVertex);

            while (!currentVertex.Equals(newEdge.Source))
            {
                if (currentVertex.lowestWeightToVertex > maxWeightedEdge.Weight)
                   maxWeightedEdge = graph.GetEdge(currentVertex, currentVertex.DFS_pi);
                
                currentVertex = currentVertex.DFS_pi;
            }

            if (maxWeightedEdge.Weight <= newEdge.Weight)
            {
                Console.WriteLine("MST Not Changed");
                graph.DeleteEdge(newEdge.Source, newEdge.Destination);
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
