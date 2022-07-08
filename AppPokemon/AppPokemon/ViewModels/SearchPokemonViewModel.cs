using Acr.UserDialogs;
using AppPokemon.Models;
using AppPokemon.Views;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPokemon.ViewModels
{
    public class SearchPokemonViewModel : INotifyPropertyChanged
    {

        private string _pokemon;
        
        private string _imageUrl;
        public string Pokemon { get { return _pokemon; } set { _pokemon = value; PropertyChanged(this, new PropertyChangedEventArgs("Pokemon")); } }
        
        public string ImageUrl { get { return _imageUrl; } set { _imageUrl = value; PropertyChanged(this, new PropertyChangedEventArgs("ImageUrl")); } }

        public Command SearchMyPokemon { get; set; }
        
        public SearchPokemonViewModel()
        {
            SearchMyPokemon = new Command(async () => await SearchSpecificPokemon());
        }

        private async Task<string> SearchSpecificPokemon()
        {
            try
            {
                HttpResponseMessage response = null;

                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{_pokemon.ToLower()}");
                }
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var Dialog = UserDialogs.Instance.Loading("Consultando os dados, por favor aguarde...", null, null, true, MaskType.Black))
                    {
                        Thread.Sleep(50);
                        string poke = await response.Content.ReadAsStringAsync();
                        PokemonAttrib attrib = JsonConvert.DeserializeObject<PokemonAttrib>(poke);
                        _imageUrl = attrib.sprites.front_default;
                        UserDialogs.Instance.Toast($"Pokemon Localizado: {attrib.name} com altura de: {attrib.height} e peso de: {attrib.weight}", TimeSpan.FromSeconds(5));

                        //App.Current.MainPage = new NavigationPage(new DetailPage(attrib));
                        await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new DetailPage(attrib));                 
                        return poke;
                    }
                }
                else
                {
                    UserDialogs.Instance.Toast($"Pokemon não localizado verifique o nome digitado: {_pokemon} ", TimeSpan.FromSeconds(5));
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

      

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
