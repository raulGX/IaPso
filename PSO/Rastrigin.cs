using System;

namespace PSO
{
    public class Rastrigin : ProblemaDeBaza
    {
        public override double Functie(double[] x)
        {
            var valAtPosition = 0.0;
            for (var i = 0; i < x.Length; ++i)
            {
                var xi = x[i];
                valAtPosition += xi * xi - 10 * Math.Cos(2 * Math.PI * xi);
            }

            return 10 * x.Length + valAtPosition;
        }
    }
}