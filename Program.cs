using System;
using System.Collections.Generic;

namespace Projekt1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Kontenerowiec statek1 = new Kontenerowiec("Titanic", 30, 5, 5000);
            Kontenerowiec statek2 = new Kontenerowiec("Posejdon", 25, 5, 5000);

            KontenerNaPlyny kontenerL1 = new KontenerNaPlyny(2.5, 1000, 2.5, 2000, true);
            KontenerNaPlyny kontenerL2 = new KontenerNaPlyny(2.0, 800, 2.0, 1500, false);
            KontenerChlodniczy kontenerC1 = new KontenerChlodniczy(3.0, 1200, 2.8, 2500, false, -18);
            KontenerChlodniczy kontenerC2 = new KontenerChlodniczy(3.0, 1200, 2.8, 2500, true, -25);

            ProduktChlodniczy produkt1 = new ProduktChlodniczy("Lody", -20);
            ProduktChlodniczy produkt2 = new ProduktChlodniczy("Mleko", 5);

            try
            {
                kontenerL1.ZaladowanieKontenera(produkt2, 800);
                kontenerL2.ZaladowanieKontenera(produkt2, 1000);
                kontenerC1.ZaladowanieKontenera(produkt1, 1000);
                kontenerC2.ZaladowanieKontenera(produkt1, 1200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy załadunku: {ex.Message}");
            }

            statek1.DodajKontener(kontenerL1);
            statek1.DodajKontener(kontenerL2);
            statek1.DodajKontener(kontenerC1);
            statek1.DodajListeKontenerow(new List<Kontener>() { kontenerC2 });

            statek1.WyswietlInformacje();

            statek1.WypiszInformacjeOKontenerze(kontenerL1.NumerSeryjny);

            statek1.RozladujKontener(kontenerL2.NumerSeryjny);

            KontenerNaPlyny nowyKontener = new KontenerNaPlyny(2.5, 900, 2.0, 1800, false);
            statek1.ZastapKontener(kontenerL2.NumerSeryjny, nowyKontener);

            statek1.PrzeniesKontenerDo(statek2, kontenerC1.NumerSeryjny);

            Console.WriteLine("\n--- STAN KOŃCOWY STATKÓW ---");
            statek1.WyswietlInformacje();
            statek2.WyswietlInformacje();

            Console.ReadKey();
        }
    }
}
