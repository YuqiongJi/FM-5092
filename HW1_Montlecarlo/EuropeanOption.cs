using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Montlecarlo
{
    class Europeanoptions : Simulator
    {
        public static double Optionvalue(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {

            double[,] p = Simulator.SimulatedPrice(S0, K, r, vol, T, Trials, Steps);
            double C = 0; // price of the option

            if (Iscall == true)
            {
                for (int i = 0; i < Trials; i++)
                {
                    C += Math.Exp(-r * T) * Math.Max(p[i, Steps] - K, 0);
                }
            }
            else
            {
                for (int i = 0; i < Trials; i++)
                {
                    C += Math.Exp(-r * T) * Math.Max(K - p[i, Steps], 0);
                }
            }
            C /= (double)Trials;

            return C;
        }

        //Calculate the standard error
        
        public static double StandardError(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {
            double SD;
            double SE;
            double d = 0;
            double C0 = Europeanoptions.Optionvalue(S0, K, r, vol, T, Trials, Steps, Iscall);

            for (int i = 0; i < Trials; i++)
            {
                d += Math.Pow(Math.Exp(-r * T) * Math.Max(Simulator.SimulatedPrice(S0, K, r, vol, T, Trials, Steps)[i, Steps] - K, 0) - C0, 2.0);
            }
            SD = Math.Sqrt(d / (Trials - 1));
            SE = SD / Math.Sqrt(Trials);
            return SE;
        }
    }
}
