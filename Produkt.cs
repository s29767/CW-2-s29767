using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class ProduktChlodniczy
    {
        public string Nazwa { get; set; }
        public double TemperaturaMinimalna { get; set; }

        public ProduktChlodniczy(string nazwa, double temperaturaMinimalna)
        {
            Nazwa = nazwa;
            TemperaturaMinimalna = temperaturaMinimalna;
        }
    }
}
