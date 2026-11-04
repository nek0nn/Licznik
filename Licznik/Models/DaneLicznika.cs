using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licznik.Models
{
    public class DaneLicznika
    {
        public string SciezkaPliku { get; set; }
        public string Nazwa { get; set; }
        public int Wartosc { get; set; }

        public DaneLicznika(string sciezkaPliku, string nazwa, int wartosc)
        {
            SciezkaPliku = sciezkaPliku;
            Nazwa = nazwa;
            Wartosc = wartosc;
        }
    }
}