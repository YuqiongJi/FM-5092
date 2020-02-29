using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Antithetic_variance_reduction
{
    class Greeks : Europeanoptions
    {
        public static double GetDelta()
        {
            double origS0 = S0;
            S0 = origS0*(1+ 0.0001);
            double value1 = Europeanoptions.Optionvalue();
            S0 = origS0 * (1 - 0.0001);
            double value2 = Europeanoptions.Optionvalue();
            S0 = origS0;
            double Delta = (value1 - value2) / (0.0002 * S0);
            return Delta;
        }
        public static double GetGamma()
        {
            double value0 = Europeanoptions.Optionvalue();
            double origS0 = S0;
            S0 = origS0*(1 + 0.0001);
            double value1 = Europeanoptions.Optionvalue();
            S0 = origS0 * (1 - 0.0001);
            double value2 = Europeanoptions.Optionvalue();
            S0 = origS0;
            double Gamma = (value1 - 2 * value0 + value2) / Math.Pow(0.0001 * S0, 2);
            return Gamma;
        }

        public static double GetVega()
        {
            double origvol = vol;
            vol = origvol*(1+0.0001);
            double value1 = Europeanoptions.Optionvalue();
            vol = origvol * (1 -0.0001);
            double value2 = Europeanoptions.Optionvalue();
            vol = origvol;
            double Vega = (value1 - value2) / (0.0002 * vol);
            return Vega;
        }
        public static double GetTheta()
        {
            double value0 = Europeanoptions.Optionvalue();
            double origT = T;
            T = origT*(1+0.0001);
            double value1 = Europeanoptions.Optionvalue();
            T = origT;
            double Theta = (value1 - value0) / (0.0001 * T);
            return Theta;
        }
        public static double GetRho()
        {
            double origr = r;
            r = origr* (1+ 0.0001);
            double value1 = Europeanoptions.Optionvalue();
            r = origr * (1 - 0.0001);
            double value2 = Europeanoptions.Optionvalue();
            r = origr;
            double Rho = (value1 - value2) / (0.0002 * r);
            return Rho;
        }
    }
}
