using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class BFS
    {
        public enum BFSColor
        {
            WHITE,
            GRAY,
            BLACK
        }

        private const int INFINITY = Int32.MaxValue;

        public static UndirectedGraph RunBFS(UndirectedGraph graph, Vertex startVertex)
        {
            foreach (Vertex vertex in graph.Vertices)
            {
                if (!vertex.Equals(startVertex))
                {
                    vertex.BFS_color = BFSColor.WHITE;
                    vertex.BFS_d = INFINITY;
                    vertex.BFS_pi = null;
                }
            }

            startVertex.BFS_color = BFSColor.GRAY;
            startVertex.BFS_d = 0;
            startVertex.BFS_pi = null;

            var Q = new Queue<Vertex>();
            Q.Enqueue(startVertex);

            while (Q.Count > 0)
            {
                var currentVertex = Q.Dequeue();

                foreach (var edge in currentVertex.Edges)
                {
                    var niebore = edge.Destination;
                    if (niebore.BFS_color == BFSColor.WHITE)
                    {
                        niebore.BFS_color = BFSColor.GRAY;
                        niebore.BFS_d = currentVertex.BFS_d + 1;
                        niebore.BFS_pi = currentVertex;
                        Q.Enqueue(niebore);
                    }
                }
                currentVertex.BFS_color = BFSColor.BLACK;
            }
        }
    }
}
