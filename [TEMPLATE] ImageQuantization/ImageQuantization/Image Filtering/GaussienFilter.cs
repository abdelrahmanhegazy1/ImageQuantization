using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageQuantization

{
    /// <summary>
    /// Smooth algorithm to reduce image noise and reduce detail.
    /// f  and g is defined as the volume of product of f and "shifted" g.
    ///  Box blure is the convolution of function f and weight w, but weight ,
    ///  Hortizontal and vertical lies within a square (box).
    ///  The nice property of the box blur is, 
    ///  that several passes (convolutions) with a box blur approximate one pass with a gaussian blur.
    /// </summary>

    public class GaussianBlur
    {
        //Class Data must be defined at constructor and set at runTime 
        private readonly int[] alpha; //O(1)
        private readonly int[] red;   //O(1)
        private readonly int[] green; //O(1)
        private readonly int[] blue; //O(1)
        private readonly int width; //O(1)
        private readonly int height; //O(1)
        // Number Of Segments To loop using Parallel.
        private readonly ParallelOptions pOptions = new ParallelOptions { MaxDegreeOfParallelism = 16 }; //O(1)
        /// <summary>
        ///  Set Data of class by set width and height of Image and set RGB in their arrays and alpha in an array
        /// </summary>
        /// <param name="image"></param>
        public GaussianBlur(Bitmap image) //O(H*W)
        {
            var rctangle = new Rectangle(0, 0, image.Width, image.Height);//O(1)
            var source = new int[rctangle.Width * rctangle.Height]; //O(1)
            var bits = image.LockBits(rctangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);//O(1)
            Marshal.Copy(bits.Scan0, source, 0, source.Length); //O(H*W)
            image.UnlockBits(bits); //O(1)

            width = image.Width;   //O(1)
            height = image.Height; //O(1)

            alpha = new int[width * height]; //O(1)
            red = new int[width * height];   //O(1)
            green = new int[width * height];  //O(1)
            blue = new int[width * height];   //O(1)

            Parallel.For(0, source.Length, pOptions, i => //O(W*H)/16 ->O(W*H)
            {
                alpha[i] = (int)((source[i] & 0xff000000) >> 24); //O(1)
                red[i] = (source[i] & 0xff0000) >> 16;    //O(1)
                green[i] = (source[i] & 0x00ff00) >> 8;   //O(1)
                blue[i] = (source[i] & 0x0000ff);         //O(1)
            });
        }
        /// <summary>
        /// this procedure sent values and receiving ready image, checking for values limtes and send image
        /// </summary>
        /// <param name="radial"> factor is input from user </param>
        /// <returns></returns>
        public Bitmap Process(int radial)//O(W*H)
        {
            var newAlpha = new int[width * height]; //O(1)
            var newRed = new int[width * height]; //O(1)
            var newGreen = new int[width * height]; //O(1)
            var newBlue = new int[width * height];  //O(1)
            var dest = new int[width * height];     //O(1)

            Parallel.Invoke(
                () => gaussBlur_4(alpha, newAlpha, radial), //O(W*H)
                () => gaussBlur_4(red, newRed, radial),      //O(W*H)
                () => gaussBlur_4(green, newGreen, radial), //O(W*H)
                () => gaussBlur_4(blue, newBlue, radial));  //O(W*H)

            Parallel.For(0, dest.Length, pOptions, i => //O(W*H)
            {
                if (newAlpha[i] > 255) newAlpha[i] = 255; //O(1)
                if (newRed[i] > 255) newRed[i] = 255;     //O(1)
                if (newGreen[i] > 255) newGreen[i] = 255; //O(1)
                if (newBlue[i] > 255) newBlue[i] = 255;   //O(1)

                if (newAlpha[i] < 0) newAlpha[i] = 0;    //O(1)
                if (newRed[i] < 0) newRed[i] = 0;       //O(1)
                if (newGreen[i] < 0) newGreen[i] = 0;   //O(1)
                if (newBlue[i] < 0) newBlue[i] = 0;    //O(1)

                dest[i] = (int)((uint)(newAlpha[i] << 24) | (uint)(newRed[i] << 16) | (uint)(newGreen[i] << 8) | (uint)newBlue[i]); //O(1)
            });

            var image = new Bitmap(width, height); //O(1)
            var rct = new Rectangle(0, 0, image.Width, image.Height); //O(1)
            var bits2 = image.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb); //O(1)
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length); //O(H*W)
            image.UnlockBits(bits2); //O(1)
            return image; //O(1)
        }

        /// <summary>
        /// this responsable for getting  box blur for one byte with three divided width blur.
        /// getting updating values in one byte array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="r"></param>
        private void gaussBlur_4(int[] source, int[] dest, int r) //O(W*H)
        {
            var bxs = boxesForGauss(r, 3); //O(1)
            boxBlur_4(source, dest, width, height, (bxs[0] - 1) / 2); //O(W*H)
            boxBlur_4(dest, source, width, height, (bxs[1] - 1) / 2); //O(W*H)
            boxBlur_4(source, dest, width, height, (bxs[2] - 1) / 2); //O(W*H)
        }
        /// <summary>
        /// this function convert the weight function into  constant smaller area (a square box) with larger radius.
        /// area  is almost equal to σ, while significant radius for gaussian is much larger
        /// it is (Constatnt Time) in our algorithm.
        /// </summary>
        /// <param name="sigma"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private int[] boxesForGauss(int sigma, int n) //O(N)
        {
            var wIdeal = Math.Sqrt((12 * sigma * sigma / n) + 1); //O(1) //best averaging filter width
            var wl = (int)Math.Floor(wIdeal); //O(1)
            if (wl % 2 == 0) //O(1)
                wl--; //O(1)
            var wu = wl + 2; //O(1)

            var mIdeal = (double)(12 * sigma * sigma - n * wl * wl - 4 * n * wl - 3 * n) / (-4 * wl - 4); //O(1)
            var m = Math.Round(mIdeal); //O(1)

            var sizes = new List<int>(); //O(1)
            for (var i = 0; i < n; i++) //O(N)
                sizes.Add(i < m ? wl : wu); //O(1)
            return sizes.ToArray(); //O(N)
        }

        /// <summary>
        /// this responsable for getting  box blur for one byte with specific width blur(divided into 3).
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="r"></param>
        private void boxBlur_4(int[] source, int[] dest, int w, int h, int r) //O(W*H)
        {
            for (var i = 0; i < source.Length; i++) //O(H*W)
                dest[i] = source[i]; //O(1)
            boxBlurH_4(dest, source, w, h, r); //O(W*H)
            boxBlurT_4(source, dest, w, h, r); //O(W*H)
        }

        /// <summary>
        /// WE HERE perform this equation for blur Height to updata cell by getting min y and sum it's value  
        /// we want to compute horizontal blur.
        /// We compute bh[i,j],bh[i,j+1],bh[i,j+2],.... But the neighboring values bh[i,j] 
        /// and bh[i,j+1] are almost the same. The only difference is in one left-most value 
        /// and one right-most value. So
        /// bh[i,j+1]=bh[i,j]+f[i,j+r+1]−f[i,j−r] .
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="r"></param>
        /// </summary>
        private void boxBlurH_4(int[] source, int[] dest, int w, int h, int r) //O(W*H)
        {
            var iar = (double)1 / (r + r + 1); //O(1)
            Parallel.For(0, h, pOptions, i => //O(W*r+ W*H)
            {
                var RowStart = i * w; //O(1)
                var li = RowStart; //O(1)
                var ri = RowStart + r; //O(1)
                var fv = source[RowStart]; //O(1)
                var lv = source[RowStart + w - 1]; //O(1)
                var val = (r + 1) * fv; //O(1)
                for (var j = 0; j < r; j++) //O(r)
                    val += source[RowStart + j]; //O(1)
                for (var j = 0; j <= r; j++)   //O(r)
                {
                    val += source[ri++] - fv; //O(1)
                    dest[RowStart++] = (int)Math.Round(val * iar); //O(1)
                }
                for (var j = r + 1; j < w - r; j++) //O(W)
                {
                    val += source[ri++] - dest[li++]; //O(1)
                    dest[RowStart++] = (int)Math.Round(val * iar); //O(1)
                }
                for (var j = w - r; j < w; j++) //O(W)
                {
                    val += lv - source[li++]; //O(1)
                    dest[RowStart++] = (int)Math.Round(val * iar); //O(1)
                }
            });
        }
        /// <summary>
        /// we get total blur for height as we get blur for width by equation
        /// bt[i+1,j]=bh[i,j]+f[i+r+1,j]−f[i-r,j] 
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="r"></param>
        /// </summary>
        private void boxBlurT_4(int[] source, int[] dest, int w, int h, int r) //O(W*H)
        {
            var iar = (double)1 / (r + r + 1);  //O(1)
            Parallel.For(0, w, pOptions, i => { //O(W*r+ W*H)
                var ti = i;  //O(1)
                var li = ti; //O(1)
                var ri = ti + r * w; //O(1)
                var fv = source[ti]; //O(1)
                var lv = source[ti + w * (h - 1)]; //O(1)
                var val = (r + 1) * fv;   //O(1)
                for (var j = 0; j < r; j++)  //O(r)
                    val += source[ti + j * w]; //O(1)
                for (var j = 0; j <= r; j++)
                { //O(r)
                    val += source[ri] - fv; //O(1)
                    dest[ti] = (int)Math.Round(val * iar); //O(1)
                    ri += w; //O(1)
                    ti += w; //O(1)
                }
                for (var j = r + 1; j < h - r; j++)
                {  //O(H)
                    val += source[ri] - source[li]; //O(1)
                    dest[ti] = (int)Math.Round(val * iar); //O(1)
                    li += w; //O(1)
                    ri += w; //O(1)
                    ti += w; //O(1)
                }
                for (var j = h - r; j < h; j++)
                { //O(H) 
                    val += lv - source[li]; //O(1)
                    dest[ti] = (int)Math.Round(val * iar); //O(1)
                    li += w; //O(1)
                    ti += w; //O(1)
                }
            });
        }

    }
}
