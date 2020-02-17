using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Montlecarlo
{
    class Simulator
    {
        private static double vol,r,S0,K,T;
        private static int Steps,Trials;
        private static bool Iscall;
        private static double[,] RandMatrix;
        public double Volatility { get { return vol; } set { vol = value; } }  // Volatility (standard deviation) of the instrument
        public double Drift { get { return r; } set { r = value; } }      //  risk-free rate of the instrument
        public double SpotPrice { get { return S0; } set { S0 = value; } }   // Starting price for the simulation
        public double SprikePrice { get { return K; } set { K = value; } }   // Exercise price of the option
        public int StepNumber { get { return Steps; } set { Steps = value; } }  // Number of steps in the simulation       
        public double Tenor { get { return T; } set { T = value; } } //Tenor of the option
        public int TrialNumber { get { return Trials; } set { Trials = value; } }   // Number of simulations
        public bool Side { get { return Iscall; } set { Iscall = value; } } // call or put
        public double [,] RandNumbers { get { return RandMatrix; } set { RandMatrix = value; } }



        //This method generates a matrix of random values that can be used when creating simulated prices.

        static Random rand = new Random();
        static double x1, x2, z3, w;
        /*
        public static double polarrejection()
        {
            double x1, x2, z3, w;
            do
            {
                x1 = 2 * rand.NextDouble() - 1; //Generate two uniform random values; and change their interval to (-1,1)
                x2 = 2 * rand.NextDouble() - 1;
                w = x1 * x1 + x2 * x2;
            } while (w > 1);              //If w > 1, repeat the first two steps, if not, continue
            z3 = Math.Sqrt(-2 * Math.Log(w) / w) * x1;
            return z3;
        }
        */
        public static double[,] GetRandNumbers(int Trials, int Steps)
        {
            double[,] matrix = new double[Trials, Steps];
            
            for (int i = 0; i < Trials; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    do
                    {
                        x1 = 2 * rand.NextDouble() - 1; //Generate two uniform random values; and change their interval to (-1,1)
                        x2 = 2 * rand.NextDouble() - 1;
                        w = x1 * x1 + x2 * x2;
                    } while (w > 1);              //If w > 1, repeat the first two steps, if not, continue
                    z3 = Math.Sqrt(-2 * Math.Log(w) / w) * x1;
                    matrix[i, j] = z3;
                }
            }
            return matrix;
        }

       

        public static double[,] SimulatedPrice(double S0, double K, double r, double vol, double T, int Trials, int Steps)
        {
            // Dimension Matrix and give it the first value

            Double[,] SimulatedPriceMatrix = new double[Trials, Steps + 1];

            for (int i = 0; i < Trials; i++)
            {
                SimulatedPriceMatrix[i, 0] = S0;
            }

            double t = T / (double)Steps;  //Time step

            for (int i = 0; i < Trials; i++)
            {
                for (int j = 1; j < (Steps + 1); j++)
                {
                    SimulatedPriceMatrix[i, j] = SimulatedPriceMatrix[i, j - 1] * Math.Exp((r - 0.5 * Math.Pow(vol, 2.0)) * t + vol * Math.Sqrt(t) * RandMatrix[i, j - 1]);
                }
            }
            return SimulatedPriceMatrix;
        }
    }
}
