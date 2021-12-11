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
                var uKey = Q.Dequeue();
                Vertex u = G.V[uKey];

                foreach (int vKey in G.Adj[uKey])
                {
                    Node v = G.V[vKey];
                    if (v.BFS_color == "WHITE")
                    {
                        v.BFS_color = "GRAY";
                        v.BFS_d = u.BFS_d + 1;
                        v.BFS_pi = uKey;
                        Q.Enqueue(vKey);
                    }
                }
                u.BFS_color = BFSColor.BLACK;
            }
        }
    }
}
