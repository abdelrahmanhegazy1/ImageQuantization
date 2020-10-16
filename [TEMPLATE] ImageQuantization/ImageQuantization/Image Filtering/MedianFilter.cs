using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    /// <summary>
    ///  Median filter is another very common filter, 
    ///  which reduces noise and preserves edges.
    ///  It can fix pixels or even small areas with damaged or missing color.
    /// </summary>
    class MedianFilter
    {
        /// <summary>
        ///  takes an image and change the pixles based on factor number
        ///  uses merge sort to sort the pixel to be sure it will take the most used pixels in an image
        /// </summary>
        /// <param name="image">the orignal image</param>
        /// <param name="Factor">the number changes the fillterd image based on it</param>
        /// <param name="RezImage">the filltered image </param>
        public static void Median_Filter(Bitmap image, int Factor, ref Bitmap RezImage) // [-> O(N Log N))]
        {
            for (int y = Factor; y < image.Height - Factor; y++) // -> O(H- Factor) -> O(X) [-> O(N Log N))]
            {
                for (int x = Factor; x < image.Width - Factor; x++) // -> O(W- Factor) -> O(Y)
                {
                    List<int> Image_List = new List<int>(); // -> O(1)
                    Image_List.Add(image.GetPixel(x - Factor, y - Factor).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x - 0, y - Factor).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x + Factor, y - Factor).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x - Factor, y - 0).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x - 0, y - 0).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x + Factor, y - 0).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x - Factor, y + Factor).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x - 0, y + Factor).ToArgb()); // -> O(1)
                    Image_List.Add(image.GetPixel(x + Factor, y + Factor).ToArgb()); // -> O(1)
                    List<int> Image_Rez = MergeSort.Sort(Image_List); // -> O(N Log N)
                    RezImage.SetPixel(x, y, Color.FromArgb(Image_Rez[5])); // -> O(1)
                }
            }
        }

    }
}
