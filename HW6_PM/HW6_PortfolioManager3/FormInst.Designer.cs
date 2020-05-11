namespace HW6_PortfolioManager3
{
    partial class FormInst
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInstrumentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxExchange = new System.Windows.Forms.TextBox();
            this.textBoxStrike = new System.Windows.Forms.TextBox();
            this.textBoxTenor = new System.Windows.Forms.TextBox();
            this.comboBoxUnderlying = new System.Windows.Forms.ComboBox();
            this.radioButtonNeitherCallPut = new System.Windows.Forms.RadioButton();
            this.radioButtonCall = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRebate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxBarrier = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxBarrierType = new System.Windows.Forms.ComboBox();
            this.radioButtonPut = new System.Windows.Forms.RadioButton();
            this.comboBoxInstType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instrument Name:";
            // 
            // textBoxInstrumentName
            // 
            this.textBoxInstrumentName.Location = new System.Drawing.Point(215, 92);
            this.textBoxInstrumentName.Name = "textBoxInstrumentName";
            this.textBoxInstrumentName.Size = new System.Drawing.Size(285, 31);
            this.textBoxInstrumentName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exchange:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Underlying:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Strike:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tenor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Type:";
            // 
            // textBoxExchange
            // 
            this.textBoxExchange.Location = new System.Drawing.Point(215, 143);
            this.textBoxExchange.Name = "textBoxExchange";
            this.textBoxExchange.Size = new System.Drawing.Size(285, 31);
            this.textBoxExchange.TabIndex = 10;
            // 
            // textBoxStrike
            // 
            this.textBoxStrike.Location = new System.Drawing.Point(215, 240);
            this.textBoxStrike.Name = "textBoxStrike";
            this.textBoxStrike.Size = new System.Drawing.Size(285, 31);
            this.textBoxStrike.TabIndex = 11;
            // 
            // textBoxTenor
            // 
            this.textBoxTenor.Location = new System.Drawing.Point(215, 288);
            this.textBoxTenor.Name = "textBoxTenor";
            this.textBoxTenor.Size = new System.Drawing.Size(285, 31);
            this.textBoxTenor.TabIndex = 12;
            // 
            // comboBoxUnderlying
            // 
            this.comboBoxUnderlying.FormattingEnabled = true;
            this.comboBoxUnderlying.Location = new System.Drawing.Point(215, 192);
            this.comboBoxUnderlying.Name = "comboBoxUnderlying";
            this.comboBoxUnderlying.Size = new System.Drawing.Size(285, 33);
            this.comboBoxUnderlying.TabIndex = 13;
            this.comboBoxUnderlying.Click += new System.EventHandler(this.comboBoxUnderlying_Click);
            // 
            // radioButtonNeitherCallPut
            // 
            this.radioButtonNeitherCallPut.AutoSize = true;
            this.radioButtonNeitherCallPut.Location = new System.Drawing.Point(215, 338);
            this.radioButtonNeitherCallPut.Name = "radioButtonNeitherCallPut";
            this.radioButtonNeitherCallPut.Size = new System.Drawing.Size(218, 29);
            this.radioButtonNeitherCallPut.TabIndex = 15;
            this.radioButtonNeitherCallPut.TabStop = true;
            this.radioButtonNeitherCallPut.Text = "Neither Call or Put";
            this.radioButtonNeitherCallPut.UseVisualStyleBackColor = true;
            // 
            // radioButtonCall
            // 
            this.radioButtonCall.AutoSize = true;
            this.radioButtonCall.Location = new System.Drawing.Point(215, 374);
            this.radioButtonCall.Name = "radioButtonCall";
            this.radioButtonCall.Size = new System.Drawing.Size(80, 29);
            this.radioButtonCall.TabIndex = 16;
            this.radioButtonCall.TabStop = true;
            this.radioButtonCall.Text = "Call";
            this.radioButtonCall.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(149, 593);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(108, 39);
            this.buttonOK.TabIndex = 18;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(308, 590);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 44);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rebate:";
            // 
            // textBoxRebate
            // 
            this.textBoxRebate.Location = new System.Drawing.Point(215, 445);
            this.textBoxRebate.Name = "textBoxRebate";
            this.textBoxRebate.Size = new System.Drawing.Size(285, 31);
            this.textBoxRebate.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 493);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Barrier:";
            // 
            // textBoxBarrier
            // 
            this.textBoxBarrier.Location = new System.Drawing.Point(215, 493);
            this.textBoxBarrier.Name = "textBoxBarrier";
            this.textBoxBarrier.Size = new System.Drawing.Size(285, 31);
            this.textBoxBarrier.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 536);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "Barrier Type:";
            // 
            // comboBoxBarrierType
            // 
            this.comboBoxBarrierType.FormattingEnabled = true;
            this.comboBoxBarrierType.Items.AddRange(new object[] {
            "Up and In",
            "Up and Out",
            "Down and In",
            "Down and Out"});
            this.comboBoxBarrierType.Location = new System.Drawing.Point(215, 536);
            this.comboBoxBarrierType.Name = "comboBoxBarrierType";
            this.comboBoxBarrierType.Size = new System.Drawing.Size(285, 33);
            this.comboBoxBarrierType.TabIndex = 25;
            // 
            // radioButtonPut
            // 
            this.radioButtonPut.AutoSize = true;
            this.radioButtonPut.Location = new System.Drawing.Point(215, 410);
            this.radioButtonPut.Name = "radioButtonPut";
            this.radioButtonPut.Size = new System.Drawing.Size(75, 29);
            this.radioButtonPut.TabIndex = 17;
            this.radioButtonPut.TabStop = true;
            this.radioButtonPut.Text = "Put";
            this.radioButtonPut.UseVisualStyleBackColor = true;
            // 
            // comboBoxInstType
            // 
            this.comboBoxInstType.FormattingEnabled = true;
            this.comboBoxInstType.Items.AddRange(new object[] {
            "Stock",
            "European Option",
            "Asian Option",
            "Digital Option",
            "Barrier Option",
            "Range Option",
            "Lookback Option"});
            this.comboBoxInstType.Location = new System.Drawing.Point(215, 31);
            this.comboBoxInstType.Name = "comboBoxInstType";
            this.comboBoxInstType.Size = new System.Drawing.Size(285, 33);
            this.comboBoxInstType.TabIndex = 27;
            this.comboBoxInstType.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 25);
            this.label8.TabIndex = 26;
            this.label8.Text = "Instrument Type:";
            // 
            // FormInst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 665);
            this.Controls.Add(this.comboBoxInstType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxBarrierType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxBarrier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxRebate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonPut);
            this.Controls.Add(this.radioButtonCall);
            this.Controls.Add(this.radioButtonNeitherCallPut);
            this.Controls.Add(this.comboBoxUnderlying);
            this.Controls.Add(this.textBoxTenor);
            this.Controls.Add(this.textBoxStrike);
            this.Controls.Add(this.textBoxExchange);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxInstrumentName);
            this.Controls.Add(this.label1);
            this.Name = "FormInst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Instrument";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInstrumentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxExchange;
        private System.Windows.Forms.TextBox textBoxStrike;
        private System.Windows.Forms.TextBox textBoxTenor;
        private System.Windows.Forms.ComboBox comboBoxUnderlying;
        private System.Windows.Forms.RadioButton radioButtonNeitherCallPut;
        private System.Windows.Forms.RadioButton radioButtonCall;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRebate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxBarrier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxBarrierType;
        private System.Windows.Forms.RadioButton radioButtonPut;
        private System.Windows.Forms.ComboBox comboBoxInstType;
        private System.Windows.Forms.Label label8;
    }
}