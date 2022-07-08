using Newtonsoft.Json;

namespace AppPokemon.Models
{
    public class GenerationIii
    {
        public Emerald emerald { get; set; }

        [JsonProperty("firered-leafgreen")]
        public FireredLeafgreen FireredLeafgreen { get; set; }

        [JsonProperty("ruby-sapphire")]
        public RubySapphire RubySapphire { get; set; }
    }
}

