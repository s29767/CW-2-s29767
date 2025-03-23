using System;

namespace Projekt1
{
    internal class KontenerNaPlyny : Kontener, IHazardNotifier
    {
        private bool czyNiebezpieczny;

        public KontenerNaPlyny(double wysokosc, double masaWlasna, double glebokosc, double maksymalnaLadownosc, bool czyNiebezpieczny)
            : base(wysokosc, masaWlasna, glebokosc, maksymalnaLadownosc, "L")
        {
            this.czyNiebezpieczny = czyNiebezpieczny;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[HAZARD - PŁYNY] {message}");
        }

        public void ZaladowanieKontenera(ProduktChlodniczy produkt, double masa)
        {
            double dopuszczalna = czyNiebezpieczny ? MaksymalnaLadownosc * 0.5 : MaksymalnaLadownosc * 0.9;

            if (masa > dopuszczalna)
            {
                NotifyHazard($"Niebezpieczna próba załadunku {masa}kg do kontenera {NumerSeryjny}. Limit: {dopuszczalna}kg.");
                throw new OverfillException("Przekroczono dopuszczalną ładowność kontenera na płyny.");
            }

            MasaLadunku = masa;
            Console.WriteLine($"Załadowano {masa}kg do kontenera {NumerSeryjny}.");
        }
    }
}