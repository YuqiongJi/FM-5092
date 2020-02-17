using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Montlecarlo
{
    class Greeks:Europeanoptions
    {
        public static double GetDelta(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {
            double Delta = (Europeanoptions.Optionvalue(S0 * 1.0001, K, r, vol, T, Trials, Steps, Iscall) - Europeanoptions.Optionvalue(S0 * 0.9999, K, r, vol, T, Trials, Steps, Iscall)) / (0.0002 * S0);
            //Console.WriteLine("Delta:" + Delta);
            return Delta;
        }
        public static double GetGamma(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {
            double Gamma = (Europeanoptions.Optionvalue(S0 * 1.0001, K, r, vol, T, Trials, Steps, Iscall) - 2 * Europeanoptions.Optionvalue(S0, K, r, vol, T, Trials, Steps, Iscall) + Europeanoptions.Optionvalue(S0 * 0.9999, K, r, vol, T, Trials, Steps, Iscall)) / Math.Pow(0.0001 * S0, 2);
            //Console.WriteLine("Gamma:" + Gamma);
            return Gamma;
        }

        public static double GetVega(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {
            double Vega = (Europeanoptions.Optionvalue(S0, K, r, vol * 1.0001, T, Trials, Steps, Iscall) - Europeanoptions.Optionvalue(S0, K, r, vol * 0.9999, T, Trials, Steps, Iscall)) / (0.0002 * vol);
            //Console.WriteLine("Vega:" + Vega);
            return Vega;
        }
        public static double GetTheta(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {
            double Theta = (Europeanoptions.Optionvalue(S0, K, r, vol, T * 1.0001, Trials, Steps, Iscall) - Europeanoptions.Optionvalue(S0, K, r, vol, T, Trials, Steps, Iscall)) / (0.0001 * T);
            //Console.WriteLine("Theta:" + Theta);
            return Theta;
        }
        public static double GetRho(double S0, double K, double r, double vol, double T, int Trials, int Steps, bool Iscall)
        {
            double Rho = (Europeanoptions.Optionvalue(S0, K, r * 1.0001, vol, T, Trials, Steps, Iscall) - Europeanoptions.Optionvalue(S0, K, r * 0.9999, vol, T, Trials, Steps, Iscall)) / (0.0002 * r);
            //Console.WriteLine("Rho:" + Rho);
            return Rho;
        }
    }
}
