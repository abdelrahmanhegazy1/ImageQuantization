using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    /// <summary>
    /// Edge is expressing the relation between two vertices and the cost to reach from one to another
    /// </summary>
    public class Edge
    {
        public int source = 0; // O(1)
        public int destionation = 0; // O(1)
        public double weight = 0.0; // O(1)
        /// <summary>
        /// Empty Constructor to compfortable initialization
        /// </summary>
        public Edge() //O(1)
        {
            //O(1)
        }
        /// <summary>
        /// Constructor that set Data(source ,target,weight)
        /// </summary>
        public Edge(int source, int destionation, double weight) ///// O(1)
        {
            this.source = source; //O(1)
            this.destionation = destionation; //O(1)
            this.weight = weight; //O(1)
        }
    }
}
