using Newtonsoft.Json;

namespace AppPokemon.Models
{
    public class GenerationV
    {
        [JsonProperty("black-white")]
        public BlackWhite BlackWhite { get; set; }
    }


}

