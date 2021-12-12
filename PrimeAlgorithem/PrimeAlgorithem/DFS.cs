using System;

namespace PrimeAlgorithem
{
    public class DFS
    {
        public enum DFSColor
        {
            WHITE,
            GRAY,
            BLACK
        }

        public static UndirectedGraph RunDFS(UndirectedGraph graph, Vertex startVertex)
        {
            foreach (Vertex vertex in graph.Vertices)
            {
                    vertex.DFS_color = DFSColor.WHITE;
                    vertex.DFS_pi = null;
            }

            foreach (Vertex vertex in graph.Vertices)
                if (vertex.DFS_color == DFSColor.WHITE)
                    DFSVisit(vertex);

            return graph;
        }

        private static void DFSVisit(Vertex vertex)
        {
            vertex.DFS_color = DFSColor.GRAY;

            foreach (var edge in vertex.Edges)
            {
                var neighbor = edge.Destination;

                if (neighbor.DFS_color == DFSColor.WHITE)
                {
                    neighbor.DFS_pi = vertex;
                    DFSVisit(neighbor);
                }

            }

            vertex.DFS_color = DFSColor.BLACK;
        }
    }
}