using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace ImageQuantization
{
    
    /// <summary>
    /// Holds the pixel color in 3 byte values: red, green and blue 
    /// </summary>
    public struct RGBPixel
    {
        public byte red, green, blue; // -> O(1).
    }
    /// <summary>
    /// Holds the pixel color in 3 double values: red, green and blue
    /// </summary>
    public struct RGBPixelD
    {
        public double red, green, blue; // -> O(1).
    }


    /// <summary>
    /// Library of static functions that deal with images (All Image Operations)
    /// </summary>
    public class ImageOperations
    {
       
        /// <summary>
        /// Open an image and load it into 2D array of colors (size: Height x Width)
        /// </summary>
        /// <param name="ImagePath">Image file path</param>
        /// <returns>2D array of colors</returns>
        public static RGBPixel[,] OpenImage(string ImagePath) // -> O(W*H)
        {
            Bitmap original_bm = new Bitmap(ImagePath); // -> O(1)
            int Height = original_bm.Height; // -> O(1)
            int Width = original_bm.Width; // -> O(1)

            RGBPixel[,] Buffer = new RGBPixel[Height, Width]; // -> O(1)
            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);    // -> O(1)
                int x, y; // -> O(1)
                int nWidth = 0; // -> O(1) 
                bool Format32 = false; // -> O(1)
                bool Format24 = false; // -> O(1)
                bool Format8 = false; // -> O(1)

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)   // -> O(1)
                {
                    Format24 = true; // -> O(1)
                    nWidth = Width * 3; // -> O(1)
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb 
                                                                                || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)  // -> O(1)
                {
                    Format32 = true; // -> O(1)
                    nWidth = Width * 4; // -> O(1)
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)   // -> O(1)
                {
                    Format8 = true; // -> O(1)
                    nWidth = Width; // -> O(1)
                }
                int nOffset = bmd.Stride - nWidth; // -> O(1)
                byte* p = (byte*)bmd.Scan0;  // -> O(1)
                for (y = 0; y < Height; y++) /* -> O(Height) * O(Width) --->> (H*W)*/ {
                    for (x = 0; x < Width; x++) /*/ -> O(Width) *  O(1) */{
                        if (Format8)  // -> O(1)
                        {
                            Buffer[y, x].red = Buffer[y, x].green = Buffer[y, x].blue = p[0]; // -> O(1)
                            p++;  // -> O(1)
                        }
                        else
                        {
                            Buffer[y, x].red = p[2]; // -> O(1)
                            Buffer[y, x].green = p[1]; // -> O(1)
                            Buffer[y, x].blue = p[0]; // -> O(1)
                            if (Format24) p += 3; // -> O(1)
                            else if (Format32) p += 4; // -> O(1)
                        }
                    }
                    p += nOffset; // -> O(1)
                }
                original_bm.UnlockBits(bmd);  // -> O(1)
            }

            return Buffer;
        }

        /// <summary>
        /// Get the height of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Height</returns>
        public static int GetHeight(RGBPixel[,] ImageMatrix)  // -> O(1)
        {
            return ImageMatrix.GetLength(0);  // -> O(1)
        }

        /// <summary>
        /// Get the width of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Width</returns>
        public static int GetWidth(RGBPixel[,] ImageMatrix)  // -> O(1)
        {
            return ImageMatrix.GetLength(1);  // -> O(1)
        }

        /// <summary>
        /// Display the given image on the given PictureBox object
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <param name="PicBox">PictureBox object to display the image on it</param>
        /// <param name="choice">to know it should make qunatization image or simple display (0/1) </param>
        public static void DisplayImage(RGBPixel[,] ImageMatrix, PictureBox PicBox,int choice) // -> O(W*H)
        {
            int Height = GetHeight(ImageMatrix);  // -> O(1)
            int Width = GetWidth(ImageMatrix);  // -> O(1)

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);  // -> O(1)
            if (choice == 1)
            {
                QuantizeImage.Quantize_Image(); // -> O(N)
                // Create Image:
                //==============

                 

                unsafe
                {
                    BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);  // -> O(1)
                    int nWidth = 0; // -> O(1)
                    nWidth = Width * 3; // -> O(1)
                    int nOffset = bmd.Stride - nWidth; // -> O(1)
                    byte* p = (byte*)bmd.Scan0;  // -> O(1)
                    for (int i = 0; i < Height; i++)  // -> O(Height) * O(Width) --->> (H*W)
                    {
                        for (int j = 0; j < Width; j++) // -> O(Width) *  O(1)
                        {
                            p[2] = QuantizeImage.final_image[ImageMatrix[i, j].red, ImageMatrix[i, j].green, ImageMatrix[i, j].blue].red;
                            p[1] = QuantizeImage.final_image[ImageMatrix[i, j].red, ImageMatrix[i, j].green, ImageMatrix[i, j].blue].green;
                            p[0] = QuantizeImage.final_image[ImageMatrix[i, j].red, ImageMatrix[i, j].green, ImageMatrix[i, j].blue].blue;
                            p += 3; // -> O(1)
                        }

                        p += nOffset; // -> O(1)
                    }
                    ImageBMP.UnlockBits(bmd); // -> O(1)
                }

            }
            else
            {
                unsafe
                {
                    BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);  // -> O(1)
                    int nWidth = 0; // -> O(1)
                    nWidth = Width * 3; // -> O(1)
                    int nOffset = bmd.Stride - nWidth; // -> O(1)
                    byte* p = (byte*)bmd.Scan0;  // -> O(1)
                    for (int i = 0; i < Height; i++)  // -> O(Height) * O(Width) --->> (H*W)
                    {
                        for (int j = 0; j < Width; j++) // -> O(Width) *  O(1)
                        {
                            p[2] = ImageMatrix[i, j].red; // -> O(1)
                            p[1] = ImageMatrix[i, j].green; // -> O(1)
                            p[0] = ImageMatrix[i, j].blue; // -> O(1)
                            p += 3; // -> O(1)
                        }

                        p += nOffset; // -> O(1)
                    }
                    ImageBMP.UnlockBits(bmd); // -> O(1)
                }
             

            }
            PicBox.Image = ImageBMP; // -> O(1)

        }

        /// <summary>
        /// Apply Gaussian smoothing filter to enhance the edge detection 
        /// </summary>
        /// <param name="ImageMatrix">Colored image matrix</param>
        /// <param name="filterSize">Gaussian mask size</param>
        /// <param name="sigma">Gaussian sigma</param>
        /// <returns>smoothed color image</returns>
        public static RGBPixel[,] GaussianFilter1D(RGBPixel[,] ImageMatrix, int filterSize, double sigma) //->  O(W*H)
        {
            int Height = GetHeight(ImageMatrix); // -> O(1)
            int Width = GetWidth(ImageMatrix);  // -> O(1)

            RGBPixelD[,] VerFiltered = new RGBPixelD[Height, Width]; // -> O(1)
            RGBPixel[,] Filtered = new RGBPixel[Height, Width];// -> O(1)


            // Create Filter in Spatial Domain:
            //=================================
            //make the filter ODD size
            if (filterSize % 2 == 0) filterSize++;  // -> O(1)

            double[] Filter = new double[filterSize]; // -> O(1)

            //Compute Filter in Spatial Domain :
            //==================================
            double Sum1 = 0; // -> O(1)
            int HalfSize = filterSize / 2; // -> O(1)
            for (int y = -HalfSize; y <= HalfSize; y++) // -> O(HalfSize (F/2))
            {
                //Filter[y+HalfSize] = (1.0 / (Math.Sqrt(2 * 22.0/7.0) * Segma)) * Math.Exp(-(double)(y*y) / (double)(2 * Segma * Segma)) ;
                Filter[y + HalfSize] = Math.Exp(-(double)(y * y) / (double)(2 * sigma * sigma)); // -> O(1)
                Sum1 += Filter[y + HalfSize]; // -> O(1)
            }
            for (int y = -HalfSize; y <= HalfSize; y++)   // -> O(HalfSize (F/2))
            {
                Filter[y + HalfSize] /= Sum1;  // -> O(1)
            }

            //Filter Original Image Vertically:
            //=================================
            int ii, jj;  // -> O(1)
            RGBPixelD Sum;  // -> O(1)
            RGBPixel Item1;  // -> O(1)
            RGBPixelD Item2;  // -> O(1)

            for (int j = 0; j < Width; j++) // -> O(W*H)
                for (int i = 0; i < Height; i++) // -> O(H * (HalfSize (F/2)))
                {
                    Sum.red = 0;  // -> O(1)
                    Sum.green = 0;  // -> O(1)
                    Sum.blue = 0;  // -> O(1)
                    for (int y = -HalfSize; y <= HalfSize; y++) // -> (HalfSize (F/2)
                    {
                        ii = i + y; // -> O(1)
                        if (ii >= 0 && ii < Height) // -> O(1)
                        {
                            Item1 = ImageMatrix[ii, j]; // -> O(1)
                            Sum.red += Filter[y + HalfSize] * Item1.red; // -> O(1)
                            Sum.green += Filter[y + HalfSize] * Item1.green; // -> O(1)
                            Sum.blue += Filter[y + HalfSize] * Item1.blue; // -> O(1)
                        }
                    }
                    VerFiltered[i, j] = Sum; // -> O(1)
                }

            //Filter Resulting Image Horizontally:
            //===================================
            for (int i = 0; i < Height; i++)  // -> O(W*H)
                for (int j = 0; j < Width; j++) // -> O(H * (HalfSize (F/2)))
                {
                    Sum.red = 0; // -> O(1)
                    Sum.green = 0; // -> O(1)
                    Sum.blue = 0; // -> O(1)
                    for (int x = -HalfSize; x <= HalfSize; x++) // -> (HalfSize (F/2)
                    {
                        jj = j + x; // -> O(1)
                        if (jj >= 0 && jj < Width) // -> O(1)
                        {
                            Item2 = VerFiltered[i, jj]; // -> O(1)
                            Sum.red += Filter[x + HalfSize] * Item2.red; // -> O(1)
                            Sum.green += Filter[x + HalfSize] * Item2.green; // -> O(1)
                            Sum.blue += Filter[x + HalfSize] * Item2.blue; // -> O(1)
                        }
                    }
                    Filtered[i, j].red = (byte)Sum.red; // -> O(1)
                    Filtered[i, j].green = (byte)Sum.green; // -> O(1)
                    Filtered[i, j].blue = (byte)Sum.blue; // -> O(1)
                }


            return Filtered; // -> O(1)
        }
    }
}
