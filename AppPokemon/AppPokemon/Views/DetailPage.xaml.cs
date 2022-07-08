using AppPokemon.Models;
using AppPokemon.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPokemon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(PokemonAttrib attrib)
        {
            InitializeComponent();
            BindingContext = new DetailPokemonViewModel(MainStackLayout, attrib);
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                App.Current.MainPage = new Views.SearchPokemon();
            });

            return true;
        }
    }
}