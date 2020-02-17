using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1_Montlecarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            PerformSimulation();
        }

        private void radioButtoncall_CheckedChanged(object sender, EventArgs e)
        {

            radioButtoncall.Enabled = true;
            
        }
        
        private void radioButtonput_CheckedChanged(object sender, EventArgs e)
        {

            radioButtoncall.Enabled = false;
            
        }



        private void PerformSimulation()
        {

            Simulator EurOption = new Simulator();
            EurOption.SpotPrice = Convert.ToDouble(textBoxS0.Text);
            EurOption.SprikePrice = Convert.ToDouble(textBoxK.Text);
            EurOption.Drift = Convert.ToDouble(textBoxr.Text);
            EurOption.Volatility = Convert.ToDouble(textBoxVolatility.Text);
            EurOption.Tenor = Convert.ToDouble(textBoxT.Text);
            EurOption.TrialNumber = Convert.ToInt32(textBoxTrials.Text);
            EurOption.StepNumber = Convert.ToInt32(textBoxStep.Text);
            EurOption.Side = radioButtoncall.Enabled;

            EurOption.RandNumbers = Simulator.GetRandNumbers(EurOption.TrialNumber, EurOption.StepNumber);

            double optionprice= Europeanoptions.Optionvalue(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side);
            label1.Text = Convert.ToString(optionprice);
            double delta = Greeks.GetDelta(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side);
            label2.Text = Convert.ToString(delta);
            double gamma = Greeks.GetGamma(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side);
            label3.Text = Convert.ToString(gamma);
            double vega = Greeks.GetVega(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side);
            label4.Text = Convert.ToString(vega);
            double Theta = Greeks.GetTheta(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side);
            label5.Text = Convert.ToString(Theta);
            double rho = Greeks.GetRho(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side);
            label6.Text = Convert.ToString(rho);
            label7.Text = Convert.ToString(Europeanoptions.StandardError(EurOption.SpotPrice, EurOption.SprikePrice, EurOption.Drift, EurOption.Volatility, EurOption.Tenor, EurOption.TrialNumber, EurOption.StepNumber, EurOption.Side));
        }

       
    }
}
