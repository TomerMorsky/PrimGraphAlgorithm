﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAlgorithem
{
    public class Vertex
    {
        #region Properties

        public int Id;
        public int Key;

        public int Prim_pi;

        public string BFS_color;
        public int BFS_d;
        public int BFS_pi;

        #endregion

        #region C'tor

        public Vertex(int id)
        {
            Id = id;
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

        public void PrintNode()
        {
            Console.WriteLine("Node: " + this.Id);
            Console.WriteLine("prev PRIM: " + this.Prim_pi);
            Console.WriteLine("Key: " + this.Key);
        }

        #endregion

    }
}