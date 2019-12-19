using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Models
{
    public class Contact
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("name")]
        public Name name;
    }

    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }
        [JsonProperty("last")]
        public string Last { get; set; }
    }

    public class Picture {

        [JsonProperty("large")]
        public string large { get; set;}

        [JsonProperty("medim")]
        public string medim { get; set; }

        [JsonProperty("thumbnail")]
        public string thumbnail { get; set; }

    }
}
