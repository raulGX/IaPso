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

            // Rastrigin
            // param.Max = 5.12;
            // param.Min = -5.12;

            // Ackley
            // param.Min = -32.768;
            // param.Max = 32.768;

            // nGriewank
            param.Min = -600;
            param.Max = 600;

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

            Console.WriteLine("\nAckley");
            p = new Ackley();
            rez = p.Rezolva(param);

            Console.WriteLine("Cost: " + rez.Cost);
            foreach (var weight in rez.Pozitie) Console.Write(weight + " ");

            Console.WriteLine("\nGriewank");
            p = new Griewank();
            rez = p.Rezolva(param);

            Console.WriteLine("Cost: " + rez.Cost);
            foreach (var weight in rez.Pozitie) Console.Write(weight + " ");
        }
    }
}