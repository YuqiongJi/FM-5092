using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Antithetic_variance_reduction
{
    class Europeanoptions : Simulator
    {
        public static double Optionvalue()
        {

            double[,] p = Simulator.SimulatedPrice();
            double C = 0; // price of the option

            if (Iscall == true)
            {
                for (int i = 0; i < Nsim; i++)
                {
                    C += Math.Exp(-r * T) * Math.Max(p[i, Steps] - K, 0);
                }
            }
            else
            {
                for (int i = 0; i < Nsim; i++)
                {
                    C += Math.Exp(-r * T) * Math.Max(K - p[i, Steps], 0);
                }
            }
            C /= (double)Nsim;

            return C;
        }

        //Calculate the standard error

        public static double StandardError()
        {
            double SD;
            double SE;
            double d = 0;
            double e = 0;
            double mean;
            double C0 = Europeanoptions.Optionvalue();
            if (Isantithetic == false)
            {
                for (int i = 0; i < Nsim; i++)
                {
                    if (Iscall == true)
                    {
                        d += Math.Pow(Math.Exp(-r * T) * Math.Max(Simulator.SimulatedPrice()[i, Steps] - K, 0) - C0, 2.0);
                    }
                    else
                    {
                        d += Math.Pow(Math.Exp(-r * T) * Math.Max(K- Simulator.SimulatedPrice()[i, Steps], 0) - C0, 2.0);
                    }
                    
                }
                SD = Math.Sqrt(d / (Nsim - 1));
                SE = SD / Math.Sqrt(Nsim);
            }
            else
            {
                double[] pair = new double[Nsim / 2];

                if (Iscall == true)
                {
                    for (int i = 0; i < Nsim / 2; i++)
                    {
                        pair[i] = Math.Exp(-r * T) * (Math.Max(Simulator.SimulatedPrice()[i, Steps] - K, 0) + Math.Max(Simulator.SimulatedPrice()[i + Nsim / 2, Steps] - K, 0)) / 2;
                        e = e + pair[i];

                    }
                }
                else
                {
                    for (int i = 0; i < Nsim / 2; i++)
                    {
                        pair[i] = Math.Exp(-r * T) * (Math.Max(K - Simulator.SimulatedPrice()[i, Steps], 0) + Math.Max(K - Simulator.SimulatedPrice()[i + Nsim / 2, Steps], 0)) / 2;
                        e = e + pair[i];

                    }
                }
                mean = e / (Nsim / 2);

                for (int i = 0; i < Nsim / 2; i++)
                {
                    d = d + Math.Pow(pair[i] - mean, 2.0);
                }
                double variance = d / (Nsim / 2 - 1);
                SE = Math.Sqrt(variance / (Nsim / 2));               

            }
            return SE;
        }
    }
}
