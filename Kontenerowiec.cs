namespace Projekt1
{
    internal class Kontenerowiec
    {
        public string Nazwa { get; set; }
        public double MaksymalnaPredkosc { get; private set; } 
        public int MaksymalnaLiczbaKontenerow { get; private set; }
        public double MaksymalnaLacznaWagaKontenerow { get; private set; } 

        private List<Kontener> kontenery = new List<Kontener>();

        public Kontenerowiec(string nazwa, double maksPredkosc, int maksKontenery, double maksLacznaWaga)
        {
            Nazwa = nazwa;
            MaksymalnaPredkosc = maksPredkosc;
            MaksymalnaLiczbaKontenerow = maksKontenery;
            MaksymalnaLacznaWagaKontenerow = maksLacznaWaga;
        }

        public bool DodajKontener(Kontener kontener)
        {
            double aktualnaWaga = ObliczLacznaWageKontenerow();
            if (kontenery.Count >= MaksymalnaLiczbaKontenerow)
            {
                Console.WriteLine("Nie można dodać kontenera - osiągnięto limit liczby kontenerów.");
                return false;
            }

            if (aktualnaWaga + kontener.MasaLadunku + kontener.MasaWlasna > MaksymalnaLacznaWagaKontenerow)
            {
                Console.WriteLine("Nie można dodać kontenera - przekroczono maksymalną łączną wagę.");
                return false;
            }

            kontenery.Add(kontener);
            Console.WriteLine($"Dodano kontener {kontener.NumerSeryjny} do kontenerowca.");
            return true;
        }

        public void DodajListeKontenerow(List<Kontener> lista)
        {
            foreach (var kontener in lista)
            {
                DodajKontener(kontener);
            }
        }

        public void UsunKontener(string numerSeryjny)
        {
            kontenery.RemoveAll(k => k.NumerSeryjny == numerSeryjny);
        }

        public void RozladujKontener(string numerSeryjny)
        {
            var kontener = kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                kontener.Oproznij();
            }
        }

        public void ZastapKontener(string numerSeryjny, Kontener nowyKontener)
        {
            int index = kontenery.FindIndex(k => k.NumerSeryjny == numerSeryjny);
            if (index != -1)
            {
                kontenery[index] = nowyKontener;
                Console.WriteLine($"Kontener {numerSeryjny} został zastąpiony.");
            }
        }

        public void PrzeniesKontenerDo(Kontenerowiec docelowy, string numerSeryjny)
        {
            var kontener = kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                if (docelowy.DodajKontener(kontener))
                {
                    kontenery.Remove(kontener);
                    Console.WriteLine($"Kontener {numerSeryjny} został przeniesiony do statku {docelowy.Nazwa}.");
                }
            }
        }

        public void WypiszInformacjeOKontenerze(string numerSeryjny)
        {
            var kontener = kontenery.Find(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                Console.WriteLine(kontener.ToString());
            }
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"\nKontenerowiec: {Nazwa}");
            Console.WriteLine($"Prędkość maksymalna: {MaksymalnaPredkosc} węzłów");
            Console.WriteLine($"Liczba kontenerów: {kontenery.Count}/{MaksymalnaLiczbaKontenerow}");
            Console.WriteLine($"Łączna waga kontenerów: {ObliczLacznaWageKontenerow()} ton (limit: {MaksymalnaLacznaWagaKontenerow})");
            Console.WriteLine("Lista kontenerów:");
            foreach (var k in kontenery)
            {
                Console.WriteLine($" - {k.ToString()}");
            }
        }

        public double ObliczLacznaWageKontenerow()
        {
            double suma = 0;
            foreach (var k in kontenery)
            {
                suma += k.MasaLadunku + k.MasaWlasna;
            }
            return suma;
        }
    }
}
