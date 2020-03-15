using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace HW3_Delta_based_control_variate
{
    class Europeanoptions : Simulator
    {
        public static double CDF(double z)
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign;
            if (z < 0.0)
                sign = -1;
            else
                sign = 1;

            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }


        public static double beta1 = -1.0;

        public static double[] OptionList()
        {
            
            double[,] S= Simulator.SimulatedPrice();
            double [] OptionList = new double [Nsim];

            if (IsDeltaCV == true)
            {
                double delta, d1;
                double dt = T / (double)Steps;  //Time step
                double T1;
                double[,] ControlVt = new double[Nsim, Steps + 1];// Dimension Matrix and give it the first value 

                for (int i = 0; i < Nsim; i++)
                {
                    ControlVt[i, 0] = 0;
                }
                if (Iscall == true)
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        for (int j = 1; j < (Steps + 1); j++)
                        {
                            T1 = T - (j - 1) * dt;
                            d1 = (Math.Log(S[i, j - 1] / K) + (r + vol * vol / 2.0) *T1) / (vol * Math.Sqrt(T1)); //calculte d1
                            delta = CDF(d1);   //calclute delta 
                            ControlVt[i, j] = ControlVt[i, j - 1] + delta * (S[i, j] - S[i, j - 1] * Math.Exp(r * dt));
                        }

                        OptionList[i] = Math.Max(S[i, Steps] - K, 0) + beta1 * ControlVt[i, Steps];
                        //Sum_CT2 += Math.Pow(Math.Max(S[i, Steps] - K, 0) + beta1 * CV[i, Steps], 2.0);
                    }
                }
                else
                {

                    for (int i = 0; i < Nsim; i++)
                    {
                        for (int j = 1; j < (Steps + 1); j++)
                        {
                            T1 = T - (j - 1) * dt;
                            d1 = (Math.Log(S[i, j - 1] / K) + (r + vol * vol / 2.0)*T1) / (vol * Math.Sqrt(T1)); //calculte d1
                            delta = CDF(d1) - 1;   //calclute delta 
                            ControlVt[i, j] = ControlVt[i, j - 1] + delta * (S[i, j] - S[i, j - 1] * Math.Exp(r * dt));
                        }
                        OptionList[i] = Math.Max(K - S[i, Steps], 0) + beta1 * ControlVt[i, Steps];

                    }
                    
                }
            }
            else
            {
                if (Iscall == true)
                {

                    for (int i = 0; i < Nsim; i++)
                    {
                        OptionList[i]= Math.Max(S[i, Steps] - K, 0);

                    }
                }
                else
                {
                    for (int i = 0; i < Nsim; i++)
                    {
                        OptionList[i] = Math.Max(K - S[i, Steps], 0);

                    }
                }
            }
       
            return OptionList;
        }



        //Calculate Option Value
        public static double OptionValue()
        {
            double C;
            double Sum_CT = 0.0;
            //double Sum_CT2 = 0.0;
            double[] Optionlist = OptionList();
            for (int i = 0; i < Nsim; i++)
            {
                Sum_CT += Optionlist[i];
                //Sum_CT2 += Math.Pow(Math.Max(K - S[i, Steps], 0), 2.0);
            }
            C= Math.Exp(-r * T) * (Sum_CT / (double)Nsim);
            return C;
        }




        //Calculate the standard error

        public static double StandardError()
        {
            double SD;
            double SE;
            //SD = Math.Sqrt((Sum_CT2-Sum_CT*Sum_CT/Nsim)*Math.Exp(-2*r * T) / (Nsim - 1));
            double d = 0;
            double C0 = Europeanoptions.OptionValue();
            double[] Optionlist = Europeanoptions.OptionList();
            if (Isantithetic == false)
            {
                for (int i = 0; i < Nsim; i++)
                {
                    d += Math.Pow(Math.Exp(-r * T) * Optionlist[i] - C0, 2.0);           
                }

                SD = Math.Sqrt(d / (Nsim - 1));
                SE = SD / Math.Sqrt(Nsim);
            }
            else
            {
                double[] pair = new double[Nsim / 2];
                for (int i = 0; i < Nsim / 2; i++)
                {
                    pair[i] = Math.Exp(-r * T) * (Optionlist[i] + Optionlist[i + Nsim / 2]) / 2.0;
                }
            
                for (int i = 0; i < Nsim / 2; i++)
                {
                    d += Math.Pow(pair[i] - C0, 2.0);
                }
                double variance = d / (double)((Nsim / 2) - 1);
                SE = Math.Sqrt(variance / (double)(Nsim / 2));

            }
            return SE;
        }
    }
}
