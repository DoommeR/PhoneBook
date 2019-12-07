using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public class Result
    {
        
        [JsonProperty("results")]
        public List<Contact> Results { get; set; }
    }
}
