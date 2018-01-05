using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    public class Griewank : ProblemaDeBaza
    {
        public override double Functie(double[] x)
        {
            var sum = 0.0;
            var prod = 1.0;
            for (var i = 0; i < x.Length; ++i)
            {
                var xi = x[i];
                sum += Math.Pow(xi, 2);
                prod *= Math.Cos(xi / Math.Sqrt(i+1));
            }
            return 1 + (1 / 4000) * sum - prod;
        }
    }
}
