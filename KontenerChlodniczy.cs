using System;

namespace Projekt1
{
    internal class KontenerChlodniczy : Kontener, IHazardNotifier
    {
        private bool czyNiebezpieczny;
        private double temperatura;

        public KontenerChlodniczy(double wysokosc, double masaWlasna, double glebokosc, double maksymalnaLadownosc,
                                   bool czyNiebezpieczny, double temperatura)
            : base(wysokosc, masaWlasna, glebokosc, maksymalnaLadownosc, "C")
        {
            this.czyNiebezpieczny = czyNiebezpieczny;
            this.temperatura = temperatura;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[HAZARD - CHŁODNICZY] {message}");
        }

        public void ZaladowanieKontenera(ProduktChlodniczy produkt, double masa)
        {
            if (temperatura > produkt.TemperaturaMinimalna)
            {
                NotifyHazard($"❗ Temperatura kontenera {NumerSeryjny} ({temperatura}°C) jest za wysoka dla produktu {produkt.Nazwa}, który wymaga min. {produkt.TemperaturaMinimalna}°C.");
                throw new InvalidOperationException("Zbyt wysoka temperatura kontenera dla tego produktu.");
            }

            double dopuszczalna = czyNiebezpieczny ? MaksymalnaLadownosc * 0.5 : MaksymalnaLadownosc * 0.9;

            if (masa > dopuszczalna)
            {
                NotifyHazard($"❗ Przekroczono dopuszczalną ładowność w kontenerze {NumerSeryjny}. Próbowano załadować {masa}kg (limit: {dopuszczalna}kg).");
                throw new OverfillException("Przekroczono dopuszczalną ładowność kontenera chłodniczego.");
            }

            MasaLadunku = masa;
            Console.WriteLine($"Załadowano {masa}kg produktu '{produkt.Nazwa}' do kontenera {NumerSeryjny}.");
        }
    }
}