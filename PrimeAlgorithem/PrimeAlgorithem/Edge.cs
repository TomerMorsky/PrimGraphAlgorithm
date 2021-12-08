using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    internal class Edge
    {
        #region Properties

        public Vertex Source;
        public Vertex Destination;
        public int Weight;

        #endregion

        #region C'tor

        public Edge(Vertex source, Vertex destination, int wiehght)
        {
            Source = source;
            Destination = destination;
            Weight = wiehght;
        }

        #endregion

        #region Override methods

        public override bool Equals(object obj)
        {
            return obj is Edge edge &&
                   Equals(Source, edge.Source) &&
                   Equals(Destination, edge.Destination);
        }

        #endregion

        #region Public methods

        public void PrintEdge()
        {
            
        }

        #endregion
    }
}
