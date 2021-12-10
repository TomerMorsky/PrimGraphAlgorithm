using System;

namespace PrimeAlgorithem
{
    public class Prime
    {
        private const int INFINITY = Int32.MaxValue;

        public static UndirectedGraph GetMstPrim(UndirectedGraph graph, Vertex startVertex)
        {
            var mstTree = new UndirectedGraph();

            foreach (Vertex vertex in graph.Vertices)
            {
                vertex.lowestWeightToVertex = INFINITY;
                vertex.Prim_pi = null;
                mstTree.AddVertex(new Vertex(vertex.Id)); // We don't want the same instance to be in the new tree
            }

            startVertex.lowestWeightToVertex = 0;

            var minHeap = new MinHeap<Vertex>(graph.Vertices);

            while (!minHeap.IsEmpty())
            {
                var currentVertex = minHeap.Pop();

                foreach (var edge in currentVertex.Edges)
                {
                    if (minHeap.Contains(edge.Destination) && edge.Weight < edge.Destination.lowestWeightToVertex)
                    {
                        edge.Destination.Prim_pi = currentVertex;
                        edge.Destination.lowestWeightToVertex = edge.Weight;
                        minHeap.ForceHeapUpdate();
                    }
                }
            }

            foreach (var vertex in graph.Vertices)
                if(vertex.Prim_pi != null)
                    mstTree.AddEdge(vertex.Id, vertex.Prim_pi.Id, vertex.lowestWeightToVertex);
                

            return mstTree;
        }
    }
}