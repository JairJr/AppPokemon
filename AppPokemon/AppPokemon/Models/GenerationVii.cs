using Newtonsoft.Json;

namespace AppPokemon.Models
{


    public class GenerationVii
    {
        public Icons icons { get; set; }

        [JsonProperty("ultra-sun-ultra-moon")]
        public UltraSunUltraMoon UltraSunUltraMoon { get; set; }
    }


}

