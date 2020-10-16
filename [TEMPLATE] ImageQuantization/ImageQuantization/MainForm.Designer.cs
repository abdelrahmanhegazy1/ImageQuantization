namespace ImageQuantization
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuantize = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.ClusterK = new System.Windows.Forms.NumericUpDown();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDisColor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMST = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGaussSigma = new System.Windows.Forms.TextBox();
            this.nudMaskSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGaussSmooth = new System.Windows.Forms.Button();
            this.FloyedBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.MedianBtn = new System.Windows.Forms.Button();
            this.SurfaceBlurBtn = new System.Windows.Forms.Button();
            this.FloyedFactorNum = new System.Windows.Forms.NumericUpDown();
            this.MedianNum = new System.Windows.Forms.NumericUpDown();
            this.SurfaceNum = new System.Windows.Forms.NumericUpDown();
            this.NonFloyedBtn = new System.Windows.Forms.Button();
            this.NonFloyedNum = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.TimeLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClusterK)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FloyedFactorNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedianNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurfaceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonFloyedNum)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(416, 368);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(12, 430);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(82, 62);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(605, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantized Image";
            // 
            // btnQuantize
            // 
            this.btnQuantize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantize.Location = new System.Drawing.Point(423, 430);
            this.btnQuantize.Name = "btnQuantize";
            this.btnQuantize.Size = new System.Drawing.Size(106, 62);
            this.btnQuantize.TabIndex = 5;
            this.btnQuantize.Text = "Quantize";
            this.btnQuantize.UseVisualStyleBackColor = true;
            this.btnQuantize.Click += new System.EventHandler(this.btnQuantize_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(591, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 9;
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(160, 465);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(57, 23);
            this.txtHeight.TabIndex = 8;
            // 
            // ClusterK
            // 
            this.ClusterK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClusterK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClusterK.Location = new System.Drawing.Point(929, 468);
            this.ClusterK.Maximum = new decimal(new int[] {
            200000000,
            0,
            0,
            0});
            this.ClusterK.Name = "ClusterK";
            this.ClusterK.Size = new System.Drawing.Size(57, 23);
            this.ClusterK.TabIndex = 10;
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(160, 430);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(57, 23);
            this.txtWidth.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(108, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(104, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 371);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(471, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 371);
            this.panel2.TabIndex = 16;
            // 
            // txtDisColor
            // 
            this.txtDisColor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisColor.Location = new System.Drawing.Point(339, 430);
            this.txtDisColor.Name = "txtDisColor";
            this.txtDisColor.ReadOnly = true;
            this.txtDisColor.Size = new System.Drawing.Size(67, 23);
            this.txtDisColor.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(232, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Distinct Colors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(232, 472);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "MST Sum :";
            // 
            // txtMST
            // 
            this.txtMST.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMST.Location = new System.Drawing.Point(339, 469);
            this.txtMST.Name = "txtMST";
            this.txtMST.ReadOnly = true;
            this.txtMST.Size = new System.Drawing.Size(67, 23);
            this.txtMST.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(880, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Clusters (optional)";
            // 
            // txtGaussSigma
            // 
            this.txtGaussSigma.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGaussSigma.Location = new System.Drawing.Point(817, 453);
            this.txtGaussSigma.Name = "txtGaussSigma";
            this.txtGaussSigma.Size = new System.Drawing.Size(57, 23);
            this.txtGaussSigma.TabIndex = 27;
            this.txtGaussSigma.Text = "1";
            // 
            // nudMaskSize
            // 
            this.nudMaskSize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaskSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaskSize.Location = new System.Drawing.Point(817, 423);
            this.nudMaskSize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudMaskSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMaskSize.Name = "nudMaskSize";
            this.nudMaskSize.Size = new System.Drawing.Size(57, 23);
            this.nudMaskSize.TabIndex = 26;
            this.nudMaskSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(723, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Gauss Sigma";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(720, 423);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Mask Size";
            // 
            // btnGaussSmooth
            // 
            this.btnGaussSmooth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaussSmooth.Location = new System.Drawing.Point(539, 430);
            this.btnGaussSmooth.Name = "btnGaussSmooth";
            this.btnGaussSmooth.Size = new System.Drawing.Size(82, 62);
            this.btnGaussSmooth.TabIndex = 23;
            this.btnGaussSmooth.Text = "Gauss Smooth";
            this.btnGaussSmooth.UseVisualStyleBackColor = true;
            this.btnGaussSmooth.Click += new System.EventHandler(this.btnGaussSmooth_Click);
            // 
            // FloyedBtn
            // 
            this.FloyedBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FloyedBtn.Location = new System.Drawing.Point(629, 430);
            this.FloyedBtn.Name = "FloyedBtn";
            this.FloyedBtn.Size = new System.Drawing.Size(82, 62);
            this.FloyedBtn.TabIndex = 28;
            this.FloyedBtn.Text = "Floyed";
            this.FloyedBtn.UseVisualStyleBackColor = true;
            this.FloyedBtn.Click += new System.EventHandler(this.FloyedBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(721, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "Floyed Factor";
            // 
            // MedianBtn
            // 
            this.MedianBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MedianBtn.Location = new System.Drawing.Point(908, 222);
            this.MedianBtn.Name = "MedianBtn";
            this.MedianBtn.Size = new System.Drawing.Size(96, 56);
            this.MedianBtn.TabIndex = 31;
            this.MedianBtn.Text = "Median Filter";
            this.MedianBtn.UseVisualStyleBackColor = true;
            this.MedianBtn.Click += new System.EventHandler(this.MedianBtn_Click);
            // 
            // SurfaceBlurBtn
            // 
            this.SurfaceBlurBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SurfaceBlurBtn.Location = new System.Drawing.Point(908, 326);
            this.SurfaceBlurBtn.Name = "SurfaceBlurBtn";
            this.SurfaceBlurBtn.Size = new System.Drawing.Size(96, 53);
            this.SurfaceBlurBtn.TabIndex = 32;
            this.SurfaceBlurBtn.Text = "Surface Blur";
            this.SurfaceBlurBtn.UseVisualStyleBackColor = true;
            this.SurfaceBlurBtn.Click += new System.EventHandler(this.SurfaceBlurBtn_Click);
            // 
            // FloyedFactorNum
            // 
            this.FloyedFactorNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FloyedFactorNum.Location = new System.Drawing.Point(821, 485);
            this.FloyedFactorNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.FloyedFactorNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FloyedFactorNum.Name = "FloyedFactorNum";
            this.FloyedFactorNum.Size = new System.Drawing.Size(57, 23);
            this.FloyedFactorNum.TabIndex = 33;
            this.FloyedFactorNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MedianNum
            // 
            this.MedianNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MedianNum.Location = new System.Drawing.Point(929, 289);
            this.MedianNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.MedianNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MedianNum.Name = "MedianNum";
            this.MedianNum.Size = new System.Drawing.Size(57, 23);
            this.MedianNum.TabIndex = 34;
            this.MedianNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SurfaceNum
            // 
            this.SurfaceNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SurfaceNum.Location = new System.Drawing.Point(929, 389);
            this.SurfaceNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.SurfaceNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SurfaceNum.Name = "SurfaceNum";
            this.SurfaceNum.Size = new System.Drawing.Size(57, 23);
            this.SurfaceNum.TabIndex = 35;
            this.SurfaceNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NonFloyedBtn
            // 
            this.NonFloyedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonFloyedBtn.Location = new System.Drawing.Point(909, 104);
            this.NonFloyedBtn.Name = "NonFloyedBtn";
            this.NonFloyedBtn.Size = new System.Drawing.Size(96, 56);
            this.NonFloyedBtn.TabIndex = 36;
            this.NonFloyedBtn.Text = "Atkinson";
            this.NonFloyedBtn.UseVisualStyleBackColor = true;
            this.NonFloyedBtn.Click += new System.EventHandler(this.NonFloyedBtn_Click);
            // 
            // NonFloyedNum
            // 
            this.NonFloyedNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonFloyedNum.Location = new System.Drawing.Point(929, 175);
            this.NonFloyedNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NonFloyedNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NonFloyedNum.Name = "NonFloyedNum";
            this.NonFloyedNum.Size = new System.Drawing.Size(57, 23);
            this.NonFloyedNum.TabIndex = 37;
            this.NonFloyedNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(892, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "Quanization Time";
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLable.Location = new System.Drawing.Point(928, 60);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(38, 15);
            this.TimeLable.TabIndex = 39;
            this.TimeLable.Text = "0 Ms";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 514);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.NonFloyedNum);
            this.Controls.Add(this.NonFloyedBtn);
            this.Controls.Add(this.SurfaceNum);
            this.Controls.Add(this.MedianNum);
            this.Controls.Add(this.FloyedFactorNum);
            this.Controls.Add(this.SurfaceBlurBtn);
            this.Controls.Add(this.MedianBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FloyedBtn);
            this.Controls.Add(this.txtGaussSigma);
            this.Controls.Add(this.nudMaskSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGaussSmooth);
            this.Controls.Add(this.txtMST);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDisColor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.ClusterK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuantize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Name = "MainForm";
            this.Text = "Image Quantization...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClusterK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FloyedFactorNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedianNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurfaceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonFloyedNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuantize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.NumericUpDown ClusterK;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDisColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMST;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGaussSigma;
        private System.Windows.Forms.NumericUpDown nudMaskSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGaussSmooth;
        private System.Windows.Forms.Button FloyedBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button MedianBtn;
        private System.Windows.Forms.Button SurfaceBlurBtn;
        private System.Windows.Forms.NumericUpDown FloyedFactorNum;
        private System.Windows.Forms.NumericUpDown MedianNum;
        private System.Windows.Forms.NumericUpDown SurfaceNum;
        private System.Windows.Forms.Button NonFloyedBtn;
        private System.Windows.Forms.NumericUpDown NonFloyedNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label TimeLable;
    }
}

