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
using System.Threading;

namespace HW4_Multithreading
{


    public partial class Form1 : Form
    {
        static double S0_text, vol_text, r_text, K_text, T_text;
        static int step_text, trial_text;
        static double optionvalue, delta, gamma, vega, theta, rho, standarderror;

        static int CoreNumber = System.Environment.ProcessorCount;

        public Form1()
        {
            InitializeComponent();

        }


        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            bool S0_bol = double.TryParse(textBoxS0.Text, out S0_text);
            bool K_bol = double.TryParse(textBoxK.Text, out K_text);
            bool r_bol = double.TryParse(textBoxr.Text, out r_text);
            bool vol_bol = double.TryParse(textBoxVolatility.Text, out vol_text);
            bool T_bol = double.TryParse(textBoxT.Text, out T_text);
            bool trial_bol = int.TryParse(textBoxTrials.Text, out trial_text);
            bool step_bol = int.TryParse(textBoxStep.Text, out step_text);



            if (S0_bol && K_bol && r_bol && vol_bol && T_bol && trial_bol && step_bol)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                if (checkBoxmultithread.Checked == true)
                {
                    Thread t1 = new Thread(new ThreadStart(Calc));
                    t1.Start();
                    t1.Join();

                }
                else
                {
                    Calc();
                }

                label1.Text = Convert.ToString(optionvalue);

                label2.Text = Convert.ToString(delta);
                label3.Text = Convert.ToString(gamma);
                label4.Text = Convert.ToString(vega);
                label5.Text = Convert.ToString(theta);
                label6.Text = Convert.ToString(rho);
                label7.Text = Convert.ToString(standarderror);
                label12.Text = Convert.ToString(CoreNumber);

                watch.Stop();
                labeltimer.Text = watch.Elapsed.Hours.ToString() + " h: "
                    + watch.Elapsed.Minutes.ToString() + " min: "
                    + watch.Elapsed.Seconds.ToString() + " s: "
                    + watch.Elapsed.Milliseconds.ToString() + " ms";
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        public void IncreProgress(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(IncreProgress), new object[] { i });
                return;

            }
            progressBar1.Value = i;
        }


        public void Calc()
        {

            IncreProgress(20);

            EuropeanOptions OptInstance = new EuropeanOptions()

            {

                SpotPrice = S0_text,
                SprikePrice = K_text,
                Drift = r_text,
                Volatility = vol_text,
                Tenor = T_text,
                TrialNumber = trial_text,
                StepNumber = step_text,

            };


            if (radioButtoncall.Checked == true)
            {
                OptInstance.Side = true;
            }
            else if (radioButtonput.Checked == true)
            {
                OptInstance.Side = false;
            }
            else
            {
                MessageBox.Show("Please select an option type!");
            }

            if (checkBoxanti.Checked == true)
            {
                OptInstance.Antithetic = true;
                OptInstance.RandNumbers = OptInstance.Anti_GetRandMatrix();
            }
            else
            {
                OptInstance.Antithetic = false;
                OptInstance.RandNumbers = OptInstance.GetRandMatrix();
            }

            IncreProgress(50);

            OptInstance.Delta_ControlVariate = checkBoxdeltaCV.Checked;

            OptInstance.Multithreading = checkBoxmultithread.Checked;

            optionvalue = OptInstance.OptionPrice();
            
            IncreProgress(70);

            delta = OptInstance.GetDelta();
            gamma = OptInstance.GetGamma();
            vega = OptInstance.GetVega();

            IncreProgress(90);
            theta = OptInstance.GetTheta();
            rho = OptInstance.GetRho();
            standarderror = OptInstance.StandardError();


            IncreProgress(100);

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
