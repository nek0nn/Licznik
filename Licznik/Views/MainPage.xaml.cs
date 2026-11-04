using Licznik.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Licznik.Views
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<DaneLicznika> Liczniki { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            WczytajLicznik();
        }

        private async void DodajLicznik_Clicked(object sender, EventArgs e)
        {
            string? nazwa = await DisplayPromptAsync("Nowy licznik", "Podaj nazwę licznika:");

            if (string.IsNullOrWhiteSpace(nazwa))
                return;

            string SciezkaPliku = Path.Combine(
                FileSystem.AppDataDirectory,
                Guid.NewGuid() + ".licznik.txt");

            DaneLicznika licznik = new DaneLicznika(SciezkaPliku, nazwa, 0);

            Liczniki.Add(licznik);

            ZapiszLicznik();
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender;
            DaneLicznika licznik = (DaneLicznika)przycisk.BindingContext;

            int index = Liczniki.IndexOf(licznik);

            Liczniki[index] = new DaneLicznika(
                licznik.SciezkaPliku,
                licznik.Nazwa,
                licznik.Wartosc - 1);

            ZapiszLicznik();
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender;
            DaneLicznika licznik = (DaneLicznika)przycisk.BindingContext;

            int index = Liczniki.IndexOf(licznik);

            Liczniki[index] = new DaneLicznika(
                licznik.SciezkaPliku,
                licznik.Nazwa,
                licznik.Wartosc + 1);

            ZapiszLicznik();
        }
    }
}