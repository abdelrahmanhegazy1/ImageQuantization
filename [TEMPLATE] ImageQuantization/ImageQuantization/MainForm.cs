using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageQuantization
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // intialization the tools
            ClusterK.Value = 0; // -> O(1)
            FloyedFactorNum.Value = 1;  // -> O(1)
            NonFloyedNum.Value = 1;  // -> O(1)
            MedianNum.Value = 1;  // -> O(1)
            SurfaceNum.Value = 1;  // -> O(1)
            txtMST.Text = null;  // -> O(1)
            txtDisColor.Text = null;  // -> O(1)
            txtGaussSigma.Text = "1";  // -> O(1)
            nudMaskSize.Value = 3;  // -> O(1)
            pictureBox2.Image = null;  // -> O(1)
            TimeLable.Text = "0 Ms";  // -> O(1)
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  // -> O(1)
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // -> O(1)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;  // -> O(1)
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);  // -> O(W*H)
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1, 0); // -> O(W*H)
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();   // -> O(1)
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();  // -> O(1)
        }

        private void btnQuantize_Click(object sender, EventArgs e)
        {
            long before = System.Environment.TickCount;          // get the current time in miliseconds  // -> O(1)
            int K = (int)ClusterK.Value;  // -> O(1)
            txtDisColor.Text = ImageAnalytics.Find_Distinct_Color(ImageMatrix).ToString();  // -> O(W*H)
            txtMST.Text = (Math.Round(ImageAnalytics.MinimumSpanningTree(), 2)).ToString(); // -> O(E Log V)
            DetectNumOfClusters x = new DetectNumOfClusters(ImageAnalytics.edges);  // -> O(E*V)
            if (K == 0) K = x.k; // -> O(1)
            QuantizeImage.Extract_K_Cluster(K); // -> O(K*D)
            QuantizeImage.Find_K_Cluster(); // -> O(D)
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2, 1); //O(N^2) where N is the height or the weight of image
            ClusterK.Value = K;                       // print the number of cluster if changed // -> O(1)
            long after = System.Environment.TickCount; // get the current time // -> O(1)
            double total = after - before;             // Calculate the taken time // -> O(1)
            total /= 60000;                            // convert miliseconds to minutes // -> O(1)
            total = Math.Round(total, 3);               // Round the Minutes to three decimal digits // -> O(1)
            TimeLable.Text = total.ToString() + " M (s)"; // -> O(1)
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            double sigma = double.Parse(txtGaussSigma.Text); // -> O(1)
            int maskSize = (int)nudMaskSize.Value; // -> O(1)
            RGBPixel[,] ImageFilltered = ImageMatrix; // -> O(1)
            ImageFilltered = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma); //->  O(W*H)
            ImageOperations.DisplayImage(ImageFilltered, pictureBox2, 0); //->  O(W*H)
        }

        private void FloyedBtn_Click(object sender, EventArgs e)
        {
            int factor = (int)FloyedFactorNum.Value;  // -> O(1)
            RGBPixel[,] ImageFilltered;  // -> O(1)
            ImageFilltered = FloyedDither.Floyed_Dithering(factor, ImageMatrix);  // ->>O(H * W)
            ImageOperations.DisplayImage(ImageFilltered, pictureBox2, 0);  // ->>O(H * W)
        }

        private void MedianBtn_Click(object sender, EventArgs e)
        {
            Bitmap orgPic = new Bitmap(this.pictureBox1.Image); // -> O(1)
            Bitmap tmpPic = new Bitmap(this.pictureBox1.Image); // -> O(1)
            int Factor = (int)MedianNum.Value; // -> O(1)
            MedianFilter.Median_Filter(orgPic, Factor, ref tmpPic); //  [-> O(N Log N))]
            pictureBox2.Image = tmpPic; // -> O(1)
        }

        private void SurfaceBlurBtn_Click(object sender, EventArgs e)
        {
            Bitmap bitMapO = new Bitmap(this.pictureBox1.Image); // -> O(1)
            Bitmap bitMapF = new Bitmap(this.pictureBox1.Image); // -> O(1)
            int Factor = (int)SurfaceNum.Value; // -> O(1)
            GaussianBlur GB = new GaussianBlur(bitMapO);  // ->>O(H * W)
            bitMapF = GB.Process(Factor);  // ->>O(H * W)
            pictureBox2.Image = bitMapF; // -> O(1)
        }

        private void NonFloyedBtn_Click(object sender, EventArgs e)
        {
            int factor = (int)NonFloyedNum.Value; // -> O(1)
            RGBPixel[,] ImageFilltered; // -> O(1)
            ImageFilltered = AtkinsonDither.Atkinson_Dithering(ImageMatrix, factor); // ->>O(H * W)
            ImageOperations.DisplayImage(ImageFilltered, pictureBox2, 0); // -> O(1)
        }
    }
}