using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddEdge(Vertex fromVertex, Vertex toVertex, int weight)
        {
            var newEdge = new Edge(fromVertex, toVertex, weight);

            if (fromVertex.Neighbors.Contains(newEdge) ||
                toVertex.Neighbors.Contains(newEdge))
                throw new Exception("Neighbor is already exist");

            fromVertex.AddNeighbor(toVertex, weight);
            toVertex.AddNeighbor(fromVertex, weight);
        }

        public void AddEdge(int fromVertexIndex, int toVertexIndex, int weight)
        {
            var fromVertex = Vertices[fromVertexIndex];
            var toVertex = Vertices[toVertexIndex];

            AddEdge(fromVertex, toVertex, weight);
        }

        public void DeleteEdge(Vertex fromVertex, Vertex toVertex)
        {
            fromVertex.RemoveNeighbor(toVertex);
            toVertex.RemoveNeighbor(fromVertex);
        }

        public bool HasEdge(Vertex fromVertex, Vertex toVertex)
        {
            return fromVertex.Neighbors.Contains(new Edge(fromVertex, toVertex));
        }

        public bool HasEdge(int fromVertexIndex, int toVertexIndex)
        {
            var fromVertex = Vertices[fromVertexIndex];
            var toVertex = Vertices[toVertexIndex];

            return fromVertex.Neighbors.Contains(new Edge(fromVertex, toVertex));
        }

        public void PrintGraph()
        {
            Console.WriteLine("Graph:");

            foreach (var vertex in Vertices)
            {
                Console.Write("Vertex: " + vertex.Id + ", edges: ");
                foreach (var edge in vertex.Neighbors)
                    Console.Write(" -> " + edge.Destination.Id);
                
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        #endregion
    }
}