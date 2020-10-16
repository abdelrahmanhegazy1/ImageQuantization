using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    /// <summary>
    /// class contains functions treat with fibbonacci heap
    /// </summary>
    class FibbonacciHeap
    {
        /// <summary>
        /// data for fibbonacci tree
        /// </summary>
        private HeapNode minHeap; // -> O(1)
        public HeapNode[] HeapList; // -> O(1)
        public int size = 0; // -> O(1)
        public int capacity = 0; // -> O(1)
        private static readonly double OneOverLogPhi = 1.0 / Math.Log((1.0 + Math.Sqrt(5.0)) / 2.0); // performance... // -> O(1)

        /// <summary>
        /// constractor intialze the fibbonaci heap
        /// </summary>
        /// <param name="capacity">levels of tree </param>
        public FibbonacciHeap(int capacity) // -> O(1)
        {
            this.capacity = capacity; // -> O(1)
            HeapList = new HeapNode[capacity]; // -> O(1)
            minHeap = null; // -> O(1)
        } 
        /// <summary>
        /// insert new node into tree
        /// </summary>
        /// <param name="NewNode">the new node </param>
        public void Insert(HeapNode NewNode) // -> O(1)
        {
            if (minHeap != null) // -> O(1)
            {
                NewNode.left = minHeap; // -> O(1)
                NewNode.right = minHeap.right; // -> O(1)
                minHeap.right = NewNode; // -> O(1)
                NewNode.right.left = NewNode; // -> O(1)
                if (NewNode.weight < minHeap.weight) // -> O(1)
                    minHeap = NewNode; // -> O(1)
            }
            else
                minHeap = NewNode; // -> O(1)
            HeapList[NewNode.key] = NewNode; // -> O(1)
            size++; // -> O(1)
        }
        /// <summary>
        /// decrease node from tree
        /// </summary>
        /// <param name="indx">the key of node</param>
        /// <param name="value">the value of node</param>
        public void decrease_key(int indx, double value) // -> O(1)
        {
            HeapNode updatednode = HeapList[indx]; // -> O(1)
            updatednode.weight = value; // -> O(1)
            HeapNode parent = updatednode.parent; // -> O(1)
            if (parent != null && updatednode.weight < parent.weight) // -> O(1)
            {
                Cut(updatednode, parent); // -> O(1)
                Cascase_cut(parent); // -> O(d) ->> O(1)
                // Rule: -->> phase(Heap) = tree(Heap)"#roots" + 2 * Root(Max Marked Node).
            }
            if (updatednode.weight < minHeap.weight) // -> O(1)
                minHeap = updatednode; // -> O(1)
        }
        /// <summary>
        /// function used in decrease_key() to change the values of node
        /// </summary>
        /// <param name="node">the current node</param>
        /// <param name="parent">the parent of node</param>
        public void Cut(HeapNode node, HeapNode parent) // -> O(1)
        {
            (node.left).right = node.right; // -> O(1)
            (node.right).left = node.left; // -> O(1)
            parent.degree--; // -> O(1)
            if (node == parent.child) // -> O(1)
                parent.child = node.right; // -> O(1)
            if (parent.degree == 0) // -> O(1)
                parent.child = null; // -> O(1)
            node.left = minHeap; // -> O(1)
            node.right = minHeap.right; // -> O(1)
            minHeap.right = node; // -> O(1)
            node.right.left = node; // -> O(1)
            node.parent = null; // -> O(1)
            node.mark = false; // -> O(1)
        }
        /// <summary>
        /// used to change th all parent node in levels (used in decrease_key())
        /// </summary>
        /// <param name="node"></param>
        public void Cascase_cut(HeapNode node) // -> O(Log V)
        {
            HeapNode parent = node.parent; // -> O(1)
            if (parent != null) // -> O(1)
                if (node.mark == false) // -> O(1)
                    node.mark = true; // -> O(1)
                else
                {
                    Cut(node, parent); // -> O(1)
                    Cascase_cut(parent); // -> O(Log Node(V))
                }
        }
        /// <summary>
        /// to merge trees 
        /// </summary>
        /// <param name="max">max node</param>
        /// <param name="min">min node</param>
        public void mergeTrees(HeapNode max, HeapNode min) // -> O(1)
        {
            max.left.right = max.right; // -> O(1)
            max.right.left = max.left; // -> O(1)
            max.parent = min; // -> O(1)
            if (min.child == null) // -> O(1)
            {
                min.child = max; // -> O(1)
                max.right = max; // -> O(1)
                max.left = max; // -> O(1)
            }
            else
            {
                max.left = min.child; // -> O(1)
                max.right = min.child.right; // -> O(1)
                min.child.right = max; // -> O(1)
                max.right.left = max; // -> O(1)
            }
            min.degree++; // -> O(1)
            max.mark = false; // -> O(1)
        }
        /// <summary>
        /// used in extract_min node to make changes in tree after extracting .
        /// </summary>
        public void Consolidate() // O(log V + d) ->> O(Log V)
        {
            int treeHeight = ((int)Math.Floor(Math.Log(size) * OneOverLogPhi)) + 1;///degree Of tree//  // -> O(1)
            HeapNode[] levels = new HeapNode[treeHeight]; // -> O(1)

            for (int i = 0; i < treeHeight; i++) // -> O(treeHeight(d))
                levels[i] = null; // -> O(1)
            
            int roots = 0; // -> O(1)
            HeapNode nodeiterator = minHeap; // -> O(1)

            if (nodeiterator != null) // -> O(1)
                do
                {
                    roots++; // -> O(1)
                    nodeiterator = nodeiterator.right; // -> O(1)
                }
                while (nodeiterator != minHeap); // -> O(V)
            while (roots > 0) // O(V)*O(d) ->> O(log V + d)
            {
                int deg = nodeiterator.degree; // -> O(1)
                HeapNode next = nodeiterator.right;  // -> O(1)
                while (true) // -> O(d) * O(1)
                {
                    HeapNode node = levels[deg]; // -> O(1)
                    if (node == null) // -> O(1)
                        break;
                    if (nodeiterator.weight > node.weight) // -> O(1)
                        swap(ref node, ref nodeiterator); // -> O(1)
                    mergeTrees(node, nodeiterator); // -> O(1)
                    levels[deg++] = null; // -> O(1)
                }
                levels[deg] = nodeiterator; // -> O(1)
                nodeiterator = next; // -> O(1)
                roots--; // -> O(1)
            }

            minHeap = null; // -> O(1)

            for (int i = 0; i < treeHeight; i++) // ->> O(degree (d))
            {
                HeapNode node = levels[i]; // -> O(1)
                if (node == null) continue; // -> O(1)
                if (minHeap != null) // -> O(1)
                {
                    node.left.right = node.right; // -> O(1)
                    node.right.left = node.left; // -> O(1)
                    node.left = minHeap; // -> O(1)
                    node.right = minHeap.right; // -> O(1)
                    minHeap.right = node; // -> O(1)
                    node.right.left = node; // -> O(1)
                    if (minHeap.weight > node.weight) // -> O(1)
                        minHeap = node; // -> O(1)
                }
                else
                    minHeap = node; // -> O(1)
            }

        }
        /// <summary>
        /// extract the min node from tree
        /// </summary>
        /// <returns>min node</returns>
        public HeapNode Extract_min() // O(log V + d) ->> O(Log V)
        {
            HeapNode min = minHeap; // -> O(1)
            if (min != null) // -> O(1)
            {
                int childs = min.degree; // -> O(1)
                HeapNode min_child = min.child; // -> O(1)
                while (childs > 0) // - >> O(degree)
                {
                    HeapNode tmp = min_child.right; // -> O(1)
                    min_child.left.right = min_child.right; // -> O(1)
                    min_child.right.left = min_child.left; // -> O(1)
                    min_child.left = minHeap; // -> O(1)
                    min_child.right = minHeap.right; // -> O(1)
                    minHeap.right = min_child; // -> O(1)
                    min_child.right.left = min_child; // -> O(1)
                    min_child.parent = null; // -> O(1)
                    min_child = tmp; // -> O(1)
                    childs--; // -> O(1)
                }
            }
            min.left.right = min.right; // -> O(1)
            min.right.left = min.left; // -> O(1)

            if (min == min.right) // -> O(1)
                minHeap = null; // -> O(1)
            else
            {
                minHeap = min.right; // -> O(1)
                Consolidate(); // O(log V + d) ->> O(Log V)
            }
            size--; // -> O(1)
            return min; // -> O(1)
        }
        /// <summary>
        /// used to swap the values between 2 node
        /// </summary>
        /// <param name="X">node 1</param>
        /// <param name="Y">node 2</param>
        public void swap(ref HeapNode X, ref HeapNode Y) // -> O(1)
        {
            HeapNode temp = X;   // -> O(1)
            X = Y; // -> O(1)
            Y = temp; // -> O(1)
        }
    }
}
