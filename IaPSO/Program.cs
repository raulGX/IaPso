using System;
using PSO;

namespace IaPSO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var param = new Parametrii();
            param.W = 0.729;
            param.C1 = 1.49445;
            param.C2 = 1.49445;

            param.DimensiuneProblema = 3;
            param.Max = 5.12;
            param.Min = -5.12;
            param.NumarIteratii = 1000;
            param.NumarParticule = 50;
            param.VitezaMaxima = 1;

            ProblemaDeBaza p = new Rastrigin();
            var rez = p.Rezolva(param);

            Console.WriteLine("Cost: " + rez.Cost);
            foreach (var weight in rez.Pozitie) Console.Write(weight + " ");
            Console.WriteLine("\nRosenbrock");
            p = new Rosenbrock();
            rez = p.Rezolva(param);

            Console.WriteLine("Cost: " + rez.Cost);
            foreach (var weight in rez.Pozitie) Console.Write(weight + " ");
        }
    }
}