using AppPokemon.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace AppPokemon.Utils
{
    public class MyRestClient
    {
        //private RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/");

        //private RestRequest request = new RestRequest("/pokemon/", Method.Get);


        public async Task<PokemonAttrib> MyRestClientAsync(string pokemon)
        {
            try
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/");
                RestRequest request = new RestRequest($"pokemon/{pokemon}", Method.Get);
                PokemonAttrib response = await client.GetAsync<PokemonAttrib>(request);
                return response;
            }
            catch (Exception)
            {
                return null;

            }
        }
    }
}