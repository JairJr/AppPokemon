using Newtonsoft.Json;

namespace AppPokemon.Models
{
    
    
        public class GenerationI
        {
            [JsonProperty("red-blue")]
            public RedBlue RedBlue { get; set; }
            public Yellow yellow { get; set; }
        }


    }

