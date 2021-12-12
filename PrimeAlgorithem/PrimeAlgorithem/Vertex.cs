using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeAlgorithem.FindCircle;

namespace PrimeAlgorithem
{
    public class Vertex : IComparable<Vertex>
    {
        #region Fields

        public List<Edge> Edges;

        #endregion

        #region Properties

        public int Id;
        public int lowestWeightToVertex;
        public Vertex Prim_pi;
        public DFSColor DFS_color;
        public int DFS_d;
        public int DFS_f;
        public Vertex DFS_pi;

        #endregion

        #region C'tor

        public Vertex(int id)
        {
            Id = id;
            Edges = new List<Edge>();
        }

        #endregion

        #region Override methods

        public override bool Equals(object obj)
        {
            return obj is Vertex vertex &&
                   Id == vertex.Id;
        }

        #endregion

        #region Public methods

        public void AddNeighbor(Edge neighbor)
        {
            Edges.Add(neighbor);
        }

        public void AddNeighbor(Vertex neighbor, int weight)
        {
            this.AddNeighbor(new Edge(this, neighbor, weight));
        }

        public bool IsNeighbor(Vertex neighbor)
        {
            return Edges.Any(edge => edge.Destination.Equals(neighbor));
        }

        public void RemoveNeighbor(Vertex neighbor)
        {
            Edges.Remove(new Edge(this, neighbor));
        }

        public void SetVisited()
        {
            DFS_color = DFSColor.GRAY;
        }

        public bool IsVisited()
        {
            return DFS_color != DFSColor.WHITE;
        }

        public void PrintNode()
        {
            Console.WriteLine("Node: " + this.Id);
            Console.WriteLine("prev PRIM: " + this.Prim_pi);
            Console.WriteLine("Key: " + this.lowestWeightToVertex);
        }


        public int CompareTo(Vertex other)
        {
            if (other == null) return 1;

            return lowestWeightToVertex.CompareTo(other.lowestWeightToVertex);
        }

        #endregion

    }
}