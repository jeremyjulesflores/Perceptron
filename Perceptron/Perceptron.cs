using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Perceptron
{
    public class Perceptron
    {
        private double[] weights = new double[2];
        private double learningRate = 1;
        private double bias;

        public Perceptron()
        {
            Random rd = new Random();
            weights[0] = rd.NextDouble() * 2 - 1;
            weights[1] = rd.NextDouble() * 2 - 1;

            bias = rd.NextDouble() * 2 - 1;
        }

        public int Activate(double input1, double input2)
        {
            double activation = bias;
            activation += input1 * weights[0] + input2 * weights[1];
            Console.WriteLine(activation);
            return activation >= 0 ? 1 : 0;
        }

        public void Train(double input1, double input2, int target, int epoch)
        {
            for(int i = 0; i<epoch; i++)
            {
                int output = Activate(input1, input2);
                int error = target - output;

                weights[0] += error * input1 * learningRate;
                weights[1] += error * input2 * learningRate;

                bias += error * learningRate;
            }
        }
   
    }
}
