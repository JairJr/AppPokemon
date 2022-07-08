using System.Collections.Generic;

namespace AppPokemon.Models
{


    public class HeldItem
    {
        public Item item { get; set; }
        public List<VersionDetail> version_details { get; set; }
    }


}

