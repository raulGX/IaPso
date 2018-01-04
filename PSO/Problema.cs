using System;
using System.Linq;

namespace PSO
{
    public interface IProblema
    {
        double Functie(double[] x);

        Particula Rezolva(Parametrii param);
        
    }

    public class ProblemaDeBaza : IProblema
    {
        public virtual double Functie(double[] x)
        {
            return 2;
        }

        public Particula Rezolva(Parametrii param)
        {
            var rand = new Random(0);
            var roi = new Particula[param.NumarParticule];

            for (var i = 0; i < roi.Length; i++)
            {
                roi[i] = new Particula();

                var pozitie = new double[param.DimensiuneProblema];
                var viteza = new double[param.DimensiuneProblema]; //initialize with 0

                for (var j = 0; j < pozitie.Length; j++)
                    pozitie[j] = (param.Max - param.Min) * rand.NextDouble() + param.Min;
                // viteza[j] = rand.NextDouble();
                roi[i].OptimPersonal = new Particula();
                roi[i].OptimPersonal.Pozitie = new double[param.DimensiuneProblema];
                pozitie.CopyTo(roi[i].OptimPersonal.Pozitie, 0);
                roi[i].Pozitie = pozitie;
                roi[i].Viteza = viteza;
                roi[i].OptimPersonal.Cost = roi[i].Cost = Functie(roi[i].Pozitie);
            } //sfarsit initializare

            var aux = roi.OrderBy(part => part.Cost).First();
            var optimSocial = new Particula();
            optimSocial.Pozitie = new double[param.DimensiuneProblema];
            aux.Pozitie.CopyTo(optimSocial.Pozitie, 0);
            optimSocial.Cost = aux.Cost;
            for (var i = 0; i < param.NumarIteratii; i++)
            for (var k = 0; k < roi.Length; k++)
            {
                var particula = roi[k];
                var r1 = rand.NextDouble();
                var r2 = rand.NextDouble();

                for (var j = 0; j < param.DimensiuneProblema; j++)
                {
                    particula.Viteza[j] =
                        param.W * particula.Viteza[j] +
                        param.C1 * r1 * (particula.OptimPersonal.Pozitie[j] - particula.Pozitie[j]) +
                        param.C2 * r2 * (optimSocial.Pozitie[j] - particula.Pozitie[j]);

                    if (particula.Viteza[j] > param.VitezaMaxima)
                        particula.Viteza[j] = param.VitezaMaxima;
                }

                for (var j = 0; j < param.DimensiuneProblema; j++)
                {
                    particula.Pozitie[j] += particula.Viteza[j];

                    if (particula.Pozitie[j] > param.Max)
                        particula.Pozitie[j] = param.Max;

                    if (particula.Pozitie[j] < param.Min)
                        particula.Pozitie[j] = param.Min;
                }

                particula.Cost = Functie(particula.Pozitie);

                if (particula.Cost < particula.OptimPersonal.Cost)
                {
                    particula.OptimPersonal = new Particula();
                    particula.OptimPersonal.Pozitie = new double[param.DimensiuneProblema];
                    particula.Pozitie.CopyTo(particula.OptimPersonal.Pozitie, 0);
                    particula.OptimPersonal.Cost = Functie(particula.OptimPersonal.Pozitie);
                }

                if (particula.Cost < optimSocial.Cost)
                {
                    particula.Pozitie.CopyTo(optimSocial.Pozitie, 0);
                    optimSocial.Cost = particula.Cost;
                }
            }

            return optimSocial;
        }
    }
}