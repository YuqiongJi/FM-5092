using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinomial_tree
{
    class Program
    {
        static double Delta, Gamma, Theta;
        static void Main(string[] args)
        {
            double Vega, Rho;
            Vega = (Trinomaltree(100, 105, 0.06, 0.2 + 0.00001, 1, 5, 0.05, "Call", "American") - Trinomaltree(100, 105, 0.06, 0.2 - 0.00001, 1, 5, 0.05, "Call", "American")) / 0.00002;
            Rho = (Trinomaltree(100, 105, 0.06 + 0.00001, 0.2, 1, 5, 0.05, "Call", "American") - Trinomaltree(100, 105, 0.06 - 0.00001, 0.2, 1, 5, 0.05, "Call", "American")) / 0.00002;
            Console.WriteLine("Optionvalue is:");
            Console.WriteLine(Trinomaltree(100, 105, 0.06, 0.2, 1, 5, 0.05, "Call", "American"));
            Console.WriteLine("Delta is:");
            Console.WriteLine(Delta);
            Console.WriteLine("Gamma is:");
            Console.WriteLine(Gamma);
            Console.WriteLine("Theta is:");
            Console.WriteLine(Theta);
            Console.WriteLine("Vega is:");
            Console.WriteLine(Vega);
            Console.WriteLine("Rho is:");
            Console.WriteLine(Rho);

            Console.ReadLine();
        }

        static double Trinomaltree(double S, double K, double r, double sigma, double T, int N, double delta, string side, string style)
        {
            double t, x, v, edx, pu, pm, pd, disc;

            t = T / N;
            x = sigma * Math.Sqrt(3 * t);
            v = r - delta - 0.5 * sigma * sigma;
            edx = Math.Exp(x);
            pu = 0.5 * ((Math.Pow(sigma, 2.0) * t + Math.Pow(v, 2.0) * Math.Pow(t, 2.0)) / Math.Pow(x, 2.0) + v * t / x);
            pm = 1 - (Math.Pow(sigma, 2.0) * t + Math.Pow(v, 2.0) * Math.Pow(t, 2.0)) / Math.Pow(x, 2.0);
            pd = 0.5 * ((Math.Pow(sigma, 2.0) * t + Math.Pow(v, 2.0) * Math.Pow(t, 2.0)) / Math.Pow(x, 2.0) - v * t / x);
            disc = Math.Exp(-r * t);

            // build underlying  tree---stock value
            double[,] stockvalue = new double[2 * N + 1, N + 1];
            stockvalue[0, 0] = S;
            for (int i = 1; i < (N + 1); i++)
            {
                for (int j = 0; j < (2 * i + 1); j++)
                {
                    stockvalue[j, i] = S * Math.Pow(edx, i - j);
                    // Console.WriteLine(stockvalue[j, i]);
                }

            }
            //option value at final node
            double[,] optionvalue = new double[2 * N + 1, N + 1];
            for (int j = 0; j < (2 * N + 1); j++)
            {
                if (side == "Call")
                {
                    optionvalue[j, N] = Math.Max(0, stockvalue[j, N] - K);
                }
                else if (side == "Put")
                {
                    optionvalue[j, N] = Math.Max(0, K - stockvalue[j, N]);
                }

            }

            //build option value tree
            for (int i = N - 1; i > -1; i--)
            {
                for (int j = 2 * i; j >= 0 ; j--)
                {
                    if (style == "European")
                    {
                        optionvalue[j, i] = disc * (pu * optionvalue[j, i + 1] + pm * optionvalue[j + 1, i + 1] + pd * optionvalue[j + 2, i + 1]);
                    }
                    else if (style == "American")
                    {
                        if (side == "Call")
                        {
                            optionvalue[j, i] = Math.Max(stockvalue[j, i] - K, disc * (pu * optionvalue[j, i + 1] + pm * optionvalue[j + 1, i + 1] + pd * optionvalue[j + 2, i + 1]));
                        }
                        else if (side == "Put")
                        {
                            optionvalue[j, i] = Math.Max(K - stockvalue[j, i], disc * (pu * optionvalue[j, i + 1] + pm * optionvalue[j + 1, i + 1] + pd * optionvalue[j + 2, i + 1]));
                        }
                    }
                }
            }

            Delta = (optionvalue[0, 1] - optionvalue[2, 1]) / (stockvalue[0, 1] - stockvalue[2, 1]);
            Gamma = (((optionvalue[0, 1] - optionvalue[1, 1]) / (stockvalue[0, 1] - stockvalue[1, 1])) - ((optionvalue[1, 1] - optionvalue[2, 1]) / (stockvalue[1, 1] - stockvalue[2, 1]))) / (0.5 * (stockvalue[0, 1] - stockvalue[2, 1]));
            Theta = (optionvalue[1, 1] - optionvalue[0, 0]) / t;

            return optionvalue[0, 0];
        }

    }
}
