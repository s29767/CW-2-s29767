using System;

namespace Projekt1
{
    internal class Kontener
    {
        private static int licznik = 1;

        public double MasaLadunku { get; protected set; }
        public double Wysokosc { get; protected set; }
        public double MasaWlasna { get; protected set; }
        public double Glebokosc { get; protected set; }
        public string NumerSeryjny { get; protected set; }
        public double MaksymalnaLadownosc { get; protected set; }
        public string RodzajKontenera { get; protected set; }

        public Kontener(double wysokosc, double masaWlasna, double glebokosc, double maksLadownosc, string rodzajKontenera)
        {
            Wysokosc = wysokosc;
            MasaWlasna = masaWlasna;
            Glebokosc = glebokosc;
            MaksymalnaLadownosc = maksLadownosc;
            RodzajKontenera = rodzajKontenera;
            NumerSeryjny = $"KON-{rodzajKontenera}-{licznik++}";
        }

        public virtual void Oproznij()
        {
            MasaLadunku = 0;
            Console.WriteLine($"Kontener {NumerSeryjny} został opróżniony.");
        }

        public override string ToString()
        {
            return $"Kontener {NumerSeryjny} ({RodzajKontenera}) | Masa ładunku: {MasaLadunku} / {MaksymalnaLadownosc}";
        }
    }
}