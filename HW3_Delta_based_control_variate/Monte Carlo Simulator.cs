using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HW3_Delta_based_control_variate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            bool S0_bol = double.TryParse(textBoxS0.Text, out double S0_text);
            bool K_bol = double.TryParse(textBoxK.Text, out double K_text);
            bool r_bol = double.TryParse(textBoxr.Text, out double r_text);
            bool vol_bol = double.TryParse(textBoxVolatility.Text, out double vol_text);
            bool T_bol = double.TryParse(textBoxT.Text, out double T_text);
            bool trial_bol = int.TryParse(textBoxTrials.Text, out int trial_text);
            bool step_bol = int.TryParse(textBoxStep.Text, out int step_text);

            if (S0_bol && K_bol && r_bol && vol_bol && T_bol && trial_bol && step_bol)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                Simulator EurOption = new Simulator
                {
                    SpotPrice = S0_text,
                    SprikePrice = K_text,
                    Drift = r_text,
                    Volatility = vol_text,
                    Tenor = T_text,
                    TrialNumber = trial_text,
                    StepNumber = step_text
                };
                

                if (radioButtoncall.Checked == true)
                {
                    EurOption.Side = true;
                }
                else if (radioButtonput.Checked == true)
                {
                    EurOption.Side = false;
                }
                else
                {
                    MessageBox.Show("Please select an option type!");
                }

                if (checkBoxanti.Checked == true)
                {
                    EurOption.Antithetic = true;
                }
                else
                {
                    EurOption.Antithetic = false;
                }

                if (checkBoxdeltaCV.Checked == true)
                {
                    EurOption.Delta_ControlVariate = true;
                }
                else
                {
                    EurOption.Delta_ControlVariate = false;
                }

                EurOption.RandNumbers = Simulator.GetRandMatrix();


                double optionprice = Europeanoptions.OptionValue();
                label1.Text = Convert.ToString(optionprice);
                double delta = Greeks.GetDelta();
                label2.Text = Convert.ToString(delta);
                double gamma = Greeks.GetGamma();
                label3.Text = Convert.ToString(gamma);
                double vega = Greeks.GetVega();
                label4.Text = Convert.ToString(vega);
                double Theta = Greeks.GetTheta();
                label5.Text = Convert.ToString(Theta);
                double rho = Greeks.GetRho();
                label6.Text = Convert.ToString(rho);
                label7.Text = Convert.ToString(Europeanoptions.StandardError());

                watch.Stop();
                labeltimer.Text = watch.Elapsed.Hours.ToString() + " h: "
                    + watch.Elapsed.Minutes.ToString() + " min: "
                    + watch.Elapsed.Seconds.ToString() + " s: "
                    + watch.Elapsed.Milliseconds.ToString()+" ms";
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void textBoxS0_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxS0.Text, out double S0_text))
            {
                textBoxS0.BackColor = Color.White;
            }
            else
            {
                textBoxS0.BackColor = Color.Pink;
            }
        }

        private void textBoxK_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxK.Text, out double K_text))
            {
                textBoxK.BackColor = Color.White;
            }
            else
            {
                textBoxK.BackColor = Color.Pink;
            }
        }

        private void textBoxr_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxr.Text, out double r_text))
            {
                textBoxr.BackColor = Color.White;
            }
            else
            {
                textBoxr.BackColor = Color.Pink;
            }
        }

        private void textBoxVolatility_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxVolatility.Text, out double vol_text))
            {
                textBoxVolatility.BackColor = Color.White;
            }
            else
            {
                textBoxVolatility.BackColor = Color.Pink;
            }
        }

        private void textBoxT_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxT.Text, out double T_text))
            {
                textBoxT.BackColor = Color.White;
            }
            else
            {
                textBoxT.BackColor = Color.Pink;
            }
        }

        private void textBoxTrials_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(textBoxTrials.Text, out int trial_text))
            {
                textBoxTrials.BackColor = Color.White;
            }
            else
            {
                textBoxTrials.BackColor = Color.Pink;
            }
        }

        private void textBoxStep_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxStep.Text, out int step_text))
            {
                textBoxStep.BackColor = Color.White;
            }
            else
            {
                textBoxStep.BackColor = Color.Pink;
            }
        }




    }
}
