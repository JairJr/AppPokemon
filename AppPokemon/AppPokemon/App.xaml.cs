using AppPokemon.Views;
using Xamarin.Forms;

namespace AppPokemon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new SearchPokemon();
            App.Current.MainPage = new NavigationPage(new SearchPokemon());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
