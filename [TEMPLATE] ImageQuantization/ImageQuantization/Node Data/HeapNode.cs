using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    /// <summary>
    /// data of each node in fibbonacii heap
    /// </summary>
    class HeapNode
    {
        // public data of node used in fibbonacii heap
        public int key; //Name of vertix//  -> O(1)
        public int degree; //number of childern//  -> O(1)
        public double weight; ///key//  -> O(1)
        public HeapNode left; // -> O(1)
        public HeapNode right; // -> O(1)
        public HeapNode parent; // -> O(1)
        public HeapNode child; // -> O(1)
        public bool mark; // -> O(1)
        /// <summary>
        /// constractor used to intialize the node
        /// </summary>
        /// <param name="key">unique number refers to node</param>
        /// <param name="value">the value of node </param>
        public HeapNode(int key,double value) // -> O(1)
        {
            this.key = key; // -> O(1)
            this.weight = value; // -> O(1)
            this.degree = 0; // -> O(1)
            this.parent = null; // -> O(1)
            this.child = null; // -> O(1)
            this.left = this; // -> O(1)
            this.right = this; // -> O(1)
            this.mark = false; // -> O(1)
        }
    }
}
