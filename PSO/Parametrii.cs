namespace PSO
{
    public class Parametrii
    {
        public double C1, C2;
        public int NumarParticule { get; set; }
        public int DimensiuneProblema { get; set; }
        public double VitezaMaxima { get; set; }
        public double W { get; set; } //inertia
        public int NumarIteratii { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }
}