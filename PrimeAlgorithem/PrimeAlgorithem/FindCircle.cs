using System;

namespace PrimeAlgorithem
{
    public class FindCircle
    {

        public static Vertex FindCycle(UndirectedGraph graph, Vertex startVertex)
        {
            foreach (Vertex vertex in graph.Vertices)
            {
                    vertex.DFS_color = DFSColor.WHITE;
                    vertex.DFS_pi = null;
            }

            return FindCycleUtil(startVertex, null);
        }

        private static Vertex FindCycleUtil(Vertex vertex, Vertex parent)
        {
            vertex.DFS_color = DFSColor.GRAY;

            foreach (var edge in vertex.Edges)
            {
                var neighbor = edge.Destination;
                neighbor.DFS_pi = vertex;

                if (!neighbor.IsVisited())
                {
                    return FindCycleUtil(neighbor, vertex);
                }
                else if (!neighbor.Equals(parent))
                    return vertex;
            }
         
            return null;
        }
    }
}