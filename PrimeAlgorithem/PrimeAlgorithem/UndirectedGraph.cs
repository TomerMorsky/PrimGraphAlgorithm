using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeAlgorithem
{
    public class UndirectedGraph
    {
        #region Properties

        public List<Vertex> Vertices;

        #endregion

        #region C'tor

        public UndirectedGraph()
        {
            Vertices = new List<Vertex>();
        }

        #endregion

        #region Public methods

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public Edge AddEdge(Vertex fromVertex, Vertex toVertex, int weight)
        {
            var newEdge = new Edge(fromVertex, toVertex, weight);

            if (fromVertex.Edges.Contains(newEdge) ||
                toVertex.Edges.Contains(newEdge))
                return null;

            fromVertex.AddNeighbor(toVertex, weight);
            toVertex.AddNeighbor(fromVertex, weight);

            return newEdge;
        }

        public Edge AddEdge(int fromVertexIndex, int toVertexIndex, int weight)
        {
            var fromVertex = Vertices[fromVertexIndex];
            var toVertex = Vertices[toVertexIndex];

            return AddEdge(fromVertex, toVertex, weight);
        }

        public void DeleteEdge(Vertex fromVertex, Vertex toVertex)
        {
            fromVertex.RemoveNeighbor(toVertex);
            toVertex.RemoveNeighbor(fromVertex);
        }

        public bool HasEdge(Vertex fromVertex, Vertex toVertex)
        {
            return fromVertex.IsNeighbor(toVertex);
        }

        public bool HasEdge(int fromVertexIndex, int toVertexIndex)
        {
            var fromVertex = Vertices[fromVertexIndex];
            var toVertex = Vertices[toVertexIndex];

            return HasEdge(fromVertex, toVertex);
        }

        public void PrintGraph()
        {
            Console.WriteLine("Graph:");

            foreach (var vertex in Vertices)
            {
                Console.Write("Vertex: " + vertex.Id + ", edges: ");
                foreach (var edge in vertex.Edges)
                    Console.Write(" -> (to:" + edge.Destination.Id + ", w:" + edge.Weight + ")");
                
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        #endregion
    }
}