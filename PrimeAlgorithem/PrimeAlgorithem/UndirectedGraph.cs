using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class UndirectedGraph
    {
        public List<Vertex> _vertices;
        private int _emptyIndex;

        public UndirectedGraph()
        {
            _vertices = new List<Vertex>();
            _emptyIndex = 0;
        }

        #region Public methods

        public void AddVertex(Vertex vertex)
        {
            _vertices[_emptyIndex] = vertex;
            _emptyIndex++;
        }

        public void AddEdge(Vertex fromVertex, Vertex toVertex, int weight)
        {
            fromVertex.AddNeighbor(toVertex, weight);
            toVertex.AddNeighbor(fromVertex, weight);
        }

        public void DeleteEdge(Vertex fromVertex, Vertex toVertex)
        {
            fromVertex.RemoveNeighbor(toVertex);
            toVertex.RemoveNeighbor(fromVertex);
        }

        public void PrintGraph()
        {
            Console.WriteLine("Graph:");
            foreach (var vertex in _vertices)
            {
                Console.Write("Vertex: " + vertex.Id + ", edges: ");
                foreach (var edge in vertex.Neighbors)
                {
                    Console.Write(" -> " + edge.Destination.Id);
                }
               
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        #endregion
    }
}
