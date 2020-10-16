using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageQuantization
{
    /// <summary>
    /// Library of static functions Its goal is to get the Quantized Image in an efficient way.
    /// </summary>
    class ImageAnalytics
    {

        static public List<Edge> edges = new List<Edge>();
        // List Of Distinct Color In Image To Use it along The program
        public static List<RGBPixel> Distinct_Colors_List = new List<RGBPixel>(); // -> O(1)

        public static int[] parent; // -> O(1)
        public static double[] weight; // -> O(1)
        public static bool[] visitedHeap; // -> O(1)

        /// <summary>
        /// responsible for extracting all unique colors and
        /// pushing them into a list.
        /// <param name= "ImageMatrix">2D Array holds data colors</param>
        /// <returns>number of distinct color</returns>
        /// </summary>
        public static long Find_Distinct_Color(RGBPixel[,] ImageMatrix) // -> O(H * W)
        {
            Distinct_Colors_List.Clear(); // -> O(N)
            bool[,,] check = new bool[256, 256, 256]; // -> O(1)
            int width_image = ImageOperations.GetWidth(ImageMatrix);  // -> O(1)
            int height_image = ImageOperations.GetHeight(ImageMatrix);  // -> O(1)
            for (int i = 0; i < height_image; i++) // -> O(H) * O(W) -> O(H * W)
            {
                for (int j = 0; j < width_image; j++) // -> O(W)*  O(1)
                {
                    int r = ImageMatrix[i, j].red // -> O(1)
                      , g = ImageMatrix[i, j].green // -> O(1)
                      , b = ImageMatrix[i, j].blue; // -> O(1)
                    if (!check[r, g, b])   //distinct_colors.Contains(ImageMatrix[i, j]) // -> O(1)
                    {
                        Distinct_Colors_List.Add(ImageMatrix[i, j]); // -> O(1)
                        check[r, g, b] = true; // -> O(1)
                    }
                }
            }
            return Distinct_Colors_List.Count; // -> O(1)
        }

        /// <summary>
        /// Finding the minimum spanning tree in the 
        /// quantization process in which we need to find the minimum costs
        /// between the colors to be able to group them after that.
        /// <returns>min cost of MST</returns>
        /// </summary>
        public static double MinimumSpanningTree() // [O(V) * O(E *Log V)] ->> O(E Log V)
        {

            edges.Clear();
            parent = new int[Distinct_Colors_List.Count]; // -> O(1)
            weight = new double[Distinct_Colors_List.Count]; // -> O(1)
            visitedHeap = new bool[Distinct_Colors_List.Count]; // -> O(1)
            FibbonacciHeap heap = new FibbonacciHeap(Distinct_Colors_List.Count); // -> O(1)
            parent[0] = 0; // -> O(1)
            weight[0] = 0; // -> O(1)
            heap.Insert(new HeapNode(0, 0)); // -> O(1)
            for (int i = 1; i < Distinct_Colors_List.Count; i++) // -> O(V)
            {
                parent[i] = -1; // -> O(1)
                weight[i] = 1e9; // -> O(1)
                heap.Insert(new HeapNode(i, weight[i])); // -> O(1)
            }
            while (heap.size != 0) // [O(E) * O(Log V)] ->> O(E Log V)
            {
                HeapNode extractedHeap = heap.Extract_min(); // -> O(Log V)
                visitedHeap[extractedHeap.key] = true; // -> O(1)
                for (int i = 0; i < Distinct_Colors_List.Count; i++) // -> O(Log E) * O(1)
                {
                    if (visitedHeap[i] || i == extractedHeap.key) // -> O(1)
                        continue;
                    double R = 0, G = 0, B = 0; // -> O(1)
                    R = Distinct_Colors_List[extractedHeap.key].red - Distinct_Colors_List[i].red; // -> O(1)
                    G = Distinct_Colors_List[extractedHeap.key].green - Distinct_Colors_List[i].green; // -> O(1)
                    B = Distinct_Colors_List[extractedHeap.key].blue - Distinct_Colors_List[i].blue;    // -> O(1)
                    double distance = R * R + G * G + B * B; // -> O(1)
                    distance = Math.Sqrt(distance);  // -> O(1)
                    if (distance < weight[i]) // -> O(1)
                    {
                        parent[i] = extractedHeap.key; // -> O(1)
                        weight[i] = distance; // -> O(1)
                        heap.decrease_key(i, distance); // -> O(1)
                    }
                }
            }
            double MSTsum = 0;
            for (int i = 0; i < Distinct_Colors_List.Count; i++)  // -> O(V)
            {
                MSTsum += weight[i]; // -> O(1)
                edges.Add(new Edge(i, parent[i], weight[i]));    // -> O(1)
            }
            return MSTsum;   // -> O(1)
        }
    }
}
