using Newtonsoft.Json;

namespace AppPokemon.Models
{


    public class GenerationVi
    {
        [JsonProperty("omegaruby-alphasapphire")]
        public OmegarubyAlphasapphire OmegarubyAlphasapphire { get; set; }

        [JsonProperty("x-y")]
        public XY XY { get; set; }
    }


}

