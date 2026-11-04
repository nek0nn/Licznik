using Licznik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licznik.Views
{
    public partial class MainPage
    {
        private void ZapiszLicznik()
        {
            foreach (DaneLicznika licznik in Liczniki)
            {
                string dane = licznik.Nazwa + "\n" + licznik.Wartosc;

                File.WriteAllText(licznik.SciezkaPliku, dane);
            }
        }

        private void WczytajLicznik()
        {
            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<string> pliki = Directory
                .EnumerateFiles(appDataPath, "*.licznik.txt");

            foreach (string plik in pliki)
            {
                string[] dane = File.ReadAllLines(plik);

                if (dane.Length == 2 && int.TryParse(dane[1], out int wartosc))
                {
                    DaneLicznika licznik = new DaneLicznika(
                        plik,
                        dane[0],
                        wartosc);

                    Liczniki.Add(licznik);
                }
            }
        }
    }
}