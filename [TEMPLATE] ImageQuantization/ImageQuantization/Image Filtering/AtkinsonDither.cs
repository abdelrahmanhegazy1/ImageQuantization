using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    /// <summary>
    ///The Atkinson dithering algorithm itself is a modified version of Floyd-Steinberg dithering,
    ///where the “error” between the intended gray level at each pixel and the black or white 
    /// dot that is actually drawn at each pixel is distributed to neighboring points.
    /// </summary>
    class AtkinsonDither
    {

        private static int h;  //->O(1)
        private static int w; //->O(1)
        private static double R1, G1, B1;  //->O(1)
        private static int R2, G2, B2;   //->O(1)
        private static int err_r, err_g, err_b;  //->O(1)
        /// <summary>
        ///  for each pixel an "error" is generated and then distributed to four pixels around
        /// the surrounding the current pixel. Each of the four offset pixels has a different
        /// weight - the error is multiplied by the weight, divided by 16 and then 
        /// added to the existing value of the offset pixel
        /// four offset pixels:
        ///     7 for the pixel to the right of the current pixel
        ///     3 for the pixel below and to the left
        ///     5 for the pixel below
        ///      1 for the pixel below and to the right
        /// </summary>
        /// <param name="ImageMatrix"></param>
        /// <param name="factor">quant_error </param>
        /// <returns></returns>
        public static RGBPixel[,] Atkinson_Dithering(RGBPixel[,] ImageMatrix, int factor) // ->>O(H * W)
        {

            h = ImageOperations.GetHeight(ImageMatrix);  //->O(1)
            w = ImageOperations.GetWidth(ImageMatrix);    //->O(1)
            RGBPixel[,] Buffer = ImageMatrix.Clone() as RGBPixel[,]; // => O(H * W)

            for (int i = 0; i < w - 1; i++) //horizontal             //->O(W) * O(H)    ->>O(H * W)
            {
                for (int j = 1; j < h - 1; j++)  // vertical                //->O(H) *O(1)  ->>O(H)
                {

                    R1 = Buffer[j, i].red;    //->O(1)
                    G1 = Buffer[j, i].green;   //->O(1)
                    B1 = Buffer[j, i].blue;   //->O(1)

                    R2 = Convert.ToInt32(Math.Round(factor * R1 / 255)) * (255 / factor);   //->O(1)
                    G2 = Convert.ToInt32(Math.Round(factor * G1 / 255)) * (255 / factor);   //->O(1)
                    B2 = Convert.ToInt32(Math.Round(factor * B1 / 255)) * (255 / factor);   //->O(1)
                    Buffer[j, i].red = (byte)R2;   //->O(1)
                    Buffer[j, i].green = (byte)G2;   //->O(1)
                    Buffer[j, i].blue = (byte)B2;   //->O(1)
                    err_r = (int)R1 - R2;    //->O(1)
                    err_g = (int)G1 - G2;   //->O(1)
                    err_b = (int)B1 - B2;  //->O(1)
                    // right
                    Buffer[j + 1, i].red = (byte)(Buffer[j + 1, i].red + err_r * 7 / 16);   //->O(1)
                    Buffer[j + 1, i].green = (byte)(Buffer[j + 1, i].green + err_g * 7 / 16);   //->O(1)
                    Buffer[j + 1, i].blue = (byte)(Buffer[j + 1, i].blue + err_b * 7 / 16);  //->O(1)
                    gray_scale(ref Buffer[j + 1, i].red, ref Buffer[j + 1, i].green, ref Buffer[j + 1, i].blue);  //->O(1)
                                                                                                                  //below and to the left
                    Buffer[j - 1, i + 1].red = (byte)(Buffer[j - 1, i + 1].red + err_r * 3 / 16);  //->O(1)
                    Buffer[j - 1, i + 1].green = (byte)(Buffer[j - 1, i + 1].green + err_g * 3 / 16);  //->O(1)
                    Buffer[j - 1, i + 1].blue = (byte)(Buffer[j - 1, i + 1].blue + err_b * 3 / 16);  //->O(1)
                    gray_scale(ref Buffer[j - 1, i + 1].red, ref Buffer[j - 1, i + 1].green, ref Buffer[j - 1, i + 1].blue);   //->O(1)
                    // below
                    Buffer[j, i + 1].red = (byte)(Buffer[j, i + 1].red + err_r * 5 / 16);  //->O(1)
                    Buffer[j, i + 1].green = (byte)(Buffer[j, i + 1].green + err_g * 5 / 16);  //->O(1)
                    Buffer[j, i + 1].blue = (byte)(Buffer[j, i + 1].blue + err_b * 5 / 16); //->O(1)
                    gray_scale(ref Buffer[j, i + 1].red, ref Buffer[j, i + 1].green, ref Buffer[j, i + 1].blue);  //->O(1)
                    // below and to right
                    Buffer[j + 1, i + 1].red = (byte)(Buffer[j + 1, i + 1].red + err_r * 1 / 16);  //->O(1)
                    Buffer[j + 1, i + 1].green = (byte)(Buffer[j + 1, i + 1].green + err_g * 1 / 16);  //->O(1)
                    Buffer[j + 1, i + 1].blue = (byte)(Buffer[j + 1, i + 1].blue + err_b * 1 / 16); //->O(1)
                    gray_scale(ref Buffer[j + 1, i + 1].red, ref Buffer[j + 1, i + 1].green, ref Buffer[j + 1, i + 1].blue);  //->O(1)

                }
            }

            return Buffer; //->O(1)
        }
        /// <summary>
        /// Converting a colour to black or white
        ///  grayscale value is around 50% 
        ///  (127 in .NET's 0 - 255 range), then the transformed pixel will be black, otherwise it will be white.
        /// </summary>
        /// <param name="R">red</param>
        /// <param name="B">blue</param>
        /// <param name="G">green</param>
        static void gray_scale(ref byte R, ref byte B, ref byte G)   //->O(1)
        {

            byte gray; //->O(1)
            gray = (byte)(0.299 * R + 0.587 * G + 0.114 * B);  //->O(1)

            if (gray < 128)  //->O(1)
                R = B = G = 0;  //->O(1)
            else   //->O(1)
                R = G = B = 255;   //->O(1)


        }
    }
}
