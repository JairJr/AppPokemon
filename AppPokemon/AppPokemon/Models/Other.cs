using Newtonsoft.Json;

namespace AppPokemon.Models
{
    public class Other
    {
        public DreamWorld dream_world { get; set; }
        public Home home { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }
}

