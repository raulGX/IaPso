using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    public class Ackley : ProblemaDeBaza
    {
        public override double Functie(double[] x)
        {
            // Vor fi preluate din interfata grafica
            var c1 = 20;
            var c2 = 0.2;
            var c3 = 2 * Math.PI;
            var n = x.Length;

            var firstItem = 0.0;
            var secondItem = 0.0;
            var firstSum = 0.0;
            var secondSum = 0.0;
            for (var i = 0; i < n; ++i)
            {
                var xi = x[i];
                firstSum += Math.Pow(xi, 2);
                secondSum += Math.Cos(c3 * xi);
            }
            firstItem += -c1 * Math.Exp(-c2 * Math.Sqrt(1 / n * firstSum));
            secondItem += Math.Exp(1 / n * secondSum);
            return firstItem - secondItem + c1 + Math.E;
        }
    }
}
