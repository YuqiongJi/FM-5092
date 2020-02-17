namespace HW1_Montlecarlo
{
    partial class Form1
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
            this.labelS0 = new System.Windows.Forms.Label();
            this.textBoxS0 = new System.Windows.Forms.TextBox();
            this.labelK = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.labelr = new System.Windows.Forms.Label();
            this.textBoxr = new System.Windows.Forms.TextBox();
            this.labelTenor = new System.Windows.Forms.Label();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.labelVolatility = new System.Windows.Forms.Label();
            this.textBoxVolatility = new System.Windows.Forms.TextBox();
            this.textBoxTrials = new System.Windows.Forms.TextBox();
            this.labelTrial = new System.Windows.Forms.Label();
            this.labelSteps = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.radioButtoncall = new System.Windows.Forms.RadioButton();
            this.radioButtonput = new System.Windows.Forms.RadioButton();
            this.labeloptionprice = new System.Windows.Forms.Label();
            this.labeldelta = new System.Windows.Forms.Label();
            this.labelGamma = new System.Windows.Forms.Label();
            this.labelVega = new System.Windows.Forms.Label();
            this.labelTheta = new System.Windows.Forms.Label();
            this.labelsderror = new System.Windows.Forms.Label();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRho = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelS0
            // 
            this.labelS0.AutoSize = true;
            this.labelS0.Location = new System.Drawing.Point(50, 62);
            this.labelS0.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelS0.Name = "labelS0";
            this.labelS0.Size = new System.Drawing.Size(105, 25);
            this.labelS0.TabIndex = 0;
            this.labelS0.Text = "SpotPrice";
            // 
            // textBoxS0
            // 
            this.textBoxS0.Location = new System.Drawing.Point(196, 56);
            this.textBoxS0.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxS0.Name = "textBoxS0";
            this.textBoxS0.Size = new System.Drawing.Size(196, 31);
            this.textBoxS0.TabIndex = 1;
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Location = new System.Drawing.Point(56, 113);
            this.labelK.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(116, 25);
            this.labelK.TabIndex = 2;
            this.labelK.Text = "StrikePrice";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(196, 113);
            this.textBoxK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(196, 31);
            this.textBoxK.TabIndex = 3;
            // 
            // labelr
            // 
            this.labelr.AutoSize = true;
            this.labelr.Location = new System.Drawing.Point(56, 183);
            this.labelr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelr.Name = "labelr";
            this.labelr.Size = new System.Drawing.Size(51, 25);
            this.labelr.TabIndex = 4;
            this.labelr.Text = "Drift";
            // 
            // textBoxr
            // 
            this.textBoxr.Location = new System.Drawing.Point(196, 169);
            this.textBoxr.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxr.Name = "textBoxr";
            this.textBoxr.Size = new System.Drawing.Size(196, 31);
            this.textBoxr.TabIndex = 5;
            // 
            // labelTenor
            // 
            this.labelTenor.AutoSize = true;
            this.labelTenor.Location = new System.Drawing.Point(56, 240);
            this.labelTenor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTenor.Name = "labelTenor";
            this.labelTenor.Size = new System.Drawing.Size(68, 25);
            this.labelTenor.TabIndex = 6;
            this.labelTenor.Text = "Tenor";
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(196, 240);
            this.textBoxT.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(196, 31);
            this.textBoxT.TabIndex = 7;
            // 
            // labelVolatility
            // 
            this.labelVolatility.AutoSize = true;
            this.labelVolatility.Location = new System.Drawing.Point(50, 325);
            this.labelVolatility.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVolatility.Name = "labelVolatility";
            this.labelVolatility.Size = new System.Drawing.Size(93, 25);
            this.labelVolatility.TabIndex = 8;
            this.labelVolatility.Text = "Volatility";
            // 
            // textBoxVolatility
            // 
            this.textBoxVolatility.Location = new System.Drawing.Point(196, 312);
            this.textBoxVolatility.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxVolatility.Name = "textBoxVolatility";
            this.textBoxVolatility.Size = new System.Drawing.Size(196, 31);
            this.textBoxVolatility.TabIndex = 9;
            // 
            // textBoxTrials
            // 
            this.textBoxTrials.Location = new System.Drawing.Point(196, 383);
            this.textBoxTrials.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxTrials.Name = "textBoxTrials";
            this.textBoxTrials.Size = new System.Drawing.Size(196, 31);
            this.textBoxTrials.TabIndex = 10;
            // 
            // labelTrial
            // 
            this.labelTrial.AutoSize = true;
            this.labelTrial.Location = new System.Drawing.Point(50, 396);
            this.labelTrial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTrial.Name = "labelTrial";
            this.labelTrial.Size = new System.Drawing.Size(135, 25);
            this.labelTrial.TabIndex = 11;
            this.labelTrial.Text = "Trial Number";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(56, 448);
            this.labelSteps.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(67, 25);
            this.labelSteps.TabIndex = 12;
            this.labelSteps.Text = "Steps";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(196, 448);
            this.textBoxStep.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(196, 31);
            this.textBoxStep.TabIndex = 13;
            // 
            // radioButtoncall
            // 
            this.radioButtoncall.AutoSize = true;
            this.radioButtoncall.Location = new System.Drawing.Point(62, 525);
            this.radioButtoncall.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.radioButtoncall.Name = "radioButtoncall";
            this.radioButtoncall.Size = new System.Drawing.Size(80, 29);
            this.radioButtoncall.TabIndex = 14;
            this.radioButtoncall.TabStop = true;
            this.radioButtoncall.Text = "Call";
            this.radioButtoncall.UseVisualStyleBackColor = true;
            this.radioButtoncall.CheckedChanged += new System.EventHandler(this.radioButtoncall_CheckedChanged);
            // 
            // radioButtonput
            // 
            this.radioButtonput.AutoSize = true;
            this.radioButtonput.Location = new System.Drawing.Point(196, 525);
            this.radioButtonput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.radioButtonput.Name = "radioButtonput";
            this.radioButtonput.Size = new System.Drawing.Size(75, 29);
            this.radioButtonput.TabIndex = 15;
            this.radioButtonput.TabStop = true;
            this.radioButtonput.Text = "Put";
            this.radioButtonput.UseVisualStyleBackColor = true;
            // 
            // labeloptionprice
            // 
            this.labeloptionprice.AutoSize = true;
            this.labeloptionprice.Location = new System.Drawing.Point(518, 60);
            this.labeloptionprice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeloptionprice.Name = "labeloptionprice";
            this.labeloptionprice.Size = new System.Drawing.Size(136, 25);
            this.labeloptionprice.TabIndex = 16;
            this.labeloptionprice.Text = "Option Price:";
            // 
            // labeldelta
            // 
            this.labeldelta.AutoSize = true;
            this.labeldelta.Location = new System.Drawing.Point(518, 113);
            this.labeldelta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeldelta.Name = "labeldelta";
            this.labeldelta.Size = new System.Drawing.Size(68, 25);
            this.labeldelta.TabIndex = 17;
            this.labeldelta.Text = "Delta:";
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(524, 169);
            this.labelGamma.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(92, 25);
            this.labelGamma.TabIndex = 18;
            this.labelGamma.Text = "Gamma:";
            // 
            // labelVega
            // 
            this.labelVega.AutoSize = true;
            this.labelVega.Location = new System.Drawing.Point(524, 240);
            this.labelVega.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVega.Name = "labelVega";
            this.labelVega.Size = new System.Drawing.Size(68, 25);
            this.labelVega.TabIndex = 19;
            this.labelVega.Text = "Vega:";
            // 
            // labelTheta
            // 
            this.labelTheta.AutoSize = true;
            this.labelTheta.Location = new System.Drawing.Point(524, 312);
            this.labelTheta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTheta.Name = "labelTheta";
            this.labelTheta.Size = new System.Drawing.Size(73, 25);
            this.labelTheta.TabIndex = 20;
            this.labelTheta.Text = "Theta:";
            // 
            // labelsderror
            // 
            this.labelsderror.AutoSize = true;
            this.labelsderror.Location = new System.Drawing.Point(524, 417);
            this.labelsderror.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelsderror.Name = "labelsderror";
            this.labelsderror.Size = new System.Drawing.Size(158, 25);
            this.labelsderror.TabIndex = 21;
            this.labelsderror.Text = "Standard Error:";
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(530, 487);
            this.buttonSimulate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(296, 110);
            this.buttonSimulate.TabIndex = 22;
            this.buttonSimulate.Text = "Simulate";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(706, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(712, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(712, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(718, 312);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(706, 417);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 25);
            this.label7.TabIndex = 28;
            // 
            // labelRho
            // 
            this.labelRho.AutoSize = true;
            this.labelRho.Location = new System.Drawing.Point(530, 358);
            this.labelRho.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRho.Name = "labelRho";
            this.labelRho.Size = new System.Drawing.Size(57, 25);
            this.labelRho.TabIndex = 29;
            this.labelRho.Text = "Rho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(706, 358);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 644);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelRho);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.labelsderror);
            this.Controls.Add(this.labelTheta);
            this.Controls.Add(this.labelVega);
            this.Controls.Add(this.labelGamma);
            this.Controls.Add(this.labeldelta);
            this.Controls.Add(this.labeloptionprice);
            this.Controls.Add(this.radioButtonput);
            this.Controls.Add(this.radioButtoncall);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.labelSteps);
            this.Controls.Add(this.labelTrial);
            this.Controls.Add(this.textBoxTrials);
            this.Controls.Add(this.textBoxVolatility);
            this.Controls.Add(this.labelVolatility);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.labelTenor);
            this.Controls.Add(this.textBoxr);
            this.Controls.Add(this.labelr);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.textBoxS0);
            this.Controls.Add(this.labelS0);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Montle Carlo Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelS0;
        private System.Windows.Forms.TextBox textBoxS0;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label labelr;
        private System.Windows.Forms.TextBox textBoxr;
        private System.Windows.Forms.Label labelTenor;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.Label labelVolatility;
        private System.Windows.Forms.TextBox textBoxVolatility;
        private System.Windows.Forms.TextBox textBoxTrials;
        private System.Windows.Forms.Label labelTrial;
        private System.Windows.Forms.Label labelSteps;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.RadioButton radioButtoncall;
        private System.Windows.Forms.RadioButton radioButtonput;
        private System.Windows.Forms.Label labeloptionprice;
        private System.Windows.Forms.Label labeldelta;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Label labelVega;
        private System.Windows.Forms.Label labelTheta;
        private System.Windows.Forms.Label labelsderror;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelRho;
        private System.Windows.Forms.Label label6;
    }
}