namespace PSO
{
    public class Rosenbrock : ProblemaDeBaza
    {
        public override double Functie(double[] x)
        {
            var rez = 0.0;
            for (var i = 0; i < x.Length - 1; ++i)
            {
                var xi = x[i];
                rez += (1 - xi) * (1 - xi) + 100 * (x[i + 1] - xi * xi) * (x[i + 1] - xi * xi);
            }

            return rez;
        }
    }
}