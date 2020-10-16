using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageQuantization
{
    /// <summary>
    /// The Floyd‑Steinberg algorithm is an error diffusion algorithm
    ///  aim is to use simple threshold dithering on each pixel, 
    ///  but to accurately account for the errors in brightness it induces.
    ///  consider a 50% gray image (an image with every pixel exactly halfway between black and white in brightness). 
    /// </summary>
    class FloyedDither
    {
        private static double R1, G1, B1;   //->O(1)
        private static int R2, G2, B2;   //->O(1)
        private static int err_r, err_g, err_b; //->O(1)
        private static int r, g, b;     //->O(1)

        /// <summary>
        /// for each pixel an "error" is generated and then distributed to four pixels around
        /// the surrounding the current pixel. Each of the four offset pixels has a different
        /// weight - the error is multiplied by the weight, divided by 16 and then 
        /// added to the existing value of the offset pixel
        /// four offset pixels:
        ///     7 for the pixel to the right of the current pixel
        ///     3 for the pixel below and to the left
        ///     5 for the pixel below
        ///      1 for the pixel below and to the right
        /// </summary>
        /// <param name="factor">quant_error </param>
        /// <param name="Filltered"></param>
        /// <returns></returns>
        public static RGBPixel[,] Floyed_Dithering(int factor, RGBPixel[,] Filltered) // ->>O(H * W)
        {

            int h = ImageOperations.GetHeight(Filltered);   //->O(1)
            int w = ImageOperations.GetWidth(Filltered);  //->O(1)
            RGBPixel[,] ImageMatrix = Filltered.Clone() as RGBPixel[,]; // => O(H * W)
            for (int i = 0; i < w - 1; i++) //horizontal             //->O(W) * O(H)    ->>O(H * W)
            {
                for (int j = 1; j < h - 1; j++)  // vertical                //->O(H) *O(1)  ->>O(H)
                {

                    R1 = ImageMatrix[j, i].red;   //->O(1)
                    G1 = ImageMatrix[j, i].green;   //->O(1)
                    B1 = ImageMatrix[j, i].blue;   //->O(1)

                    R2 = Convert.ToInt32(Math.Round(factor * R1 / 255)) * (255 / factor);     //->O(1)
                    G2 = Convert.ToInt32(Math.Round(factor * G1 / 255)) * (255 / factor);     //->O(1)
                    B2 = Convert.ToInt32(Math.Round(factor * B1 / 255)) * (255 / factor);     //->O(1)
                    ImageMatrix[j, i].red = (byte)R2;    //->O(1)
                    ImageMatrix[j, i].green = (byte)G2;    //->O(1)
                    ImageMatrix[j, i].blue = (byte)B2;   //->O(1)
                    err_r = (int)R1 - R2;     //->O(1)
                    err_g = (int)G1 - G2;   //->O(1)
                    err_b = (int)B1 - B2;   //->O(1)
                    r = ImageMatrix[j + 1, i].red + err_r * 7 / 16;      //->O(1)
                    g = ImageMatrix[j + 1, i].green + err_g * 7 / 16;     //->O(1)
                    b = ImageMatrix[j + 1, i].blue + err_b * 7 / 16;     //->O(1)
                    Scale();  // ->O(1)
                    ImageMatrix[j + 1, i].red = (byte)r;  // ->O(1)
                    ImageMatrix[j + 1, i].green = (byte)g;   // ->O(1)
                    ImageMatrix[j + 1, i].blue = (byte)b;  // ->O(1)
                    r = ImageMatrix[j - 1, i + 1].red + err_r * 3 / 16;   // ->O(1)
                    g = ImageMatrix[j - 1, i + 1].green + err_g * 3 / 16;  // ->O(1)
                    b = ImageMatrix[j - 1, i + 1].blue + err_b * 3 / 16;   // ->O(1)
                    Scale();  // ->O(1)
                    ImageMatrix[j - 1, i + 1].red = (byte)r;   // ->O(1)
                    ImageMatrix[j - 1, i + 1].green = (byte)g;  // ->O(1)
                    ImageMatrix[j - 1, i + 1].blue = (byte)b;   // ->O(1)
                    r = (ImageMatrix[j, i + 1].red + err_r * 5 / 16);   // ->O(1)
                    g = (ImageMatrix[j, i + 1].green + err_g * 5 / 16);   // ->O(1)
                    b = (ImageMatrix[j, i + 1].blue + err_b * 5 / 16);   // ->O(1)
                    Scale();  // ->O(1)
                    ImageMatrix[j, i + 1].red = (byte)r;    // ->O(1)
                    ImageMatrix[j, i + 1].green = (byte)g;   // ->O(1)
                    ImageMatrix[j, i + 1].blue = (byte)b;   // ->O(1)
                    r = ImageMatrix[j + 1, i + 1].red + err_r * 1 / 16;      // ->O(1)
                    g = ImageMatrix[j + 1, i + 1].green + err_g * 1 / 16;   // ->O(1)
                    b = ImageMatrix[j + 1, i + 1].blue + err_b * 1 / 16;   // ->O(1)
                    Scale();  // ->O(1)
                    ImageMatrix[j + 1, i + 1].red = (byte)r;  // ->O(1)
                    ImageMatrix[j + 1, i + 1].green = (byte)g;   // ->O(1)
                    ImageMatrix[j + 1, i + 1].blue = (byte)b;    // ->O(1)
                }
            }
            return ImageMatrix; // ->O(1)
        }
        /// <summary>
        ///   a black-white checker pattern at the pixel level
        /// </summary>
        public static void Scale()      // ->O(1)
        {
            if (r > 255) r = 255;    // ->O(1)
            else if (r < 0) r = 0;  // ->O(1)

            if (g > 255) g = 255;   // ->O(1)
            else if (g < 0) g = 0;  // ->O(1)

            if (b > 255) b = 255;   // ->O(1)
            else if (b < 0) b = 0; // ->O(1)
        }

    }
}
