using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    class MergeSort
    {
        /// <summary>
        /// Uses recursion to break the collection into progressively smaller collections.
        /// Eventually, each collection will have just one element.
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns>sorted array </returns>

        public static List<int> Sort(List<int> unsorted) // -> O(N Log N)
        {
            if (unsorted.Count <= 1) // ->O(1)
            {
                return unsorted; // ->O(1)
            }
            List<int> left = new List<int>(); // ->O(1)
            List<int> right = new List<int>(); // ->O(1)
            int median = unsorted.Count / 2; // ->O(1)
            for (int i = 0; i < median; i++)  //Dividing the unsorted list // ->O(median)
            {
                left.Add(unsorted[i]); // ->O(1)
            }
            for (int i = median; i < unsorted.Count; i++) // ->O(median)
            {
                right.Add(unsorted[i]); // ->O(1)
            }

            left = Sort(left); // -> O(median)
            right = Sort(right);  // -> O(median)
            return Merge(left, right);// -> O(Log N)
        }
        /// <summary>
        /// Method takes two sorted "sublists" (left and right) of original list and merges them into a new colletion
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>merged list of the left and right list</returns>

        private static List<int> Merge(List<int> left, List<int> right) // -> Log (N)
        {
            List<int> result = new List<int>(); //The new collection // ->O(1)

            while (left.Any() || right.Any()) //O(Log N)
            {
                if (left.Any() && right.Any()) // ->O(1)
                {
                    if (left.First() <= right.First()) // ->O(1)  //Comparing the first element of each sublist 
                                                                   // to see which is smaller
                    {
                        result.Add(left.First()); // ->O(1)
                        left.Remove(left.First()); // ->O(1)
                    }
                    else
                    {
                        result.Add(right.First()); // ->O(1)
                        right.Remove(right.First()); // ->O(1)
                    }
                }
                else if (left.Any()) // ->O(1)
                {
                    result.Add(left.First()); // ->O(1)
                    left.Remove(left.First()); // ->O(1)
                }
                else if (right.Any()) // ->O(1)
                {
                    result.Add(right.First()); // ->O(1)
                    right.Remove(right.First()); // ->O(1)
                } 
            }
            return result; // ->O(1)
        }
    }
}
