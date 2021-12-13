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
            graph.AddEdge(newEdge.Source, newEdge.Destination, newEdge.Weight);
            var endCycleVertex = FindCircle.FindCycle(graph, newEdge.Source);
            return graph;
        }
    }
}
