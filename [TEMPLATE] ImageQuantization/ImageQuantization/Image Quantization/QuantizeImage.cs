using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    /// <summary>
    /// class QuantizeImage used to get Quantization images 
    /// </summary>
    class QuantizeImage
    {
        private static List<int>[] adj_list;            //->O(1)
        private static RGBPixelD RGB_colors;     //->O(1)
        public static RGBPixel[] final_Adj_list;   //->O(1)
        private static int id_color = 0, number_color;  //->O(1)
        private static int[] Ids_Color;                              //->O(1)
        public static RGBPixel[,,] final_image;             //->O(1)

        /// <summary>
        ///Remove edges that have highest weights until reaching the desired number of clusters. 
        ///to obtain a set of disjoint sub trees (clusters).
        /// </summary>
        /// <param name="K">number of cluster</param>
        public static void Extract_K_Cluster(int K)   //->O(K*D)
        {
            for (int i = 0; i < K - 1; i++)       //->O(K)
            {
                double Max = 0; int index = -1;       //->O(1)
                for (int j = 1; j < ImageAnalytics.Distinct_Colors_List.Count; j++)    //->O(D)
                {
                    if (ImageAnalytics.weight[j] > Max)     //->O(1)
                    {
                        Max = ImageAnalytics.weight[j];      //->O(1)
                        index = j;                                                  //->O(1)
                    }
                }
                ImageAnalytics.parent[index] = index;
                ImageAnalytics.weight[index] = -1;
            }


        }

        /// <summary>
        /// find minimum distance between edges
        /// </summary>
        /// <param name="Color"></param>
        private static void BFS(int Color)   //->> O(V + E)
        {
            ImageAnalytics.visitedHeap[Color] = true;      //->O(1)
            Queue<int> min_dis = new Queue<int>();   //->O(1)
            min_dis.Enqueue(Color);                                       //->O(1)
            while (min_dis.Count != 0)                                  //-O(V) *Body  ->> O(V + E)
            {
                Color = min_dis.Dequeue();                           //->O(1)
                Ids_Color[Color] = id_color;                          //->O(1)
                number_color++;                                           //->O(1)
                RGB_colors.red += ImageAnalytics.Distinct_Colors_List[Color].red;           //->O(1)
                RGB_colors.green += ImageAnalytics.Distinct_Colors_List[Color].green;    //->O(1)
                RGB_colors.blue += ImageAnalytics.Distinct_Colors_List[Color].blue;       //->O(1)

                int itration = adj_list[Color].Count;                       //->O(1)
                for (int indx = 0; indx < itration; indx++)         //->O(E)
                {
                    if (!ImageAnalytics.visitedHeap[adj_list[Color][indx]])         //->O(1)
                    {
                        ImageAnalytics.visitedHeap[adj_list[Color][indx]] = true;    //->O(1)
                        min_dis.Enqueue(adj_list[Color][indx]);                                         //->O(1)

                    }
                }
            }
        }

        /// <summary>
        /// Find the representative color of each cluster
        /// </summary>
        public static void Find_K_Cluster() //->>O(D) 
        {
            adj_list = new List<int>[ImageAnalytics.Distinct_Colors_List.Count];  //-->O(1)
            for (int i = 0; i < ImageAnalytics.Distinct_Colors_List.Count; i++)       //-->O(D) * O(1)->> O(D)
            {
                adj_list[i] = new List<int>(ImageAnalytics.Distinct_Colors_List.Count);   //-->O(1)
            }
            for (int i = 0; i < ImageAnalytics.Distinct_Colors_List.Count; i++)    //-->O(D) *O(1) ->>O(D)
            {
                if (i == ImageAnalytics.parent[i])                           //-->O(1)
                    continue;                                                                    //-->O(1)
                adj_list[ImageAnalytics.parent[i]].Add(i);  //-->O(1)
                adj_list[i].Add(ImageAnalytics.parent[i]);   //-->O(1)
            }
            final_Adj_list = new RGBPixel[ImageAnalytics.Distinct_Colors_List.Count];                     //-->O(1)
            ImageAnalytics.visitedHeap = new bool[ImageAnalytics.Distinct_Colors_List.Count];            //-->O(1)
            Ids_Color = new int[ImageAnalytics.Distinct_Colors_List.Count];                       //-->O(1)
            id_color = 0;                                          //-->O(1)

            for (int i = 0; i < ImageAnalytics.Distinct_Colors_List.Count; i++)  //->O(D) * O(V+E) ->> O(D)
            {
                if (!ImageAnalytics.visitedHeap[i])   //-->O(1)
                {
                    number_color = 0;              //-->O(1)
                    RGB_colors.red = RGB_colors.green = RGB_colors.blue = 0;  //-->O(1)
                    BFS(i);    //-->O(V+E)
                    double col = (double)RGB_colors.red / number_color;      //-->O(1)
                    final_Adj_list[id_color].red = (byte)col;   //-->O(1)
                    col = (double)RGB_colors.green / number_color;   //-->O(1)
                    final_Adj_list[id_color].green = (byte)col;  //-->O(1)
                    col = (double)RGB_colors.blue / number_color;  //-->O(1)
                    final_Adj_list[id_color].blue = (byte)col;   //-->O(1)
                    id_color++;              //-->O(1)

                }
            }

        }
        /// <summary>
        /// Quantize the image by replacing the colors of each cluster by its representative color.
        /// </summary>
        public static void Quantize_Image() //->O(D)
        {
            final_image = new RGBPixel[256, 256, 256];  //->O(1)

            for (int i = 0; i < ImageAnalytics.Distinct_Colors_List.Count; i++)  //->O(D)*O(1) ->>O(D)
            {
                int d = Ids_Color[i];//->O(1)
                final_image[ImageAnalytics.Distinct_Colors_List[i].red, ImageAnalytics.Distinct_Colors_List[i].green,
                    ImageAnalytics.Distinct_Colors_List[i].blue] = final_Adj_list[d];   //->O(1)
            }

        }
    }
}
