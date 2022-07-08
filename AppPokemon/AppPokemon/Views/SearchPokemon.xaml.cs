
using AppPokemon.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPokemon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPokemon : ContentPage
    {
        public SearchPokemon()
        {
            InitializeComponent();
            BindingContext = new SearchPokemonViewModel();
        }
    }
}