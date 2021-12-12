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
            DFS.RunDFS(graph, newEdge.Source);
            return graph;
        }
    }
}
