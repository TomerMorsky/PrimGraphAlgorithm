using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class Prime
    {
        private const int INFINITY = Int32.MaxValue;

        public static UndirectedGraph GetMstPrim(UndirectedGraph graph, Vertex startNode)
        {
            var mstTree = new UndirectedGraph();

            foreach (Vertex vertex in graph.Vertices)
            {
                vertex.lowestWeightToVertex = INFINITY;
                vertex.Prim_pi = null;
                mstTree.AddVertex(new Vertex(vertex.Id)); // We don't want the same instance to be in the new tree
            }

            startNode.lowestWeightToVertex = 0;

            var minHeap = new MinHeap<Vertex>(graph.Vertices);

            while (!minHeap.IsEmpty())
            {
                var currentVertex = minHeap.Pop();

                foreach (var neighbor in currentVertex.Neighbors)
                {
                    if (minHeap.Contains(neighbor.Destination) && neighbor.Weight < neighbor.Destination.lowestWeightToVertex)
                    {
                        neighbor.Destination.Prim_pi = currentVertex;
                        neighbor.Destination.lowestWeightToVertex = neighbor.Weight;
                        //minHeap.DecreaseKey(neighbor.Destination, neighbor.Weight); TODO - not sure if needed because we use instance
                    }
                }
            }

            foreach (var vertex in graph.Vertices)
            {
                if(vertex.Prim_pi != null)
                    mstTree.AddEdge(vertex.Id, vertex.Prim_pi.Id, vertex.lowestWeightToVertex);
                
            }

            return mstTree;
        }
    }
}
