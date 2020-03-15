namespace HW3_Delta_based_control_variate
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxanti = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labeltimer = new System.Windows.Forms.Label();
            this.checkBoxdeltaCV = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelS0
            // 
            this.labelS0.AutoSize = true;
            this.labelS0.Location = new System.Drawing.Point(61, 60);
            this.labelS0.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelS0.Name = "labelS0";
            this.labelS0.Size = new System.Drawing.Size(105, 25);
            this.labelS0.TabIndex = 0;
            this.labelS0.Text = "SpotPrice";
            // 
            // textBoxS0
            // 
            this.textBoxS0.Location = new System.Drawing.Point(196, 56);
            this.textBoxS0.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxS0.Name = "textBoxS0";
            this.textBoxS0.Size = new System.Drawing.Size(196, 31);
            this.textBoxS0.TabIndex = 1;
            this.textBoxS0.TextChanged += new System.EventHandler(this.textBoxS0_TextChanged);
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Location = new System.Drawing.Point(50, 112);
            this.labelK.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(116, 25);
            this.labelK.TabIndex = 2;
            this.labelK.Text = "StrikePrice";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(196, 113);
            this.textBoxK.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(196, 31);
            this.textBoxK.TabIndex = 3;
            this.textBoxK.TextChanged += new System.EventHandler(this.textBoxK_TextChanged);
            // 
            // labelr
            // 
            this.labelr.AutoSize = true;
            this.labelr.Location = new System.Drawing.Point(115, 175);
            this.labelr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelr.Name = "labelr";
            this.labelr.Size = new System.Drawing.Size(51, 25);
            this.labelr.TabIndex = 4;
            this.labelr.Text = "Drift";
            // 
            // textBoxr
            // 
            this.textBoxr.Location = new System.Drawing.Point(196, 169);
            this.textBoxr.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxr.Name = "textBoxr";
            this.textBoxr.Size = new System.Drawing.Size(196, 31);
            this.textBoxr.TabIndex = 5;
            this.textBoxr.TextChanged += new System.EventHandler(this.textBoxr_TextChanged);
            // 
            // labelTenor
            // 
            this.labelTenor.AutoSize = true;
            this.labelTenor.Location = new System.Drawing.Point(98, 224);
            this.labelTenor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTenor.Name = "labelTenor";
            this.labelTenor.Size = new System.Drawing.Size(68, 25);
            this.labelTenor.TabIndex = 6;
            this.labelTenor.Text = "Tenor";
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(196, 226);
            this.textBoxT.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(196, 31);
            this.textBoxT.TabIndex = 7;
            this.textBoxT.TextChanged += new System.EventHandler(this.textBoxT_TextChanged);
            // 
            // labelVolatility
            // 
            this.labelVolatility.AutoSize = true;
            this.labelVolatility.Location = new System.Drawing.Point(73, 282);
            this.labelVolatility.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVolatility.Name = "labelVolatility";
            this.labelVolatility.Size = new System.Drawing.Size(93, 25);
            this.labelVolatility.TabIndex = 8;
            this.labelVolatility.Text = "Volatility";
            // 
            // textBoxVolatility
            // 
            this.textBoxVolatility.Location = new System.Drawing.Point(196, 282);
            this.textBoxVolatility.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxVolatility.Name = "textBoxVolatility";
            this.textBoxVolatility.Size = new System.Drawing.Size(196, 31);
            this.textBoxVolatility.TabIndex = 9;
            this.textBoxVolatility.TextChanged += new System.EventHandler(this.textBoxVolatility_TextChanged);
            // 
            // textBoxTrials
            // 
            this.textBoxTrials.Location = new System.Drawing.Point(196, 337);
            this.textBoxTrials.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxTrials.Name = "textBoxTrials";
            this.textBoxTrials.Size = new System.Drawing.Size(196, 31);
            this.textBoxTrials.TabIndex = 10;
            this.textBoxTrials.TextChanged += new System.EventHandler(this.textBoxTrials_TextChanged);
            // 
            // labelTrial
            // 
            this.labelTrial.AutoSize = true;
            this.labelTrial.Location = new System.Drawing.Point(31, 337);
            this.labelTrial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTrial.Name = "labelTrial";
            this.labelTrial.Size = new System.Drawing.Size(135, 25);
            this.labelTrial.TabIndex = 11;
            this.labelTrial.Text = "Trial Number";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(99, 393);
            this.labelSteps.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(67, 25);
            this.labelSteps.TabIndex = 12;
            this.labelSteps.Text = "Steps";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(196, 393);
            this.textBoxStep.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(196, 31);
            this.textBoxStep.TabIndex = 13;
            this.textBoxStep.TextChanged += new System.EventHandler(this.textBoxStep_TextChanged);
            // 
            // radioButtoncall
            // 
            this.radioButtoncall.AutoSize = true;
            this.radioButtoncall.Location = new System.Drawing.Point(208, 448);
            this.radioButtoncall.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtoncall.Name = "radioButtoncall";
            this.radioButtoncall.Size = new System.Drawing.Size(80, 29);
            this.radioButtoncall.TabIndex = 14;
            this.radioButtoncall.TabStop = true;
            this.radioButtoncall.Text = "Call";
            this.radioButtoncall.UseVisualStyleBackColor = true;
            // 
            // radioButtonput
            // 
            this.radioButtonput.AutoSize = true;
            this.radioButtonput.Location = new System.Drawing.Point(317, 448);
            this.radioButtonput.Margin = new System.Windows.Forms.Padding(6);
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
            this.labeloptionprice.Location = new System.Drawing.Point(464, 57);
            this.labeloptionprice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeloptionprice.Name = "labeloptionprice";
            this.labeloptionprice.Size = new System.Drawing.Size(136, 25);
            this.labeloptionprice.TabIndex = 16;
            this.labeloptionprice.Text = "Option Price:";
            // 
            // labeldelta
            // 
            this.labeldelta.AutoSize = true;
            this.labeldelta.Location = new System.Drawing.Point(532, 142);
            this.labeldelta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeldelta.Name = "labeldelta";
            this.labeldelta.Size = new System.Drawing.Size(68, 25);
            this.labeldelta.TabIndex = 17;
            this.labeldelta.Text = "Delta:";
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(508, 194);
            this.labelGamma.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(92, 25);
            this.labelGamma.TabIndex = 18;
            this.labelGamma.Text = "Gamma:";
            // 
            // labelVega
            // 
            this.labelVega.AutoSize = true;
            this.labelVega.Location = new System.Drawing.Point(532, 243);
            this.labelVega.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVega.Name = "labelVega";
            this.labelVega.Size = new System.Drawing.Size(68, 25);
            this.labelVega.TabIndex = 19;
            this.labelVega.Text = "Vega:";
            // 
            // labelTheta
            // 
            this.labelTheta.AutoSize = true;
            this.labelTheta.Location = new System.Drawing.Point(527, 299);
            this.labelTheta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTheta.Name = "labelTheta";
            this.labelTheta.Size = new System.Drawing.Size(73, 25);
            this.labelTheta.TabIndex = 20;
            this.labelTheta.Text = "Theta:";
            // 
            // labelsderror
            // 
            this.labelsderror.AutoSize = true;
            this.labelsderror.Location = new System.Drawing.Point(442, 414);
            this.labelsderror.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelsderror.Name = "labelsderror";
            this.labelsderror.Size = new System.Drawing.Size(158, 25);
            this.labelsderror.TabIndex = 21;
            this.labelsderror.Text = "Standard Error:";
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(523, 552);
            this.buttonSimulate.Margin = new System.Windows.Forms.Padding(6);
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
            this.label1.Location = new System.Drawing.Point(652, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(652, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(652, 243);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(657, 414);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 25);
            this.label7.TabIndex = 28;
            // 
            // labelRho
            // 
            this.labelRho.AutoSize = true;
            this.labelRho.Location = new System.Drawing.Point(543, 355);
            this.labelRho.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRho.Name = "labelRho";
            this.labelRho.Size = new System.Drawing.Size(57, 25);
            this.labelRho.TabIndex = 29;
            this.labelRho.Text = "Rho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(652, 355);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(464, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Greeks:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 25);
            this.label9.TabIndex = 33;
            this.label9.Text = "Call or Put ?";
            // 
            // checkBoxanti
            // 
            this.checkBoxanti.AutoSize = true;
            this.checkBoxanti.Location = new System.Drawing.Point(41, 506);
            this.checkBoxanti.Name = "checkBoxanti";
            this.checkBoxanti.Size = new System.Drawing.Size(358, 29);
            this.checkBoxanti.TabIndex = 34;
            this.checkBoxanti.Text = "Use antithetic variance reduction";
            this.checkBoxanti.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(535, 463);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 25);
            this.label10.TabIndex = 35;
            this.label10.Text = "Time:";
            // 
            // labeltimer
            // 
            this.labeltimer.AutoSize = true;
            this.labeltimer.Location = new System.Drawing.Point(657, 462);
            this.labeltimer.Name = "labeltimer";
            this.labeltimer.Size = new System.Drawing.Size(0, 25);
            this.labeltimer.TabIndex = 36;
            // 
            // checkBoxdeltaCV
            // 
            this.checkBoxdeltaCV.AutoSize = true;
            this.checkBoxdeltaCV.Location = new System.Drawing.Point(41, 553);
            this.checkBoxdeltaCV.Name = "checkBoxdeltaCV";
            this.checkBoxdeltaCV.Size = new System.Drawing.Size(342, 29);
            this.checkBoxdeltaCV.TabIndex = 37;
            this.checkBoxdeltaCV.Text = "Use delta based control variate";
            this.checkBoxdeltaCV.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 705);
            this.Controls.Add(this.checkBoxdeltaCV);
            this.Controls.Add(this.labeltimer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxanti);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
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
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxanti;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labeltimer;
        private System.Windows.Forms.CheckBox checkBoxdeltaCV;
    }
}

