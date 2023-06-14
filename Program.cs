namespace E72LET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime datum = new DateTime(2022, 12, 1);
            Kezeles kezel = new Kezeles(datum);

            kezel.FeladatElkeszult += Szimulal.EgyszeriElvegezve;
            kezel.Kovetkezo += Szimulal.Emlekeztet;
            kezel.UjNap += Szimulal.Masnap;
            kezel.Letrehoz();

        }
    }
}