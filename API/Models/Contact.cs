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
}
